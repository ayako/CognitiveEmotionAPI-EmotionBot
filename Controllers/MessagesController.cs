using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
//追加
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.Collections.Generic;

namespace EmotionBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        //public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        //{
        //    if (activity.Type == ActivityTypes.Message)
        //    {
        //        ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
        //        // calculate something for us to return
        //        int length = (activity.Text ?? string.Empty).Length;

        //        // return our reply to the user
        //        Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
        //        await connector.Conversations.ReplyToActivityAsync(reply);
        //    }
        //    else
        //    {
        //        HandleSystemMessage(activity);
        //    }
        //    var response = Request.CreateResponse(HttpStatusCode.OK);
        //    return response;
        //}
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {

            //Emotion API を使う準備: emotionApiKey にサブスクリプションキーを入れてください
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            const string emotionApiKey = "";

            //Emotion API を Call する EmotionServiceClient を生成
            EmotionServiceClient emotionServiceClient = new EmotionServiceClient(emotionApiKey);
            Emotion[] emotionResult = null;

            //入力値(URL) を元に Emotion API を Call
            try
            {
                emotionResult = await emotionServiceClient.RecognizeAsync(activity.Text);
            }
            catch (Exception e)
            {
                emotionResult = null;
            }

            //デフォルトの返答 (初回、または写真判定ができなかったとき))
            Activity reply = activity.CreateReply("顔の表情を判定します。写真のURLを送ってね。");

            //Call 結果を元に 返答を作成
            if (emotionResult != null)
            {
                //表情スコアを取得
                Scores emotionScores = emotionResult[0].Scores;

                //取得したスコアを KeyValuePair に代入、スコア数値の大きい順に並び替える
                IEnumerable<KeyValuePair<string, float>> emotionList = new Dictionary<string, float>()
                {
                    { "怒ってる", emotionScores.Anger},
                    { "軽蔑してる", emotionScores.Contempt },
                    { "うんざりしてる", emotionScores.Disgust },
                    { "怖がってる", emotionScores.Fear },
                    { "楽しい", emotionScores.Happiness},
                    { "特になし", emotionScores.Neutral},
                    { "悲しい", emotionScores.Sadness },
                    { "驚いてる", emotionScores.Surprise}
                }
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key)
                .ToList();

                KeyValuePair<string, float> topEmotion = emotionList.ElementAt(0);
                string topEmotionKey = topEmotion.Key;
                float topEmotionScore = topEmotion.Value;

                reply = activity.CreateReply
                    (
                        "顔の表情を判定しました。" 
                        + (int)(topEmotionScore * 100) + "% " + topEmotionKey + "顔だと思うよ。"
                    );
            }

            await connector.Conversations.ReplyToActivityAsync(reply);
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}
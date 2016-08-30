# CognitiveEmotionAPI-EmotionBot

##概要 | Description

[Microsoft Cognitive Services Emotion API](https://www.microsoft.com/cognitive-services/en-us/emotion-api) および [Microsoft Bot Framework v3.0](https://www.botframework.com/) による 表情判定BOT サンプルです。
動作には Emotion API のサブスクリプションが必要です。
**※こちらは アプリケーションサンプルです。ご自身の責任の下ご利用をお願いいたします。**

This is emotion auto-detect sample bot by [Microsoft Cognitive Services Emotion API](https://www.microsoft.com/cognitive-services/en-us/emotion-api) and [Microsoft Bot Framework v3.0](https://www.botframework.com/)
Emotion API Subscription needed to make this work.
**THIS IS SAMPLE and please use this for your infomation and on your own responsibility.**

##使用環境 | Environment

Windows 10 (Anniversary Update), Visual Studio 2015 (Enterprise, Update 3), Microsoft Bot Framework v3.0 テンプレート で作成されています。
環境構成方法は [Bot Framework を使うための開発環境](http://qiita.com/annie/items/edc26c0ee9603e84a2e4#bot-framework-%E3%82%92%E4%BD%BF%E3%81%86%E3%81%9F%E3%82%81%E3%81%AE%E9%96%8B%E7%99%BA%E7%92%B0%E5%A2%83) をご覧ください。

Developed on Windows 10 (Anniversary Update), Visual Studio 2015 (Enterprise, Update 3) and Microsoft Bot Framework v3.0 Template.
How to get envorpnment, please refer [Environment for Bot Framework development](http://qiita.com/annie/items/edc26c0ee9603e84a2e4#bot-framework-%E3%82%92%E4%BD%BF%E3%81%86%E3%81%9F%E3%82%81%E3%81%AE%E9%96%8B%E7%99%BA%E7%92%B0%E5%A2%83).

##利用方法 | How to User
ダウンロード後、Visual Studio のソリューションファイル(EmotionBot.sln)を開き、ビルドを行って必要なライブラリの読み込みを行ってください。
48行目の emotionApiKey に Emotion Api のサブスクリプションキーをコピーします。
Webアプリとして起動したら、Bot Framework Channel Emulator でアクセスします。
Emulator の利用方法は [Botアプリケーションのローカル実行とエミュレーターによるアクセス](http://qiita.com/annie/items/edc26c0ee9603e84a2e4#bot%E3%82%A2%E3%83%97%E3%83%AA%E3%82%B1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%81%AE%E3%83%AD%E3%83%BC%E3%82%AB%E3%83%AB%E5%AE%9F%E8%A1%8C%E3%81%A8%E3%82%A8%E3%83%9F%E3%83%A5%E3%83%AC%E3%83%BC%E3%82%BF%E3%83%BC%E3%81%AB%E3%82%88%E3%82%8B%E3%82%A2%E3%82%AF%E3%82%BB%E3%82%B9) をご覧ください。

After download bits, open solution file (EmotionBot.sln) and make build so to import nesessary libraries.
Paste Emotion API Subscription Key to emotionApiKey on line 48.
While working web app, access via Bot Framework Channel Emulator.
Please refer [How to running bot app locally and accessing via emulator](http://qiita.com/annie/items/edc26c0ee9603e84a2e4#bot%E3%82%A2%E3%83%97%E3%83%AA%E3%82%B1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%81%AE%E3%83%AD%E3%83%BC%E3%82%AB%E3%83%AB%E5%AE%9F%E8%A1%8C%E3%81%A8%E3%82%A8%E3%83%9F%E3%83%A5%E3%83%AC%E3%83%BC%E3%82%BF%E3%83%BC%E3%81%AB%E3%82%88%E3%82%8B%E3%82%A2%E3%82%AF%E3%82%BB%E3%82%B9)

# VrcVideoUrlDispenser

## これ何？
VrChatのコンポーネント、VRC_SyncVideoPlayerのUrlリストにボタン1つでUrlリストを分配するコンポーネントです。

## YouTubeのプレイリストをSyncVideoPlayerに入れる
### 必要なもの
あらかじめ、以下のソフトをダウンロードしてください。
- [Youtube List Grabber](https://sourceforge.net/projects/youtubelistgrabber/)

### 手順
1. Youtube List Grabberで、YouTubeのプレイリストUrlを取得します。
取得したいプレイリストを開きます。
![PlayList.png](\:storage\0.4cobxfmfj4b.png)
プレイリストの一番上の動画をクリックした後に、以下のようなプレイリストのUrlをコピーします。(途中省略しています)
```
https://www.youtube.com/watch?v=cqn～8Es&list=PLl～Jnd&index=1
```
Youtube List Grabberを起動して、UrlをList Urlに貼り付け、Grab!ボタンを押して動画リストを取得します。
(上手くいかない場合は、Grab!ボタンを3回くらい押してみたり、Youtube List Grabberを再起動してみてください。)
再生リストが表示されたら、右クリックからSaveを選択してください。
![Youtube List Grabber.png](\:storage\0.5qncd3s9cy9.png)
Youtube List Grabberと同じフォルダーに、YouList.txtが出力されます。
この中にUrlリストが入っています。

2. UnityPackageからインポート
Assets/Import Package/Custom PackageからVrcVideoUrlDispenserをインポートしてください。
![CustomPackage.png](\:storage\0.94j34yvzpg.png)

3. UrlをSyncVideoPlayerへ適用する
VRC_SyncVideoPlayerのコンポーネントが付いているGameObjectでAddComponentを押して、VrcVideoUrlDispenserを追加します。
![AddComponent.png](\:storage\0.9tgyhco3sup.png)
1.で作ったYouList.txtからUrlをコピーして、UrlListの中にCtrl + VでUrlを貼りつけます。
(TextAreaにUrlを貼り付ける時、キー認識が鈍いみたいなので、しっかり押して下さい。)
Startボタンを押します。
そのままVrChatへアップロードできるように、Url配置に成功するとコンポーネントは自動的に消えます。
IndexOutOfRangeExceptionというエラーが出るかもしれませんが、成功ログが出てくれば配置されています。
Urlが入っている事を確認できれば終わりです！

## VrChat既存の問題
### 特定の動画で大音量の雑音が流れる
VrChatでYouTubeの動画を流す際、大音量の雑音が流れる場合があります。
これは、どうやら動画のコーデックの種類の問題で、VrChatでサポートされているコーデックを指定すれば回避できるようです。(はっか調べ)
YouTubeだと、動画を右クリック → 詳細統計情報で動画のコーデックを調べることができます。
何のコーデックがサポートされているかは...まだ調査不足で調べられていません。
よかったら誰か教えてください >ヮ・)
# VisualizeNetwork
Visual Studioのプロジェクト。<br>
WSN（Wireless Sensor Network）におけるルーティングプロトコルを評価するため、ネットワーク図やグラフ、指標などを可視化するためのアプリケーション。<br><br>
<img src="https://user-images.githubusercontent.com/66106684/227737687-c183d806-198f-4a47-ba0b-6812fa94e324.png" width="100%">

## WSNとは
アドホックネットワークの一種で、あるエリアに配置された多数のセンサーが取得した情報を、センサー同士で構築した通信経路を使って1箇所に集めるためのネットワーク。<br>
工場の設備やサーバールームなどから温度等の情報を、監視・異常検出・空調制御するのに用いられる。<br><br>
<img src="https://user-images.githubusercontent.com/66106684/227737753-cbbf9a50-e374-4f01-be17-1ddaee395c88.png" width="60%">

センサノードは電源に接続されないことを前提としているため、ネットワーク寿命や負荷分散が求められる。これを解決するため、クラスタリングを用いた手法が数多く提案されている。

## なぜ作ったのか
新たなルーティングプロトコルを考案して既存のものと比較・評価するとき、ノードの配置図や接続関係、生存ノード数の推移などを数値だけで考察するのはとてもわかりにくい。
また、距離の遠いノード同士が接続されているなど、実装に間違いがあったときに気づきにくい問題がある。

## 環境
- Visual Studio
- C#

## できること
### シミュレーション再生
各ラウンドごとのネットワークトポロジーの変化を、アニメーションで再生する。

### グラフ
ラウンドごとの生存ノード数などの推移をグラフ化。<br>
<img src="https://user-images.githubusercontent.com/66106684/229350628-933623d7-1709-4a72-ad1e-d0932c44d711.png" width="100%">

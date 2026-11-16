# SpiderManEX

Meta Quest 3のハンドトラッキングで両手からウェブを撃つ Unity VR / MR プロジェクトです。収録バージョンは **1.14.0**（Android versionCode 24）です。

- **VR** — ビル街でウェブを巻き取りながらスイングし、手を開いて勢いを保ったまま飛べます。腕振り歩行、壁登り、ウェブを強く引く発進にも対応します。
- **MR** — パススルーで見える部屋で、仮想の物を引き寄せて投げたり、壺を割ったりできます。部屋の平面を使うには Quest のスペース設定と空間データへのアクセス許可が必要です。

## Unity で開く

1. このリポジトリをクローンし、ルートフォルダーを Unity Hub に追加します。
2. Android Build Support（SDK / NDK / OpenJDK）付きの Unity 6000.6.4f1 で開きます。
3. シーンは `Assets/Scenes/WebSwingLab.unity` です。体験環境は再生時に生成されます。
4. Quest 用の APK は Unity の **WebSwing > Build Quest APK** で作成できます。Windows で Android ビルドする場合は、日本語を含まないパスにクローンしてください。

操作は[操作ガイド](OPERATIONS_JA.md)、素材の出典は[素材メモ](ASSET_NOTES.txt)を参照してください。現行コードは [Scripts](Assets/WebSwing/Scripts) と [Editor](Assets/WebSwing/Editor) にあります。

## 体験動画

### MR版 — 新しい体験映像




https://github.com/user-attachments/assets/6a766884-a90f-4ac3-9b91-dbfee8683dec


### VR版（旧版）

**スイング（41秒）**

https://github.com/user-attachments/assets/9b2de374-23c0-4373-a2ec-4e46ac9bdcb7

**オブジェクトを引っ張る（33秒）**

https://github.com/user-attachments/assets/735fed45-696f-434e-a9b1-0606d24f4d1c

### MR版（旧版）

**実際の部屋でオブジェクトを引っ張る（13秒）**

https://github.com/user-attachments/assets/408cc20d-63dc-459d-9f97-a01f1b2de48c

[MR版の高画質動画をダウンロード](https://github.com/Iz7sev/web-swing-lab/raw/refs/heads/main/demo.mp4)


<img src="WebSwingIcon.png" alt="Web Swing Lab icon" width="128">

## 旧版の資料

上の動画は旧版を収録したものです。[旧版の UnityProject.zip](UnityProject.zip) と [旧版の C# スナップショット](src) も参照できます。

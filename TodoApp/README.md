# TodoApp - .NET 9 MVC 待辦事項系統

這是一個使用 .NET 9 MVC 架構建立的待辦事項管理系統，使用 Entity Framework Core In-Memory 資料庫。

## 功能特色

- ✅ 新增待辦事項
- ✅ 編輯待辦事項
- ✅ 刪除待辦事項
- ✅ 標記完成/取消完成
- ✅ 雙欄位顯示（進行中 / 已完成）
- ✅ 中文介面
- ✅ Bootstrap 5 響應式設計
- ✅ In-Memory 資料庫（資料會在應用程式重啟後重置）

## 技術棧

- .NET 9.0
- ASP.NET Core MVC
- Entity Framework Core 9.0
- Entity Framework Core In-Memory Database
- Bootstrap 5
- Bootstrap Icons

## 專案結構

```
TodoApp/
├── Controllers/
│   ├── HomeController.cs      # 首頁控制器
│   └── TodoController.cs      # 待辦事項控制器
├── Data/
│   └── TodoContext.cs         # Entity Framework DbContext
├── Models/
│   ├── TodoItem.cs            # 待辦事項資料模型
│   └── ErrorViewModel.cs      # 錯誤頁面模型
├── Views/
│   ├── Todo/
│   │   ├── Index.cshtml       # 待辦事項列表頁面
│   │   ├── Create.cshtml      # 新增待辦事項頁面
│   │   ├── Edit.cshtml        # 編輯待辦事項頁面
│   │   └── Delete.cshtml      # 刪除確認頁面
│   └── Shared/
│       └── _Layout.cshtml     # 共用版面配置
├── Program.cs                 # 應用程式進入點及設定
└── appsettings.json          # 應用程式設定檔
```

## 執行方式

### 前置需求

- .NET 9.0 SDK

### 執行步驟

1. 克隆專案到本地端：
```bash
git clone https://github.com/lettucebo/20251111-GH100.git
cd 20251111-GH100/TodoApp
```

2. 還原 NuGet 套件：
```bash
dotnet restore
```

3. 建置專案：
```bash
dotnet build
```

4. 執行應用程式：
```bash
dotnet run
```

5. 開啟瀏覽器，訪問：
   - HTTP: http://localhost:5000
   - HTTPS: https://localhost:5001

## 資料模型

### TodoItem

| 欄位 | 類型 | 說明 |
|------|------|------|
| Id | int | 主鍵（自動產生）|
| Title | string | 待辦事項標題（必填）|
| Description | string? | 待辦事項描述（選填）|
| IsCompleted | bool | 是否已完成 |
| CreatedAt | DateTime | 建立時間 |
| CompletedAt | DateTime? | 完成時間 |

## 主要功能說明

### 1. 待辦事項列表
- 分為「進行中」和「已完成」兩個區塊
- 顯示每個事項的標題、描述、建立時間（或完成時間）
- 提供快速操作按鈕：完成、編輯、刪除

### 2. 新增待辦事項
- 輸入標題（必填）
- 輸入描述（選填）
- 自動記錄建立時間

### 3. 編輯待辦事項
- 修改標題和描述
- 可切換完成狀態
- 自動更新完成時間

### 4. 標記完成/取消完成
- 一鍵切換完成狀態
- 自動記錄完成時間
- 已完成的項目會以刪除線顯示

### 5. 刪除待辦事項
- 刪除前會顯示確認頁面
- 顯示待辦事項的詳細資訊

## 範例資料

應用程式啟動時會自動載入三筆範例資料：

1. **完成專案文件** - 進行中
2. **Code Review** - 進行中
3. **修復 Bug #123** - 已完成

這些資料儲存在 In-Memory 資料庫中，應用程式重啟後會重新產生。

## 注意事項

- 此專案使用 **In-Memory 資料庫**，所有資料會在應用程式關閉後遺失
- 如需持久化儲存，可改用 SQL Server、PostgreSQL 或 SQLite 等資料庫
- 預設首頁為待辦事項列表頁面

## 開發環境

- Visual Studio 2022 或 Visual Studio Code
- .NET 9.0 SDK
- 任何支援 .NET 9 的作業系統（Windows、macOS、Linux）

## 授權

MIT License

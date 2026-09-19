# RizUI (C# / Uno Platform)

<div align="center">

![License: AGPL-3.0](https://img.shields.io/badge/License-AGPL--3.0-blue.svg)
![.NET: 10.0](https://img.shields.io/badge/.NET-10.0-purple.svg)
![Platform: Uno](https://img.shields.io/badge/Platform-Uno%20Platform%206.7-orange.svg)
[![GitHub Release](https://img.shields.io/github/v/release/Yun-Hydrogen/RizUI-Csharp?color=success&label=Release)](https://github.com/Yun-Hydrogen/RizUI-Csharp/releases/latest)

**一套面向 Uno Platform (.NET 10 / WinUI 3 / Skia) 的轻量、精致、高性能跨平台原生 UI 组件库。**

[下载与引入](#如何引入现有项目) • [快速开始](#快速开始) • [组件文档](doc/README.md) • [版本规范与自动构建](#版本控制与发布) • [开源协议](#开源协议与商业授权)

</div>

---

## 支持平台

基于 Uno Platform 单一工程架构与 Skia 渲染后端，一份代码即可跨平台原生运行：
- 🪟 **Windows**（WinUI 3 / Skia Desktop）
- 🍎 **macOS**（Skia Desktop）
- 🐧 **Linux**（Skia Desktop / Wayland / X11）
- 📱 **iOS / Android**（规划与跨平台适配中）
- 🌐 **WebAssembly**（Uno Wasm 规划与跨平台适配中）

---

## 如何引入现有项目

本项目采用 **GitHub Releases 自动化编译发布**。您可直接从 GitHub Release 下载最新的 `.nupkg` 包并在项目中本地引用。

### 方式一：下载 GitHub Release 安装包（推荐）

1. 进入 [GitHub Releases 最新发布页](https://github.com/Yun-Hydrogen/RizUI-Csharp/releases/latest) 下载 `RizUI.Uwp.*.nupkg`。
2. 将下载的包放置于项目目录下的任意文件夹（例如 `./packages`）。
3. 通过 .NET CLI 命令行引入：
   ```bash
   dotnet add package RizUI.Uwp --source ./packages
   ```
   或者在解决方案根目录创建 `nuget.config` 文件以支持全局查找：
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
     <packageSources>
       <add key="local-packages" value="./packages" />
     </packageSources>
   </configuration>
   ```
   随后在应用的 `.csproj` 中直接声明依赖：
   ```xml
   <ItemGroup>
     <PackageReference Include="RizUI.Uwp" Version="29.9.1" />
   </ItemGroup>
   ```

### 方式二：通过本地源码项目引用

克隆本仓库并在您的应用项目 `.csproj` 中直接添加 `ProjectReference`：
```xml
<ItemGroup>
  <ProjectReference Include="..\RizUI-Csharp\dotnet\RizUI.Uwp\RizUI.Uwp.csproj" />
</ItemGroup>
```

---

## 快速开始

### 1. 引入 XAML 命名空间

在需要使用组件的 XAML 视图文件（如 `MainPage.xaml`、`UserControl` 等）根节点声明：

```xml
<Page
    x:Class="YourApp.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:rizui="using:RizUI.Uwp.Controls">
```

### 2. 编写组件示例

```xml
<StackPanel Spacing="16" Margin="24">
    <!-- 1. 卡片与配置项行 -->
    <rizui:RizCard Title="通用设置"
                   Desc="自定义应用程序的交互参数"
                   Icon="fa-solid fa-gear">
        <StackPanel Spacing="12">
            <!-- 配置行与开关 -->
            <rizui:RizCfgRow Label="开机自动启动"
                             Hint="登录系统后在后台静默运行"
                             Icon="fa-solid fa-power-off">
                <rizui:RizSwitch IsOn="True" />
            </rizui:RizCfgRow>

            <!-- 配置行与滑块 -->
            <rizui:RizCfgRow Label="界面音效音量"
                             Icon="fa-solid fa-volume-high">
                <rizui:RizSlider Width="200" Value="60" Display="%" />
            </rizui:RizCfgRow>
        </StackPanel>
    </rizui:RizCard>

    <!-- 2. 按钮与主题色 -->
    <StackPanel Orientation="Horizontal" Spacing="10">
        <rizui:RizButton Text="常规按钮" />
        <rizui:RizButton Text="主色按钮" Primary="True" />
        <rizui:RizButton Text="初音绿按钮" Primary="True" Color="#39C5BB" />
        <rizui:RizButton Text="警告删除" Danger="True" />
    </StackPanel>
</StackPanel>
```

### 3. C# 静态轻提示调用

可在后台代码中直接调用非阻断式 Toast 消息通知：

```csharp
using RizUI.Uwp.Controls;

// 快捷弹出提示（需传入当前页面的 XamlRoot）
RizToast.ShowToast(this.XamlRoot, "操作成功", "您的配置已保存至本地数据库。");
```

---

## 特性亮点

1. **统一自适应主题 (`Theme`)**：所有组件原生支持 `"auto"`（跟随系统）、`"dark"`（深色/夜间模式）和 `"light"`（浅色模式）。
2. **灵活色彩体系 (`Color`)**：组件属性直传十六进制颜色（如 `"#39C5BB"`、`"#66CCFF"`），留空即自动继承全局强调色。
3. **内置 Font Awesome 6 Free 图标**：打包内置 Solid、Regular 与 Brands 数千款官方矢量图标，零外部依赖，直接填入 CSS 类名（如 `fa-solid fa-house`）即可呈现。
4. **完备的 Markdown 渲染**：`RizMdEditor` 具备平滑双栏切换、跨平台富文本预览（完整支持粗体、斜体、删除线、代码块、表格、任务清单等）。

---

## 组件文档清单

详细用法、属性定义、事件签名与实战示例已整理在 [`doc/`](doc/README.md) 目录：

- [RizButton (按钮)](doc/RizButton.md)
- [RizCard (卡片容器)](doc/RizCard.md)
- [RizCfgRow (配置项行)](doc/RizCfgRow.md)
- [RizCheckbox (复选框)](doc/RizCheckbox.md)
- [RizCode (代码块高亮)](doc/RizCode.md)
- [RizColorPicker (颜色选择器)](doc/RizColorPicker.md)
- [RizDialog (模态对话框)](doc/RizDialog.md)
- [RizDropdown (下拉菜单)](doc/RizDropdown.md)
- [RizInfoBox (状态提示框)](doc/RizInfoBox.md)
- [RizMdEditor (Markdown 编辑器)](doc/RizMdEditor.md)
- [RizSlider (数值滑块)](doc/RizSlider.md)
- [RizSliderNav (侧边栏导航)](doc/RizSliderNav.md)
- [RizSwitch (拨动开关)](doc/RizSwitch.md)
- [RizTable (数据表格)](doc/RizTable.md)
- [RizText (文本输入框)](doc/RizText.md)
- [RizTimeline (时间线进度)](doc/RizTimeline.md)
- [RizToast (轻提示通知)](doc/RizToast.md)
- [RizFontAwesome (图标系统)](doc/RizFontAwesome.md)

---

## 版本控制与发布

### 1. 版本号命名规范
本项目采用自研的日期迭代版本号格式：
`年份.月.第几次更新`（例如 `29.09.01` / SemVer 归一化为 `29.9.1`）。

### 2. 单点版本源
整个解决方案的版本由 [`dotnet/Directory.Build.props`](dotnet/Directory.Build.props) 集中管理：
```xml
<Project>
  <PropertyGroup>
    <Version>29.09.01</Version>
    <PackageVersion>$(Version)</PackageVersion>
  </PropertyGroup>
</Project>
```

### 3. GitHub Actions 自动化 Release
当您在 Git 中打上版本标签并推送时：
```bash
git tag v29.09.01
git push origin v29.09.01
```
GitHub Actions 将自动触发编译，并在 [GitHub Releases](https://github.com/Yun-Hydrogen/RizUI-Csharp/releases) 页面自动创建 Release 并上传打包好的 `RizUI.Uwp.*.nupkg` 资源包。

---

## 开源协议与商业授权

- **开源协议**：本项目基于 **GNU Affero General Public License v3 (AGPL-3.0)** 协议开源。
  - 允许免费学习、二次开发与搭建开源项目；
  - 任何引入或链接了本项目作为依赖的衍生应用程序，其自身代码也必须根据 AGPL-3.0 条款向其使用者（包括网络远程用户）完全开放源代码。
- **商业双重授权 (Commercial License)**：
  - 若您的企业或产品为闭源商业软件，无法满足 AGPL-3.0 的开源传染要求，请联系作者获取商业闭源授权。
- **第三方资产鸣谢**：
  - [Font Awesome Free](https://fontawesome.com/) 遵循 SIL OFL 1.1 与 MIT 协议；
  - [Uno Platform](https://platform.uno/) 遵循 Apache 2.0 协议。

# RizUI 组件库文档

RizUI 是一套面向 **Uno Platform (.NET 10 / C# / WinUI 3 / Skia)** 的轻量、精致、高性能的跨平台原生 UI 组件库。它提供了统一的现代扁平化视觉规范、流畅的交互动效、深浅色模式自适应以及开箱即用的 Font Awesome Free 图标体系。

---

## 平台支持

- **Windows**：WinUI 3 / Uno Skia Desktop
- **macOS / Linux**：Uno Skia Desktop
- **iOS / Android**：Uno Mobile
- **WebAssembly**：Uno Wasm（规划与兼容中）

---

## 快速上手

### 1. 引入 NuGet 包 / 项目引用

在你的 Uno Platform 业务项目或目标 `.csproj` 中添加引用：

```xml
<PackageReference Include="RizUI.Uwp" Version="0.1.0" />
```
或直接引用本地项目：
```xml
<ProjectReference Include="..\..\RizUI.Uwp\RizUI.Uwp.csproj" />
```

### 2. 引入 XAML 命名空间

在需要使用 RizUI 组件的 XAML 文件（如 `Page`、`UserControl`、`Window`）根节点中声明命名空间：

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 全局与通用特性

### 1. 主题自适应 (`Theme`)

大多数组件均支持 `Theme` 属性，用于控制明暗外观风格：
- `"auto"`（默认）：根据系统当前的主题自动在明暗主题之间无缝切换。
- `"dark"`：强制以深色/暗黑主题呈现（适用于暗黑看板、沉浸式编辑界面等）。
- `"light"`：强制以浅色主题呈现。

### 2. 主题色彩体系 (`Color`)

RizUI 支持在组件上通过 `Color` 属性覆盖默认强调色。支持格式包括：
- 标准 16 进制字符串：如 `"#39C5BB"`（初音绿）、`"#66CCFF"`（天蓝色）、`"#A855F7"`（紫色）等。
- 留空（默认）：自动跟随全局定义的强调色 `--rizui_themecolor`。

### 3. 内置 Font Awesome Free 图标库

RizUI 内置打包了 Font Awesome 6 Free 全部 Solid、Regular 与 Brands 图标。在所有支持 `Icon`、`LIcon`、`RIcon` 的组件中，直接输入标准 CSS 类名即可直接渲染，例如：
- `fa-solid fa-house`
- `fa-solid fa-magnifying-glass`
- `fa-brands fa-github`
- `fa-regular fa-bell`

更多图标使用技巧请参阅 [RizFontAwesome 图标系统](RizFontAwesome.md)。

---

## 组件目录索引

| 组件类别 | 组件名称 | 说明 | 文档链接 |
| :--- | :--- | :--- | :--- |
| **基础控件** | `RizButton` | 按钮组件，支持主色、警告、通栏、左右图标及样式定制 | [RizButton 文档](RizButton.md) |
| | `RizCheckbox` | 复选框组件，支持左右双标签、状态双向绑定与命令触发 | [RizCheckbox 文档](RizCheckbox.md) |
| | `RizSwitch` | 开关组件，提供平滑拨动动画与状态切换事件 | [RizSwitch 文档](RizSwitch.md) |
| **输入控件** | `RizText` | 单行及多行输入框，支持占位符、回车触发与聚焦动效 | [RizText 文档](RizText.md) |
| | `RizSlider` | 数值滑块，支持步进、范围限制与后缀单位显示 | [RizSlider 文档](RizSlider.md) |
| | `RizColorPicker` | 颜色选择器，支持实时吸色板、透明度调节与十六进制输入 | [RizColorPicker 文档](RizColorPicker.md) |
| | `RizDropdown` | 下拉菜单，支持图标选项与自定义弹窗展开 | [RizDropdown 文档](RizDropdown.md) |
| | `RizMdEditor` | Markdown 编辑器与渲染器，支持常用工具栏与富文本预览 | [RizMdEditor 文档](RizMdEditor.md) |
| **容器与布局** | `RizCard` | 现代化卡片容器，支持标题、图标、描述与折叠展开动画 | [RizCard 文档](RizCard.md) |
| | `RizCfgRow` | 偏好设置/配置行容器，支持左右或堆叠布局与禁用状态 | [RizCfgRow 文档](RizCfgRow.md) |
| | `RizSliderNav` | 多级折叠侧边栏导航，支持固定与悬浮双模式 | [RizSliderNav 文档](RizSliderNav.md) |
| **数据与展示** | `RizTable` | 数据表格，支持交互式编辑、动态加行加列或只读展示 | [RizTable 文档](RizTable.md) |
| | `RizCode` | 代码块展示组件，内置多语言语法高亮与一键复制 | [RizCode 文档](RizCode.md) |
| | `RizTimeline` | 时间线进度控件，支持时间刻度、拖拽与数值换算 | [RizTimeline 文档](RizTimeline.md) |
| **反馈与弹窗** | `RizInfoBox` | 状态提示框，预设 info / warn / error 类型 | [RizInfoBox 文档](RizInfoBox.md) |
| | `RizDialog` | 模态对话框，支持遮罩、倒计时进度条、自定义底栏 | [RizDialog 文档](RizDialog.md) |
| | `RizToast` | 轻提示消息通知，支持静态调用与嵌入式展示 | [RizToast 文档](RizToast.md) |
| **工具与辅助** | `RizFontAwesome` | Font Awesome Free 图标解析器，零依赖加载字形与字体族 | [RizFontAwesome 文档](RizFontAwesome.md) |


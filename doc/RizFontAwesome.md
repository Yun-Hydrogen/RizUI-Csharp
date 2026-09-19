# RizFontAwesome 图标系统

`RizFontAwesome` 是 RizUI 内置的 Font Awesome 6 Free 官方图标解析与渲染引擎。

组件库已直接嵌入了官方字体资源（`fa-solid-900.ttf`、`fa-regular-400.ttf`、`fa-brands-400.ttf`）及完整的样式规则表。业务应用**无需**在系统或项目中额外安装任何 Font Awesome 字体，即可使用所有官方免费图标。

---

## 命名空间

```csharp
using RizUI.Uwp.Controls;
```

---

## 支持的图标类型与类名

直接使用标准的 Font Awesome 6 CSS 类名字符串：

| 图标分类 | 前缀类名 | 示例类名 | 字体文件 |
| :--- | :--- | :--- | :--- |
| **实心图标 (Solid)** | `fa-solid` 或 `fas` | `fa-solid fa-house`<br/>`fa-solid fa-magnifying-glass`<br/>`fa-solid fa-gear` | `fa-solid-900.ttf` |
| **常规线条图标 (Regular)** | `fa-regular` 或 `far` | `fa-regular fa-bell`<br/>`fa-regular fa-envelope`<br/>`fa-regular fa-comment` | `fa-regular-400.ttf` |
| **品牌与组织图标 (Brands)** | `fa-brands` 或 `fab` | `fa-brands fa-github`<br/>`fa-brands fa-windows`<br/>`fa-brands fa-apple` | `fa-brands-400.ttf` |

---

## 在 RizUI 组件中使用

RizUI 的所有带图标属性的控件均原生集成了 `RizFontAwesome`，无需编写 C# 代码，直接在 XAML 属性中传入类名字符串即可：

```xml
<!-- 按钮图标 -->
<rizui:RizButton Text="GitHub 主页"
                 LIcon="fa-brands fa-github"
                 Primary="True" />

<!-- 卡片图标 -->
<rizui:RizCard Title="系统监控"
               Icon="fa-solid fa-gauge-high" />

<!-- 设置项图标 -->
<rizui:RizCfgRow Label="通知提醒"
                 Icon="fa-regular fa-bell">
    <rizui:RizSwitch IsOn="True" />
</rizui:RizCfgRow>

<!-- 对话框图标 -->
<rizui:RizDialog Title="警示信息"
                 Icon="fa-solid fa-triangle-exclamation" />

<!-- 动态轻提示图标 -->
<rizui:RizToast Title="文件已就绪"
                Icon="fa-solid fa-file-arrow-down" />
```

---

## 在自定义业务代码中使用

如果你在自定义的 XAML 控件（如原生的 `TextBlock`）中也需要显示 Font Awesome 图标，可以直接调用 `RizFontAwesome.Resolve` 静态方法：

```csharp
using RizUI.Uwp.Controls;

// 解析图标
RizFontAwesomeIcon icon = RizFontAwesome.Resolve("fa-solid fa-rocket");

// 绑定或赋值给 TextBlock
myTextBlock.Text = icon.Glyph;
myTextBlock.FontFamily = icon.FontFamily;
```

### 检查是否支持某图标 (`Supports`)

```csharp
bool isSupported = RizFontAwesome.Supports("fa-house");
```

---

## API 说明

### 静态成员

| 成员名 | 类型 | 说明 |
| :--- | :--- | :--- |
| `Resolve(string? classes)` | 方法 | 输入 CSS 类名组合，解析并返回包含字形字符和字体的 `RizFontAwesomeIcon` 结构体 |
| `Supports(string? iconClass)` | 方法 | 校验给定的类名是否属于内置支持的 Free 图标 |
| `SupportedClassCount` | 属性 (`int`) | 当前已内置从官方 CSS 解析得到的全部 Free class 总数量（数千个） |
| `FreeFamily` | 常量 (`string`) | Solid / Regular 字体族名 (`"Font Awesome 6 Free"`) |
| `BrandsFamily` | 常量 (`string`) | Brands 字体族名 (`"Font Awesome 6 Brands"`) |

### `RizFontAwesomeIcon` 结构体

```csharp
public readonly record struct RizFontAwesomeIcon(
    string Glyph,           // 解码后的 Unicode 字形字符
    FontFamily? FontFamily  // 对应的字体族引用 (ms-appx:///Assets/FontAwesome/...)
);
```


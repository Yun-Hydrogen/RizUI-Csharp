# RizColorPicker 颜色选择器

`RizColorPicker` 是用于色彩选取与 Hex 十六进制色值编辑的组件。支持交互式选色、透明度与色相调节、色块实时预览、十六进制颜色双向同步以及预设色快捷选取。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础用法

```xml
<StackPanel Spacing="16">
    <!-- 双向绑定选中的十六进制色值 -->
    <rizui:RizColorPicker ColorValue="{x:Bind ViewModel.SelectedHexColor, Mode=TwoWay}" />

    <!-- 默认预设颜色 -->
    <rizui:RizColorPicker ColorValue="#39C5BB" />
</StackPanel>
```

### 2. 结合配置行 (`RizCfgRow`)

在主题设置或个性化外观面板中，通过 `RizCfgRow` 承载：

```xml
<rizui:RizCfgRow Label="应用强调色"
                 Hint="全局按钮、进度条及高亮边框的主题色"
                 Icon="fa-solid fa-palette">
    <rizui:RizColorPicker ColorValue="{x:Bind ViewModel.AccentColorHex, Mode=TwoWay}" />
</rizui:RizCfgRow>
```

### 3. 监听色彩变更事件

```xml
<rizui:RizColorPicker ColorChanged="OnColorPicked" />
```

```csharp
private void OnColorPicked(object sender, string hexColor)
{
    System.Diagnostics.Debug.WriteLine($"用户选取了新颜色: {hexColor}");
    // 动态应用至界面或保存到用户配置
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `ColorValue` | `string` | `"#66CCFF"` | 当前选中的十六进制颜色字符串（格式如 `"#RRGGBB"` 或 `"#AARRGGBB"`，支持双向绑定 `Mode=TwoWay`） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

> **提示**：`RizColorPicker` 自身即为色彩选取器，其前景与控件强调色直接由内部选取的 `ColorValue` 自主控制，因此未设单独的 `Color` 覆盖属性。

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `ColorChanged` | `(object sender, string hex)` | 当用户在面板中拖动或输入改变颜色值时实时触发，传递最新的 Hex 字符串 |


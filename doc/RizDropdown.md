# RizDropdown 下拉菜单

`RizDropdown` 是用于在预设的选项列表中展开浮层并选取单项数据的下拉选择器控件。支持深浅色自适应浮层、选中项高亮背景与主题色覆盖。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 数据模型与初始化

在后台代码或 ViewModel 中准备 `RizDropdownItem` 列表：

```csharp
using RizUI.Uwp.Controls;

public List<RizDropdownItem> GraphicOptions { get; } = new()
{
    new("vulkan", "Vulkan (高性能)"),
    new("opengl", "OpenGL (高兼容)"),
    new("dx12", "DirectX 12 (Windows 原生)"),
    new("software", "Software (软件渲染/关闭加速)")
};
```

### 2. XAML 中基础绑定

```xml
<StackPanel Spacing="16">
    <!-- 基础下拉框 -->
    <rizui:RizDropdown Options="{x:Bind GraphicOptions}"
                       SelectedValue="{x:Bind ViewModel.CurrentBackend, Mode=TwoWay}" />

    <!-- 搭配 RizCfgRow 配置行使用 -->
    <rizui:RizCfgRow Label="图形渲染引擎"
                     Hint="若遇到画面卡顿或黑屏，请切换至兼容模式"
                     Icon="fa-solid fa-microchip">
        <rizui:RizDropdown Width="200"
                           Options="{x:Bind GraphicOptions}"
                           SelectedValue="{x:Bind ViewModel.CurrentBackend, Mode=TwoWay}" />
    </rizui:RizCfgRow>
</StackPanel>
```

### 3. 自定义高亮主题色 (`Color`)

选中项的标记背景和展开焦点边框支持通过 `Color` 自定义：

```xml
<rizui:RizDropdown Options="{x:Bind GraphicOptions}"
                   SelectedValue="vulkan"
                   Color="#39C5BB" />
```

### 4. 监听选中变更事件

```xml
<rizui:RizDropdown Options="{x:Bind GraphicOptions}"
                   SelectionChanged="OnSelectionChanged" />
```

```csharp
private void OnSelectionChanged(object sender, string selectedValue)
{
    System.Diagnostics.Debug.WriteLine($"选中的值: {selectedValue}");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `SelectedValue` | `string` | `""` | 当前选中的选项值 `Value`（支持双向绑定 `Mode=TwoWay`） |
| `Options` | `IList` | `null` | 下拉选项列表，接收 `RizDropdownItem` 对象的集合 |

#### `RizDropdownItem` 类定义

```csharp
public class RizDropdownItem
{
    public string Value { get; set; } = string.Empty; // 唯一标识/存库值
    public string Label { get; set; } = string.Empty; // 展示文案
}
```

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 边框聚焦与选中项的高亮主题色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `SelectionChanged` | `(object sender, string selectedValue)` | 当用户点击切换下拉选项时触发，传递选中的选项值字符串 |


# RizSlider 滑块

`RizSlider` 是用于在指定数值区间内进行离散或连续调节的滑块控件。支持自定义最小值、最大值、步长、单位后缀显示、主题色覆盖以及双向数据绑定。

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
    <!-- 默认 0~100 范围 -->
    <rizui:RizSlider Value="{x:Bind ViewModel.Volume, Mode=TwoWay}" />

    <!-- 自定义范围与步进 -->
    <rizui:RizSlider Minimum="10"
                     Maximum="200"
                     Step="5"
                     Value="50" />
</StackPanel>
```

### 2. 数值单位后缀 (`Display`)

通过 `Display` 属性可以为滑块数值标签添加百分比、物理单位或自定义文字后缀：

```xml
<StackPanel Spacing="16">
    <!-- 百分比 -->
    <rizui:RizSlider Value="75" Display="%" />

    <!-- 播放倍速 -->
    <rizui:RizSlider Minimum="0.5" Maximum="3.0" Step="0.25" Value="1.0" Display="x" />

    <!-- 自定义单位 -->
    <rizui:RizSlider Minimum="0" Maximum="120" Step="1" Value="60" Display=" FPS" />
</StackPanel>
```

### 3. 搭配配置行 (`RizCfgRow`)

在设置页面中，通常将 `RizSlider` 置入 `RizCfgRow` 中：

```xml
<rizui:RizCfgRow Label="界面透明度"
                 Hint="调节主窗口背景的毛玻璃不透明度"
                 Icon="fa-solid fa-droplet">
    <rizui:RizSlider Width="220"
                     Minimum="20"
                     Maximum="100"
                     Step="1"
                     Display="%"
                     Value="{x:Bind ViewModel.OpacityPercent, Mode=TwoWay}" />
</rizui:RizCfgRow>
```

### 4. 监听数值变化

```xml
<rizui:RizSlider ValueChanged="OnSliderValueChanged" />
```

```csharp
private void OnSliderValueChanged(object sender, double val)
{
    System.Diagnostics.Debug.WriteLine($"滑块实时数值: {val}");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Value` | `double` | `0` | 当前滑块所处的数值（支持双向绑定 `Mode=TwoWay`） |
| `Minimum` | `double` | `0` | 滑块允许调节的最小下限值 |
| `Maximum` | `double` | `100` | 滑块允许调节的最大上限值 |
| `Step` | `double` | `1` | 数值每次增减的步进间隔 |
| `Display` | `string` | `""` | 紧随数值显示的单位后缀（如 `"%"`、`"x"`、`"ms"`） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 已填充进度条与滑块的高亮主题色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `ValueChanged` | `(object sender, double value)` | 当滑块位置或数值发生变化时实时触发 |


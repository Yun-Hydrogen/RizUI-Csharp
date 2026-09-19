# RizSwitch 开关

`RizSwitch` 是用于在两种互斥状态（开/关、启用/禁用）之间进行切换的拨动开关控件。拥有平滑的滑块位移动画、深浅色模式自适应背景以及支持自定义开启高亮色。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础用法

```xml
<StackPanel Spacing="12">
    <!-- 默认关闭 -->
    <rizui:RizSwitch IsOn="False" />

    <!-- 默认开启 -->
    <rizui:RizSwitch IsOn="True" />

    <!-- 数据双向绑定 -->
    <rizui:RizSwitch IsOn="{x:Bind ViewModel.IsAutoSaveEnabled, Mode=TwoWay}" />
</StackPanel>
```

### 2. 结合设置项行 (`RizCfgRow`)

在实际业务设置界面中，通常与 `RizCfgRow` 搭配使用：

```xml
<rizui:RizCfgRow Label="开机自动启动"
                 Hint="系统启动登录后，自动在后台静默运行"
                 Icon="fa-solid fa-power-off">
    <rizui:RizSwitch IsOn="{x:Bind ViewModel.AutoStart, Mode=TwoWay}" />
</rizui:RizCfgRow>
```

### 3. 自定义开启主题色 (`Color`)

开启状态下的胶囊背景色可通过 `Color` 进行个性化覆盖：

```xml
<StackPanel Orientation="Horizontal" Spacing="16">
    <rizui:RizSwitch IsOn="True" Color="#39C5BB" />
    <rizui:RizSwitch IsOn="True" Color="#66CCFF" />
    <rizui:RizSwitch IsOn="True" Color="#E278B3" />
    <rizui:RizSwitch IsOn="True" Color="#10B981" />
</StackPanel>
```

### 4. 监听状态改变事件

```csharp
// XAML 中声明: Toggled="OnSwitchToggled"
private void OnSwitchToggled(object sender, bool isOn)
{
    System.Diagnostics.Debug.WriteLine($"开关当前状态: {isOn}");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `IsOn` | `bool` | `false` | 开关当前开启/关闭状态（支持双向绑定 `Mode=TwoWay`） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 开关处于开启状态时的胶囊背景填充色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `Toggled` | `(object sender, bool isOn)` | 当开关状态发生改变时触发，直接返回当前的 `bool` 值 |


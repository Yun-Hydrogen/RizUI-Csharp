# RizCheckbox 复选框

`RizCheckbox` 是用于多选、开关确认的复选框控件，提供圆角方形的精致勾选框、支持左/右双向标签文本配置以及自定义勾选高亮色。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础用法

```xml
<StackPanel Spacing="10">
    <!-- 右侧标签（最常见形式） -->
    <rizui:RizCheckbox RLabel="已阅读并同意服务条款"
                       IsChecked="{x:Bind ViewModel.AgreeTerms, Mode=TwoWay}" />

    <!-- 默认勾选状态 -->
    <rizui:RizCheckbox RLabel="开机时自动启动应用"
                       IsChecked="True" />

    <!-- 左侧标签 -->
    <rizui:RizCheckbox LLabel="开启硬件加速" />

    <!-- 左右双标签 -->
    <rizui:RizCheckbox LLabel="状态"
                       RLabel="启用实验性渲染器" />
</StackPanel>
```

### 2. 自定义主题色 (`Color`)

当复选框处于勾选状态时，勾选框背景会自动渲染为指定的主题色：

```xml
<StackPanel Orientation="Horizontal" Spacing="16">
    <rizui:RizCheckbox RLabel="天蓝风格" IsChecked="True" Color="#66CCFF" />
    <rizui:RizCheckbox RLabel="初音绿风格" IsChecked="True" Color="#39C5BB" />
    <rizui:RizCheckbox RLabel="星空紫风格" IsChecked="True" Color="#A855F7" />
</StackPanel>
```

### 3. 事件与命令处理

```xml
<rizui:RizCheckbox RLabel="同步上传云端"
                   Checked="OnSyncChecked"
                   Unchecked="OnSyncUnchecked"
                   Toggled="OnSyncToggled"
                   Command="{x:Bind ViewModel.ToggleSyncCommand}" />
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `IsChecked` | `bool` | `false` | 当前复选框选中状态（支持双向绑定 `Mode=TwoWay`） |
| `IsOn` | `bool` | `false` | 兼容旧版/开关 API 的状态别名（与 `IsChecked` 同步） |
| `LLabel` | `string` | `""` | 勾选框左侧的标签文本 |
| `RLabel` | `string` | `""` | 勾选框右侧的标签文本 |
| `Command` | `ICommand` | `null` | 状态切换时触发的 MVVM 命令 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 选中状态下的激活背景主题色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `Checked` | `(object sender, EventArgs e)` | 复选框从未选中变为选中时触发 |
| `Unchecked` | `(object sender, EventArgs e)` | 复选框从选中变为未选中时触发 |
| `Toggled` | `(object sender, EventArgs e)` | 复选框状态发生切换（勾选或取消）时触发 |


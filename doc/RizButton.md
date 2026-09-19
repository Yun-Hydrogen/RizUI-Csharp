# RizButton 按钮

`RizButton` 是 RizUI 提供的核心基础按钮控件，支持强调主题色、危险警示、通栏铺满、左/右 Font Awesome 图标组合以及样式精细覆盖。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础用法

```xml
<StackPanel Orientation="Horizontal" Spacing="10">
    <!-- 次要/常规按钮 -->
    <rizui:RizButton Text="常规按钮" Click="OnButtonClick" />

    <!-- 主色强调按钮 -->
    <rizui:RizButton Text="主色按钮" Primary="True" Click="OnButtonClick" />

    <!-- 危险操作按钮 -->
    <rizui:RizButton Text="删除数据" Danger="True" Click="OnDeleteClick" />

    <!-- 禁用状态 -->
    <rizui:RizButton Text="不可点击" IsEnabled="False" />
</StackPanel>
```

### 2. 带图标按钮

支持通过 `LIcon`（左侧）和 `RIcon`（右侧）设置完整的 Font Awesome 类名，文本与图标自动适配对齐与间距：

```xml
<StackPanel Orientation="Horizontal" Spacing="10">
    <!-- 左侧图标 -->
    <rizui:RizButton Text="发送" LIcon="fa-solid fa-paper-plane" Primary="True" />

    <!-- 右侧图标 -->
    <rizui:RizButton Text="下一页" RIcon="fa-solid fa-arrow-right" />

    <!-- 纯图标按钮（不填 Text） -->
    <rizui:RizButton LIcon="fa-solid fa-gear" />
    <rizui:RizButton LIcon="fa-solid fa-magnifying-glass" Primary="True" />
</StackPanel>
```

### 3. 通栏按钮 (`Long`)

通栏按钮宽度将自适应撑满父级容器，非常适合登录表单底部的提交按钮：

```xml
<rizui:RizButton Text="确认提交" Primary="True" Long="True" />
```

### 4. 自定义色彩 (`Color`)

除了默认的全局强调色外，可以通过 `Color` 属性为单一按钮指定特定颜色：

```xml
<StackPanel Orientation="Horizontal" Spacing="10">
    <rizui:RizButton Text="初音绿" Primary="True" Color="#39C5BB" />
    <rizui:RizButton Text="星空紫" Primary="True" Color="#A855F7" />
</StackPanel>
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Text` | `string` | `""` | 按钮文本内容。留空时可作为纯图标按钮展示 |
| `TextStyle` | `Style` | `null` | 按钮文本的 XAML `Style` 覆盖（如字号、字体等） |
| `LIcon` | `string` | `""` | 左侧图标的 Font Awesome 类名（如 `fa-solid fa-paper-plane`） |
| `LIconStyle` | `Style` | `null` | 左侧图标的 XAML `Style` 覆盖（颜色、大小等） |
| `RIcon` | `string` | `""` | 右侧图标的 Font Awesome 类名（如 `fa-solid fa-angle-right`） |
| `RIconStyle` | `Style` | `null` | 右侧图标的 XAML `Style` 覆盖 |
| `Primary` | `bool` | `false` | 是否为主色高亮按钮（以强调色填充背景） |
| `Danger` | `bool` | `false` | 是否为危险警示按钮（珊瑚红背景） |
| `Long` | `bool` | `false` | 是否撑满父容器宽度（通栏按钮） |
| `Command` | `ICommand` | `null` | MVVM 绑定的点击命令 |
| `CommandParameter` | `object` | `null` | 传递给命令的参数 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 自定义背景填充色（十六进制如 `"#39C5BB"`），为空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `Click` | `(object sender, RoutedEventArgs e)` | 当用户点击按钮时触发 |


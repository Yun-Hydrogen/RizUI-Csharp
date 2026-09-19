# RizInfoBox 状态提示框

`RizInfoBox` 是用于在页面中展示辅助信息、状态通知、操作警告或错误警示的横幅式提示框控件。支持三种预设语义类型、自定义图标、文本样式覆盖、主题色定义以及扩展子控件插槽。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 预设语义类型 (`Type`)

提供三种开箱即用的语义状态，分别匹配专属的柔和背景、边框、强调文字色及默认图标：

```xml
<StackPanel Spacing="12">
    <!-- 信息提示 (info - 默认) -->
    <rizui:RizInfoBox Type="info"
                      Text="系统将在今日凌晨 02:00 进行常规数据库维护。" />

    <!-- 警示提醒 (warn) -->
    <rizui:RizInfoBox Type="warn"
                      Text="磁盘剩余空间不足 10%，请及时清理旧版本缓存文件。" />

    <!-- 错误异常 (error) -->
    <rizui:RizInfoBox Type="error"
                      Text="无法连接到远程授权服务器，请检查本地网络代理配置。" />
</StackPanel>
```

### 2. 自定义图标与样式覆盖

支持替换默认图标，并通过 `TextStyle` 或 `IconStyle` 精细覆盖字号或颜色：

```xml
<rizui:RizInfoBox Type="info"
                  Text="已成功导出 128 条记录至本地 Excel 文件"
                  Icon="fa-solid fa-file-circle-check">
    <rizui:RizInfoBox.TextStyle>
        <Style TargetType="TextBlock">
            <Setter Property="FontWeight" Value="SemiBold" />
        </Style>
    </rizui:RizInfoBox.TextStyle>
</rizui:RizInfoBox>
```

### 3. 自定义内容插槽 (`Content`)

除了单行说明文字外，`RizInfoBox` 支持作为容器包裹额外的富文本、按钮或配置行。当同时设置了 `Text` 和子元素时，两者之间会自动呈现精巧的细分隔线：

```xml
<rizui:RizInfoBox Type="info" Text="发现新版本 v2.1.0 可供更新">
    <StackPanel Orientation="Horizontal" Spacing="10" Margin="0,6,0,0">
        <rizui:RizButton Text="查看更新日志" />
        <rizui:RizButton Text="立即下载并安装" Primary="True" />
    </StackPanel>
</rizui:RizInfoBox>
```

### 4. 自定义色彩 (`Color`)

在 `Type="info"` 时，支持通过 `Color` 属性定制提示框的强调基色：

```xml
<rizui:RizInfoBox Type="info"
                  Text="紫色调个性化提示信息"
                  Color="#A855F7" />
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Type` | `string` | `"info"` | 预设类型：`"info"`（常规提示）/ `"warn"`（警告注意）/ `"error"`（严重错误） |
| `Text` | `string` | `""` | 提示框主要展示文本内容 |
| `TextStyle` | `Style` | `null` | 主要文本的 XAML `Style` 覆盖（如字号、粗细等） |
| `Icon` | `string` | `""` | 自定义左侧 Font Awesome 图标类名（留空则根据 `Type` 自动匹配预设图标） |
| `IconStyle` | `Style` | `null` | 左侧图标的 XAML `Style` 覆盖 |
| `Content` | `object` | `null` | 提示框下方承载的扩展子内容元素 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 自定义强调主题色（仅在 `Type="info"` 时生效，留空跟随全局 `--rizui_themecolor`） |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |


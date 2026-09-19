# RizCard 卡片容器

`RizCard` 是用于信息聚合、模块化分区的卡片容器控件。采用多层拟态柔和阴影、圆角边框设计，支持主标题、副标题说明、Font Awesome 图标展示以及带平滑高度动画的可折叠交互。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础卡片

作为 `ContentControl`，卡片的内容区可直接放入任意 XAML 布局：

```xml
<rizui:RizCard Title="基础信息"
               Desc="查看当前用户的系统授权与绑定状态"
               Icon="fa-solid fa-user-shield">
    <StackPanel Spacing="8">
        <TextBlock Text="用户 ID: 10086" />
        <TextBlock Text="授权级别: 企业版终身授权" />
    </StackPanel>
</rizui:RizCard>
```

### 2. 可折叠卡片 (`Foldable`)

开启 `Foldable="True"` 后，卡片标题右侧将呈现折叠旋转箭头。用户点击标题栏整块区域即可平滑展开/收起卡片内容：

```xml
<rizui:RizCard Title="高级网络设置"
               Desc="点击标题栏展开或收起高级代理配置"
               Icon="fa-solid fa-network-wired"
               Foldable="True">
    <StackPanel Spacing="10" Margin="0,8,0,0">
        <rizui:RizCfgRow Label="启用 HTTP 代理">
            <rizui:RizSwitch IsOn="False" />
        </rizui:RizCfgRow>
        <rizui:RizCfgRow Label="代理端口">
            <rizui:RizText Text="7890" Width="100" />
        </rizui:RizCfgRow>
    </StackPanel>
</rizui:RizCard>
```

### 3. 极简卡片（仅内容或仅标题）

支持省略副标题或图标，灵活适应不同界面密度：

```xml
<!-- 无副标题与图标的简洁卡片 -->
<rizui:RizCard Title="快捷操作">
    <StackPanel Orientation="Horizontal" Spacing="10">
        <rizui:RizButton Text="刷新缓存" Primary="True" />
        <rizui:RizButton Text="导出日志" />
    </StackPanel>
</rizui:RizCard>
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Title` | `string` | `""` | 卡片主标题文字 |
| `TitleStyle` | `Style` | `null` | 标题文本的 XAML `Style` 覆盖（颜色、字号等） |
| `Desc` | `string` | `""` | 卡片副标题/辅助说明文字 |
| `DescStyle` | `Style` | `null` | 副标题文本的 XAML `Style` 覆盖 |
| `Icon` | `string` | `""` | 标题左侧的 Font Awesome 类名（如 `fa-solid fa-folder-open`） |
| `IconStyle` | `Style` | `null` | 图标的 XAML `Style` 覆盖 |
| `Foldable` | `bool` | `false` | 是否开启折叠模式：点击标题栏平滑折叠/展开卡片内容 |
| `Content` | `object` | `null` | 卡片承载的主体内容元素（XAML 默认内容属性） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

> **提示**：卡片背景与阴影自动根据当前 `Theme` 调整为适合明暗模式的层次色调，内容区控件可各自独立配置自身的主题色。


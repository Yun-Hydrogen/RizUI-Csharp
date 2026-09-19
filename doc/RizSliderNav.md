# RizSliderNav 侧边导航栏

`RizSliderNav` 是一套适用于管理后台、大型桌面客户端侧边栏的多级树状导航组件。支持无限层级子菜单折叠展开、固定与悬浮双模式、全局折叠/展开动画、底部插槽以及双向绑定当前选中栏目。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 数据模型定义

在后台或 ViewModel 中构建 `RizSliderNavItem` 树状层级：

```csharp
using RizUI.Uwp.Controls;

public List<RizSliderNavItem> NavItems { get; } = new()
{
    new RizSliderNavItem
    {
        Key = "home",
        Text = "工作台",
        Icon = "fa-solid fa-house"
    },
    new RizSliderNavItem
    {
        Key = "settings",
        Text = "系统设置",
        Icon = "fa-solid fa-gear",
        IsExpanded = true,
        Children =
        {
            new RizSliderNavItem { Key = "settings-general", Text = "常规选项", Icon = "fa-solid fa-sliders" },
            new RizSliderNavItem { Key = "settings-theme", Text = "外观主题", Icon = "fa-solid fa-palette" }
        }
    },
    new RizSliderNavItem
    {
        Key = "about",
        Text = "关于我们",
        Icon = "fa-solid fa-circle-info"
    }
};
```

### 2. XAML 中基础布局

```xml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>

    <!-- 侧边栏 -->
    <rizui:RizSliderNav Grid.Column="0"
                        Title="沙勒终端"
                        Icon="fa-solid fa-shield-halved"
                        Items="{x:Bind NavItems}"
                        SelectedItem="{x:Bind ViewModel.CurrentPageKey, Mode=TwoWay}"
                        SelectionChanged="OnNavSelectionChanged">
        <!-- 底部自定义插槽 -->
        <rizui:RizSliderNav.Footer>
            <StackPanel Orientation="Horizontal" Spacing="8" Margin="12">
                <TextBlock Text="v1.0.0" Opacity="0.6" FontSize="12" />
            </StackPanel>
        </rizui:RizSliderNav.Footer>
    </rizui:RizSliderNav>

    <!-- 主页面内容区域 -->
    <Frame Grid.Column="1" x:Name="ContentFrame" />
</Grid>
```

### 3. 布局模式 (`StyleMode`)

- `Fixed`（默认）：固定并排，展开或收起时占据实际布局宽度，主界面随着宽度变化重排。
- `Floating`：悬浮抽屉模式，侧边栏以浮层形式覆盖在主内容之上，适合紧凑屏幕或平板设备。

```xml
<rizui:RizSliderNav StyleMode="Floating"
                    Items="{x:Bind NavItems}" />
```

### 4. 监听选中事件

```csharp
private void OnNavSelectionChanged(object sender, RizSliderNavItem item)
{
    System.Diagnostics.Debug.WriteLine($"跳转到: {item.Key} ({item.Text})");
    // 根据 item.Key 导航页面
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Items` | `IList<RizSliderNavItem>` | `null` | 侧边栏树状数据源集合，支持任意深度的 `Children` 嵌套 |
| `SelectedItem` | `string` | `""` | 当前激活选中的条目 `Key`（支持双向绑定 `Mode=TwoWay`） |
| `DefaultSelectedItem` | `string` | `""` | 首次初始化载入时默认高亮的条目 `Key` |
| `StyleMode` | `RizSliderNavStyle` | `Fixed` | 导航栏布局模式：`Fixed`（固定占位）或 `Floating`（浮动覆盖） |
| `Title` | `string` | `"RizUI"` | 侧边栏顶端品牌标题文案 |
| `Icon` | `string` | `"fa-solid fa-layer-group"` | 顶端品牌图标（支持完整 Font Awesome 类名） |
| `IsCollapsible` | `bool` | `true` | 是否展示折叠按钮并允许用户点击展开/收起 |
| `IsCollapsed` | `bool` | `false` | 当前是否处于折叠收起状态（支持双向绑定） |
| `Footer` | `object` | `null` | 侧边栏底部自定义插槽内容 |

#### `RizSliderNavItem` 数据项

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Key` | `string` | `""` | 该导航项的唯一标识字符串（用于匹配 `SelectedItem`） |
| `Text` | `string` | `""` | 菜单显示的文本标题 |
| `Icon` | `string` | `""` | 图标 Font Awesome 类名（如 `fa-solid fa-house`） |
| `Children` | `IList<RizSliderNavItem>` | `[]` | 子级嵌套菜单列表 |
| `IsExpanded` | `bool` | `false` | 子级列表初始是否展开 |
| `Command` | `ICommand` | `null` | 点击该项时触发的 MVVM 命令 |
| `CommandParameter` | `object` | `null` | 传递给命令的参数 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `SelectionChanged` | `(object sender, RizSliderNavItem item)` | 当用户点击切换导航项时触发，传递选中的项模型 |


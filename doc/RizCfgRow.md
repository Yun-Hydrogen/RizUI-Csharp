# RizCfgRow 配置项行容器

`RizCfgRow` 是用于快速构建应用设置、偏好选项列表的配置行容器控件。内置左侧标题标签、提示小字、Font Awesome 图标对齐，并在右侧承载各类交互控件；支持竖向堆叠模式与整行禁用状态。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础用法（搭配各种输入组件）

```xml
<StackPanel Spacing="12">
    <!-- 搭配 RizSwitch -->
    <rizui:RizCfgRow Label="自动检查更新"
                     Hint="在应用每次启动时检测最新版本"
                     Icon="fa-solid fa-arrows-rotate">
        <rizui:RizSwitch IsOn="True" />
    </rizui:RizCfgRow>

    <!-- 搭配 RizSlider -->
    <rizui:RizCfgRow Label="背景音效音量"
                     Hint="调整主菜单与界面点击的反馈音量"
                     Icon="fa-solid fa-volume-high">
        <rizui:RizSlider Width="200" Value="60" Display="%" />
    </rizui:RizCfgRow>

    <!-- 搭配 RizButton -->
    <rizui:RizCfgRow Label="清理本地临时缓存"
                     Hint="当前缓存大小：128.4 MB"
                     Icon="fa-solid fa-trash-can">
        <rizui:RizButton Text="立即清理" Danger="True" />
    </rizui:RizCfgRow>
</StackPanel>
```

### 2. 竖向堆叠模式 (`Stack`)

当右侧操作控件较长（如宽文本框、长输入条、复合多选组等）时，开启 `Stack="True"` 将使控件自动移至标签与提示文案下方展示：

```xml
<rizui:RizCfgRow Label="WebHook 回调地址"
                 Hint="接收自动化构建推送的外部完整 URL"
                 Icon="fa-solid fa-link"
                 Stack="True">
    <rizui:RizText Placeholder="https://api.example.com/webhook/endpoint"
                   Margin="0,8,0,0" />
</rizui:RizCfgRow>
```

### 3. 整行禁用 (`Disabled`)

将 `Disabled="True"` 会自动为整行附加半透明遮罩视觉效果，并彻底阻断内部所有子控件的鼠标/键盘交互：

```xml
<rizui:RizCfgRow Label="离线数据同步"
                 Hint="未检测到本地网络连接，此功能暂时不可用"
                 Icon="fa-solid fa-wifi"
                 Disabled="True">
    <rizui:RizSwitch IsOn="False" />
</rizui:RizCfgRow>
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Label` | `string` | `""` | 配置项主标题文字 |
| `LabelStyle` | `Style` | `null` | 标题文字的 XAML `Style` 覆盖（字号、字重等） |
| `Hint` | `string` | `""` | 标题下方的次要辅助提示小字 |
| `HintStyle` | `Style` | `null` | 辅助提示文字的 XAML `Style` 覆盖 |
| `Icon` | `string` | `""` | 左侧图标的 Font Awesome 类名（如 `fa-solid fa-gear`） |
| `IconStyle` | `Style` | `null` | 左侧图标的 XAML `Style` 覆盖（颜色、大小等） |
| `Stack` | `bool` | `false` | 是否启用垂直堆叠布局（为 `True` 时将控件置于标题下方） |
| `Disabled` | `bool` | `false` | 是否禁用整行（半透明呈现并阻止子控件一切交互） |
| `Content` | `object` | `null` | 右侧操作区所承载的控件内容（XAML 默认内容属性） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |


# RizDialog 模态对话框

`RizDialog` 是用于重要操作确认、表单弹窗录入、阻断式警告提示的模态对话框控件。内置平滑缩放进入动画、背景毛玻璃/暗色遮罩、右上角圆角关闭按钮、底部操作栏（Footer）插槽以及自动倒计时进度条关闭机制。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础对话框

```xml
<rizui:RizDialog Show="{x:Bind ViewModel.IsDialogOpen, Mode=TwoWay}"
                 Title="确认注销登录"
                 Icon="fa-solid fa-arrow-right-from-bracket"
                 WidthText="380px"
                 Closed="OnDialogClosed">
    <!-- 主体内容 -->
    <TextBlock Text="注销后未保存的临时草稿将会丢失，确定要继续吗？"
               TextWrapping="Wrap" />

    <!-- 底部操作按钮栏 -->
    <rizui:RizDialog.Footer>
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Spacing="10">
            <rizui:RizButton Text="取消" Click="OnCancelClick" />
            <rizui:RizButton Text="确认注销" Danger="True" Click="OnConfirmLogoutClick" />
        </StackPanel>
    </rizui:RizDialog.Footer>
</rizui:RizDialog>
```

### 2. 倒计时自动关闭与进度条 (`Countdown` / `ShowBar`)

设置 `Countdown="5"`，底部将呈现自动递减的进度条，倒计时归零时自动触发关闭：

```xml
<rizui:RizDialog Show="{x:Bind ViewModel.IsSyncing, Mode=TwoWay}"
                 Title="数据同步完成"
                 Icon="fa-solid fa-cloud-arrow-up"
                 Countdown="5"
                 ShowBar="True"
                 Color="#39C5BB"
                 WidthText="400px">
    <TextBlock Text="本地配置已同步上传至云端服务器，5 秒后将自动关闭..." />

    <rizui:RizDialog.Footer>
        <rizui:RizButton Text="立即完成" Primary="True" Color="#39C5BB" Click="OnCancelClick" />
    </rizui:RizDialog.Footer>
</rizui:RizDialog>
```

### 3. 强约束弹窗（禁止点击遮罩与隐藏右上角关闭）

对于必须用户作出明确选择的关键流程，可禁用遮罩点击与右上角关闭按钮：

```xml
<rizui:RizDialog Show="True"
                 Title="重要协议确认"
                 Closable="False"
                 MaskClose="False"
                 WidthText="420px">
    <TextBlock Text="请阅读并确认新版隐私保护政策以继续使用。" />
    <rizui:RizDialog.Footer>
        <rizui:RizButton Text="我已充分阅读并同意" Primary="True" Long="True" Click="OnAgreedClick" />
    </rizui:RizDialog.Footer>
</rizui:RizDialog>
```

### 4. 监听对话框关闭

```csharp
private void OnDialogClosed(object sender, EventArgs e)
{
    System.Diagnostics.Debug.WriteLine("对话框已关闭");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Show` | `bool` | `false` | 控制对话框显示与隐藏状态（支持双向绑定 `Mode=TwoWay`） |
| `Title` | `string` | `""` | 对话框顶部主标题文字 |
| `TitleStyle` | `Style` | `null` | 标题文本的 XAML `Style` 覆盖 |
| `Icon` | `string` | `""` | 标题左侧的 Font Awesome 类名（如 `fa-solid fa-triangle-exclamation`） |
| `IconStyle` | `Style` | `null` | 标题图标的 XAML `Style` 覆盖 |
| `WidthText` | `string` | `"auto"` | 对话框面板宽度，支持具体像素如 `"380px"`、`"440px"` 或 `"auto"` |
| `Closable` | `bool` | `true` | 是否在右上角显示关闭按钮 |
| `MaskClose` | `bool` | `true` | 点击对话框背景遮罩层时是否自动关闭对话框 |
| `Countdown` | `double` | `0` | 自动关闭倒计时（秒）。大于 0 时开始倒数并在归零时关闭 |
| `ShowBar` | `bool` | `false` | 是否在对话框底边展示倒计时进度条 |
| `Progress` | `double` | `-1` | 手动进度值（`0.0 ~ 1.0`）。小于 0 时由 `Countdown` 自动驱动 |
| `Footer` | `object` | `null` | 对话框底部操作按钮栏插槽 |
| `Content` | `object` | `null` | 对话框主体内容插槽 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 对话框标题图标、倒计时进度条及按钮交互高亮主题色，留空跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `Closed` | `(object sender, EventArgs e)` | 当对话框完全关闭（通过按钮、点击遮罩或倒计时归零）时触发 |


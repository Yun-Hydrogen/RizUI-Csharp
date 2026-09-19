# RizToast 轻提示消息通知

`RizToast` 是用于在屏幕右上角或特定区域弹出非阻断式操作反馈、即时警示或系统通知的组件。支持静态方法快捷弹出、底部倒计时进度条递减动画、右上角关闭按钮、常驻模式以及点击整块通知触发回调。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 静态方法快捷弹出 (`ShowToast`)

无需在 XAML 声明，通过静态方法直接在当前窗口顶层触发：

```csharp
using RizUI.Uwp.Controls;

// 1. 成功 / 常规信息提示 (默认 3 秒自动关闭并带进度条)
RizToast.ShowToast(
    xamlRoot: this.XamlRoot,
    title: "保存成功",
    hint: "所有配置更改已同步到本地数据库。"
);

// 2. 警告类型
RizToast.ShowToast(
    xamlRoot: this.XamlRoot,
    title: "网络波动",
    hint: "正在尝试第 2 次重新连接...",
    type: "warn"
);

// 3. 错误警示
RizToast.ShowToast(
    xamlRoot: this.XamlRoot,
    title: "上传失败",
    hint: "文件大小超过 50MB 上限。",
    type: "error"
);

// 4. 自定义色彩与图标
RizToast.ShowToast(
    xamlRoot: this.XamlRoot,
    title: "任务完成",
    hint: "每日日常已全部结算！",
    color: "#39C5BB",
    icon: "fa-solid fa-gift"
);
```

### 2. 交互式与常驻通知

将 `Countdown = 0` 可使通知保持常驻不自动消逝；可监听 `Click` 事件：

```csharp
var actionToast = new RizToast
{
    XamlRoot = this.XamlRoot,
    Title = "新邮件到达",
    Hint = "收到来自沙勒的 1 封新任务邮件，点击立即查阅。",
    Countdown = 0, // 常驻
    Icon = "fa-solid fa-envelope",
    Color = "#66CCFF"
};

actionToast.Click += (s, _) =>
{
    ((RizToast)s).Close(); // 关闭通知
    NavigateToMailBox();   // 跳转到邮箱
};

// 挂载显示
HostPanel.Children.Add(actionToast);
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Type` | `string` | `"info"` | 预设类型：`"info"` / `"warn"` / `"error"` |
| `Title` | `string` | `""` | 通知主标题文字 |
| `Hint` | `string` | `""` | 标题下方的辅助说明提示小字 |
| `Countdown` | `double` | `3` | 自动关闭等待时间（秒）。设为 `0` 时为常驻模式，不自动关闭 |
| `Closable` | `bool` | `true` | 是否显示右上角关闭按钮 |
| `ShowBar` | `bool` | `true` | 是否在底部展示随时间缩短的平滑动量进度条 |
| `WidthText` | `string` | `""` | 自定义通知面板宽度（如 `"360px"`、`"400px"`，默认 `"320px"`） |
| `Icon` | `string` | `""` | 自定义 Font Awesome 图标（留空则根据 `Type` 自动匹配） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 自定义主题色（在 `Type="info"` 时生效，留空跟随全局 `--rizui_themecolor`） |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 静态方法

```csharp
public static RizToast ShowToast(
    XamlRoot xamlRoot,
    string title,
    string hint = "",
    string type = "info",
    double countdown = 3,
    string color = "",
    string icon = "",
    object? content = null,
    FontFamily? fontFamily = null)
```

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `Click` / `Clicked` | `(object sender, EventArgs e)` | 当用户点击通知主体卡片时触发 |
| `Closed` | `(object sender, double remaining)` | 当通知关闭消失（倒计时结束或用户手动点击关闭）时触发 |


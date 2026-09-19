# RizTimeline 时间线进度条

`RizTimeline` 是专门针对音视频播放定位、动画帧选取、长过程任务回溯等时间流场景定制的进度拖拽控件。内置精准秒数换算、拖拽反馈动效、自定义时间区间与步长，并支持覆盖进度条主题色。

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
    <!-- 默认 0~120 秒时间轴 -->
    <rizui:RizTimeline Value="{x:Bind ViewModel.CurrentPositionSeconds, Mode=TwoWay}" />

    <!-- 自定义音视频时长 (如 300 秒) 与步进 -->
    <rizui:RizTimeline Minimum="0"
                       Maximum="300"
                       Step="0.5"
                       Value="45.5" />
</StackPanel>
```

### 2. 自定义主题色 (`Color`)

进度条已填充部分及时间游标指示块可通过 `Color` 覆盖：

```xml
<rizui:RizTimeline Minimum="0"
                   Maximum="60"
                   Step="1"
                   Value="25"
                   Color="#39C5BB" />
```

### 3. 监听时间点变动事件

```xml
<rizui:RizTimeline ValueChanged="OnTimelineSeek" />
```

```csharp
private void OnTimelineSeek(object sender, double currentSeconds)
{
    // 将播放器精确定位至指定秒数
    System.Diagnostics.Debug.WriteLine($"播放进度拖动至: {currentSeconds:F1} 秒");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Value` | `double` | `0` | 当前时间进度秒数值（支持双向绑定 `Mode=TwoWay`） |
| `Minimum` | `double` | `0` | 起始时间刻度（秒） |
| `Maximum` | `double` | `120` | 结束时间刻度（秒） |
| `Step` | `double` | `1` | 拖动与调节时的最小时间步进间隔（秒） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 时间线进度高亮与游标主题色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `ValueChanged` | `(object sender, double value)` | 当用户点击或拖动时间游标时实时触发，传递当前秒数值 |


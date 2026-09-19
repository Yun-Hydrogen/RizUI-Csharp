# RizText 文本输入框

`RizText` 是用于接收用户单行或多行文本输入的编辑框控件。提供圆角扁平化风格、输入框聚焦高亮边框过渡、占位提示、只读展示以及回车提交事件监听。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础单行输入

```xml
<StackPanel Spacing="12">
    <!-- 标准输入框 -->
    <rizui:RizText Placeholder="请输入用户名..."
                   Text="{x:Bind ViewModel.Username, Mode=TwoWay}" />

    <!-- 预设文本内容 -->
    <rizui:RizText Text="默认输入的内容" />

    <!-- 只读状态 -->
    <rizui:RizText Text="admin@company.org" IsReadOnly="True" />
</StackPanel>
```

### 2. 多行文本模式 (`Plaintext`)

将 `Plaintext` 设为 `True`，输入框将转换为支持换行滚动的多行文本区域（类似于 HTML `<textarea>`）：

```xml
<rizui:RizText Plaintext="True"
               Height="120"
               Placeholder="在此输入多行备注或详细描述..."
               Text="{x:Bind ViewModel.Description, Mode=TwoWay}" />
```

### 3. 回车与输入事件监听

在搜索框或即时输入场景中，可监听 `Enter` 和 `TextChanged` 事件：

```xml
<rizui:RizText Placeholder="输入关键词按回车搜索..."
               Enter="OnSearchEnter"
               TextChanged="OnInputChanged" />
```

```csharp
private void OnSearchEnter(object sender, string query)
{
    System.Diagnostics.Debug.WriteLine($"用户按下回车提交搜索: {query}");
}

private void OnInputChanged(object sender, string text)
{
    System.Diagnostics.Debug.WriteLine($"当前输入实时内容: {text}");
}
```

### 4. 自定义聚焦高亮色 (`Color`)

当输入框获得焦点时，边框会高亮为指定的主题色：

```xml
<rizui:RizText Placeholder="聚焦呈现初音绿高亮边框"
               Color="#39C5BB" />
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Text` | `string` | `""` | 当前输入框文本内容（支持双向绑定 `Mode=TwoWay`） |
| `Placeholder` | `string` | `""` | 未输入内容时展示的占位提示文字 |
| `Plaintext` | `bool` | `false` | 是否启用多行纯文本编辑模式（为 `True` 时支持换行与纵向滚动） |
| `IsReadOnly` | `bool` | `false` | 是否处于只读状态（可选中复制但不可更改内容） |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 聚焦时的边框高亮主题色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `TextChanged` | `(object sender, string text)` | 当输入文本内容发生变化时即时触发 |
| `Enter` | `(object sender, string text)` | 在单行输入框中按下回车键（Enter）时触发，传递当前文本 |


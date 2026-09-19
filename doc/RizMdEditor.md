# RizMdEditor Markdown 编辑器

`RizMdEditor` 是功能完备的轻量级 Markdown 编辑与渲染组件。内置常用富文本快捷工具栏、平滑平移动画的「编辑/预览」双栏切换、跨平台语法高亮、表格与清单渲染，并可作为只读 Markdown 查看器独立使用。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 基础用法

```xml
<rizui:RizMdEditor HeightText="380px"
                   Placeholder="在此输入 Markdown 文案..."
                   Value="{x:Bind ViewModel.ArticleContent, Mode=TwoWay}" />
```

### 2. 只读渲染模式 (`IsReadOnly`)

当 `IsReadOnly="True"` 时，组件会自动隐藏顶端快捷工具栏和编辑输入框，仅保留优雅排版的渲染预览视图，适合用于文档页、更新日志、公告展示等场景：

```xml
<rizui:RizMdEditor IsReadOnly="True"
                   HeightText="450px"
                   Value="{x:Bind ViewModel.ChangelogMarkdown}" />
```

### 3. 支持的 Markdown 语法特性

| 语法类型 | 示例语法 | 预览呈现效果 |
| :--- | :--- | :--- |
| **标题** | `# H1`, `## H2`, `### H3` | 阶梯字号标题，H1 附带底部细分隔线 |
| **粗体** | `**粗体文字**` 或 `__粗体__` | 高对比度加粗标题色文字 |
| **斜体** | `*斜体文字*` 或 `_斜体_` | 倾斜字体展示 |
| **粗斜体** | `***粗斜体文本***` | 同时具备加粗与倾斜特征 |
| **删除线** | `~~删除的文本~~` | 次要灰度 + 水平穿线（在 Uno Skia 桌面端原生完美渲染） |
| **行内代码** | `` `const x = 10;` `` | 等宽洋红/粉色 Cascadia Code 胶囊字体 |
| **代码块** | ` ```csharp ... ``` ` | 自动内嵌 `RizCode` 组件，支持语言标头与一键复制 |
| **任务清单** | `- [ ] 待办` / `- [x] 已完成` | 渲染为已选/未选复选框图形 |
| **无序/有序列表** | `- 列表项` / `1. 第一步` | 带前缀指示点或编号的整齐段落 |
| **引用块** | `> 这是一段引用文本` | 带有强调色左边框和微弱底色的引用卡片 |
| **表格** | 包含 `| 表头 \|` 与 `| --- \|` 分隔 | 圆角边框、表头主题色衬底、交替边线的数据表格 |
| **超链接** | `[链接描述](https://example.com)` | 强调色文字并带下划线 |

### 4. 预览字体设置 (`PreviewFontFamily`)

默认配置跨平台高品质字体族：`"Segoe UI, -apple-system, BlinkMacSystemFont, Microsoft YaHei, PingFang SC, sans-serif"`。如需特殊排版（例如中英文混排、印刷级字体），可直接指定：

```xml
<rizui:RizMdEditor PreviewFontFamily="Consolas, Microsoft YaHei"
                   Value="{x:Bind MarkdownCode}" />
```

### 5. 监听内容变更

```xml
<rizui:RizMdEditor ValueChanged="OnMarkdownChanged" />
```

```csharp
private void OnMarkdownChanged(object sender, string markdownText)
{
    System.Diagnostics.Debug.WriteLine($"Markdown 字符数: {markdownText.Length}");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Value` | `string` | `""` | Markdown 源码文本（支持双向绑定 `Mode=TwoWay`） |
| `Placeholder` | `string` | `"在此输入…"` | 编辑区域未输入内容时的占位提示文字 |
| `IsReadOnly` | `bool` | `false` | 是否为只读状态（为 `True` 时隐藏工具栏与编辑框，仅呈现富文本渲染预览） |
| `HeightText` | `string` | `"320px"` | 编辑器整体高度（支持如 `"360px"`、`"500px"` 或 `"auto"`） |
| `PreviewFontFamily` | `FontFamily` | `Segoe UI...` | 富文本渲染预览区域所采用的排版字体族，突破单一字重限制以确保粗斜体字形完整呈现 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 工具栏激活按钮、超链接、引用块边框的主题色，留空跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `ValueChanged` | `(object sender, string value)` | 当用户在编辑区域键入或工具栏修改内容时实时触发 |


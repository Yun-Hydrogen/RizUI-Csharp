# RizCode 代码块展示

`RizCode` 是用于呈现单行行内代码或多行大代码块的语法展示组件。内置 22 种编程语言关键字词法高亮、代码块头部语言标签显示、一键复制到剪贴板以及最大高度限制与滚动。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 行内代码 (`Block="False"`)

默认情况下呈现为紧凑的行内代码胶囊：

```xml
<TextBlock>
    请先在终端运行
    <rizui:RizCode Code="dotnet build -c Release" />
    完成编译。
</TextBlock>
```

### 2. 大代码块 (`Block="True"`)

开启 `Block="True"` 模式，将呈现完整的代码块容器，包含顶部标头（语言标签 + 复制代码按钮）以及内容展示区：

```xml
<rizui:RizCode Block="True"
               Lang="csharp"
               Code="public void SayHello(string name)&#x0a;{&#x0a;    Console.WriteLine($&quot;Hello, {name}!&quot;);&#x0a;}" />
```

### 3. 支持的语法高亮语言 (`Lang`)

`Lang` 属性支持主流主流编程与标记语言，大小写不敏感且支持常见别名：

| 语言类别 | `Lang` 传值 |
| :--- | :--- |
| **.NET** | `cs` / `csharp` / `dotnet` / `fsharp` |
| **Web 前端** | `html` / `xml` / `js` / `javascript` / `ts` / `typescript` / `css` / `vue` |
| **系统级语言** | `c` / `cpp` / `c++` / `rust` / `go` / `java` / `kotlin` / `swift` |
| **脚本与后端** | `python` / `py` / `bash` / `sh` / `shell` / `powershell` / `php` |
| **数据与配置** | `json` / `yaml` / `yml` / `sql` / `markdown` / `md` |

### 4. 高度限制与滚动 (`HeightText`)

当代码行数较多时，可设置 `HeightText`（如 `"180px"`、`"240px"`）限制高度，内容将自动提供纵向平滑滚动条：

```xml
<rizui:RizCode Block="True"
               Lang="json"
               HeightText="160px"
               Code="{x:Bind AppConfigJson}" />
```

### 5. 监听复制成功事件

```xml
<rizui:RizCode Block="True"
               Code="{x:Bind SnippetCode}"
               Copied="OnCodeCopied" />
```

```csharp
private void OnCodeCopied(object sender, EventArgs e)
{
    System.Diagnostics.Debug.WriteLine("用户成功将代码复制到了系统剪贴板！");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Code` | `string` | `""` | 要显示的代码文本内容（XAML 默认内容属性） |
| `Block` | `bool` | `false` | 是否为大代码块模式（为 `True` 时提供多行展示、语言标头及复制按钮） |
| `Lang` | `string` | `""` | 代码语言标识（如 `cs`、`js`、`python`、`sql`、`json` 等） |
| `HeightText` | `string` | `""` | 代码块最大高度限制（如 `"160px"`、`"220px"`），超出则纵向滚动 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 边框与复制按钮悬浮高亮色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `Copied` | `(object sender, EventArgs e)` | 当用户点击代码块右上角复制按钮成功写入剪贴板时触发 |


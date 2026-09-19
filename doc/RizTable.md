# RizTable 数据表格

`RizTable` 是用于结构化二维数据展示与交互式编辑的数据表格组件。支持只读展示、直接编辑单元格内容、动态增删行列、最大行列数约束以及数据变更通知。

---

## 命名空间

```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

---

## 代码示例

### 1. 只读数据展示 (`IsReadOnly="True"`)

```xml
<rizui:RizTable x:Name="ServerStatusTable"
                IsReadOnly="True" />
```

```csharp
using System.Collections.ObjectModel;

ServerStatusTable.Headers = new ObservableCollection<string>
{
    "节点名称", "网络协议", "延迟 (ms)", "运行负载"
};

ServerStatusTable.Rows = new ObservableCollection<ObservableCollection<string>>
{
    new() { "CN-Hangzhou-01", "TCP/TLS", "12", "42%" },
    new() { "CN-Beijing-02",  "UDP/QUIC", "18", "65%" },
    new() { "US-West-01",     "TCP/TLS", "135", "28%" }
};
```

### 2. 交互式可编辑表格

默认 `IsReadOnly="False"` 时，表格进入交互编辑模式：
- 用户可点击任意单元格直接修改文本内容；
- 底部与右侧自动提供「+ 添加行」与「+ 添加列」交互按钮；
- 悬浮在行或列标头时可删除行/列。

```xml
<rizui:RizTable x:Name="EditableTable"
                MaxRows="10"
                MaxColumns="6"
                DataChanged="OnTableDataChanged" />
```

### 3. 限制最大增添行列数 (`MaxRows` / `MaxColumns`)

可配置防止用户在编辑模式下无限扩增：

```xml
<rizui:RizTable Headers="{x:Bind TableHeaders}"
                Rows="{x:Bind TableRows}"
                MaxRows="8"
                MaxColumns="5" />
```

### 4. 监听表格数据变动

```csharp
private void OnTableDataChanged(object sender, EventArgs e)
{
    System.Diagnostics.Debug.WriteLine("用户编辑了表格内容或增删了行列！");
}
```

---

## 属性说明

### 私有属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `IsReadOnly` | `bool` | `false` | 是否为只读状态。为 `False` 时支持单元格实时编辑与行列增删 |
| `Headers` | `IList<string>` | `null` | 表头标题文本集合 |
| `Rows` | `IList<ObservableCollection<string>>` | `null` | 表格二维行数据集合（每行为字符串集合） |
| `MaxRows` | `int` | `0` | 编辑模式下允许添加的最大行数限制（`0` 表示不限） |
| `MaxColumns` | `int` | `0` | 编辑模式下允许添加的最大列数限制（`0` 表示不限） |
| `RowCount` | `int` | `0` | 显式指定行数，大于 0 时自动进行补齐或截断 |
| `ColumnCount` | `int` | `0` | 显式指定列数，大于 0 时自动进行补齐或截断 |

### 公共属性

| 属性名 | 类型 | 默认值 | 说明 |
| :--- | :--- | :--- | :--- |
| `Color` | `string` | `""` | 表头底色衬托、聚焦高亮的主题色，留空则跟随全局 `--rizui_themecolor` |
| `Theme` | `string` | `"auto"` | 明暗主题模式：`"auto"` 跟随系统 / `"dark"` 强制深色 / `"light"` 强制浅色 |

---

## 事件

| 事件名 | 参数 | 描述 |
| :--- | :--- | :--- |
| `DataChanged` | `(object sender, EventArgs e)` | 当用户编辑了单元格文本、添加或删除了行/列时触发 |


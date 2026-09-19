using System.Collections.ObjectModel;
using RizUI.Uwp.Controls;

namespace RizUI.Demo;

/// <summary>
/// Demo 页面属性列表表格初始化辅助类。
/// </summary>
public static class DemoTableHelper
{
    private static readonly ObservableCollection<string> Headers = new() { "属性", "类型", "默认值", "说明" };

    /// <summary>初始化组件私有属性表。</summary>
    public static void SetPrivateProps(RizTable table, ObservableCollection<ObservableCollection<string>> rows)
    {
        table.Headers = new ObservableCollection<string>(Headers);
        table.Rows = rows;
    }

    /// <summary>
    /// 初始化公共属性表（包含 Theme 和可选的 Color）。
    /// </summary>
    public static void SetCommonProps(RizTable table, bool hasColor = true, string? colorDesc = null, string colorDefault = "\"\"")
    {
        table.Headers = new ObservableCollection<string>(Headers);
        var rows = new ObservableCollection<ObservableCollection<string>>();
        if (hasColor)
        {
            rows.Add(new ObservableCollection<string>
            {
                "Color", "string", colorDefault, colorDesc ?? "自定义主题色，空则跟随全局 --rizui_themecolor"
            });
        }
        rows.Add(new ObservableCollection<string>
        {
            "Theme", "string", "\"auto\"", "Dark 强制暗色 / Light 强制亮色 / auto 跟随系统"
        });
        table.Rows = rows;
    }
}


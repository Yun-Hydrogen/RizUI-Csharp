# RizUI (C# / Uno Platform)

一套面向 **Uno Platform (.NET 10 / WinUI 3 / Skia)** 的轻量、精致、高性能跨平台原生 UI 组件库。

---

## 引入依赖

通过 .NET CLI 命令行：
```bash
dotnet add package RizUI.Uwp
```
或者在项目 `.csproj` 中添加：
```xml
<PackageReference Include="RizUI.Uwp" Version="0.1.0" />
```

---

## 快速使用

在 XAML 中引入命名空间：
```xml
xmlns:rizui="using:RizUI.Uwp.Controls"
```

编写常用控件：
```xml
<StackPanel Spacing="12">
    <!-- 按钮 -->
    <rizui:RizButton Text="主色按钮" Primary="True" />

    <!-- 卡片容器 -->
    <rizui:RizCard Title="系统设置" Icon="fa-solid fa-gear">
        <rizui:RizCfgRow Label="自动同步">
            <rizui:RizSwitch IsOn="True" />
        </rizui:RizCfgRow>
    </rizui:RizCard>
</StackPanel>
```

---

## 平台支持

- Windows（WinUI 3 / Skia Desktop）
- macOS / Linux（Skia Desktop）
- iOS / Android / WebAssembly（跨平台规划与适配中）

---

## 开源协议

本项目采用 **AGPL-3.0** 协议开源。任何在业务中引入该组件库的衍生应用均须遵循 AGPL-3.0 要求对用户开源。如需在商业闭源应用中使用，请获取商业授权。

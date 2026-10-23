[English](README.md) | [简体中文](README.zh-CN.md)

# Shared

共享 C# 游戏逻辑、资源解析、输入支持，以及 D3D11、Vulkan、D3D12 原生渲染器。托管项目入口为 `Shared.slnx`；Unity 与 Godot 使用其编译输出。

本仓库是工作区中的独立子模块，默认放在 `Shared/`，与 Unity、Godot、Tools 相邻。桌面准备目标为 Windows x64、Linux x64 和 macOS x64，需要 PowerShell 7 与 .NET SDK 10。原生渲染器另需 CMake 3.24+ 及系统对应的 C/C++ 编译器：Windows 使用 Visual Studio 桌面工具链和 Windows SDK，Linux 使用 GCC／Clang，macOS 使用 Xcode Command Line Tools。游戏嵌入资源需从使用者有权使用的安装中恢复。

Windows 提供 D3D11、Vulkan 和 D3D12；Linux 使用 Vulkan；macOS 通过 MoltenVK 使用 Vulkan。需要提供对应系统的原生依赖，包括 FMOD 1.10.14。Apple Silicon 使用 Rosetta 运行 x64 宿主和依赖。

在父级工作区按 `Tools/README.md` 完成准备，或运行 `pwsh ./Tools/Prepare.ps1 -CelesteDirectory 'D:/Games/Celeste' -Targets Managed -CompileOnly`。需要 Helper 模块时添加 `-IncludeHelpers`。

许可范围见 [NOTICE.md](NOTICE.md) 和 [LICENSES/components.json](LICENSES/components.json)。

自有贡献采用 MPL-2.0，见 [LICENSE](LICENSE) 和 [NOTICE.md](NOTICE.md)。

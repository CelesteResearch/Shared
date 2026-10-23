[English](README.md) | [简体中文](README.zh-CN.md)

# Shared

Shared C# game logic, resource decoding, input support, and native D3D11, Vulkan and D3D12 renderers. `Shared.slnx` builds the managed projects consumed by Unity and Godot.

Place this independent repository at `Shared/`, beside the selected host and Tools repositories. Desktop preparation targets Windows x64, Linux x64 and macOS x64, using PowerShell 7 and .NET SDK 10. Native renderers require CMake 3.24+ and the platform C/C++ compiler. Windows uses Visual Studio desktop tools and the Windows SDK; Linux uses GCC/Clang; macOS uses Xcode Command Line Tools. Restore embedded inputs from a game installation you are entitled to use.

Windows provides D3D11, Vulkan and D3D12. Linux uses Vulkan; macOS uses Vulkan through MoltenVK. Supply the corresponding native dependencies, including FMOD 1.10.14. On Apple Silicon, use x64 hosts and dependencies through Rosetta.

Follow the adjacent Tools repository's README. From the workspace root, managed-only preparation is:

```powershell
pwsh ./Tools/Prepare.ps1 -CelesteDirectory 'D:/Games/Celeste' -Targets Managed -CompileOnly
```

Enable Helper modules with `-IncludeHelpers`.

See [NOTICE.md](NOTICE.md) and [LICENSES/components.json](LICENSES/components.json) for license boundaries and third-party terms.

Original contributions are licensed under MPL-2.0; see [LICENSE](LICENSE) and [NOTICE.md](NOTICE.md).

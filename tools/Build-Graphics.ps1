[CmdletBinding()]
param(
    [ValidateSet('Direct3D11', 'Vulkan', 'Direct3D12')][string[]]$Backend,
    [ValidateSet('Debug', 'Release')][string]$Configuration = 'Release',
    [string]$BuildDirectory,
    [string]$OutputDirectory,
    [string]$RuntimeIdentifier,
    [string]$CMakeExecutable = 'cmake'
)

$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$platform = if ($IsWindows) { 'win' } elseif ($IsLinux) { 'linux' } elseif ($IsMacOS) { 'osx' } else { throw 'Unsupported native build platform.' }
$architecture = [Runtime.InteropServices.RuntimeInformation]::ProcessArchitecture.ToString().ToLowerInvariant()
if (-not $RuntimeIdentifier) { $RuntimeIdentifier = "$platform-$architecture" }
if ($RuntimeIdentifier -notin @('win-x64', 'linux-x64', 'linux-arm64', 'osx-x64', 'osx-arm64')) { throw "Unsupported runtime identifier: $RuntimeIdentifier" }
if (-not $RuntimeIdentifier.StartsWith("$platform-")) { throw 'Build native libraries on their target operating system.' }
if ($RuntimeIdentifier -ne "$platform-$architecture" -and $platform -ne 'osx') { throw 'Use a compiler/process matching the requested native architecture.' }
if (-not $Backend) { $Backend = if ($IsWindows) { @('Direct3D11', 'Vulkan', 'Direct3D12') } else { @('Vulkan') } }
if (-not $IsWindows -and ($Backend -contains 'Direct3D11' -or $Backend -contains 'Direct3D12')) { throw 'Direct3D backends require Windows.' }
if (-not $BuildDirectory) { $BuildDirectory = Join-Path $root "artifacts/native/Graphics/$RuntimeIdentifier" }
if (-not $OutputDirectory) { $OutputDirectory = Join-Path $root "artifacts/runtime/$RuntimeIdentifier" }
$direct3D11 = if ($Backend -contains 'Direct3D11') { 'ON' } else { 'OFF' }
$direct3D12 = if ($Backend -contains 'Direct3D12') { 'ON' } else { 'OFF' }
$vulkan = if ($Backend -contains 'Vulkan') { 'ON' } else { 'OFF' }
$configure = @('-S', (Join-Path $root 'native'), '-B', $BuildDirectory,
    "-DCELESTE_BUILD_DIRECT3D11=$direct3D11", "-DCELESTE_BUILD_VULKAN=$vulkan", "-DCELESTE_BUILD_DIRECT3D12=$direct3D12",
    '-DCELESTE_BUILD_EFFECTS=ON', "-DCMAKE_BUILD_TYPE=$Configuration")
if ($IsWindows) { $configure += @('-A', 'x64') }
if ($IsMacOS) { $configure += '-DCMAKE_OSX_ARCHITECTURES=' + $(if ($RuntimeIdentifier.EndsWith('-arm64')) { 'arm64' } else { 'x86_64' }) }
& $CMakeExecutable @configure
if ($LASTEXITCODE -ne 0) { throw 'Shared graphics configuration failed.' }
& $CMakeExecutable --build $BuildDirectory --config $Configuration --parallel 4
if ($LASTEXITCODE -ne 0) { throw 'Shared graphics build failed.' }

$libraries = [ordered]@{ CelesteGraphicsEffects = 'Effects' }
if ($direct3D12 -eq 'ON') { $libraries.CelesteGraphicsDirect3D12 = 'Graphics/Direct3D12' }
if ($direct3D11 -eq 'ON') { $libraries.CelesteGraphicsD3D11 = 'Graphics/Direct3D11' }
if ($vulkan -eq 'ON') { $libraries.CelesteGraphicsVulkan = 'Graphics/Vulkan' }
[IO.Directory]::CreateDirectory($OutputDirectory) | Out-Null
foreach ($entry in $libraries.GetEnumerator()) {
    $filename = if ($IsWindows) { "$($entry.Key).dll" } elseif ($IsMacOS) { "lib$($entry.Key).dylib" } else { "lib$($entry.Key).so" }
    $source = @(
        Join-Path $BuildDirectory "$($entry.Value)/$Configuration/$filename"
        Join-Path $BuildDirectory "$($entry.Value)/$filename"
    ) | Where-Object { Test-Path -LiteralPath $_ -PathType Leaf } | Select-Object -First 1
    if (-not $source) { throw "Built native library missing: $filename" }
    $destination = Join-Path $OutputDirectory $filename
    Copy-Item -LiteralPath $source -Destination $destination -Force
    if ($IsWindows) {
        $importLibrary = [IO.Path]::ChangeExtension($source, '.lib')
        Copy-Item -LiteralPath $importLibrary -Destination ([IO.Path]::ChangeExtension($destination, '.lib')) -Force
    }
    Get-FileHash -LiteralPath $destination -Algorithm SHA256
}

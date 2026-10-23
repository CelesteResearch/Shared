[CmdletBinding()]
param(
    [string]$ProjectDirectory = (Split-Path $PSScriptRoot -Parent),
    [string]$BuildDirectory,
    [string]$PluginDirectory,
    [ValidateSet('Debug', 'Release')][string]$Configuration = 'Release'
)
$ErrorActionPreference = 'Stop'
$root = [IO.Path]::GetFullPath($ProjectDirectory)
$arguments = @{ Backend = @(); Configuration = $Configuration }
if ($BuildDirectory) { $arguments.BuildDirectory = $BuildDirectory }
if ($PluginDirectory) { $arguments.OutputDirectory = $PluginDirectory }
& (Join-Path $root 'tools/Build-Graphics.ps1') @arguments

namespace Celeste.Graphics.Vulkan.Submission;

public enum VulkanWindowSurfaceKind : uint
{
    Win32 = 0,
    Xlib = 1,
    Wayland = 2,
    MetalView = 3
}

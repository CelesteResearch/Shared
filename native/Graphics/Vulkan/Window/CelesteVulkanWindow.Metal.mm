#import <Cocoa/Cocoa.h>
#import <QuartzCore/CAMetalLayer.h>
#include <cstdint>
#include <stdexcept>

@interface CelesteVulkanSurfaceView : NSView
@end
@implementation CelesteVulkanSurfaceView
- (NSView*)hitTest:(NSPoint)point
{
    return nil;
}
@end

void* CelesteCreateMetalSurfaceView(void* nativeView, uint32_t width, uint32_t height)
{
    if (![NSThread isMainThread])
        throw std::logic_error("Metal surface views must be created on the main thread");
    NSView* parent = static_cast<NSView*>(nativeView);
    if (![parent isKindOfClass:[NSView class]])
        throw std::invalid_argument("A live NSView is required for Vulkan presentation");
    CelesteVulkanSurfaceView* view = [[CelesteVulkanSurfaceView alloc] initWithFrame:parent.bounds];
    view.autoresizingMask = NSViewWidthSizable | NSViewHeightSizable;
    view.wantsLayer = YES;
    CAMetalLayer* layer = [CAMetalLayer layer];
    layer.opaque = YES;
    layer.contentsScale = parent.window ? parent.window.backingScaleFactor : 1.0;
    layer.drawableSize = CGSizeMake(width, height);
    view.layer = layer;
    [parent addSubview:view];
    return view;
}

const void* CelesteMetalSurfaceLayer(void* surface)
{
    return static_cast<NSView*>(surface).layer;
}

void CelesteMetalSurfaceDrawableSize(void* surface, uint32_t* width, uint32_t* height)
{
    NSView* view = static_cast<NSView*>(surface);
    CGFloat scale = view.window ? view.window.backingScaleFactor : 1.0;
    *width = static_cast<uint32_t>(view.bounds.size.width * scale);
    *height = static_cast<uint32_t>(view.bounds.size.height * scale);
    CAMetalLayer* layer = static_cast<CAMetalLayer*>(view.layer);
    layer.contentsScale = scale;
    layer.drawableSize = CGSizeMake(*width, *height);
}

void CelesteDestroyMetalSurfaceView(void* surface) noexcept
{
    NSView* view = static_cast<NSView*>(surface);
    [view removeFromSuperview];
    [view release];
}

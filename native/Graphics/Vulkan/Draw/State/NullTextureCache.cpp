#include "NullTextureCache.h"
#include "mojoshader.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    uint32_t NullTextureCache::Dimension(int type)
    {
        switch (type)
        {
        case MOJOSHADER_SAMPLER_2D:
            return CelesteGraphicsTexture2D;
        case MOJOSHADER_SAMPLER_VOLUME:
            return CelesteGraphicsTexture3D;
        case MOJOSHADER_SAMPLER_CUBE:
            return CelesteGraphicsTextureCube;
        default:
            throw std::invalid_argument("Unsupported shader sampler dimension");
        }
    }
    const std::shared_ptr<TextureImage>& NullTextureCache::Get(int type)
    {
        const auto dimension = Dimension(type);
        auto& image = images[dimension];
        if (!image)
        {
            CelesteGraphicsTextureInfo info{SourceSurfaceFormat_Color, dimension, 1, 1, 1, 1, 0};
            image = std::make_shared<TextureImage>(context, info);
        }
        return image;
    }
}

#include "Direct3D12Effects.h"
#include "CelesteGraphicsPacket.h"
#include "Direct3D12DrawContext.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    void ApplyEffect(CelesteGraphicsPacket* packet, void* effect, uint32_t pass, void* changes)
    {
        if (!packet)
            throw std::invalid_argument("Packet is null");
        packet->RequireOpen();
        auto& draw = GetDrawContext(packet->Owner());
        if (!draw.effects)
            draw.effects = std::make_shared<Direct3D12EffectCache>();
        GetDrawState(*packet).effect = draw.effects->Apply(effect, pass, changes);
    }
    std::shared_ptr<const Direct3D12EffectProgram> PrepareShadersForLayout(const Direct3D12EffectSnapshot& snapshot,
                                                                           const D3D12_INPUT_ELEMENT_DESC* elements,
                                                                           size_t count)
    {
        auto cache = snapshot.cache.lock();
        if (!cache)
            throw std::logic_error("Effect owner is already released");
        return cache->Prepare(snapshot, elements, count);
    }
}

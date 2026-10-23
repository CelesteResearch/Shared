#include "Direct3D12ResourceApi.h"
#include "CelesteGraphicsReadback.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    int32_t GetReadbackStatus(CelesteGraphicsReadback* value)
    {
        if (!value)
            throw std::invalid_argument("Readback handle is null");
        if (value->unchanged)
            return 2;
        if (!value->completion->Ready())
            return 0;
        if (!value->copied)
        {
            if (value->footprint)
                value->footprint->Unpack(value->bytes.data(), value->bytes.size(), value->staging->Map());
            else
                value->staging->Read(0, value->bytes.data(), value->bytes.size());
            value->copied = true;
            value->staging.reset();
        }
        return 1;
    }
    void GetReadbackBytes(CelesteGraphicsReadback* value, const void** bytes, uint32_t* count)
    {
        if (bytes)
            *bytes = nullptr;
        if (count)
            *count = 0;
        if (!bytes || !count)
            throw std::invalid_argument("Readback output is null");
        const int32_t status = GetReadbackStatus(value);
        if (status == 0)
            throw std::logic_error("Readback is pending");
        if (status == 2)
            return;
        *bytes = value->bytes.data();
        *count = static_cast<uint32_t>(value->bytes.size());
    }
    void ReleaseReadback(CelesteGraphicsReadback* value) noexcept
    {
        delete value;
    }
}

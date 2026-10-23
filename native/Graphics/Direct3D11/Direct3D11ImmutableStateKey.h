#pragma once
#include <array>
#include <cstddef>
#include <cstdint>
#include <cstring>

template <size_t Size> using SourceImmutableStateKey = std::array<uint8_t, Size>;
template <size_t Size> struct SourceImmutableStateKeyHash
{
    size_t operator()(const SourceImmutableStateKey<Size>& key) const noexcept
    {
        size_t hash = static_cast<size_t>(14695981039346656037ull);
        for (uint8_t value : key)
            hash = (hash ^ value) * static_cast<size_t>(1099511628211ull);
        return hash;
    }
};
template <size_t Size, class T>
inline void SourceStateKeyField(SourceImmutableStateKey<Size>& key, size_t& offset, const T& value)
{
    std::memcpy(key.data() + offset, &value, sizeof(value));
    offset += sizeof(value);
}

// Wide descriptors are already encoded field by field; no descriptor padding enters this hash.
template <size_t Size> struct SourceImmutableStateWideKeyHash
{
    size_t operator()(const SourceImmutableStateKey<Size>& key) const noexcept
    {
        uint64_t hash = 14695981039346656037ull;
        size_t offset = 0;
        for (; offset + sizeof(uint64_t) <= Size; offset += sizeof(uint64_t))
        {
            uint64_t value;
            std::memcpy(&value, key.data() + offset, sizeof(value));
            hash = (hash ^ value) * 1099511628211ull;
        }
        for (; offset < Size; ++offset)
            hash = (hash ^ key[offset]) * 1099511628211ull;
        return static_cast<size_t>(hash);
    }
};

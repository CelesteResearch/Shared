#pragma once
#include "DeviceContext.h"
#include <vector>
namespace Celeste::Graphics::Direct3D12
{
    class CommandLease
    {
        std::shared_ptr<DeviceContext> context;
        Microsoft::WRL::ComPtr<ID3D12CommandAllocator> allocator;
        Microsoft::WRL::ComPtr<ID3D12GraphicsCommandList> commands;
        std::vector<std::shared_ptr<void>> retained;
        bool closed = false;

      public:
        explicit CommandLease(std::shared_ptr<DeviceContext> context);
        CommandLease(const CommandLease&) = delete;
        CommandLease& operator=(const CommandLease&) = delete;
        ID3D12GraphicsCommandList* List() const noexcept
        {
            return commands.Get();
        }
        const DeviceContext& Context() const noexcept
        {
            return *context;
        }
        template <class T> void Retain(std::shared_ptr<T> resource)
        {
            retained.emplace_back(std::move(resource));
        }
        void Close();

      private:
        friend class SubmissionQueue;
        void Recycle();
    };
}

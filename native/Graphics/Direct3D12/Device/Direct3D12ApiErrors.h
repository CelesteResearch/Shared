#pragma once
#include <string>
#include <exception>
namespace Celeste::Graphics::Direct3D12
{
    extern thread_local std::string lastError;
    template <class F> int Invoke(F&& action) noexcept
    {
        try
        {
            action();
            return 1;
        }
        catch (const std::exception& error)
        {
            lastError = error.what();
        }
        catch (...)
        {
            lastError = "Unknown D3D12 exception";
        }
        return 0;
    }
    template <auto Function> struct CheckedFunction;
    template <class... Args, void (*Function)(Args...)> struct CheckedFunction<Function>
    {
        static int32_t __cdecl Call(Args... args) noexcept
        {
            return Invoke([&] { Function(args...); });
        }
    };
}

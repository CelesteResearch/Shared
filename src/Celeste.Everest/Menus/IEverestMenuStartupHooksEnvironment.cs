using System;

namespace Celeste.Everest.Menus
{
    public interface IEverestMenuStartupHooksEnvironment
    {
        bool InvokeSourceOobeStart(Func<bool> original);
        bool InvokeSourceTitleStart(Func<bool> installed, Func<bool> original);
    }
}

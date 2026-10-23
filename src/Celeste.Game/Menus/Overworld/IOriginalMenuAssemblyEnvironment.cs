using System;

namespace Celeste.Game.Menus.Overworld
{
    public interface IOriginalMenuAssemblyEnvironment
    {
        // Selected original PE/menu inheritance order, independent of physical DLL layout.
        Type[] GetMenuTypes();
    }
}

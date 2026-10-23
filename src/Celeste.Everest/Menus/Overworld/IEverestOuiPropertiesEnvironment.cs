using System;
using System.Collections.Generic;

namespace Celeste.Everest.Menus.Overworld
{
    public interface IEverestOuiPropertiesEnvironment
    {
        IEnumerable<OuiPropertiesAttribute> GetDeclaredOuiProperties(Type actualType);
    }
}

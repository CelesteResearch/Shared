using System;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Menus.Overworld
{
    public partial class OverworldSequence
    {
        // The runtime Type must be the sole registered actual type. Its ordered source
        // assembly enumeration remains mandatory; this method does not supply a type universe.
        protected OuiState ConstructOui(Type actualType)
        {
            var constructor = actualType.GetConstructor(new[] { typeof(ISourceEngineContext) });
            if (constructor == null)
                throw new MissingMethodException(actualType.FullName, ".ctor(ISourceEngineContext)");
            return (OuiState)constructor.Invoke(new object[] { EngineContext });
        }
    }
}

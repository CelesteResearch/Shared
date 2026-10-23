using Celeste.Input.Runtime;
using Celeste.Input.Bindings;
using Celeste.Graphics.Display;
using Celeste.Graphics.Content.Atlas;
using Celeste.Core.Mathematics;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Controls.Source
{
    public interface IOriginalGameInputSourceEnvironment : ISourceMInputEnvironment, ISourceVectorEnvironment
    {
        IOriginalGameInputSourceSettings InputSourceSettings { get; }
        OriginalSaveDataState CurrentSave { get; }
        AtlasData GuiAtlas { get; }
    }
}

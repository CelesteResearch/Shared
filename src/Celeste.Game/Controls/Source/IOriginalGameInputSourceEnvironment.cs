using Celeste.Core.Mathematics;
using Celeste.Game.Save.Data;
using Celeste.Graphics.Content.Atlas;
using Celeste.Input.Runtime;

namespace Celeste.Game.Controls.Source
{
    public interface IOriginalGameInputSourceEnvironment : ISourceMInputEnvironment, ISourceVectorEnvironment
    {
        IOriginalGameInputSourceSettings InputSourceSettings { get; }
        OriginalSaveDataState CurrentSave { get; }
        AtlasData GuiAtlas { get; }
    }
}

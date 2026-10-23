using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Save.Data;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Components.Talking
{
    public interface IOriginalTalkProcess
    {
        ISourceEngineContext EngineContext { get; }
        AtlasData GuiAtlas { get; }
        ActiveBitmapFont ActiveFont { get; }
        WigglerComponentPool WigglerPool { get; }
        ISourceEasingArithmetic EasingArithmetic { get; }
        ISourceExtremaArithmetic ExtremaArithmetic { get; }
        OriginalSaveDataState CurrentSave { get; }
        void PlayUiSound(string eventName);
    }
}

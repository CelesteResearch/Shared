using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Input.Gameplay;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Text;
using Celeste.Game.Save.Data;

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

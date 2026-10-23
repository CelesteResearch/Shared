using Celeste.Core.Scheduling;
using Celeste.Graphics.Text.RichText.Drawing;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceRichTextDrawProcess
    {
        float ISourceRichTextDrawProcess.RawTimeActive =>
            ((ISourceSceneClock)Frame.Scenes.CurrentScene).RawTimeActive;
    }
}

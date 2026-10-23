using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Presentation.Hud.Speedrun;
using Celeste.Game.Settings;
using Celeste.Simulation.Presentation.Hud.Speedrun;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Chapters.Flow
{
    public partial class OriginalAreaCompleteInfoState
    {
        private void DrawTime(ISourceRenderContext context, object owner, Vector2 position, string text,
            float scale = 1f)
            => global::Celeste.Game.Presentation.Hud.Speedrun.SpeedrunTimerState.DrawTimeSource(engine, context,
                owner, position, text, scale);

        public void Info(ISourceRenderContext context, object owner, float ease, string chapterTime,
            string fileTime, string chapterText, string version)
        {
            if (ease > 0f && (SpeedrunClockMode)((ISettingsContext)engine).Settings.SpeedrunClock !=
                SpeedrunClockMode.Off)
            {
                Vector2 at =
                    new Vector2(80f - 300f * (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ease)),
                        1000f);
                if ((SpeedrunClockMode)((ISettingsContext)engine).Settings.SpeedrunClock ==
                    SpeedrunClockMode.Chapter)
                    DrawTime(context, owner, at, chapterTime);
                else
                {
                    at.Y -= 16f;
                    DrawTime(context, owner, at, fileTime);
                    Text.ActiveFont.DrawOutline(context, owner, chapterText, at + new Vector2(0f, 40f),
                        new Vector2(0f, 1f),
                        Vector2.One * .6f, PackedColor.White, 2f, PackedColor.Black);
                    DrawTime(context, owner, at + new Vector2(Text.ActiveFont.Measure(chapterText).X * .6f + 8f, 40f),
                        chapterTime, .6f);
                }

                VersionNumberAndVariants(context, owner, version, ease, 1f);
            }

            global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                .Get<IOriginalAreaCompleteInfoHooksEnvironment>(engine)
                ?.AfterSourceAreaCompleteInfoRendered(context, owner, ease);
        }
    }
}

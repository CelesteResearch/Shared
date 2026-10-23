using Celeste.Core.Display;
using Celeste.Game.Settings;
using System.Numerics;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Presentation.Hud.Speedrun;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.Chapters.Flow
{
    public sealed class EverestAreaCompleteSequence : AreaCompleteSequence
    {
        private float buttonTimerDelay;
        private float buttonTimerEase;

        public EverestAreaCompleteSequence(ChapterCompletionSession session, XmlElement xml, AtlasData atlas,
            HiresSnowState snow, ISourceEngineContext engine, IInstalledAreaCompleteConstruction construction)
            : base(session, xml, atlas, snow, engine, construction)
        {
        }

        public override void Begin()
        {
            base.Begin();
            ((EverestAreaCompleteInfoState)Info).InitializeInstalled(false, Session);
            buttonTimerDelay = 2.2f;
            buttonTimerEase = 0f;
        }

        public override void End()
        {
            base.End();
            ((EverestAreaCompleteInfoState)Info).DisposeInstalled();
        }

        public override void Update()
        {
            base.Update();
            buttonTimerDelay -= EngineContext.DeltaTime;
            if (buttonTimerDelay <= 0f)
                buttonTimerEase = ScalarMath.Approach(buttonTimerEase, 1f, EngineContext.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
        }

        protected override void RenderUI(ISourceRenderContext context)
        {
            base.RenderUI(context);
            if (!(buttonTimerEase > 0f) || ((ISettingsContext)EngineContext).Settings.SpeedrunClock !=
                (int)SpeedrunClockMode.Off) return;
            var texture = Input.GuiButton(Input.MenuConfirm);
            Vector2 at = new Vector2(1860f - texture.Width, 1020f - texture.Height);
            float num = buttonTimerEase * buttonTimerEase;
            float num2 = .9f + buttonTimerEase * .1f;
            for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                if (i != 0 && j != 0)
                    SourceAtlasDrawing.DrawCentered(context, this, texture, at + new Vector2(i, j),
                        PackedColor.Black * num * num * num * num, Vector2.One * num2);
            SourceAtlasDrawing.DrawCentered(context, this, texture, at, PackedColor.White * num, Vector2.One * num2);
        }
    }
}

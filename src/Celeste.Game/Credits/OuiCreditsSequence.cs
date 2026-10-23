using Celeste.Core.Display;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Credits
{
    public class OuiCreditsSequence : OuiState
    {
        private readonly Vector2 onScreen = new Vector2(960f, 0f);
        private readonly Vector2 offScreen = new Vector2(3840f, 0f);
        private CreditsPresentation credits;
        private float vignetteAlpha;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public OuiCreditsSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Position = offScreen;
            Visible = false;
        }

        public override IEnumerator Enter(OuiState from)
        {
            Process.AudioSession.SetMusic("event:/music/menu/credits");
            Overworld.ShowConfirmUI = false;
            ((IOriginalCreditsProcessEnvironment)engine).CreditsProcess.BorderColor = PackedColor.Black;
            credits = new CreditsPresentation(engine);
            credits.Enabled = false;
            Visible = true;
            vignetteAlpha = 0f;
            for (float p = 0f; p < 1f; p += engine.Frame.DeltaTime * 4f)
            {
                Position = offScreen + (onScreen - offScreen)
                    * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }
        }

        public override IEnumerator Leave(OuiState next)
        {
            Process.AudioSession.Play("event:/ui/main/whoosh_large_out");
            Overworld.SetNormalMusic();
            Overworld.ShowConfirmUI = true;
            for (float p = 0f; p < 1f; p += engine.Frame.DeltaTime * 4f)
            {
                Position = onScreen + (offScreen - onScreen)
                    * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            Visible = false;
        }

        public override void Update()
        {
            if (Focused && (((IGameInputEnvironment)engine).Input[GameAction.MenuCancel].Pressed
                            || credits.BottomTimer > 3f))
                Overworld.Goto<MainMenuSequence>();
            if (credits != null)
            {
                credits.Update();
                credits.Enabled = Focused && Selected;
            }

            vignetteAlpha = ScalarMath.Approach(vignetteAlpha, Selected ? 1f : 0f,
                engine.Frame.DeltaTime * (Selected ? 1f : 4f),
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (vignetteAlpha > 0f)
            {
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f,
                    PackedColor.Black * vignetteAlpha * .4f);
                SourceAtlasDrawing.Draw(context, this,
                    ((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["vignette"],
                    Vector2.Zero, Vector2.Zero, PackedColor.White
                                                * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                                                    vignetteAlpha), 1f);
            }

            if (credits != null)
                credits.Render(context, Position);
        }
    }
}

using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Collectibles.Cassettes
{
    public class UnlockedBSideState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalGameTextProcess TextProcess => ((IOriginalGameTextEnvironment)engine).Text;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;


        public UnlockedBSideState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
        }

        private float alpha;

        private string text;

        private bool waitForKeyPress;

        private float timer;

        public override void Added(object scene)
        {
            base.Added(scene);
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            text = TextProcess.ActiveFont.Font.Get(TextProcess.ActiveFont.BaseSize)
                .AutoNewline(TextProcess.Dialog.Clean("UI_REMIX_UNLOCKED"), 900);
            Depth = -10000;
        }

        public IEnumerator EaseIn()
        {
            _ = Scene;
            while ((alpha += engine.DeltaTime / 0.5f) < 1f) yield return null;

            alpha = 1f;
            yield return 1.5f;
            waitForKeyPress = true;
        }

        public IEnumerator EaseOut()
        {
            waitForKeyPress = false;
            while ((alpha -= engine.DeltaTime / 0.5f) > 0f) yield return null;

            alpha = 0f;
            RemoveSelf();
        }

        public override void Update()
        {
            timer += engine.DeltaTime;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var num = Easing.CubeOut(alpha);
            var vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(1920f, 1080f), 2f) +
                         new Vector2(0f, 64f);
            var vector2 = Vector2.UnitY * 64f * (1f - num);
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * num * 0.8f);
            SourceAtlasDrawing.DrawJustified(context, this, Graphics.GuiAtlas["collectables/cassette"],
                vector - vector2 + new Vector2(0f, 32f), new(0.5f, 1f), PackedColor.White * num);
            TextProcess.ActiveFont.Draw(context, this, text, vector + vector2, new(0.5f, 0f), Vector2.One,
                PackedColor.White * num);
            if (waitForKeyPress)
                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["textboxbutton"],
                    new(1824f, 984 + (timer % 1f < 0.25f ? 6 : 0)), PackedColor.White);
        }
    }
}

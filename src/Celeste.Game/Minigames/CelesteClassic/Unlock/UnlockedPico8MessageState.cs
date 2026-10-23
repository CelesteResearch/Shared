using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Gui;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Input.Gameplay;
using Celeste.Scene.Entities;

namespace Celeste.Game.Minigames.CelesteClassic.Unlock
{
    public class UnlockedPico8MessageState : SceneEntityState
    {
        private float alpha;
        private string text;
        private bool waitForKeyPress;
        private float timer;
        private readonly Action callback;
        private readonly ISourceEngineContext engine;

        public UnlockedPico8MessageState(ISourceEngineContext engine, Action callback = null)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.callback = callback;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            text = ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Font.Get(
                    ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.BaseSize)
                .AutoNewline(((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("PICO8_UNLOCKED"), 900);
            Depth = -10000;
            Add(new SimulationCoroutine(engine, Routine()));
        }

        private IEnumerator Routine()
        {
            var level = Scene as OriginalLevelSceneRoot;
            level.PauseLock = true;
            level.Paused = true;
            while ((alpha += engine.DeltaTime / .5f) < 1f) yield return null;
            alpha = 1f;
            waitForKeyPress = true;
            while (!((ISourceGameInputEnvironment)engine).Input[GameAction.MenuConfirm].Pressed) yield return null;
            waitForKeyPress = false;
            while ((alpha -= engine.DeltaTime / .5f) > 0f) yield return null;
            alpha = 0f;
            level.PauseLock = false;
            level.Paused = false;
            RemoveSelf();
            if (callback != null) callback();
        }

        public override void Update()
        {
            timer += engine.DeltaTime;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var num = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(alpha);
            SourcePrimitiveDrawing.Rect((ISourceDrawScope)engine, -10f, -10f, 1940f, 1100f,
                PackedColor.Black * num * .8f);
            SourceAtlasDrawing.DrawJustified((ISourceDrawScope)engine,
                ((ISourceGuiAtlasResources)((ISourceGameGraphicsEnvironment)engine)
                    .GameGraphics).GuiAtlas["pico8"],
                GameRuntime.TargetCenter + new Vector2(0f, -64f * (1f - num) - 16f),
                new(.5f, 1f),
                PackedColor.White * num);
            var position = GameRuntime.TargetCenter + new Vector2(0f, 64f * (1f - num) + 16f);
            var vector = ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(text);
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this, text, position,
                new(.5f, 0f), Vector2.One, PackedColor.White * num);
            if (waitForKeyPress)
                SourceAtlasDrawing.DrawCentered((ISourceDrawScope)engine,
                    ((ISourceGuiAtlasResources)
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas["textboxbutton"],
                    GameRuntime.TargetCenter + new Vector2(vector.X / 2f + 32f,
                        vector.Y + 48f + (timer % 1f < .25f ? 6f : 0f)),
                    PackedColor.White);
        }
    }
}

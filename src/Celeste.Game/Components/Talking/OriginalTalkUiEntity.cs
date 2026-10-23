using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Bindings;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.UI.Dialogue.Textboxes;

namespace Celeste.Game.Components.Talking
{
    public class OriginalTalkUiEntity : SceneEntityState
    {
        public OriginalTalkComponent Handler;
        private bool highlighted;
        protected float slide;
        public float Slide => slide;
        protected float timer;
        protected WigglerComponent wiggler;
        protected float alpha = 1f;
        public ref float SourceAlpha => ref alpha;
        protected PackedColor lineColor = PackedColor.White;
        protected IOriginalTalkProcess Process => Handler.Process;

        protected OriginalGameInputProcess Input =>
            ((IOriginalGameInputProcessEnvironment)Process.EngineContext).InputSource;

        public bool Highlighted
        {
            get => highlighted;
            set
            {
                if ((highlighted != value) & Display)
                {
                    highlighted = value;
                    if (highlighted) Process.PlayUiSound(Handler.HoverUI.SfxIn);
                    else Process.PlayUiSound(Handler.HoverUI.SfxOut);
                    wiggler.Start();
                }
            }
        }

        public bool Display
        {
            get
            {
                if (!Handler.Enabled) return false;
                if (Scene == null) return false;
                if (((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<TextboxState>("Celeste.Textbox") !=
                    null)
                    return false;
                RoomPlayerSession player = ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (player == null || player.Machine.State == 11) return false;
                OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
                if (!level.FrozenOrPaused) return level.RetryPlayerCorpse == null;
                return false;
            }
        }

        public OriginalTalkUiEntity(OriginalTalkComponent handler)
            : base(((ISourceEntitySourceDataEnvironment)handler.Process.EngineContext).EntitySourceDataRegistration)
        {
            Handler = handler;
            AddTag(((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)Process.EngineContext).Tags
                   .HUD.Value |
                   ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)Process.EngineContext).Tags
                   .Persistent.Value);
            Add(wiggler = handler.Process.WigglerPool.Create(0.25f, 4f));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (Handler.Entity == null || SourceSceneCollision.FirstPoint<object>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.FakeWall",
                    ((ISourceEntityPosition)Handler.Entity).Position) != null)
                alpha = 0f;
        }

        public override void Update()
        {
            timer += Process.EngineContext.DeltaTime;
            slide = ScalarMath.Approach(slide, Display ? 1 : 0,
                Process.EngineContext.DeltaTime * 4f, Process.ExtremaArithmetic);
            if (alpha < 1f && Handler.Entity != null && SourceSceneCollision.FirstPoint<object>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.FakeWall",
                    ((ISourceEntityPosition)Handler.Entity).Position) == null)
                alpha = ScalarMath.Approach(alpha, 1f, 2f * Process.EngineContext.DeltaTime, Process.ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
            if (level.FrozenOrPaused || !(slide > 0f) || Handler.Entity == null) return;
            Vector2 camera = Vector2Geometry.Floor(level.Camera.Position);
            Vector2 at = ((ISourceEntityPosition)Handler.Entity).Position + Handler.DrawAt - camera;
            if (Process.CurrentSave != null && Process.CurrentSave.Assists.MirrorMode) at.X = 320f - at.X;
            at.X *= 6f;
            at.Y *= 6f;
            at.Y += (float)Math.Sin(timer * 4f) * 12f + 64f * (1f - Process.EasingArithmetic.CubeOut(slide));
            float scale = !Highlighted ? 1f + wiggler.Value * 0.5f : 1f - wiggler.Value * 0.5f;
            float ease = Process.EasingArithmetic.CubeInOut(slide) * alpha;
            PackedColor color = lineColor * ease;
            if (Highlighted)
                SourceAtlasDrawing.DrawJustified(context, this, Handler.HoverUI.Texture, at,
                    new Vector2(0.5f, 1f), color * alpha, scale);
            else
                SourceAtlasDrawing.DrawJustified(context, this, Process.GuiAtlas.Entries["hover/idle"], at,
                    new Vector2(0.5f, 1f), color * alpha, scale);
            if (Highlighted)
            {
                Vector2 inputAt = at + Handler.HoverUI.InputPosition * scale;
                if (Input.GuiInputController())
                    SourceAtlasDrawing.DrawJustified(context, this,
                        Input.GuiButton(Input.Talk), inputAt,
                        new Vector2(0.5f), PackedColor.White * ease, scale);
                else
                    Process.ActiveFont.DrawOutline(context, this,
                        Input.FirstKey(Input.Talk).ToString().ToUpper(),
                        inputAt, new Vector2(0.5f), new Vector2(scale),
                        PackedColor.White * ease, 2f, PackedColor.Black);
            }
        }
    }
}

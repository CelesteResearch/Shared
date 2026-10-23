using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collision;

namespace Celeste.Game.Entities.Lookouts
{
    public class OriginalLookoutHud : SceneEntityState, ILookoutHudState
    {
        public bool TrackMode;

        public float TrackPercent;

        public bool OnlyY;

        public float Easer;

        private AtlasEntry halfDot;
        private readonly IOriginalLookoutProcess process;

        public OriginalLookoutHud(IOriginalLookoutProcess process)
            : base(((ISourceEntitySourceDataEnvironment)process.EngineContext).EntitySourceDataRegistration,
                Vector2.Zero)
        {
            this.process = process;
            halfDot = process.GuiAtlas.Entries["dot"].GetSubtexture(0, 0, 64, 32);
            AddTag(((IOriginalGameTagsEnvironment)process.EngineContext).Tags
                .HUD.Value);
        }

        public override void Update()
        {
            LookoutHudPresentation.Update(this);
        }

        public override void Render(ISourceRenderContext context)
        {
            LookoutHudPresentation.Render(this, context);
        }

        private bool Blocked(IntRect rectangle)
        {
            return SourceSceneCollisionQueries.First<object>(rectangle,
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.LookoutBlocker")) != null;
        }

        private void DrawCentered(ISourceRenderContext context, AtlasEntry texture, Vector2 position,
            PackedColor color, float scale = 1f, float rotation = 0f)
        {
            SourceAtlasDrawing.DrawCentered(context, this, texture, position, color, scale, rotation);
        }

        private void DrawJustified(ISourceRenderContext context, AtlasEntry texture, Vector2 position,
            Vector2 justify, PackedColor color)
        {
            SourceAtlasDrawing.DrawJustified(context, this, texture, position, justify, color);
        }

        private void DrawJustified(ISourceRenderContext context, AtlasEntry texture, Vector2 position,
            Vector2 justify, PackedColor color, Vector2 scale)
        {
            SourceAtlasDrawing.DrawJustified(context, this, texture, position, justify, color, scale);
        }

        SceneEntityState ILookoutHudState.Entity => this;
        IOriginalLookoutProcess ILookoutHudState.Process => process;

        void ILookoutHudState.UpdateComponents()
        {
            base.Update();
        }

        bool ILookoutHudState.TrackMode
        {
            get => TrackMode;
            set => TrackMode = value;
        }

        float ILookoutHudState.TrackPercent
        {
            get => TrackPercent;
            set => TrackPercent = value;
        }

        bool ILookoutHudState.OnlyY
        {
            get => OnlyY;
            set => OnlyY = value;
        }

        float ILookoutHudState.Easer
        {
            get => Easer;
            set => Easer = value;
        }

        float ILookoutHudState.TimerUp { get; set; }

        float ILookoutHudState.TimerDown { get; set; }

        float ILookoutHudState.TimerLeft { get; set; }

        float ILookoutHudState.TimerRight { get; set; }

        float ILookoutHudState.MultUp { get; set; }

        float ILookoutHudState.MultDown { get; set; }

        float ILookoutHudState.MultLeft { get; set; }

        float ILookoutHudState.MultRight { get; set; }

        float ILookoutHudState.Left { get; set; }

        float ILookoutHudState.Right { get; set; }

        float ILookoutHudState.Up { get; set; }

        float ILookoutHudState.Down { get; set; }

        Vector2 ILookoutHudState.Aim { get; set; }

        AtlasEntry ILookoutHudState.HalfDot
        {
            get => halfDot;
            set => halfDot = value;
        }
    }
}

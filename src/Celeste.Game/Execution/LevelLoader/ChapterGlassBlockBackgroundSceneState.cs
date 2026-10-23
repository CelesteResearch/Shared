using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Execution.LevelLoader
{
    public partial class ChapterGlassBlockBackgroundSceneState : SceneEntityState
    {
        protected struct Star
        {
            public Vector2 Position;
            public AtlasEntry Texture;
            public PackedColor Color;
            public Vector2 Scroll;
        }

        protected struct Ray
        {
            public Vector2 Position;
            public float Width, Length;
            public PackedColor Color;
        }

        private static readonly PackedColor[] defaultStarColors =
        [
            new(127, 159, 186, 255), new(155, 209, 205, 255),
            new(186, 202, 227, 255),
        ];

        protected PackedColor[] starColors = defaultStarColors;
        protected readonly ISourceEngineContext engine;
        protected Star[] stars = new Star[100];
        protected Ray[] rays = new Ray[50];
        private readonly SourceVertexPositionColor[] verts = new SourceVertexPositionColor[2700];
        private readonly Vector2 rayNormal;
        protected PackedColor bgColor = new(13, 46, 137, 255);
        private VirtualRenderTarget beamsTarget, starsTarget;
        private bool hasBlocks;
        protected ISourceRandom CurrentRandom => ((ISourceRandomEnvironment)engine).Random;

        protected float Alpha = 1f;
        protected float FadeInRate;
        protected virtual string SurfaceTargetName => "glass-block-surfaces";
        protected virtual string BeamTargetName => "glass-block-beams";
        protected virtual int BufferWidth => 320;
        protected virtual int BufferHeight => 180;

        protected virtual IReadOnlyList<object> GetGlassBlocks()
        {
            return ((OriginalLevelSceneRoot)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.GlassBlock");
        }

        protected virtual Vector2 BlockShake(ISourceEntityCollider block)
        {
            return Vector2.Zero;
        }

        protected virtual float BlockAlpha(ISourceEntityCollider block)
        {
            return 1f;
        }

        protected virtual Vector2 DisplacementInset => Vector2.Zero;

        public ChapterGlassBlockBackgroundSceneState(ISourceEngineContext engine) : this(engine, true, true, true)
        {
        }

        protected ChapterGlassBlockBackgroundSceneState(ISourceEngineContext engine, bool initializeVisualState,
            bool global, bool displacement)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            rayNormal = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(new Vector2(-5f, -8f));
            if (global)
                Tags = ((ISourceGlobalFrozenExecutionTagsEnvironment)engine).GlobalFrozenExecutionTags.Global.Value;
            OwnedComponents.Add(new BeforeRenderCallbackComponentState(BeforeRender));
            if (displacement) OwnedComponents.Add(new DisplacementRenderHookState(OnDisplacementRender));
            Depth = -9990;
            if (initializeVisualState) InitializeVisualState();
        }

        protected void InitializeVisualState()
        {
            var atlasSubtextures =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures("particles/stars/");
            for (var i = 0; i < stars.Length; i++)
            {
                stars[i].Position.X = CurrentRandom.Next(BufferWidth);
                stars[i].Position.Y = CurrentRandom.Next(BufferHeight);
                stars[i].Texture = CurrentRandom.Choose(atlasSubtextures);
                stars[i].Color = CurrentRandom.Choose(starColors);
                stars[i].Scroll = Vector2.One * SourceRandomMath.NextFloat(CurrentRandom, .05f);
            }

            for (var j = 0; j < rays.Length; j++)
            {
                rays[j].Position.X = CurrentRandom.Next(BufferWidth);
                rays[j].Position.Y = CurrentRandom.Next(BufferHeight);
                rays[j].Width = SourceRandomMath.Range(CurrentRandom, 4f, 16f);
                rays[j].Length = CurrentRandom.Choose(48, 96, 128);
                rays[j].Color = PackedColor.White * SourceRandomMath.Range(CurrentRandom, .2f, .4f);
            }
        }

        protected void CopyVisualStateFrom(ChapterGlassBlockBackgroundSceneState previous)
        {
            stars = (Star[])previous.stars.Clone();
            rays = previous.rays;
            if (!previous.starColors.SequenceEqual(starColors))
            {
                Alpha = 0f;
                for (var i = 0; i < stars.Length; i++) stars[i].Color = CurrentRandom.Choose(starColors);
            }
            else if (previous.bgColor != bgColor)
            {
                Alpha = 0f;
            }
        }
    }
}

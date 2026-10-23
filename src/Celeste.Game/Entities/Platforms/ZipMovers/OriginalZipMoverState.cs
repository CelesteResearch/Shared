using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Controls.Source;
using Celeste.Game.Entities.Platforms.ZipMovers.Motion;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Presentation.Platforms.ZipMovers;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using JetBrains.Annotations;

namespace Celeste.Game.Entities.Platforms.ZipMovers
{
    public class OriginalZipMoverState : SourceSolidEntityState
    {
        public enum Themes
        {
            Normal,
            Moon,
        }

        public class ZipMoverPathRenderer : SceneEntityState
        {
            public OriginalZipMoverState ZipMover;

            private readonly AtlasEntry cog;

            private readonly Vector2 from;

            private readonly Vector2 to;

            private readonly Vector2 sparkAdd;

            private readonly float sparkDirFromA;

            private readonly float sparkDirFromB;

            private readonly float sparkDirToA;

            private readonly float sparkDirToB;

            public ZipMoverPathRenderer(OriginalZipMoverState zipMover)
                : base(((ISourceEntitySourceDataEnvironment)zipMover.engine).EntitySourceDataRegistration)
            {
                Depth = 5000;
                ZipMover = zipMover;
                from = SourceVector2Math.Add(ZipMover.start, new(ZipMover.Width / 2f, ZipMover.Height / 2f));
                to = SourceVector2Math.Add(ZipMover.target, new(ZipMover.Width / 2f, ZipMover.Height / 2f));
                sparkAdd = Vector2Geometry.Perpendicular(
                    ((ISourceVectorEnvironment)ZipMover.engine).VectorArithmetic.SafeNormalize(
                        SourceVector2Math.Subtract(from, to), 5f));
                var num = Vector2Geometry.Angle(SourceVector2Math.Subtract(from, to));
                sparkDirFromA = num + (float)Math.PI / 8f;
                sparkDirFromB = num - (float)Math.PI / 8f;
                sparkDirToA = num + (float)Math.PI - (float)Math.PI / 8f;
                sparkDirToB = num + (float)Math.PI + (float)Math.PI / 8f;
                if (zipMover.theme == Themes.Moon)
                    cog = ((ISourceGameGraphicsEnvironment)ZipMover.engine).GameGraphics.GameAtlas[
                        "objects/zipmover/moon/cog"];
                else
                    cog = ((ISourceGameGraphicsEnvironment)ZipMover.engine).GameGraphics.GameAtlas[
                        "objects/zipmover/cog"];
            }

            public void CreateSparks()
            {
                ZipMoverDrawing.Sparks(this, ZipMover.engine, from, to, sparkAdd,
                    sparkDirFromA, sparkDirFromB, sparkDirToA, sparkDirToB);
            }

            public override void Render(ISourceRenderContext context)
            {
                DrawCogs(context, Vector2.UnitY, PackedColor.Black);
                DrawCogs(context, Vector2.Zero);
                if (ZipMover.drawBlackBorder)
                    SourcePrimitiveDrawing.Rect((ISourceDrawScope)context,
                        new((int)(ZipMover.X + ZipMover.Shake.X - 1f),
                            (int)(ZipMover.Y + ZipMover.Shake.Y - 1f),
                            (int)ZipMover.Width + 2, (int)ZipMover.Height + 2), PackedColor.Black);
            }

            private void DrawCogs(ISourceRenderContext context, Vector2 offset, PackedColor? colorOverride = null)
            {
                ZipMoverDrawing.Ropes(context, this, ZipMover.engine, from, to, cog, ZipMover.percent,
                    ZipMover.ropeColor, ZipMover.ropeLightColor, offset, colorOverride);
            }
        }


        private readonly Themes theme;

        private readonly AtlasEntry[,] edges = new AtlasEntry[3, 3];

        private readonly BloomPointState bloom;

        private ZipMoverPathRenderer pathRenderer;

        private readonly List<AtlasEntry> innerCogs;

        private readonly AtlasEntry temp = new();

        private readonly bool drawBlackBorder;

        private readonly Vector2 start;

        private readonly Vector2 target;

        private float percent;

        private PackedColor ropeColor => ((IOriginalZipMoverColorsEnvironment)engine).ZipMoverColors.RopeColor;

        private PackedColor ropeLightColor =>
            ((IOriginalZipMoverColorsEnvironment)engine).ZipMoverColors.RopeLightColor;

        private readonly ISourceEngineContext engine;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private SoundSourceComponentState sfx;

        protected SoundSourceComponentState SourceMovementSound => sfx;
        protected Sprite SourceStreetlight { get; }

        public OriginalZipMoverState(ISourceEngineContext engine, Vector2 position, int width, int height,
            Vector2 target,
            Themes theme, ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
            this.engine = engine;
            sfx = new(engine);
            Depth = -9999;
            start = Position;
            this.target = target;
            this.theme = theme;
            OwnedComponents.Add(new SimulationCoroutine(engine, Sequence()));
            OwnedComponents.Add(new LightOccludeState());
            string path;
            string id;
            string key;
            if (theme == Themes.Moon)
            {
                path = "objects/zipmover/moon/light";
                id = "objects/zipmover/moon/block";
                key = "objects/zipmover/moon/innercog";
                drawBlackBorder = false;
            }
            else
            {
                path = "objects/zipmover/light";
                id = "objects/zipmover/block";
                key = "objects/zipmover/innercog";
                drawBlackBorder = true;
            }

            innerCogs = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(key);
            OwnedComponents.Add(SourceStreetlight =
                new(engine, ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas, path));
            SourceStreetlight.Add("frames", "", 1f);
            SourceStreetlight.Play("frames");
            SourceStreetlight.Active = false;
            SourceStreetlight.SetAnimationFrame(1);
            SourceStreetlight.Position = new(Width / 2f - SourceStreetlight.Width / 2f, 0f);
            OwnedComponents.Add(bloom = new(1f, 6f));
            bloom.Position = new(Width / 2f, 4f);
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
                edges[i, j] = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[id]
                    .GetSubtexture(i * 8, j * 8, 8, 8);

            SurfaceSoundIndex = 7;
            sfx.Position =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(Width, Height), 2f);
            OwnedComponents.Add(sfx);
        }

        public OriginalZipMoverState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                SourceVector2Math.Add(data.Nodes[0], offset),
                EntityAttributeReader.Enum(data.Values, "theme", Themes.Normal), world)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(pathRenderer = new(this));
        }

        public override void Removed(object scene)
        {
            ((ISourceScene)scene).SourceScene.RemoveEntity(pathRenderer);
            pathRenderer = null;
            base.Removed(scene);
        }

        public override void Update()
        {
            base.Update();
            bloom.Y = SourceStreetlight.CurrentAnimationFrame * 3;
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = Position;
            Position = SourceVector2Math.Add(Position, Shake);
            ZipMoverDrawing.Body(context, this, percent, innerCogs, edges, temp, 1f);
            base.Render(context);
            Position = position;
        }

        private void ScrapeParticlesCheck(Vector2 to)
        {
            ZipMoverDrawing.ScrapeParticles(this, engine, to);
        }

        private IEnumerator Sequence()
        {
            var start = Position;
            while (true)
            {
                if (!HasPlayerRider())
                {
                    yield return null;
                    continue;
                }

                sfx.Play(theme == Themes.Normal
                    ? "event:/game/01_forsaken_city/zip_mover"
                    : "event:/new_content/game/10_farewell/zip_mover");
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                    RumbleLength.Short);
                StartShaking(0.1f);
                yield return 0.1f;
                SourceStreetlight.SetAnimationFrame(3);
                StopPlayerRunIntoAnimation = false;
                var at = 0f;
                while (at < 1f)
                {
                    yield return null;
                    var vector = ZipMoverMotion.Forward(engine, start, target, ref at, ref percent);
                    ScrapeParticlesCheck(vector);
                    if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.1f, engine)) pathRenderer.CreateSparks();

                    MoveTo(vector);
                }

                StartShaking(0.2f);
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                    RumbleLength.Medium);
                (Scene as OriginalLevelSceneRoot).Shake();
                StopPlayerRunIntoAnimation = true;
                yield return 0.5f;
                StopPlayerRunIntoAnimation = false;
                SourceStreetlight.SetAnimationFrame(2);
                at = 0f;
                while (at < 1f)
                {
                    yield return null;
                    var position = ZipMoverMotion.Backward(engine, target, start, ref at, ref percent);
                    MoveTo(position);
                }

                StopPlayerRunIntoAnimation = true;
                StartShaking(0.2f);
                SourceStreetlight.SetAnimationFrame(1);
                yield return 0.5f;
            }
        }

        private float mod(float x, float m)
        {
            return (x % m + m) % m;
        }
    }
}

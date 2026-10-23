using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Game.Entities.ReflectionTentacles
{
    public class OriginalReflectionTentaclesState : SceneEntityState
    {
        private struct Tentacle
        {
            public Vector2 Position;

            public float Width;

            public float Length;

            public float Approach;

            public float WaveOffset;

            public int TexIndex;

            public int FillerTexIndex;

            public Vector2 LerpPositionFrom;

            public float LerpPercent;

            public float LerpDuration;
        }

        public int Index;

        public List<Vector2> Nodes = [];

        private Vector2 outwards;

        private Vector2 lastOutwards;

        private float ease;

        private Vector2 p;

        private RoomPlayerSession player;

        private float fearDistance;

        private float offset;

        private readonly bool createdFromLevel;

        private int slideUntilIndex;

        private int layer;

        private const int NodesPerTentacle = 10;

        private static readonly float[] TentacleWavePowers = CreateTentacleWavePowers();

        private static float[] CreateTentacleWavePowers()
        {
            var powers = new float[NodesPerTentacle];
            for (var j = 1; j <= NodesPerTentacle; j++)
                powers[j - 1] = (float)Math.Pow(1.100000023841858, j);
            return powers;
        }

        private Tentacle[] tentacles;

        private int tentacleCount;

        private SourceVertexPositionColorTexture[] vertices;

        private int vertexCount;

        private PackedColor color = new(128, 0, 128, 255);

        private float soundDelay = 0.25f;

        private readonly List<AtlasEntry[]> arms = [];

        private List<AtlasEntry> fillers;

        private readonly ISourceEngineContext engine;
        private readonly ReflectionTentaclesProfile profile;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private AtlasData Game => ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private struct UVSet
        {
            public Vector2 TopLeft, TopRight, BottomLeft, BottomRight;
        }

        private struct AtlasEntryComparer : IEqualityComparer<AtlasEntry>
        {
            public bool Equals(AtlasEntry x, AtlasEntry y)
            {
                return ReferenceEquals(x, y);
            }

            public int GetHashCode(AtlasEntry value)
            {
                return value.GetHashCode();
            }
        }

        private Dictionary<AtlasEntry, UVSet> UVCache;

        public OriginalReflectionTentaclesState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            profile = ((IGameProfileEnvironment)engine).SourceProfile switch
            {
                GameProfile.Original => ReflectionTentaclesProfile.Original,
                GameProfile.InstalledEverest => ReflectionTentaclesProfile.Installed,
                _ => throw new InvalidOperationException("Unknown actual source game profile."),
            };
        }

        public OriginalReflectionTentaclesState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            profile = ((IGameProfileEnvironment)engine).SourceProfile switch
            {
                GameProfile.Original => ReflectionTentaclesProfile.Original,
                GameProfile.InstalledEverest => ReflectionTentaclesProfile.Installed,
                _ => throw new InvalidOperationException("Unknown actual source game profile."),
            };
            Nodes.Add(Position);
            var nodes = data.Nodes;
            foreach (var vector in nodes) Nodes.Add(offset + vector);

            switch (EntityAttributeReader.Attr(data.Values, "fear_distance"))
            {
                case "close":
                    fearDistance = 16f;
                    break;
                case "medium":
                    fearDistance = 40f;
                    break;
                case "far":
                    fearDistance = 80f;
                    break;
            }

            var num = EntityAttributeReader.Int(data.Values, "slide_until");
            Create(fearDistance, num, 0, Nodes);
            createdFromLevel = true;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (createdFromLevel)
                for (var i = 1; i < 4; i++)
                {
                    var reflectionTentacles = new OriginalReflectionTentaclesState(engine);
                    reflectionTentacles.Create(fearDistance, slideUntilIndex, i, Nodes);
                    ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(reflectionTentacles);
                }
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            var flag = false;
            while (entity != null && Index < Nodes.Count - 1)
            {
                var vector = p = Vector2Geometry.ClosestPointOnLine(Nodes[Index], Nodes[Index] + outwards * 10000f,
                    entity.Center, VectorArithmetic);
                if (!(VectorArithmetic.Length(Nodes[Index] - vector) < fearDistance)) break;

                flag = true;
                Retreat();
            }

            if (flag)
            {
                ease = 1f;
                SnapTentacles();
            }
        }

        public void Create(float fearDistance, int slideUntilIndex, int layer, List<Vector2> startNodes)
        {
            Nodes = [];
            foreach (var startNode in startNodes)
                Nodes.Add(startNode + new Vector2(
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -8, 8),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -8, 8)));

            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate
                .Value;
            Position = Nodes[0];
            outwards = VectorArithmetic.SafeNormalize(Nodes[0] - Nodes[1]);
            this.fearDistance = fearDistance;
            this.slideUntilIndex = slideUntilIndex;
            this.layer = layer;
            switch (layer)
            {
                case 0:
                    Depth = -1000000;
                    color = new(63, 42, 79, 255);
                    offset = 110f;
                    break;
                case 1:
                    Depth = 8990;
                    color = new(123, 53, 85, 255);
                    offset = 80f;
                    break;
                case 2:
                    Depth = 10010;
                    color = new(102, 40, 71, 255);
                    offset = 50f;
                    break;
                case 3:
                    Depth = 10011;
                    color = new(73, 38, 50, 255);
                    offset = 20f;
                    break;
            }

            foreach (var atlasSubtexture in Game.GetAtlasSubtextures("scenery/tentacles/arms"))
            {
                var array = new AtlasEntry[10];
                var num = atlasSubtexture.FrameWidth / 10;
                for (var i = 0; i < 10; i++)
                    array[i] = atlasSubtexture.GetSubtexture(num * (10 - i - 1), 0, num, atlasSubtexture.FrameHeight);

                arms.Add(array);
            }

            fillers = Game.GetAtlasSubtextures("scenery/tentacles/filler");
            tentacles = new Tentacle[100];
            var num2 = 0f;
            var num3 = 0;
            while (num3 < tentacles.Length && num2 < 440f)
            {
                tentacles[num3].Approach =
                    0.25f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 0.75f;
                tentacles[num3].Length =
                    32f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 64f);
                tentacles[num3].Width = 4f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 16f);
                tentacles[num3].Position = TargetTentaclePosition(tentacles[num3], Nodes[0], num2);
                tentacles[num3].WaveOffset = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                tentacles[num3].TexIndex = ((ISourceRandomEnvironment)engine).Random.Next(arms.Count);
                tentacles[num3].FillerTexIndex = ((ISourceRandomEnvironment)engine).Random.Next(fillers.Count);
                tentacles[num3].LerpDuration =
                    0.5f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.25f);
                num2 += tentacles[num3].Width;
                num3++;
                tentacleCount++;
            }

            vertices = new SourceVertexPositionColorTexture[tentacleCount * 12 * 6];
            for (var j = 0; j < vertices.Length; j++) vertices[j].Color = color;
        }

        private Vector2 TargetTentaclePosition(Tentacle tentacle, Vector2 position, float along)
        {
            Vector2 vector2;
            var vector = vector2 = position - outwards * offset;
            if (player != null)
            {
                var vector3 = Vector2Geometry.Perpendicular(outwards);
                vector2 = Vector2Geometry.ClosestPointOnLine(vector2 - vector3 * 200f, vector2 + vector3 * 200f,
                    player.Position, VectorArithmetic);
            }

            var vector4 =
                vector + Vector2Geometry.Perpendicular(outwards) * (-220f + along + tentacle.Width * 0.5f);
            var num = VectorArithmetic.Length(vector2 - vector4);
            return vector4 + outwards * num * 0.6f;
        }

        public void Retreat()
        {
            if (Index < Nodes.Count - 1)
            {
                lastOutwards = outwards;
                ease = 0f;
                Index++;
                if (layer == 0 && soundDelay <= 0f)
                    ((IOriginalGameplayProcess)engine).AudioSession.Play(
                        VectorArithmetic.Length(Nodes[Index - 1] - Nodes[Index]) > 180f
                            ? "event:/game/06_reflection/scaryhair_whoosh"
                            : "event:/game/06_reflection/scaryhair_move");

                for (var i = 0; i < tentacleCount; i++)
                {
                    tentacles[i].LerpPercent = 0f;
                    tentacles[i].LerpPositionFrom = tentacles[i].Position;
                }
            }
        }

        public override void Update()
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long updateStarted = 0;
            var measuringUpdate = diagnostics?.BeginReflectionTentaclesUpdate(out updateStarted) ?? false;
            try
            {
                soundDelay -= engine.DeltaTime;
                if (slideUntilIndex > Index)
                {
                    player = Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                    if (player != null)
                    {
                        var vector = p = Vector2Geometry.ClosestPointOnLine(Nodes[Index] - outwards * 10000f,
                            Nodes[Index] + outwards * 10000f, player.Center, VectorArithmetic);
                        if (VectorArithmetic.Length(vector - Nodes[Index]) < 32f)
                        {
                            Retreat();
                            outwards = VectorArithmetic.SafeNormalize(Nodes[Index - 1] - Nodes[Index]);
                        }
                        else
                        {
                            MoveTentacles(vector - outwards * 190f);
                        }
                    }
                }
                else
                {
                    var entity = Level.Scheduler.Entities.GetTrackedEntity<object>("Celeste.FinalBoss");
                    player = Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                    if (entity == null && player != null && Index < Nodes.Count - 1)
                    {
                        var vector2 = p = Vector2Geometry.ClosestPointOnLine(Nodes[Index],
                            Nodes[Index] + outwards * 10000f, player.Center, VectorArithmetic);
                        if (VectorArithmetic.Length(Nodes[Index] - vector2) < fearDistance) Retreat();
                    }

                    if (Index > 0)
                    {
                        ease = ScalarMath.Approach(ease, 1f,
                            (Index != Nodes.Count - 1 ? 1 : 2) * engine.DeltaTime,
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                        outwards = Vector2Geometry.AngleToVector(
                            ScalarMath.AngleLerp(Vector2Geometry.Angle(lastOutwards),
                                Vector2Geometry.Angle(Nodes[Index - 1] - Nodes[Index]), Easing.QuadOut(ease)), 1f);
                        var num = 0f;
                        for (var i = 0; i < tentacleCount; i++)
                        {
                            var vector3 = TargetTentaclePosition(tentacles[i], Nodes[Index], num);
                            if (tentacles[i].LerpPercent < 1f)
                            {
                                tentacles[i].LerpPercent += engine.DeltaTime / tentacles[i].LerpDuration;
                                tentacles[i].Position = Vector2Interpolation.Lerp(tentacles[i].LerpPositionFrom,
                                    vector3,
                                    Easing.CubeInOut(tentacles[i].LerpPercent),
                                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                            }
                            else
                            {
                                tentacles[i].Position += (vector3 - tentacles[i].Position) *
                                                         (1f - (float)Math.Pow(0.1f * tentacles[i].Approach,
                                                             engine.DeltaTime));
                            }

                            num += tentacles[i].Width;
                        }
                    }
                    else
                    {
                        MoveTentacles(Nodes[Index]);
                    }
                }

                if (Index == Nodes.Count - 1)
                {
                    var color = this.color * (1f - ease);
                    for (var j = 0; j < vertices.Length; j++) vertices[j].Color = color;
                }

                UpdateVertices();
            }
            finally
            {
                if (measuringUpdate) diagnostics.EndReflectionTentaclesUpdate(updateStarted);
            }
        }

        private void MoveTentacles(Vector2 pos)
        {
            var num = 0f;
            for (var i = 0; i < tentacleCount; i++)
            {
                var vector = TargetTentaclePosition(tentacles[i], pos, num);
                tentacles[i].Position += (vector - tentacles[i].Position) *
                                         (1f - (float)Math.Pow(0.1f * tentacles[i].Approach, engine.DeltaTime));
                num += tentacles[i].Width;
            }
        }

        public void SnapTentacles()
        {
            var num = 0f;
            for (var i = 0; i < tentacleCount; i++)
            {
                tentacles[i].LerpPercent = 1f;
                tentacles[i].Position = TargetTentaclePosition(tentacles[i], Nodes[Index], num);
                num += tentacles[i].Width;
            }
        }

        private void UpdateVertices()
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long updateStarted = 0;
            var measuringUpdate = diagnostics?.BeginReflectionTentaclesVertices(out updateStarted) ?? false;
            try
            {
                var vector = -Vector2Geometry.Perpendicular(outwards);
                var n = 0;
                for (var i = 0; i < tentacleCount; i++)
                {
                    var position = tentacles[i].Position;
                    var widthScale = tentacles[i].Width * 0.5f + 2f;
                    var vector2 = new Vector2(vector.X * widthScale, vector.Y * widthScale);
                    var array = arms[tentacles[i].TexIndex];
                    var fillerA = new Vector2(position.X + vector2.X, position.Y + vector2.Y);
                    var fillerBScale = new Vector2(vector2.X * 1.5f, vector2.Y * 1.5f);
                    var fillerBStart = new Vector2(position.X + fillerBScale.X, position.Y + fillerBScale.Y);
                    var fillerBOutwards = outwards;
                    var fillerBEnd = new Vector2(fillerBOutwards.X * 240f, fillerBOutwards.Y * 240f);
                    var fillerB = new Vector2(fillerBStart.X - fillerBEnd.X, fillerBStart.Y - fillerBEnd.Y);
                    var fillerCScale = new Vector2(vector2.X * 1.5f, vector2.Y * 1.5f);
                    var fillerCStart = new Vector2(position.X - fillerCScale.X, position.Y - fillerCScale.Y);
                    var fillerCOutwards = outwards;
                    var fillerCEnd = new Vector2(fillerCOutwards.X * 240f, fillerCOutwards.Y * 240f);
                    var fillerC = new Vector2(fillerCStart.X - fillerCEnd.X, fillerCStart.Y - fillerCEnd.Y);
                    var fillerD = new Vector2(position.X - vector2.X, position.Y - vector2.Y);
                    Quad(ref n, fillerA, fillerB, fillerC, fillerD, fillers[tentacles[i].FillerTexIndex]);
                    var vector3 = position;
                    var vector4 = vector2;
                    var num = tentacles[i].Length / 10f;
                    num += ScalarMath.YoYo(tentacles[i].LerpPercent) * 6f;
                    for (var j = 1; j <= 10; j++)
                    {
                        var num2 = j / 10f;
                        var num3 = Level.Clock.TimeActive * tentacles[i].WaveOffset *
                                   TentacleWavePowers[j - 1] *
                                   2f;
                        var num4 = tentacles[i].WaveOffset * 3f + j * 0.05f;
                        var num5 = 2f + 4f * num2;
                        // Keep this call boundary to preserve Mono's original float rounding around Sin.
                        var wave = vector * (float)Math.Sin(num3 + num4);
                        var vector5 = new Vector2(wave.X * num5, wave.Y * num5);
                        var segmentOutwards = outwards;
                        var segmentOffset = new Vector2(segmentOutwards.X * num, segmentOutwards.Y * num);
                        var segmentStart = new Vector2(vector3.X + segmentOffset.X, vector3.Y + segmentOffset.Y);
                        var vector6 = new Vector2(segmentStart.X + vector5.X, segmentStart.Y + vector5.Y);
                        var taper = 1f - num2;
                        var vector7 = new Vector2(vector2.X * taper, vector2.Y * taper);
                        var a = new Vector2(vector6.X - vector7.X, vector6.Y - vector7.Y);
                        var b = new Vector2(vector3.X - vector4.X, vector3.Y - vector4.Y);
                        var c = new Vector2(vector3.X + vector4.X, vector3.Y + vector4.Y);
                        var d = new Vector2(vector6.X + vector7.X, vector6.Y + vector7.Y);
                        Quad(ref n, a, b, c, d, array[j - 1]);
                        vector3 = vector6;
                        vector4 = vector7;
                    }
                }

                vertexCount = n;
            }
            finally
            {
                if (measuringUpdate) diagnostics.EndReflectionTentaclesVertices(updateStarted);
            }
        }

        private void QuadOriginal(ref int n, Vector2 a, Vector2 b, Vector2 c, Vector2 d, AtlasEntry subtexture = null)
        {
            if (subtexture == null) subtexture = Game.Entries["util/pixel"];

            var num = 1f / subtexture.Texture.TextureSafe.Width;
            var num2 = 1f / subtexture.Texture.TextureSafe.Height;
            var textureCoordinate =
                new Vector2(subtexture.ClipRect.Left * num, subtexture.ClipRect.Top * num2);
            var textureCoordinate2 =
                new Vector2(subtexture.ClipRect.Right * num, subtexture.ClipRect.Top * num2);
            var textureCoordinate3 =
                new Vector2(subtexture.ClipRect.Left * num, subtexture.ClipRect.Bottom * num2);
            var textureCoordinate4 =
                new Vector2(subtexture.ClipRect.Right * num, subtexture.ClipRect.Bottom * num2);
            vertices[n].Position = new(a, 0f);
            vertices[n++].TextureCoordinate = textureCoordinate;
            vertices[n].Position = new(b, 0f);
            vertices[n++].TextureCoordinate = textureCoordinate2;
            vertices[n].Position = new(d, 0f);
            vertices[n++].TextureCoordinate = textureCoordinate3;
            vertices[n].Position = new(d, 0f);
            vertices[n++].TextureCoordinate = textureCoordinate3;
            vertices[n].Position = new(b, 0f);
            vertices[n++].TextureCoordinate = textureCoordinate2;
            vertices[n].Position = new(c, 0f);
            vertices[n++].TextureCoordinate = textureCoordinate4;
        }

        private void Quad(ref int n, Vector2 a, Vector2 b, Vector2 c, Vector2 d, AtlasEntry subtexture = null)
        {
            switch (profile)
            {
                case ReflectionTentaclesProfile.Original: QuadOriginal(ref n, a, b, c, d, subtexture); break;
                case ReflectionTentaclesProfile.Installed: QuadInstalled(ref n, a, b, c, d, subtexture); break;
                default: throw new InvalidOperationException("Unknown actual ReflectionTentacles profile.");
            }
        }

        private void QuadInstalled(ref int n, Vector2 a, Vector2 b, Vector2 c, Vector2 d, AtlasEntry subtexture = null)
        {
            if (subtexture == null) subtexture = Game.Entries["util/pixel"];
            if (UVCache == null) UVCache = new(33, default(AtlasEntryComparer));
            if (!UVCache.TryGetValue(subtexture, out var value))
            {
                var textureSafe = subtexture.Texture.TextureSafe;
                var clipRect = subtexture.ClipRect;
                var x = 1f / textureSafe.Width;
                var y = 1f / textureSafe.Height;
                value = new()
                {
                    TopLeft = new(clipRect.Left * x, clipRect.Top * y),
                    TopRight = new(clipRect.Right * x, clipRect.Top * y),
                    BottomLeft = new(clipRect.Left * x, clipRect.Bottom * y),
                    BottomRight = new(clipRect.Right * x, clipRect.Bottom * y),
                };
                UVCache[subtexture] = value;
            }

            if (n + 5 < vertices.Length)
            {
                vertices[n].Position.X = a.X;
                vertices[n].Position.Y = a.Y;
                vertices[n].TextureCoordinate = value.TopLeft;
                vertices[n + 1].Position.X = b.X;
                vertices[n + 1].Position.Y = b.Y;
                vertices[n + 1].TextureCoordinate = value.TopRight;
                vertices[n + 2].Position.X = d.X;
                vertices[n + 2].Position.Y = d.Y;
                vertices[n + 2].TextureCoordinate = value.BottomLeft;
                vertices[n + 3].Position.X = d.X;
                vertices[n + 3].Position.Y = d.Y;
                vertices[n + 3].TextureCoordinate = value.BottomLeft;
                vertices[n + 4].Position.X = b.X;
                vertices[n + 4].Position.Y = b.Y;
                vertices[n + 4].TextureCoordinate = value.TopRight;
                vertices[n + 5].Position.X = c.X;
                vertices[n + 5].Position.Y = c.Y;
                vertices[n + 5].TextureCoordinate = value.BottomRight;
                n += 6;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long renderStarted = 0;
            var measuringRender = diagnostics?.BeginReflectionTentaclesRender(out renderStarted) ?? false;
            try
            {
                if (vertexCount > 0)
                {
                    ((ISourceGameplayBatchScopeEnvironment)engine).GameplayBatchScope.End(context);
                    var device = ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice;
                    switch (profile)
                    {
                        case ReflectionTentaclesProfile.Original:
                            device.Textures[0] = arms[0][0].Texture.TextureSafe; break;
                        case ReflectionTentaclesProfile.Installed:
                            device.Textures[0] = arms[0][0].Texture.TextureSafe; break;
                        default: throw new InvalidOperationException("Unknown actual ReflectionTentacles profile.");
                    }

                    SourcePrimitiveGraphics.DrawVertices(
                        ((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                        Level.Camera.Matrix, vertices, vertexCount,
                        ((ISourceBackdropEffectResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                        .FxTexture);
                    ((ISourceGameplayBatchScopeEnvironment)engine).GameplayBatchScope.Begin(context);
                }
            }
            finally
            {
                if (measuringRender) diagnostics.EndReflectionTentaclesRender(renderStarted);
            }
        }
    }
}

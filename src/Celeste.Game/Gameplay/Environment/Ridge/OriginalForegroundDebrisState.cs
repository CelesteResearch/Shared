using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display.Colors;
using Color = Celeste.Core.Display.PackedColor;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation.Audio.Sources;
using Image = Celeste.Graphics.Animation.SpriteImage;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;
using SineWave = Celeste.Scene.Components.Oscillation.SineWaveState;
using BloomPoint = Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState;
using VertexLight = Celeste.Simulation.Presentation.Lighting.VertexLightState;
using Hitbox = Celeste.Physics.Collision.Shapes.HitboxColliderGeometry;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalForegroundDebrisState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        private Vector2 start;

        private float parallax;

        public OriginalForegroundDebrisState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            start = Position;
            base.Depth = -999900;
            string key = "scenery/fgdebris/" + ((ISourceRandomEnvironment)engine).Random.Choose("rock_a", "rock_b");
            List<MTexture> atlasSubtextures =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(key);
            atlasSubtextures.Reverse();
            foreach (MTexture item in atlasSubtextures)
            {
                Image img = new Image(item);
                img.CenterOrigin();
                Add(img);
                SineWave sine = new SineWave(engine, 0.4f);
                sine.Randomize();
                sine.OnUpdate = delegate { img.Position.Y = sine.Value * 2f; };
                Add(sine);
            }

            parallax = 0.05f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.08f);
        }

        public OriginalForegroundDebrisState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, engine)
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 vector = ((Level)Scene).Camera.Position + new Vector2(320f, 180f) / 2f - start;
            Vector2 position = Position;
            Position -= vector * parallax;
            base.Render(context);
            Position = position;
        }
    }
}

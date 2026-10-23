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
    public class OriginalClotheslineState : SceneEntityState
    {
        public OriginalClotheslineState(Vector2 from, Vector2 to, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            base.Depth = 8999;
            Position = from;
            Add(((IOriginalRidgeClothEnvironment)engine).Flaglines.Create(engine, to,
                ((IOriginalRidgeClothEnvironment)engine).Clothesline.LineColor,
                ((IOriginalRidgeClothEnvironment)engine).Clothesline.PinColor,
                ((IOriginalRidgeClothEnvironment)engine).Clothesline.Colors, 8, 20, 8, 16, 2, 8));
        }

        public OriginalClotheslineState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, data.Nodes[0] + offset, engine)
        {
        }
    }
}

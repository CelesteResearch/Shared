using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Gameplay.Actors.Facing;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using JetBrains.Annotations;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Hair
{
    public sealed partial class PlayerHair : SourceComponentState
    {
        public PackedColor Color = new(172, 50, 50);

        public PackedColor Border =
            PackedColor.Black;

        public float Alpha = 1;
        public int Facing;

        public FacingDirection SourceFacing
        {
            get => (FacingDirection)Facing;
            set => Facing = (int)value;
        }

        public bool DrawPlayerSpriteOutline, SimulateMotion = true;
        public Vector2 StepPerSegment = new(0, 2);
        public float StepInFacingPerSegment = .5f, StepApproach = 64, StepYSinePerSegment;
        public PlayerSprite Sprite;
        public List<Vector2> Nodes = [];
        private readonly List<AtlasEntry> bangs;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly ISourceEngineContext engine;

        public ISourceEngineContext EngineContext => engine;
        private float wave;
        private readonly bool useHairSegmentColorGetter;

        public PlayerHair(PlayerSprite sprite,
            ISourceEngineContext engine) : base(true, true)
        {
            this.engine = engine;
            useHairSegmentColorGetter = (engine as IPlayerHairColorEnvironment)?.UseHairSegmentColorGetter ?? false;
            Sprite = sprite;
            bangs = CurrentAtlas.GetAtlasSubtextures("characters/player/bangs");
            for (var i = 0; i < sprite.HairCount; i++) Nodes.Add(Vector2.Zero);
        }

        public void Start()
        {
            var position = ((ISourceEntityPosition)Entity).Position +
                           new Vector2(-Facing * 200, 200);
            for (var i = 0; i < Nodes.Count; i++) Nodes[i] = position;
        }

        public override void Update()
        {
            wave += engine.DeltaTime * 4f;
            base.Update();
        }

        // Called after the player's movement and sprite update, separately from component Update.
        public void AfterUpdate()
        {
            var offset = Sprite.HairOffset * new Vector2(Facing, 1);
            Nodes[0] = Sprite.RenderPosition + new Vector2(0, -9 * Sprite.Scale.Y) + offset;
            var target = Nodes[0] +
                         new Vector2(-Facing * StepInFacingPerSegment * 2,
                             (float)Math.Sin(wave) * StepYSinePerSegment) + StepPerSegment;
            var previous = Nodes[0];
            for (var i = 1; i < Sprite.HairCount; i++)
            {
                if (i >= Nodes.Count) Nodes.Add(Nodes[i - 1]);
                if (SimulateMotion)
                {
                    var approach = (1 - (float)i / Sprite.HairCount * .5f) * StepApproach;
                    Nodes[i] = VectorArithmetic.Approach(Nodes[i], target, approach * engine.DeltaTime);
                }

                var distance = Nodes[i] - previous;
                if (VectorArithmetic.Length(distance) > 3)
                    Nodes[i] = previous + VectorArithmetic.SafeNormalize(distance) * 3;
                target = Nodes[i] + new Vector2(-Facing * StepInFacingPerSegment,
                    (float)Math.Sin(wave + i * .8f) * StepYSinePerSegment) + StepPerSegment;
                previous = Nodes[i];
            }
        }

        public void MoveHairBy(Vector2 amount)
        {
            for (var i = 0; i < Nodes.Count; i++) Nodes[i] += amount;
        }

        public Vector2 GetHairScale(int index)
        {
            var size = .25f + (1 - (float)index / Sprite.HairCount) * .75f;
            return new((index == 0 ? Facing : size) * Math.Abs(Sprite.Scale.X), size);
        }

        private AtlasData CurrentAtlas
            => ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic
            => ((ISourceVectorEnvironment)engine).VectorArithmetic;
    }
}

using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Hair
{
    public sealed partial class PlayerHair : global::Celeste.Core.Components.SourceComponentState
    {
        public global::Celeste.Core.Display.PackedColor Color =
            new global::Celeste.Core.Display.PackedColor(172, 50, 50);

        public global::Celeste.Core.Display.PackedColor Border =
            global::Celeste.Core.Display.PackedColor.Black;

        public float Alpha = 1;
        public int Facing;

        public global::Celeste.Simulation.Gameplay.Actors.Facing.FacingDirection SourceFacing
        {
            get => (global::Celeste.Simulation.Gameplay.Actors.Facing.FacingDirection)Facing;
            set => Facing = (int)value;
        }

        public bool DrawPlayerSpriteOutline, SimulateMotion = true;
        public Vector2 StepPerSegment = new Vector2(0, 2);
        public float StepInFacingPerSegment = .5f, StepApproach = 64, StepYSinePerSegment;
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite;
        public List<Vector2> Nodes = new List<Vector2>();
        private List<global::Celeste.Graphics.Content.Atlas.AtlasEntry> bangs;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        public global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext => engine;
        private float wave;
        private readonly bool useHairSegmentColorGetter;

        public PlayerHair(global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite sprite,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine) : base(true, true)
        {
            this.engine = engine;
            useHairSegmentColorGetter = (engine as IPlayerHairColorEnvironment)?.UseHairSegmentColorGetter ?? false;
            Sprite = sprite;
            bangs = CurrentAtlas.GetAtlasSubtextures("characters/player/bangs");
            for (int i = 0; i < sprite.HairCount; i++) Nodes.Add(Vector2.Zero);
        }

        public void Start()
        {
            Vector2 position = ((global::Celeste.Core.Components.ISourceEntityPosition)Entity).Position +
                               new Vector2(-Facing * 200, 200);
            for (int i = 0; i < Nodes.Count; i++) Nodes[i] = position;
        }

        public override void Update()
        {
            wave += engine.DeltaTime * 4f;
            base.Update();
        }

        // Called after the player's movement and sprite update, separately from component Update.
        public void AfterUpdate()
        {
            Vector2 offset = Sprite.HairOffset * new Vector2(Facing, 1);
            Nodes[0] = Sprite.RenderPosition + new Vector2(0, -9 * Sprite.Scale.Y) + offset;
            Vector2 target = Nodes[0] +
                             new Vector2(-Facing * StepInFacingPerSegment * 2,
                                 (float)Math.Sin(wave) * StepYSinePerSegment) + StepPerSegment;
            Vector2 previous = Nodes[0];
            for (int i = 1; i < Sprite.HairCount; i++)
            {
                if (i >= Nodes.Count) Nodes.Add(Nodes[i - 1]);
                if (SimulateMotion)
                {
                    float approach = (1 - (float)i / Sprite.HairCount * .5f) * StepApproach;
                    Nodes[i] = VectorArithmetic.Approach(Nodes[i], target, approach * engine.DeltaTime);
                }

                Vector2 distance = Nodes[i] - previous;
                if (VectorArithmetic.Length(distance) > 3)
                    Nodes[i] = previous + VectorArithmetic.SafeNormalize(distance) * 3;
                target = Nodes[i] + new Vector2(-Facing * StepInFacingPerSegment,
                    (float)Math.Sin(wave + i * .8f) * StepYSinePerSegment) + StepPerSegment;
                previous = Nodes[i];
            }
        }

        public void MoveHairBy(Vector2 amount)
        {
            for (int i = 0; i < Nodes.Count; i++) Nodes[i] += amount;
        }

        public Vector2 GetHairScale(int index)
        {
            float size = .25f + (1 - (float)index / Sprite.HairCount) * .75f;
            return new Vector2((index == 0 ? Facing : size) * Math.Abs(Sprite.Scale.X), size);
        }

        private global::Celeste.Graphics.Content.Atlas.AtlasData CurrentAtlas
            => ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private global::Celeste.Core.Mathematics.ISourceVectorArithmetic VectorArithmetic
            => ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic;
    }
}

using System;
using System.Numerics;
using Celeste.Core.Components;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public struct NormalMotionState
    {
        public Vector2 Speed;
        private Vector2 genericSpriteScale;
        private ISourceScaleState spriteScaleOwner;

        public void BindSpriteScaleOwner(ISourceScaleState actualOwner)
        {
            spriteScaleOwner = actualOwner ?? throw new ArgumentNullException(nameof(actualOwner));
        }

        public Vector2 SpriteScale
        {
            get => spriteScaleOwner == null ? genericSpriteScale : spriteScaleOwner.Scale;
            set
            {
                if (spriteScaleOwner == null) genericSpriteScale = value;
                else spriteScaleOwner.Scale = value;
            }
        }

        public float SpriteScaleX
        {
            get => SpriteScale.X;
            set
            {
                var scale = SpriteScale;
                scale.X = value;
                SpriteScale = scale;
            }
        }

        public float SpriteScaleY
        {
            get => SpriteScale.Y;
            set
            {
                var scale = SpriteScale;
                scale.Y = value;
                SpriteScale = scale;
            }
        }

        public float MaxFall;
        public float VariableJumpTimer;
        public float VariableJumpSpeed;
        public bool HoldCannotDuck;
    }
}

using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers
{
    public struct ChaserState
    {
        public Vector2 Position;
        public float TimeStamp;
        public string Animation;
        public int Facing;

        public global::Celeste.Simulation.Gameplay.Actors.Facing.FacingDirection SourceFacing
        {
            get => (global::Celeste.Simulation.Gameplay.Actors.Facing.FacingDirection)Facing;
            set => Facing = (int)value;
        }

        public bool OnGround;
        public global::Celeste.Core.Display.PackedColor HairColor;
        public int Depth;
        public Vector2 Scale, DashDirection;

        private global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound sound0,
            sound1,
            sound2,
            sound3,
            sound4;

        public int Sounds;

        public global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound this[int index] =>
            index == 0 ? sound0 :
            index == 1 ? sound1 :
            index == 2 ? sound2 :
            index == 3 ? sound3 :
            index == 4 ? sound4 : default;

        internal ChaserState(float time, Vector2 position, string animation, int facing, bool onGround,
            global::Celeste.Core.Display.PackedColor hairColor, int depth, Vector2 spriteScale,
            Vector2 dashDirection,
            List<global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound> sounds)
        {
            Position = position;
            TimeStamp = time;
            Animation = animation;
            Facing = facing;
            OnGround = onGround;
            HairColor = hairColor;
            Depth = depth;
            Scale = new Vector2(Math.Abs(spriteScale.X) * facing, spriteScale.Y);
            DashDirection = dashDirection;
            Sounds = Math.Min(5, sounds.Count);
            sound0 = Sounds > 0 ? sounds[0] : default;
            sound1 = Sounds > 1 ? sounds[1] : default;
            sound2 = Sounds > 2 ? sounds[2] : default;
            sound3 = Sounds > 3 ? sounds[3] : default;
            sound4 = Sounds > 4 ? sounds[4] : default;
        }
    }
}

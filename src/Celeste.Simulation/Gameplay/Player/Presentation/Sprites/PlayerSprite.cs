using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Sprites
{
    public sealed partial class PlayerSprite : Sprite
    {
        public static IReadOnlyList<string> SpriteNames { get; } = Array.AsReadOnly(
            ["player", "player_no_backpack", "badeline", "player_badeline", "player_playback"]);

        private readonly ISourceEngineContext engine;

        public PlayerFramesMetadata Metadata =>
            ((ISourcePlayerSpriteEnvironment)engine).PlayerMetadata;

        public PlayerSpriteMode Mode { get; private set; }

        public int HairCount = 4;

        public Vector2 HairOffset
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => Texture != null ? Metadata.Get(Texture)?.HairOffset ?? Vector2.Zero : Vector2.Zero;
        }

        public float CarryYOffset
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (Texture != null)
                {
                    var value = Metadata.Get(Texture);
                    if (value != null) return value.CarryYOffset * Scale.Y;
                }

                return 0f;
            }
        }

        public int HairFrame
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => Texture != null ? Metadata.Get(Texture)?.Frame ?? 0 : 0;
        }

        public bool HasHair
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => Texture != null && (Metadata.Get(Texture)?.HasHair ?? false);
        }

        public bool Running =>
            LastAnimationID != null && (LastAnimationID == "flip" || LastAnimationID.StartsWith("run"));

        public bool DreamDashing => LastAnimationID != null && LastAnimationID.StartsWith("dreamDash");

        public PlayerSprite(ISourceEngineContext engine, PlayerSpriteMode mode) : base(
            engine,
            null, null)
        {
            this.engine = engine;
            Mode = mode;
            var id = "";
            switch (mode)
            {
                case PlayerSpriteMode.Madeline: id = "player"; break;
                case PlayerSpriteMode.MadelineNoBackpack: id = "player_no_backpack"; break;
                case PlayerSpriteMode.Badeline: id = "badeline"; break;
                case PlayerSpriteMode.MadelineAsBadeline: id = "player_badeline"; break;
                case PlayerSpriteMode.Playback: id = "player_playback"; break;
            }

            SpriteName = id;
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory
                .CreateOn(this, id);
        }
    }
}

using Celeste.Core.Display;
using Celeste.Game.Entities.BadelineDummy;
using System;
using Celeste.Core.Rendering;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        public global::Celeste.Graphics.Animation.Sprite Sprite { get; private set; }

        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite NormalSprite
        {
            get;
            private set;
        }

        public global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair NormalHair { get; private set; }
        public global::Celeste.Graphics.Animation.Sprite CurrentSprite => Sprite ?? NormalSprite;

        void CreateNormalSprite()
        {
            NormalSprite = new global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite(engine,
                global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode.Badeline);
            NormalSprite.Scale = new Vector2(-1, NormalSprite.Scale.Y);
            NormalSprite.Play("laugh");
            NormalHair =
                new global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair(NormalSprite, engine)
                {
                    Color = new global::Celeste.Core.Display.PackedColor(BadelineDummyPresentation.HairColor),
                    Border = global::Celeste.Core.Display.PackedColor.Black, Facing = -1
                };
            OwnedComponents.Add(NormalHair);
            OwnedComponents.Add(NormalSprite);
        }

        void CreateBossSprite()
        {
            Sprite = Bank.Create("badeline_boss");
            OwnedComponents.Add(Sprite);
            Sprite.OnFrameChange = animation =>
            {
                if (animation == "idle" && Sprite.CurrentAnimationFrame == 18)
                    ((global::Celeste.Core.Audio.ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                        "event:/char/badeline/boss_idle_air", Position);
            };
            Facing = -1;
            if (NormalSprite != null)
            {
                Sprite.Position = NormalSprite.Position;
                OwnedComponents.Remove(NormalSprite);
            }

            if (NormalHair != null) OwnedComponents.Remove(NormalHair);
            NormalSprite = null;
            NormalHair = null;
        }

        public override void Render(ISourceRenderContext ctx)
        {
            if (Sprite != null)
            {
                Sprite.Scale.X = Facing;
                Sprite.Scale.Y = 1f;
                Sprite.Scale *= 1f + ScaleWiggler.Value * .2f;
            }

            if (NormalSprite != null)
            {
                Vector2 position = NormalSprite.Position;
                NormalSprite.Position = new Vector2((float)Math.Floor(NormalSprite.Position.X),
                    (float)Math.Floor(NormalSprite.Position.Y));
                base.Render(ctx);
                NormalSprite.Position = position;
            }
            else base.Render(ctx);
        }
    }
}

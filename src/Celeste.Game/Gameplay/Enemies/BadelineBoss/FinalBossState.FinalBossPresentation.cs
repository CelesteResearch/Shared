using System;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        public Sprite Sprite { get; private set; }

        public PlayerSprite NormalSprite { get; private set; }

        public PlayerHair NormalHair { get; private set; }
        public Sprite CurrentSprite => Sprite ?? NormalSprite;

        private void CreateNormalSprite()
        {
            NormalSprite = new(EngineContext,
                PlayerSpriteMode.Badeline);
            NormalSprite.Scale = new(-1, NormalSprite.Scale.Y);
            NormalSprite.Play("laugh");
            NormalHair =
                new(NormalSprite, EngineContext)
                {
                    Color = new(BadelineDummyPresentation.HairColor),
                    Border = PackedColor.Black, Facing = -1,
                };
            OwnedComponents.Add(NormalHair);
            OwnedComponents.Add(NormalSprite);
        }

        private void CreateBossSprite()
        {
            Sprite = Bank.Create("badeline_boss");
            OwnedComponents.Add(Sprite);
            Sprite.OnFrameChange = animation =>
            {
                if (animation == "idle" && Sprite.CurrentAnimationFrame == 18)
                    ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Play(
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
                var position = NormalSprite.Position;
                NormalSprite.Position = new((float)Math.Floor(NormalSprite.Position.X),
                    (float)Math.Floor(NormalSprite.Position.Y));
                base.Render(ctx);
                NormalSprite.Position = position;
            }
            else
            {
                base.Render(ctx);
            }
        }
    }
}

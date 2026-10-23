using Celeste.Core.Rendering;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        public override void Render(ISourceRenderContext context)
        {
            var position = Position;
            Position += shaker.Value;
            var scale = sprite.Scale;
            sprite.Scale *= 1f - .3f * scaleWiggler.Value;
            sprite.Scale.X *= spriteFacing;
            base.Render(context);
            Position = position;
            sprite.Scale = scale;
        }

        public override void DebugRender(ISourceRenderContext context, object actualCamera)
        {
            var collider = Collider;
            Collider = AttackHitbox;
            AttackHitbox.Render(actualCamera, new(255, 0, 0), context);
            Collider = BounceHitbox;
            BounceHitbox.Render(actualCamera, new(0, 255, 255), context);
            Collider = collider;
        }
    }
}

namespace Celeste.Graphics.Animation
{
    public partial class Sprite
    {
        public void CopyPlaybackPhaseFrom(Sprite source)
        {
            Animating = source.Animating;
            CurrentAnimationID = source.CurrentAnimationID;
            CurrentAnimationFrame = source.CurrentAnimationFrame;
            currentAnimation = Animations.TryGetValue(CurrentAnimationID, out var animation)
                ? animation
                : source.currentAnimation;
            animationTimer = source.animationTimer;
            Scale = source.Scale;
        }
    }
}

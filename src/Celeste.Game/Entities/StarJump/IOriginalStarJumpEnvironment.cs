namespace Celeste.Game.Entities.StarJump
{
    public interface IOriginalStarJumpEnvironment
    {
        StarJumpRuntimeProfile StarJumpProfile { get; }
        StarClimbGraphicsProcessState StarClimbGraphics { get; }
    }
}

namespace Celeste.Simulation.Presentation.ScreenEffects
{
    public interface ISourceScreenEffectSettings
    {
        RoomScreenshakeAmount ScreenShake { get; }
        bool DisableFlashes { get; }
        bool AllowScreenFlash { get; }
    }
}

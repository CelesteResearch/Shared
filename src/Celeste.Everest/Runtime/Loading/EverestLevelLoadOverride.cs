using Celeste.Simulation;

namespace Celeste.Everest.Runtime.Loading
{
    public sealed class EverestLevelLoadOverride
    {
        public RoomPlayerSession NextLoadedPlayer;
        public int SkipScreenWipes;
        public bool ShouldAutoPause;
        public bool HasOverrides => NextLoadedPlayer != null || SkipScreenWipes != 0 || ShouldAutoPause;
    }
}

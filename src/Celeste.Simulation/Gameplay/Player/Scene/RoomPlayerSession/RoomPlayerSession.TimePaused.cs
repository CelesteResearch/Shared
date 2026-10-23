// ReSharper disable once CheckNamespace

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool TimePaused
        {
            get
            {
                if (Dead) return true;
                var state = Machine.State;
                if (state != 10 && unchecked((uint)(state - 12)) > 3u && state != 25)
                    return false;
                return true;
            }
        }
    }
}

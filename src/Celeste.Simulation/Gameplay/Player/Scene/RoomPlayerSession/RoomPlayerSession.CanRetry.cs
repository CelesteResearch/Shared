// ReSharper disable once CheckNamespace

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool CanRetry
        {
            get
            {
                var state = Machine.State;
                return (uint)(state - 12) > 3u && state != 18 && state != 25;
            }
        }
    }
}

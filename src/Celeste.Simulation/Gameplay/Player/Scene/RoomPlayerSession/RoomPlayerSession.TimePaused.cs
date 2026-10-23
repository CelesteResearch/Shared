namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool TimePaused
        {
            get
            {
                if (Dead) return true;
                int state = Machine.State;
                if (state != 10 && unchecked((uint)(state - 12)) > 3u && state != 25)
                    return false;
                return true;
            }
        }
    }
}

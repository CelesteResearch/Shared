// ReSharper disable once CheckNamespace

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool IsIntroState
        {
            get
            {
                switch (Machine.State)
                {
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 23:
                    case 25:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}

using System.Numerics;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation.Gameplay.Player.Events;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        internal void Rumble(int strength, int length) =>
            ((ISourceRumbleEnvironment)engineContext).RumbleSession.Rumble(strength, length);

        internal void ReportRumble(int strength, int length, string name, Vector2 position)
        {
            Rumble(strength, length);
            Report(RoomPlayerEventKind.Rumble, name, position);
        }
    }
}

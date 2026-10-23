namespace Celeste.Simulation.Gameplay.Camera
{
    // An immutable mapping from a game's player state IDs to camera behavior.
    public readonly struct CameraPlayerStateRoles
    {
        public readonly int DirectionBias, RiseBias, NoOffsetAndSnap, LookAhead, FastFollow;
        public readonly uint UncontrolledMask;

        public CameraPlayerStateRoles(int directionBias, int riseBias, int noOffsetAndSnap,
            int lookAhead, int fastFollow, uint uncontrolledMask)
        {
            DirectionBias = directionBias;
            RiseBias = riseBias;
            NoOffsetAndSnap = noOffsetAndSnap;
            LookAhead = lookAhead;
            FastFollow = fastFollow;
            UncontrolledMask = uncontrolledMask;
        }

        public bool InControl(int state)
        {
            return state < 0 || state >= 32 ||
                   (UncontrolledMask & (1u << state)) == 0;
        }
    }
}

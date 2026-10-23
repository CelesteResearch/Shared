using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        [MethodImpl(MethodImplOptions
            .NoInlining)]
        public bool RefillDash()
        {
            if (Data.Dashes < Motor.BeforeState.MaxDashes)
            {
                Data.Dashes = Motor.BeforeState.MaxDashes;
                return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions
            .NoInlining)]
        public bool UseRefill(bool twoDashes)
        {
            var maximum = Motor.BeforeState.MaxDashes;
            if (twoDashes)
                maximum = 2;
            if (Data.Dashes < maximum || Data.Stamina < 20f)
            {
                Data.Dashes = maximum;
                RefillStamina();
                return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions
            .NoInlining)]
        public void RefillStamina()
        {
            Data.Stamina = 110f;
        }
    }
}

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions
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

        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions
            .NoInlining)]
        public bool UseRefill(bool twoDashes)
        {
            int maximum = Motor.BeforeState.MaxDashes;
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

        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions
            .NoInlining)]
        public void RefillStamina() => Data.Stamina = 110f;
    }
}

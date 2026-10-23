using Celeste.Core.Display;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public PackedColor? OverrideHairColor;

        public void UpdateHair(bool applyGravity)
        {
            Appearance.UpdateColor(Data, Machine.State, Motor.BeforeState.MaxDashes, Hair,
                applyGravity, EngineContext.DeltaTime, OverrideHairColor);
        }
    }
}

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : global::Celeste.Core.Components.ISourceEntityUpdate
    {
        bool global::Celeste.Core.Components.ISourceEntityUpdate.Active => Active;

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public override void Update()
        {
            UpdateActualPlayer(engineContext.DeltaTime, engineContext.RawDeltaTime);
        }

        void global::Celeste.Core.Components.ISourceEntityUpdate.Update() => Update();
    }
}

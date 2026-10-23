using System.Runtime.CompilerServices;
using Celeste.Core.Components;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISourceEntityUpdate
    {
        bool ISourceEntityUpdate.Active => Active;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Update()
        {
            UpdateActualPlayer(EngineContext.DeltaTime, EngineContext.RawDeltaTime);
        }

        void ISourceEntityUpdate.Update()
        {
            Update();
        }
    }
}

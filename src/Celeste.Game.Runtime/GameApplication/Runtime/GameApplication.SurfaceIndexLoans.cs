using System.Threading;
using Celeste.Core.Threading;
using Celeste.Everest.Audio.Surfaces;
using Celeste.Game.Execution.Audio.Surfaces;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSurfaceIndexEnvironment
    {
        private SourceTypeInitialization<OriginalSurfaceIndex> sourceSurfaceIndexInitialization;

        public OriginalSurfaceIndex SurfaceIndex
        {
            get
            {
                var initialization = Volatile.Read(ref sourceSurfaceIndexInitialization);
                if (initialization == null)
                {
                    var descriptor = new SourceTypeInitialization<OriginalSurfaceIndex>(
                        "Celeste.SurfaceIndex", new SurfaceIndexInitializationFactory(SourceProfile));
                    initialization =
                        Interlocked.CompareExchange(ref sourceSurfaceIndexInitialization, descriptor, null) ??
                        descriptor;
                }

                return initialization.Value;
            }
        }

        private sealed class SurfaceIndexInitializationFactory : ISourceTypeInitializationFactory<OriginalSurfaceIndex>
        {
            private readonly GameProfile profile;

            public SurfaceIndexInitializationFactory(GameProfile profile)
            {
                this.profile = profile;
            }

            public OriginalSurfaceIndex Allocate()
            {
                return profile == GameProfile.Original
                    ? new OriginalSurfaceIndex()
                    : new EverestSurfaceIndex();
            }

            public void Initialize(OriginalSurfaceIndex instance)
            {
            }
        }
    }
}

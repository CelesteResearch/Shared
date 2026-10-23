using System;
using Celeste.Core.Framework.Startup;
using Celeste.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Game.Runtime.Platform
{
    internal sealed class HostRunPlatform : ISourceGameRunPlatform
    {
        private readonly SourceGraphicsAdapterProcess adapters;
        private readonly ISourceGameHostRuntimeIO host;

        internal HostRunPlatform(SourceGraphicsAdapterProcess adapters, ISourceGameHostRuntimeIO host)
        {
            this.adapters = adapters ?? throw new ArgumentNullException(nameof(adapters));
            this.host = host ?? throw new ArgumentNullException(nameof(host));
        }

        public SourceGraphicsAdapter RegisterGame(SourceGameProcess game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));
            return adapters.DefaultAdapter;
        }

        public void UnregisterGame(SourceGameProcess game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));
        }

        public bool GetTouchDeviceConnected()
        {
            return host.GetTouchDeviceConnected();
        }

        public bool NeedsPlatformMainLoop()
        {
            return false;
        }

        public void RunPlatformMainLoop(SourceGameProcess game)
        {
            throw new NotSupportedException("The existing host owns its platform event loop.");
        }

        public void OnIsMouseVisibleChanged(bool visible)
        {
            host.SetMouseVisible(visible);
        }
    }
}

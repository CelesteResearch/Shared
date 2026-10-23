using System;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void DisposeSourceContentRegistry(object sender, EventArgs args)
        {
            try
            {
                sourceLoader?.StopWatching();
            }
            finally
            {
                sourceContentRegistry?.Dispose();
            }
        }
    }
}

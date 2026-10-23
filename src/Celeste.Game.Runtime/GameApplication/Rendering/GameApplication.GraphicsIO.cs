using System;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private ISourceGraphicsDeviceIO sourceGraphicsIO;

        public ISourceGraphicsDeviceIO GraphicsIO => sourceGraphicsIO ??
                                                     throw new InvalidOperationException(
                                                         "The actual physical graphics IO is not constructed.");

        public void ConstructSourcePhysicalGraphicsIO()
        {
            if (sourceGraphicsIO != null)
                throw new InvalidOperationException("The actual physical graphics IO is already constructed.");
            sourceGraphicsIO = PhysicalIO.GraphicsFactory.CreateGraphicsDevice(ImageStreams)
                               ?? throw new InvalidOperationException(
                                   "The physical graphics factory did not create an actual device IO.");
        }
    }
}

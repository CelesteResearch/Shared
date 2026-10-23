using System;
using Celeste.Core.Framework.Graphics;
using Celeste.Core.Framework.Services;
using Celeste.Framework.Startup;
using Celeste.Game.Execution;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceGraphicsDeviceEnvironment,
        ISourceGameProcessEnvironment
    {
        private GameRuntime actualGame;

        public GameRuntime ActualGame => actualGame ??
                                         throw new InvalidOperationException(
                                             "The actual shared Celeste Game is not constructed.");

        SourceGameProcess
            ISourceGameProcessEnvironment.GameProcess => ActualGame;

        public SourceGameServiceContainer Services => ActualGame.Services;
        public SourceContentManager ContentManager => ActualGame.Content;

        public SourceGraphicsDevice GraphicsDevice =>
            (SourceGraphicsDevice)((ISourceGraphicsDeviceService)Services.GetService(
                typeof(ISourceGraphicsDeviceService)))
            .GraphicsDevice;

        public void PublishSourceActualGame(GameRuntime game)
        {
            if (actualGame != null) throw new InvalidOperationException("The actual Game is already published.");
            if (game == null) throw new ArgumentNullException(nameof(game));
            if (!ReferenceEquals(game.Process, this))
                throw new InvalidOperationException("The actual Game must borrow this same shared process.");
            actualGame = game;
            ConstructSourceRuntimeModuleMetadata();
        }
    }
}

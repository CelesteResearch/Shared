using System;
using Celeste.Hosting.Runtime.Graphics;
using Celeste.Graphics.Rendering.Offscreen;

namespace Celeste.Hosting.Runtime
{
    public static class GameSessionFactory
    {
        public static IEmbeddedGameSession Create(EmbeddedGameConfiguration configuration,
            IOffscreenGraphicsBackendFactory backendFactory)
            => Create(configuration, new RgbaEmbeddedGraphicsSessionFactory(backendFactory));

        public static IEmbeddedGameSession CreateBackground(EmbeddedGameConfiguration configuration,
            IOffscreenGraphicsBackendFactory backendFactory)
            => CreateBackground(configuration, new RgbaEmbeddedGraphicsSessionFactory(backendFactory));

        public static IEmbeddedGameSession CreateBackground(EmbeddedGameConfiguration configuration,
            IEmbeddedGraphicsSessionFactory graphicsFactory)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (graphicsFactory == null) throw new ArgumentNullException(nameof(graphicsFactory));
            return new BackgroundEmbeddedGameSession(configuration, value => Create(value, graphicsFactory));
        }

        public static IEmbeddedGameSession Create(EmbeddedGameConfiguration configuration,
            IEmbeddedGraphicsSessionFactory graphicsFactory)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            var session = new EmbeddedGameSession(configuration, graphicsFactory);
            try
            {
                session.Initialize();
                return session;
            }
            catch (Exception startupFailure)
            {
                try
                {
                    session.Dispose();
                }
                catch (Exception cleanupFailure)
                {
                    throw new AggregateException(startupFailure, cleanupFailure);
                }

                throw;
            }
        }
    }
}

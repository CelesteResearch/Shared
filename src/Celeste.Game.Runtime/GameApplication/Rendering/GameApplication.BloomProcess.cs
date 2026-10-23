using System;
using Celeste.Core.Threading;
using Celeste.Everest.Presentation.Effects.Bloom;
using Celeste.Game.Presentation.Effects.Bloom;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Profiles;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalBloomProcess
    {
        private SourceTypeInitialization<IOriginalBloomBlendStates> sourceBloomBlendStates;

        OriginalGameGraphicsResources IOriginalBloomProcess.Graphics => GraphicsResources;

        IOriginalBloomBlendStates IOriginalBloomProcess.BloomBlendStates =>
            (sourceBloomBlendStates
             ?? throw new InvalidOperationException("The actual original bloom type initialization is not bound."))
            .Value;

        SourceEffect ISourceGaussianBlurEnvironment.FxGaussianBlur => GraphicsResources.FxGaussianBlur;

        internal void ConstructSourceBloomBlendStateInitialization()
        {
            if (sourceBloomBlendStates != null)
                throw new InvalidOperationException("The actual original bloom type initialization is already bound.");
            ISourceTypeInitializationFactory<IOriginalBloomBlendStates> factory =
                SourceProfile == GameProfile.Original
                    ? new OriginalBloomBlendStateInitializationFactory()
                    : new EverestBloomBlendStateInitializationFactory();
            sourceBloomBlendStates =
                new SourceTypeInitialization<IOriginalBloomBlendStates>("Celeste.BloomRenderer", factory);
        }
    }
}

using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine.Effects;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalDistortionEnvironment
    {
        private OriginalEngineDistortionOutput distortionOutput;

        ISourceDistortionParameter IOriginalDistortionEnvironment.GetCurrentDistortionParameter(string name)
        {
            var effect = GraphicsResources.FxDistort ??
                         throw new InvalidOperationException("The current distortion effect has not been loaded.");
            return effect.Parameters[name];
        }

        bool IOriginalDistortionEnvironment.DisableFlashes =>
            SourceProfile == GameProfile.Original ? Settings.DisableFlashes : !CurrentCoreSettings.AllowDistort;

        void IOriginalDistortionEnvironment.OnDistortionEffectLoaded()
        {
            if (GraphicsResources.FxDistort == null)
                throw new InvalidOperationException(
                    "Publish distortion output only after its actual effect is loaded.");
            if (distortionOutput == null)
            {
                distortionOutput = new(this);
                Effects.BindDistortionOutput(distortionOutput);
            }
            else
            {
                Effects.SynchronizeDistortionOutput();
            }
        }
    }
}

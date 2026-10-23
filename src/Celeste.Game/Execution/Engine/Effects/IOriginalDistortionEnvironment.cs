using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Engine.Effects
{
    public interface IOriginalDistortionEnvironment
    {
        ISourceDistortionParameter GetCurrentDistortionParameter(string name);
        bool DisableFlashes { get; }
        void OnDistortionEffectLoaded();
    }
}

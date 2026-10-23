using Celeste.Core.Scheduling;

namespace Celeste.Game.Execution.Engine.Effects
{
    public sealed class OriginalEngineDistortionOutput : ISourceEngineDistortionOutput
    {
        private readonly IOriginalDistortionEnvironment environment;

        public OriginalEngineDistortionOutput(IOriginalDistortionEnvironment environment)
        {
            this.environment = environment ?? throw new System.ArgumentNullException(nameof(environment));
        }

        public ISourceDistortionParameter AnxietyOrigin => environment.GetCurrentDistortionParameter("anxietyOrigin");
        public ISourceDistortionParameter Anxiety => environment.GetCurrentDistortionParameter("anxiety");
        public ISourceDistortionParameter GameRate => environment.GetCurrentDistortionParameter("gamerate");
        public ISourceDistortionParameter WaterSine => environment.GetCurrentDistortionParameter("waterSine");
        public ISourceDistortionParameter WaterCameraY => environment.GetCurrentDistortionParameter("waterCameraY");
        public ISourceDistortionParameter WaterAlpha => environment.GetCurrentDistortionParameter("waterAlpha");
        public bool DisableFlashes => environment.DisableFlashes;
    }
}

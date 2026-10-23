namespace Celeste.Audio.Fmod.Runtime
{
    public sealed partial class FmodStudioRuntime
    {
        private ISourceFmodEventDescriptionPolicy sourceDescriptionPolicy;

        public void BindSourceDescriptionPolicy(ISourceFmodEventDescriptionPolicy policy) =>
            sourceDescriptionPolicy = policy;
    }
}

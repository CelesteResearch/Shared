namespace Celeste.Everest.Modules.Runtime
{
    public sealed class EverestModuleEventsProcess
    {
        public delegate void ModLoadedHandler(EverestModuleMetadata metadata);

        public delegate void RegisterModuleHandler(SourceEverestModule module);

        public event ModLoadedHandler OnLoadMod;
        public event RegisterModuleHandler OnRegisterModule;

        internal void LoadMod(EverestModuleMetadata metadata)
        {
            OnLoadMod?.Invoke(metadata);
        }

        internal void RegisterModule(SourceEverestModule module)
        {
            OnRegisterModule?.Invoke(module);
        }
    }
}

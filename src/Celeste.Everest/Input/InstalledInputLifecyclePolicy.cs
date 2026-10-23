using Celeste.Input.Runtime;
using Celeste.Input.Bindings;
using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Controls.Source;

namespace Celeste.Everest.Input
{
    public sealed class InstalledInputLifecyclePolicy : IOriginalInputLifecyclePolicy
    {
        private readonly ISourceEngineContext engine;

        public InstalledInputLifecyclePolicy(ISourceEngineContext engine)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public void AfterInitialize(OriginalGameInputProcess input)
        {
            foreach (var module in ((ISourceEverestModulesEnvironment)engine).Modules)
                module.OnInputInitialize();
            var settings = ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings;
            input.MountainAim =
                ((ISourceVirtualInputConstructionEnvironment)engine).VirtualInputConstruction.CreateJoystick(
                    ((ISourceMInputEnvironment)engine).MInput, settings.CameraForward.Binding,
                    settings.CameraBackward.Binding,
                    settings.CameraLeft.Binding, settings.CameraRight.Binding, input.Gamepad, 0.1f);
            ((IEverestInputEventsEnvironment)engine).InputEvents.Initialize();
        }

        public void AfterDeregister(OriginalGameInputProcess input)
        {
            input.Feather?.Deregister();
            foreach (var module in ((ISourceEverestModulesEnvironment)engine).Modules)
                module.OnInputDeregister();
            ((IEverestInputEventsEnvironment)engine).InputEvents.Deregister();
        }
    }
}

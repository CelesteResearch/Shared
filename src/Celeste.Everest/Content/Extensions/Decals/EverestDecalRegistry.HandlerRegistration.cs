using System;
using System.Collections.Generic;
using System.Reflection;

namespace Celeste.Everest.Content.Extensions.Decals
{
    public sealed partial class EverestDecalRegistry
    {
        private readonly Dictionary<string, HandlerRegistration> scopedHandlerRegistrations = new();

        public IDisposable RegisterPropertyHandler(Func<EverestDecalPropertyHandler> factory)
        {
            var handler = factory();
            var name = handler.Name;
            var hadPrevious = handlers.TryGetValue(name, out var previous);
            if (hadPrevious) LogConflict(name, Assembly.GetCallingAssembly());
            scopedHandlerRegistrations.TryGetValue(name, out var previousRegistration);
            if (previousRegistration != null && !ReferenceEquals(previousRegistration.Factory, previous))
                previousRegistration = null;
            var registration =
                new HandlerRegistration(this, name, factory, hadPrevious, previous, previousRegistration);
            handlers[name] = factory;
            scopedHandlerRegistrations[name] = registration;
            ScheduleHotReloadIfNeeded();
            return registration;
        }

        private sealed class HandlerRegistration(
            EverestDecalRegistry owner,
            string name,
            Func<EverestDecalPropertyHandler> factory,
            bool hadPrevious,
            Func<EverestDecalPropertyHandler> previous,
            HandlerRegistration previousRegistration) : IDisposable
        {
            internal readonly Func<EverestDecalPropertyHandler> Factory = factory;
            private EverestDecalRegistry registry = owner;
            private readonly bool hadPrevious = hadPrevious;
            private readonly Func<EverestDecalPropertyHandler> previous = previous;
            private readonly HandlerRegistration previousRegistration = previousRegistration;

            public void Dispose()
            {
                var target = registry;
                if (target == null) return;
                registry = null;
                if (target.scopedHandlerRegistrations.TryGetValue(name, out var latest) &&
                    ReferenceEquals(latest, this))
                    target.scopedHandlerRegistrations.Remove(name);
                if (!target.handlers.TryGetValue(name, out var current) || !ReferenceEquals(current, Factory)) return;
                var restore = this;
                while (restore.previousRegistration != null && restore.previousRegistration.registry == null)
                    restore = restore.previousRegistration;
                if (restore.hadPrevious) target.handlers[name] = restore.previous;
                else target.handlers.Remove(name);
                if (restore.previousRegistration != null)
                    target.scopedHandlerRegistrations[name] = restore.previousRegistration;
                target.ScheduleHotReloadIfNeeded();
            }
        }
    }
}

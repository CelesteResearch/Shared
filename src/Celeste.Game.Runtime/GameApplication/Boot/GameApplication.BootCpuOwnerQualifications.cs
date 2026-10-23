using System;
using Celeste.Everest.Modules.Core;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Compatibility;
using Celeste.Everest.Scripting.Lua;
using Celeste.Game.Execution;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        internal void PublishSourceInstalledBootCpuOwnerQualifications()
        {
            BindSourceBootCpuOwner(typeof(EverestLegacyDynamicDataHookProcess),
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyDynamicDataCompatHooks", 33557338);
            BindSourceBootCpuOwner(typeof(EverestLegacyMonoModCompatibilityProcess),
                "Celeste.Mod.Helpers.LegacyMonoMod.LegacyMonoModCompatLayer", 33557355);
            BindSourceBootCpuOwner(typeof(EverestMonoModPoliceProcess),
                "Celeste.Mod.Helpers.LegacyMonoMod.MonoModPolice",
                33557359);
            BindSourceBootCpuOwner(typeof(SourceCoreModule), "Celeste.Mod.Core.CoreModule", 33557433);
            BindSourceBootCpuOwner(typeof(SourceNullModule),
                "Celeste.Mod.NullModule", 33557090);
            BindSourceBootCpuOwner(typeof(EverestLuaLoaderProcess),
                "Celeste.Mod.Everest+LuaLoader", 33556855);
            BindSourceBootCpuOwner(typeof(GameRuntime),
                "Celeste.Celeste", 33556455);
        }

        private void BindSourceBootCpuOwner(Type actualType, string originalIdentity, int token)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = SourceMembers.GetOriginalTypeDefinition(assembly, originalIdentity);
            if (definition.MetadataToken != token)
                throw new InvalidOperationException(
                    "The actual Boot CPU source owner differs from the selected original PE.");
            SourceMembers.RegisterSourceType(actualType, assembly, originalIdentity);
            if (!ReferenceEquals(SourceMembers.GetOriginalTypeDefinition(actualType), definition))
                throw new InvalidOperationException(
                    "The actual Boot CPU owner has a different registered source operation identity.");
        }
    }
}

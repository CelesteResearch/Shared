using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private bool sourceBootSdkBridgeFrameOwnershipPublished;

        // Original event subscription site: Installed Celeste.dll SHA256
        // cbe1262e6f53ddf959b072fcacdf7b8f5eb08e67f5eb5853c5c6ab1ad12b2089,
        // Celeste.Mod.Everest.Boot MethodDef 100677691, TypeDef 33556765.
        // These are ownership facts only: the bridge is not an original TypeDef/MethodDef.
        internal void PublishSourceBootSdkBridgeFrameOwnership()
        {
            if (sourceBootSdkBridgeFrameOwnershipPublished)
                throw new InvalidOperationException("The actual Boot SDK bridge frame origin is already published.");
            var members = Reflection.SourceMembers;
            var methods = Reflection.SourceMethods;
            Type sourceOwner = typeof(SourceEverestModulesProcess);
            var ownerDefinition = members.GetOriginalTypeDefinition(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Mod.Everest");
            if (ownerDefinition.AssemblyIdentity != "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" ||
                ownerDefinition.Identity != "Celeste.Mod.Everest" || ownerDefinition.MetadataToken != 33556765)
                throw new InvalidOperationException(
                    "The SDK subscription bridge has no qualified original Everest source owner.");
            var originalSubscription = methods.RequireDefinition(ownerDefinition.AssemblyIdentity, 100677691);
            if (originalSubscription.DeclaringType != ownerDefinition.Identity ||
                originalSubscription.TypeDefinitionToken != ownerDefinition.MetadataToken ||
                originalSubscription.Name != "Boot")
                throw new InvalidOperationException(
                    "The SDK bridge event subscriptions have no matching original Boot operation.");
            members.RegisterSourceType(sourceOwner, ownerDefinition.AssemblyIdentity, ownerDefinition.Identity);
            if (!ReferenceEquals(members.GetOriginalTypeDefinition(sourceOwner), ownerDefinition))
                throw new InvalidOperationException(
                    "The actual module process is not bound to its validated original Everest owner.");
            Type actualHelper = typeof(global::Celeste.Everest.Detours.EverestBootDetourRuntime);
            methods.RegisterActualHelperFrameOwnership(members, actualHelper, sourceOwner);
            // Prove the emitted callback frames through actual CLR metadata at publication.
            // The manual ManagedInfo/NativeInfo adapters are not compiler closures and do
            // not gain source identity through a nested-name or whole-assembly shortcut.
            foreach (Type closure in actualHelper.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (!closure.IsDefined(typeof(CompilerGeneratedAttribute), inherit: false)) continue;
                if (!closure.IsNested || closure.DeclaringType != actualHelper || closure.Assembly.IsDynamic ||
                    closure.Module != actualHelper.Module || closure.Assembly != actualHelper.Assembly ||
                    (closure.MetadataToken & unchecked((int)0xff000000)) != 0x02000000)
                    throw new InvalidOperationException(
                        "The emitted Boot callback closure has no real helper parent metadata.");
                const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic |
                                           BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
                foreach (MethodInfo actualCallback in closure.GetMethods(flags))
                    if (methods.RequireFrameSourceAssemblyIdentity(members, actualCallback) !=
                        ownerDefinition.AssemblyIdentity)
                        throw new InvalidOperationException(
                            "The actual Boot callback frame has a different source operation owner.");
                foreach (ConstructorInfo constructor in closure.GetConstructors(flags))
                    if (methods.RequireFrameSourceAssemblyIdentity(members, constructor) !=
                        ownerDefinition.AssemblyIdentity)
                        throw new InvalidOperationException(
                            "The actual Boot closure constructor has a different source operation owner.");
            }

            PublishSourceInstalledBootOperationFrameOwners();
            sourceBootSdkBridgeFrameOwnershipPublished = true;
        }
    }
}

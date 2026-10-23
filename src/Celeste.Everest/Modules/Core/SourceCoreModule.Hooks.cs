using System;
using System.Runtime.ExceptionServices;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Everest.Modules.Runtime.Assemblies;
using Celeste.Core.Framework.Timing;
using Celeste.Framework.Startup;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;
using NLua;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        private ILHook nluaAssemblyGetTypesHook;
        private Hook nluaObjectTranslatorFindType;
        private Hook legacyXNAGameTickHook;

        private readonly FastReflectionHelper.FastInvoker fGame_accumulatedElapsedTime =
            typeof(SourceGameTickKernel)
                .GetField("accumulatedElapsedTime", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetFastInvoker();

        private readonly object[] fGame_accumulatedElapsedTime_ArgsCache = new object[1];

        private void patchNLuaAssemblyGetTypes(ILContext il)
        {
            var cursor = new ILCursor(il);
            while (cursor.TryGotoNext((Instruction instruction) => instruction.MatchCallvirt<Assembly>("GetTypes")))
            {
                var logger =
                    ((global::Celeste.Everest.Diagnostics.Logging.IEverestLoggerProcessEnvironment)SourceEngine)
                    .Logger;
                // The logger's interpolation guard must run before evaluating FullName/index.
                logger.VerboseCoreNLuaRedirect(il, cursor);
                cursor.Remove();
                cursor.EmitDelegate<Func<Assembly, Type[]>>(
                    ((global::Celeste.Everest.Reflection.ISourceEverestReflectionEnvironment)SourceEngine)
                    .Reflection.TypeSafety.GetTypesSafe);
            }
        }

        private Type hookNLuaObjectTranslatorFindType(Func<ObjectTranslator, string, Type> orig,
            ObjectTranslator translator, string typeName)
        {
            Type type = orig(translator, typeName);
            if (type != null) return type;
            // NLua's loaded-assembly search accepts FullName, while Lua's cached type
            // proxy supplies AssemblyQualifiedName. Resolve that physical CLR identity
            // against the assemblies which are actually loaded in this process.
            type = Type.GetType(typeName,
                requested => AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(assembly => string.Equals(assembly.FullName, requested.FullName,
                        StringComparison.Ordinal)),
                (assembly, name, ignoreCase) => assembly?.GetType(name, false, ignoreCase), false);
            if (type != null) return type;
            var contexts = ((ISourceEverestAssemblyProcessEnvironment)SourceEngine).AssemblyContexts;
            contexts._AllContextsLock.EnterReadLock();
            try
            {
                Type found =
                    (from assembly in contexts._AllContexts.SelectMany(context =>
                            context?.Assemblies ?? Enumerable.Empty<Assembly>())
                        select assembly.GetType(typeName)).FirstOrDefault(candidate => candidate != null);
                if (found != null) return found;
            }
            finally
            {
                contexts._AllContextsLock.ExitReadLock();
            }

            return null;
        }

        private void hookLegacyXNAGameTick(Action<SourceGameProcess> orig, SourceGameProcess game)
        {
            orig(game);
            var elapsed = (TimeSpan)fGame_accumulatedElapsedTime(game.TickKernel);
            elapsed += TimeSpan.FromTicks(game.Timing.TargetElapsedTime.Ticks >> 6);
            fGame_accumulatedElapsedTime_ArgsCache[0] = elapsed;
            fGame_accumulatedElapsedTime(game.TickKernel, fGame_accumulatedElapsedTime_ArgsCache);
        }

        private void InstallSourceNLuaHooks()
        {
            nluaAssemblyGetTypesHook = new ILHook(typeof(Lua).Assembly.GetType("NLua.Extensions.TypeExtensions")
                .GetMethod("GetExtensionMethods"), patchNLuaAssemblyGetTypes);
            nluaObjectTranslatorFindType = new Hook(
                typeof(ObjectTranslator).GetMethod("FindType", BindingFlags.Instance | BindingFlags.NonPublic),
                new Func<Func<ObjectTranslator, string, Type>, ObjectTranslator, string, Type>(
                    hookNLuaObjectTranslatorFindType));
        }

        private void InstallSourceLegacyXNATickHook()
        {
            legacyXNAGameTickHook = new Hook(typeof(SourceGameProcess).GetMethod("Tick"),
                new Action<Action<SourceGameProcess>, SourceGameProcess>(hookLegacyXNAGameTick));
        }

        private void DisposeSourceCoreHooks()
        {
            var spikeBounds = spikeAttachmentBounds;
            spikeAttachmentBounds = null;
            var entityRemoval = committedEntityRemoval;
            committedEntityRemoval = null;
            try
            {
                var spinnerHook = crystalSpinnerConnectionHook;
                crystalSpinnerConnectionHook = null;
                var tileGridHook = tileGridRenderClipHook;
                tileGridRenderClipHook = null;
                ExceptionDispatchInfo spinnerDisposeFailure = null;
                try
                {
                    spinnerHook?.Dispose();
                }
                catch (Exception exception)
                {
                    spinnerDisposeFailure = ExceptionDispatchInfo.Capture(exception);
                }

                try
                {
                    tileGridHook?.Dispose();
                }
                finally
                {
                    spinnerDisposeFailure?.Throw();
                }

                nluaAssemblyGetTypesHook?.Dispose();
                nluaAssemblyGetTypesHook = null;
                nluaObjectTranslatorFindType?.Dispose();
                nluaObjectTranslatorFindType = null;
                legacyXNAGameTickHook?.Dispose();
                legacyXNAGameTickHook = null;
            }
            finally
            {
                try
                {
                    spikeBounds?.Dispose();
                }
                finally
                {
                    entityRemoval?.Dispose();
                }
            }
        }
    }
}

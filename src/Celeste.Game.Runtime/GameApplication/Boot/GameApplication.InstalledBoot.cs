using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;


namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication


    {
        private ResolveEventHandler sourceBootSdkAssemblyResolver;

        private void LoadSourceBootSdkAssemblies()


        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;


            try
            {
                sourceBootSdkAssemblyResolver = ResolveSourceBootSdkAssembly;
                AppDomain.CurrentDomain.AssemblyResolve += sourceBootSdkAssemblyResolver;


                Assembly.Load("MonoMod.RuntimeDetour");


                Assembly.Load("MonoMod.Utils");


                Assembly.Load(typeof(Mono.Cecil.ModuleDefinition).Assembly.GetName());


                Assembly.Load("YamlDotNet");


                Assembly.Load("Newtonsoft.Json");


                Assembly.Load("Jdenticon");
            }
            catch
            {
                DisposeSourceBootSdkAssemblyResolver();
                throw;
            }
        }

        private void DisposeSourceBootSdkAssemblyResolver()
        {
            var resolver = System.Threading.Interlocked.Exchange(ref sourceBootSdkAssemblyResolver, null);
            if (resolver != null) AppDomain.CurrentDomain.AssemblyResolve -= resolver;
        }


        private Assembly ResolveSourceBootSdkAssembly(object sender, ResolveEventArgs args)


        {
            var name = new AssemblyName(args.Name);


            if (!global::Celeste.Everest.Modules.Runtime.Assemblies.CecilRuntimeAssemblies.IsRuntimeName(name.Name) &&
                !name.Name.StartsWith("YamlDotNet") &&
                !name.Name.StartsWith("NLua") && !name.Name.StartsWith("DotNetZip") &&
                !name.Name.StartsWith("Newtonsoft.Json") && !name.Name.StartsWith("Jdenticon")) return null;


            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(other => other.GetName().Name == name.Name);


            return assembly != null
                ? assembly
                : Assembly.LoadFrom(Path.Combine(EverestRuntime.PathGame, name.Name + ".dll"));
        }


        private void RegisterSourceBuiltinModulesAtBoot()


        {
            ConstructSourceInstalledUiProcess();
            ConstructSourceCoreModule();


            ModulesProcess.Register(ActualCoreModule);
            ConstructSourceInstalledLuaLoader();


            // Only physical probes inside ProcessAssembly use the SDK carrier. The complete


            // declared source inventory comes from the selected PE catalog, never this DLL.GetTypes().


            Loader.ProcessAssembly(ActualCoreModule.Metadata,
                typeof(global::Celeste.Everest.Modules.Core.SourceCoreModule).Assembly,
                Reflection.GetFakeEntryAssembly().GetOriginalTypeDefinitions());


            ModulesProcess.RegisterMod(ActualCoreModule.Metadata);
        }


        private void RegisterSourceVanillaModuleAtBoot()

        {
            var vanilla = new SourceNullModule(this, new EverestModuleMetadata


            {
                Name = "Celeste",


                VersionString = ActualGame.Version.ToString() + "-fna"
            });


            ModulesProcess.Register(vanilla);


            ModulesProcess.RegisterMod(vanilla.Metadata);
        }

        internal void CompleteSourceInstalledBoot()

        {
            WriteSourceInstalledBootDiagnostics();

            LoadSourceBootSdkAssemblies();

            InitializeSourceInstalledStoragePaths();

            PublishSourceBootSdkBridgeFrameOwnership();
            ConstructSourceInstalledBootDetourOwners();

            ModulesProcess.InitializeSourceBootDetourHooks();

            LegacyCompatibility.Initialize();

            InitializeSourceInstalledFlags();

            InitializeSourceInstalledContent();

            ConstructSourceInstalledMainThread();

            ConstructSourceInstalledStaThread();
            ConstructSourcePlainScenePolicy();
            ConstructSourceCriticalErrors();
            ConstructSourceAssetReload();
            ConstructSourceDecalRegistry();

            RegisterSourceBuiltinModulesAtBoot();

            EnableSourceBootColorizedLogging();

            RegisterSourceVanillaModuleAtBoot();

            LuaLoader.Initialize();

            ConstructSourceInstalledSplash();
            Loader.LoadAuto();

            SourceContentRegistry.Crawl(new global::Celeste.Everest.Content.Sources.MapBinsInModsContentSource(
                SourceContentRegistry, Loader, Path.Combine(EverestRuntime.PathEverest, "Mods")));

            ModulesProcess.ParseArgs(EverestRuntime.Args);

            ConstructSourceInstalledUpdater();
            Updater.StartVersionListRequestAtBoot();

            Updater.CheckForUpdateFailure();

            ModUpdater.RunAsyncCheckForModUpdates(excludeBlacklist: true);

            AssemblyContexts.PostBootCleanupAllContexts();
        }
    }
}

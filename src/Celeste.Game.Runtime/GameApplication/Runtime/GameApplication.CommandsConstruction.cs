using Celeste.Input.Devices.Keyboard;
using System;
using System.Linq;
using System.Collections.Generic;
using Celeste.Core.Diagnostics;
using Celeste.Core.Geometry;
using Celeste.Core.Pooling;
using Celeste.Core.Reflection;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Engine.Initialization;
using Celeste.Game.Execution.Engine.Commands;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Profiles;
using Celeste.Everest.Diagnostics.Commands;
using Celeste.Everest.Runtime.Input;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceCommandsBuiltinProcess,
        IEverestCommandsProcess, IOriginalEngineInitializationPublication
    {
        private SourceCatalogAssemblyMetadata sourceCommandsAssembly;
        private Lazy<bool> sourceCommandsTasInstalled;
        ISourceCommandsKeyboard ISourceCommandsProcess.Keyboard => MInput.Keyboard;
        SourceKeyboardState ISourceCommandsProcess.ReadKeyboardState() => KeyboardState.GetState();
        IntRect ISourceCommandsProcess.WindowClientBounds => ActualGame.Window.ClientBounds;
        int ISourceCommandsProcess.ViewWidth => EngineRuntime.ViewWidth;
        int ISourceCommandsProcess.ViewHeight => EngineRuntime.ViewHeight;
        ISourceAssemblyMetadata ISourceCommandsProcess.CommandsCallingAssembly => sourceCommandsAssembly;
        ISourceAssemblyMetadata ISourceCommandsProcess.CommandsEntryAssembly => sourceCommandsAssembly;
        SourceGraphicsDeviceManager ISourceCommandsBuiltinProcess.Graphics => EngineRuntime.Graphics;

        ISourceSceneDiagnostics ISourceCommandsBuiltinProcess.Scene =>
            ((SourceSceneState)Frame.Scenes.CurrentScene)?.SourceScene;

        SourceEntityPoolRegistry ISourceCommandsBuiltinProcess.Pooler => EntityPools;
        ISourceLogicalTypeNameMetadata ISourceCommandsBuiltinProcess.SceneMetadata => SceneCatalog;
        void ISourceCommandsBuiltinProcess.Exit() => ActualGame.Exit();
        void ISourceCommandsBuiltinProcess.SetFullscreen() => EngineScreen.SetFullscreen();

        void ISourceCommandsBuiltinProcess.SetWindowed(int width, int height) =>
            EngineScreen.SetWindowed(width, height);

        IEverestCommandsSettings IEverestCommandsProcess.Settings => CurrentCoreSettings;
        EverestTextInputProcess IEverestCommandsProcess.TextInput => InstalledTextInput;
        object IEverestCommandsProcess.Scene => Frame.Scenes.CurrentScene;

        IntRect IEverestCommandsProcess.Viewport => new IntRect(EngineGraphics.Viewport.X, EngineGraphics.Viewport.Y,
            EngineGraphics.Viewport.Width, EngineGraphics.Viewport.Height);

        int IEverestCommandsProcess.Width => EngineRuntime.Width;
        IEnumerable<IOriginalAreaData> IEverestCommandsProcess.Areas => ((IOriginalAreaSourceTable)this).Areas;
        Lazy<bool> IEverestCommandsProcess.CelesteTASInstalled => sourceCommandsTasInstalled;

        public void ConstructSourceCommands()
        {
            if (sourceCommands != null)
                throw new InvalidOperationException("The actual Commands are already constructed.");
            const string identity = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            sourceCommandsAssembly = new SourceCatalogAssemblyMetadata(SceneCatalog, identity);
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceCommandsTasInstalled =
                    new Lazy<bool>(() => Modules.Any(module => module.Metadata?.Name == "CelesteTAS"));
            if (SourceProfile == GameProfile.Original)
            {
                global::Celeste.Game.Reflection.Commands.OriginalDeclaredCommandMethodFacts.Register(SceneCatalog);
                OriginalCelesteCommandBindings.Bind(SceneCatalog);
                PublishSourceCommands(new SourceCommands(this));
            }
            else
            {
                global::Celeste.Everest.Reflection.Commands.InstalledDeclaredCommandMethodFacts.Register(SceneCatalog);
                InstalledCelesteCommandBindings.Bind(SceneCatalog);
                PublishSourceCommands(new SourceEverestCommands(this));
            }
        }

        void IOriginalEngineInitializationPublication.ConfigureSourcePoolConstructors() =>
            ConfigureActualSourcePoolConstructors();

        void IOriginalEngineInitializationPublication.CompleteSourceEngineInitialization()
        {
            InitializeSourceScreenWipeProcess();
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                ConstructSourceInstalledLevelGraphics();
                ConstructSourceLevelLoaders();
            }

            BindSourceEngineFrameAndDraw();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Diagnostics;
using Celeste.Core.Geometry;
using Celeste.Core.Pooling;
using Celeste.Core.Reflection;
using Celeste.Everest.Diagnostics.Commands;
using Celeste.Everest.Reflection.Commands;
using Celeste.Everest.Runtime.Input;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Engine.Commands;
using Celeste.Game.Execution.Engine.Initialization;
using Celeste.Game.Profiles;
using Celeste.Game.Reflection.Commands;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Input.Devices.Keyboard;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking.Initialization;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceCommandsBuiltinProcess,
        IEverestCommandsProcess, IOriginalEngineInitializationPublication
    {
        private SourceCatalogAssemblyMetadata sourceCommandsAssembly;
        private Lazy<bool> sourceCommandsTasInstalled;
        ISourceCommandsKeyboard ISourceCommandsProcess.Keyboard => MInput.Keyboard;

        SourceKeyboardState ISourceCommandsProcess.ReadKeyboardState()
        {
            return KeyboardState.GetState();
        }

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

        void ISourceCommandsBuiltinProcess.Exit()
        {
            ActualGame.Exit();
        }

        void ISourceCommandsBuiltinProcess.SetFullscreen()
        {
            EngineScreen.SetFullscreen();
        }

        void ISourceCommandsBuiltinProcess.SetWindowed(int width, int height)
        {
            EngineScreen.SetWindowed(width, height);
        }

        IEverestCommandsSettings IEverestCommandsProcess.Settings => CurrentCoreSettings;
        EverestTextInputProcess IEverestCommandsProcess.TextInput => InstalledTextInput;
        object IEverestCommandsProcess.Scene => Frame.Scenes.CurrentScene;

        IntRect IEverestCommandsProcess.Viewport => new(EngineGraphics.Viewport.X, EngineGraphics.Viewport.Y,
            EngineGraphics.Viewport.Width, EngineGraphics.Viewport.Height);

        int IEverestCommandsProcess.Width => EngineRuntime.Width;
        IEnumerable<IOriginalAreaData> IEverestCommandsProcess.Areas => ((IOriginalAreaSourceTable)this).Areas;
        Lazy<bool> IEverestCommandsProcess.CelesteTASInstalled => sourceCommandsTasInstalled;

        public void ConstructSourceCommands()
        {
            if (CommandsOrNull != null)
                throw new InvalidOperationException("The actual Commands are already constructed.");
            const string identity = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            sourceCommandsAssembly = new(SceneCatalog, identity);
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceCommandsTasInstalled =
                    new(() => Modules.Any(module => module.Metadata?.Name == "CelesteTAS"));
            if (SourceProfile == GameProfile.Original)
            {
                OriginalDeclaredCommandMethodFacts.Register(SceneCatalog);
                OriginalCelesteCommandBindings.Bind(SceneCatalog);
                PublishSourceCommands(new(this));
            }
            else
            {
                InstalledDeclaredCommandMethodFacts.Register(SceneCatalog);
                InstalledCelesteCommandBindings.Bind(SceneCatalog);
                PublishSourceCommands(new SourceEverestCommands(this));
            }
        }

        void IOriginalEngineInitializationPublication.ConfigureSourcePoolConstructors()
        {
            ConfigureActualSourcePoolConstructors();
        }

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

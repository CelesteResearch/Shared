using Celeste.Input.Devices.Keyboard;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands : ISourceCommands
    {
        protected readonly ISourceCommandsProcess process;
        bool ISourceCommands.Open => Open;
        bool ISourceCommands.Enabled => Enabled;
        protected internal const float UNDERSCORE_TIME = 0.5f;

        protected internal const float REPEAT_DELAY = 0.5f;

        protected internal const float REPEAT_EVERY = 1f / 30f;

        protected internal const float OPACITY = 0.8f;

        public bool Enabled = true;

        public bool Open;

        protected internal Dictionary<string, SourceCommandInfo> commands;

        protected internal List<string> sorted;

        protected internal SourceKeyboardState oldState;

        protected internal SourceKeyboardState currentState;

        protected internal string currentText = "";

        protected internal List<SourceCommandLine> drawCommands;

        protected internal bool underscore;

        protected internal float underscoreCounter;

        protected internal List<string> commandHistory;

        protected internal int seekIndex = -1;

        protected internal int tabIndex = -1;

        protected internal string tabSearch;

        protected internal float repeatCounter;

        protected internal SourceKeys? repeatKey;

        protected internal bool canOpen;

        public Action[] FunctionKeyActions { get; private set; }

        public SourceCommands(ISourceCommandsProcess process)
        {
            this.process = process;
            commandHistory = new List<string>();
            drawCommands = new List<SourceCommandLine>();
            commands = new Dictionary<string, SourceCommandInfo>();
            sorted = new List<string>();
            FunctionKeyActions = new Action[12];
            BuildCommandsList();
        }
    }
}

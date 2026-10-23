using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands : SourceCommands
    {
        protected IEverestCommandsProcess installed => (IEverestCommandsProcess)process;
        private int mouseScroll;
        private int cursorScale;
        private int charIndex;
        private bool installedListener;
        private int firstLineIndexToDraw;
        internal StringBuilder debugRClog;
        private bool printedInfoMessage;
        private string[] tabResults;
        private string tabPrefix;

        public SourceEverestCommands(IEverestCommandsProcess process) : base(process)
        {
        }

        protected override string NormalizeCommandName(string name) => name.ToLowerInvariant();
    }
}

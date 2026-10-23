using System.Text;
using Celeste.Framework.Diagnostics.Commands;

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

        protected override string NormalizeCommandName(string name)
        {
            return name.ToLowerInvariant();
        }
    }
}

using Celeste.Core.Diagnostics;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands : ISourceObjectLog
    {
        void ISourceObjectLog.Log(object value)
        {
            Log(value);
        }
    }
}

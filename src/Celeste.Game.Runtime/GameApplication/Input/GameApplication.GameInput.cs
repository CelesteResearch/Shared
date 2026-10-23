using System;
using Celeste.Game.Controls.Source;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private OriginalGameInputProcess sourceGameInput;

        public OriginalGameInputProcess InputSource => sourceGameInput ??
                                                       throw new InvalidOperationException(
                                                           "The actual game Input process is not published.");

        public void InitializeSourceGameInputProcess()
        {
            if (sourceGameInput != null)
                throw new InvalidOperationException("The game Input process is already published.");
            sourceGameInput = new OriginalGameInputProcess((IOriginalGameInputSourceEnvironment)engine);
        }
    }
}

using System.Collections.Generic;

namespace Celeste.Core.Framework.Startup
{
    public class SourceLaunchParameters : Dictionary<string, string>
    {
        private static readonly char[] Flags = ['/', '-'];

        public SourceLaunchParameters(ISourceCommandLineDevice device)
        {
            var commandLineArgs = device.GetCommandLineArgs();
            for (var i = 0; i < commandLineArgs.Length; i++)
            {
                var text = commandLineArgs[i].TrimStart(Flags);
                if (text.Length < 3)
                    continue;
                var num = text.IndexOf(":", 1, text.Length - 2);
                if (num >= 0)
                {
                    var key = text.Substring(0, num);
                    if (!ContainsKey(key))
                        Add(key, text.Substring(num + 1));
                }
            }
        }
    }
}

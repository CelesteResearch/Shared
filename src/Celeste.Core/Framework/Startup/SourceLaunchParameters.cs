using System;
using System.Collections.Generic;

namespace Celeste.Core.Framework.Startup
{
    public class SourceLaunchParameters : Dictionary<string, string>
    {
        private static readonly char[] flags = new char[2] { '/', '-' };

        public SourceLaunchParameters(ISourceCommandLineDevice device)
        {
            string[] commandLineArgs = device.GetCommandLineArgs();
            for (int i = 0; i < commandLineArgs.Length; i++)
            {
                string text = commandLineArgs[i].TrimStart(flags);
                if (text.Length < 3)
                {
                    continue;
                }

                int num = text.IndexOf(":", 1, text.Length - 2);
                if (num >= 0)
                {
                    string key = text.Substring(0, num);
                    if (!ContainsKey(key))
                    {
                        Add(key, text.Substring(num + 1));
                    }
                }
            }
        }
    }
}

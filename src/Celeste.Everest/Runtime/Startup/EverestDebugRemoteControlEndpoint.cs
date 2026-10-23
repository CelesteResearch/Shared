using System;
using System.Net;

namespace Celeste.Everest.Runtime.Startup
{
    public class EverestDebugRemoteControlEndpoint
    {
        public string Path;

        public string PathHelp;

        public string PathExample;

        public string Name;

        public string InfoHTML;

        public Action<HttpListenerContext> Handle;
    }
}

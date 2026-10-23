#nullable enable annotations
using System;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.AutoSplitting;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Input;
using Celeste.Everest.Runtime.Threading;
using Celeste.Game.Audio.Runtime;
using Celeste.Framework.Startup;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestInitializationSaveLinkIO
    {
        string GetDirectoryLinkTarget(DirectoryInfo directory);
    }
}

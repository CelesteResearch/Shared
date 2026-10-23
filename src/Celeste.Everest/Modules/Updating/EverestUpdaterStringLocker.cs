using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Runtime;
using Celeste.Everest.UI.Progress;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Shutdown;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Modules.Updating
{
    internal sealed class EverestUpdaterStringLocker
    {
        public string String;
    }
}

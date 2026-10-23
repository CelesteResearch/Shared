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
    public class EverestUpdateSource
    {
        private readonly EverestUpdaterProcess owner;
        private EverestLoggerProcess Logger => owner.Logger;
        private Dictionary<string, EverestUpdaterStringLocker> sharedCache => owner.sharedCache;
        public EverestUpdateSource(EverestUpdaterProcess owner) => this.owner = owner;

        public string Name;

        public string Description;

        public int MinimumBuild;

        public EverestUpdatePriority UpdatePriority = EverestUpdatePriority.Low;

        public Func<string> Index;

        public Func<EverestUpdateSource, string, List<EverestUpdateEntry>> ParseData;

        public Func<string, EverestUpdateEntry> ParseLine;

        private Task<EverestUpdateSource> _RequestTask;

        public virtual ReadOnlyCollection<EverestUpdateEntry> Entries { get; protected set; }

        public string ErrorDialog { get; protected set; }

        public Task<EverestUpdateSource> Request()
        {
            if (_RequestTask != null)
            {
                return _RequestTask;
            }

            _RequestTask = new Task<EverestUpdateSource>(delegate
            {
                try
                {
                    return _RequestStart();
                }
                catch (Exception e)
                {
                    ErrorDialog = "updater_versions_err_download";
                    Logger.Log(EverestLogLevel.Warn, "updater", "Uncaught exception while loading version list");
                    Logger.LogDetailed(e);
                    return this;
                }
            });
            _RequestTask.Start();
            return _RequestTask;
        }

        private EverestUpdateSource _RequestStart()
        {
            Entries = null;
            ErrorDialog = null;
            string text2;
            try
            {
                string text = Index();
                EverestUpdaterStringLocker value;
                lock (sharedCache)
                {
                    if (!sharedCache.TryGetValue(text, out value))
                    {
                        sharedCache.Add(text, value = new EverestUpdaterStringLocker());
                    }
                }

                lock (value)
                {
                    if (value.String != null)
                    {
                        Logger.Log(EverestLogLevel.Verbose, "updater",
                            "Got value from shared cache for source: " + text);
                        text2 = value.String;
                    }
                    else
                    {
                        Logger.Log(EverestLogLevel.Debug, "updater",
                            "Attempting to download update list from source: " + text);
                        using (HttpClient httpClient = owner.CompressedHttp.CreateClient())
                        {
                            text2 = httpClient.GetStringAsync(text).Result;
                        }

                        value.String = text2;
                        Logger.Log(EverestLogLevel.Verbose, "updater",
                            "Download from source done, releasing locker: " + text);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorDialog = "updater_versions_err_download";
                Logger.Log(EverestLogLevel.Warn, "updater", "Failed requesting index: " + ex.ToString());
                return this;
            }

            List<EverestUpdateEntry> list = new List<EverestUpdateEntry>();
            if (ParseData != null)
            {
                try
                {
                    list.AddRange(ParseData(this, text2));
                }
                catch (Exception ex2)
                {
                    ErrorDialog = "updater_versions_err_format";
                    Logger.Log(EverestLogLevel.Warn, "updater", "Failed parsing index: " + ex2.ToString());
                    return this;
                }
            }
            else
            {
                string[] array = text2.Split('\n');
                for (int i = 0; i < array.Length; i++)
                {
                    string text3 = array[i].Trim('\r', '\n').Trim();
                    if (text3.Length == 0 || text3.StartsWith("#"))
                    {
                        continue;
                    }

                    try
                    {
                        EverestUpdateEntry entry = ParseLine(text3);
                        if (entry != null)
                        {
                            list.Add(entry);
                        }
                    }
                    catch (Exception ex3)
                    {
                        ErrorDialog = "updater_versions_err_format";
                        Logger.Log(EverestLogLevel.Warn, "updater", "Failed parsing index: " + ex3.ToString());
                        return this;
                    }
                }
            }

            for (int j = 0; j < list.Count; j++)
            {
                if (list[j].Build < MinimumBuild)
                {
                    list.RemoveAt(j--);
                }
            }

            Entries = new ReadOnlyCollection<EverestUpdateEntry>(list);
            return this;
        }

        public void Clear()
        {
            if (_RequestTask == null || _RequestTask.IsCompleted || _RequestTask.IsCanceled || _RequestTask.IsFaulted)
            {
                _RequestTask = null;
                Entries = null;
                ErrorDialog = null;
            }
        }
    }
}

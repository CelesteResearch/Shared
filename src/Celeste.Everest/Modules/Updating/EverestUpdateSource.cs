using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Modules.Updating
{
    public class EverestUpdateSource
    {
        private readonly EverestUpdaterProcess owner;
        private EverestLoggerProcess Logger => owner.Logger;
        private Dictionary<string, EverestUpdaterStringLocker> sharedCache => owner.sharedCache;

        public EverestUpdateSource(EverestUpdaterProcess owner)
        {
            this.owner = owner;
        }

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
            if (_RequestTask != null) return _RequestTask;

            _RequestTask = new(delegate
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
                var text = Index();
                EverestUpdaterStringLocker value;
                lock (sharedCache)
                {
                    if (!sharedCache.TryGetValue(text, out value)) sharedCache.Add(text, value = new());
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
                        using (var httpClient = owner.CompressedHttp.CreateClient())
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
                Logger.Log(EverestLogLevel.Warn, "updater", "Failed requesting index: " + ex);
                return this;
            }

            var list = new List<EverestUpdateEntry>();
            if (ParseData != null)
            {
                try
                {
                    list.AddRange(ParseData(this, text2));
                }
                catch (Exception ex2)
                {
                    ErrorDialog = "updater_versions_err_format";
                    Logger.Log(EverestLogLevel.Warn, "updater", "Failed parsing index: " + ex2);
                    return this;
                }
            }
            else
            {
                var array = text2.Split('\n');
                for (var i = 0; i < array.Length; i++)
                {
                    var text3 = array[i].Trim('\r', '\n').Trim();
                    if (text3.Length == 0 || text3.StartsWith("#")) continue;

                    try
                    {
                        var entry = ParseLine(text3);
                        if (entry != null) list.Add(entry);
                    }
                    catch (Exception ex3)
                    {
                        ErrorDialog = "updater_versions_err_format";
                        Logger.Log(EverestLogLevel.Warn, "updater", "Failed parsing index: " + ex3);
                        return this;
                    }
                }
            }

            for (var j = 0; j < list.Count; j++)
                if (list[j].Build < MinimumBuild)
                    list.RemoveAt(j--);

            Entries = new(list);
            return this;
        }

        public void Clear()
        {
            if (!(_RequestTask == null || _RequestTask.IsCompleted || _RequestTask.IsCanceled ||
                  _RequestTask.IsFaulted))
                return;
            _RequestTask = null;
            Entries = null;
            ErrorDialog = null;
        }
    }
}

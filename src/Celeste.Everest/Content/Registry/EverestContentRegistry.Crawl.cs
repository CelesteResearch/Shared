using System.Diagnostics;
using Celeste.Everest.Content.Sources;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public void Crawl(EverestContentSource source)
        {
            if (!Mods.Contains(source))
                Mods.Add(source);
            source.CrawlCore();
            if (!processing.ContentLoaded)
                return;
            var message = processing.Logger.BeginEnabledMessage("content", EverestLogLevel.Verbose);
            if (message.ShouldLog)
                message.Write("Late ingest via update for " + source.Name);
            Stopwatch previous = processing.ProcessTiming.LoadTimer;
            Stopwatch timer = Stopwatch.StartNew();
            try
            {
                processing.ProcessTiming.LoadTimer = timer;
                foreach (EverestContentAsset item in source.List)
                    Update(Get(item.PathVirtual, includeDirs: true), item);
            }
            finally
            {
                timer.Stop();
                processing.ProcessTiming.LoadTimer = previous;
            }
        }
    }
}

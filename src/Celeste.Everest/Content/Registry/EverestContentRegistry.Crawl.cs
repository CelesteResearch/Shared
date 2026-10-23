using System.Diagnostics;
using Celeste.Everest.Content.Sources;

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
            var previous = processing.ProcessTiming.LoadTimer;
            var timer = Stopwatch.StartNew();
            try
            {
                processing.ProcessTiming.LoadTimer = timer;
                foreach (var item in source.List)
                    Update(Get(item.PathVirtual, true), item);
            }
            finally
            {
                timer.Stop();
                processing.ProcessTiming.LoadTimer = previous;
            }
        }
    }
}

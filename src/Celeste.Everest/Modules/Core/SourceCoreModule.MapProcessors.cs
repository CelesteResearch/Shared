using Celeste.Everest.Content.Maps.Processing;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        public override void PrepareMapDataProcessors(EverestMapDataFixup context)
        {
            context.Add(new InstalledCoreMapDataProcessor(SourceEngine));
        }
    }
}

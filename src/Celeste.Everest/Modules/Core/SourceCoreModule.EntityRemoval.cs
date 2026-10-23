namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        private SourceCommittedEntityRemoval committedEntityRemoval;

        private void InstallSourceCommittedEntityRemoval()
        {
            var removal = new SourceCommittedEntityRemoval(SourceEngine);
            try
            {
                removal.Install();
                committedEntityRemoval = removal;
            }
            catch
            {
                removal.Dispose();
                throw;
            }
        }
    }
}

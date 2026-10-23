using Celeste.Core.Diagnostics;

namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler : ISourceSceneDiagnostics
    {
        int ISourceSceneDiagnostics.EntityCount => Entities.Count;

        int ISourceSceneDiagnostics.GetTagCount(int tagIndex)
        {
            return CountTaggedEntities(tagIndex);
        }

        void ISourceSceneDiagnostics.LogEntities(ISourceObjectLog output)
        {
            Entities.LogEntities(output);
        }

        void ISourceSceneDiagnostics.LogComponents(ISourceObjectLog output)
        {
            Components.LogComponents(output);
        }
    }
}

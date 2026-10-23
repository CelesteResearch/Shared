using Celeste.Core.Diagnostics;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        public void LogEntities(ISourceObjectLog output)
        {
            foreach (var entity in tracker)
            {
                var obj = string.Concat(catalog.GetLogicalTypeName(entity.Key), " : ",
                    entity.Value.Count);
                output.Log(obj);
            }
        }
    }
}

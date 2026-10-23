using Celeste.Core.Diagnostics;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        public void LogEntities(ISourceObjectLog output)
        {
            foreach (var entity in tracker)
            {
                string obj = string.Concat((object)catalog.GetLogicalTypeName(entity.Key), (object)" : ",
                    (object)entity.Value.Count);
                output.Log(obj);
            }
        }
    }
}

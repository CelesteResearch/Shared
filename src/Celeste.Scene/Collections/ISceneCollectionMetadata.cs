using Celeste.Scene.Tracking;

namespace Celeste.Scene.Collections
{
    public interface ISceneCollectionMetadata
    {
        ISceneCollectionMetadataScope BindScene(SceneEntityCatalog catalog, object scene);
    }
}

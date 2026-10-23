namespace Celeste.Scene.Collections
{
    public interface ISceneCollectionMetadataScope
    {
        void RegisterEntities(object collection);
        void RegisterComponents(object collection);
        void RegisterTyped(object collection, System.Type elementType);
    }
}

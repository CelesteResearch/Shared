namespace Celeste.Game.Entities.Decoration.Decals
{
    public interface IOriginalDecalRegistrationPolicy
    {
        void AfterAwake(OriginalDecalEntity decal);
        void Apply(OriginalDecalEntity decal, int depthBeforeAdded);
    }
}

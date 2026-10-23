namespace Celeste.Core.Components
{
    public interface ISourceEntityUpdate
    {
        bool Active { get; }
        void BeforeEntityUpdate();
        void Update();
        void AfterEntityUpdate();
    }
}

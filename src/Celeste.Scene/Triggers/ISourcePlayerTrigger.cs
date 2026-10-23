using Celeste.Physics.Collision;

namespace Celeste.Scene.Triggers
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface ISourcePlayerTrigger<TPlayer> : ISourceEntityCollider
    {
        bool Triggered { get; set; }
        void OnEnter(TPlayer player);
        void OnStay(TPlayer player);
        void OnLeave(TPlayer player);
    }
}

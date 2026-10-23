using System.Numerics;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public interface IOriginalAngryOshiroConstructors
    {
        OriginalAngryOshiroState Create(Vector2 position, bool fromCutscene, IOriginalAngryOshiroProcess process);
    }
}

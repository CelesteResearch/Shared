using System.Numerics;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public sealed class OriginalAngryOshiroConstructors : IOriginalAngryOshiroConstructors
    {
        public OriginalAngryOshiroState Create(Vector2 position, bool fromCutscene, IOriginalAngryOshiroProcess process)
        {
            return new(position, fromCutscene, process);
        }
    }
}

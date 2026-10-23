using System.Numerics;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;

namespace Celeste.Everest.Gameplay.Enemies.AngryOshiro
{
    public sealed class EverestAngryOshiroConstructors : IOriginalAngryOshiroConstructors
    {
        public OriginalAngryOshiroState Create(Vector2 position, bool fromCutscene, IOriginalAngryOshiroProcess process)
        {
            return new EverestAngryOshiroState(position, fromCutscene, process);
        }
    }
}

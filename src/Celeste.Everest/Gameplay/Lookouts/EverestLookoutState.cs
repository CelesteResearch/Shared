using System.Numerics;
using Celeste.Game.Entities.Lookouts;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Everest.Gameplay.Lookouts
{
    public class EverestLookoutState : OriginalLookoutState
    {
        public EverestLookoutState(EntityData data, Vector2 offset, IOriginalLookoutProcess process)
            : base(data, offset, process)
        {
        }

        public override void Update()
        {
            if (talk.UI != null)
                talk.UI.Visible = !CollideCheck("Celeste.Solid");
            UpdateComponentsAndSprite();
        }
    }
}

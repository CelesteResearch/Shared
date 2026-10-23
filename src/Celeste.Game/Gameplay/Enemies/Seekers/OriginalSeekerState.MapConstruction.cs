using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        public OriginalSeekerState(EntityData data, Vector2 offset, IOriginalSeekerProcess engine)
            : this(data.Position + offset, data.NodesOffset(offset), engine)
        {
        }
    }
}

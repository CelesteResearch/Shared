using System.Numerics;
using Celeste.Core.Display;

namespace Celeste.Game.Gameplay.Decoration.MoonCreatures
{
    public interface IMoonCreatureTrailNode
    {
        Vector2 TrailPosition { get; set; }
        PackedColor TrailColor { get; }
    }
}

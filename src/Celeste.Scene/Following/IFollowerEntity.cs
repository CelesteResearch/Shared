using System.Numerics;
using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Following
{
    public interface IFollowerEntity
    {
        Vector2 Position { get; set; }
        SceneTagSet Tags { get; set; }
    }
}

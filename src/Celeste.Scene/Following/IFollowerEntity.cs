using Celeste.Scene.Scheduling;
using System;
using System.Numerics;

namespace Celeste.Scene.Following
{
    public interface IFollowerEntity
    {
        Vector2 Position { get; set; }
        SceneTagSet Tags { get; set; }
    }
}

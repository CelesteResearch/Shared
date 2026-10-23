using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Animation;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Lookouts
{
    public interface ILookoutInteractionState
    {
        SceneEntityState Entity { get; }
        IOriginalLookoutProcess Process { get; }
        ILookoutHudState Hud { get; set; }
        Sprite Sprite { get; }
        bool Interacting { get; set; }
        bool OnlyY { get; }
        List<Vector2> Nodes { get; }
        int Node { get; set; }
        float NodePercent { get; set; }
        bool Summit { get; }
        string AnimationPrefix { get; }
        float Acceleration { get; }
        float MaximumSpeed { get; }
        ILookoutHudState CreateHud();
        void OnViewStarted();
        void OnViewEnded();
    }
}

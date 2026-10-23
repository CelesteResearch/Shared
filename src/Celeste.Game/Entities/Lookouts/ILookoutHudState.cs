using System.Numerics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Lookouts
{
    public interface ILookoutHudState
    {
        SceneEntityState Entity { get; }
        IOriginalLookoutProcess Process { get; }
        void UpdateComponents();
        bool TrackMode { get; set; }
        float TrackPercent { get; set; }
        bool OnlyY { get; set; }
        float Easer { get; set; }
        float TimerUp { get; set; }
        float TimerDown { get; set; }
        float TimerLeft { get; set; }
        float TimerRight { get; set; }
        float MultUp { get; set; }
        float MultDown { get; set; }
        float MultLeft { get; set; }
        float MultRight { get; set; }
        float Left { get; set; }
        float Right { get; set; }
        float Up { get; set; }
        float Down { get; set; }
        Vector2 Aim { get; set; }
        AtlasEntry HalfDot { get; set; }
    }
}

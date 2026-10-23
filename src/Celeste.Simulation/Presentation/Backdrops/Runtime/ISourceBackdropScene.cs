using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Presentation.Backdrops.Runtime
{
    public interface ISourceBackdropScene : ISourceScene, ISourceEngineContextScene
    {
        CameraState Camera { get; }
        Vector2 CameraPosition { get; }
        Vector2 Wind { get; }
        IntRect Bounds { get; }
        string Level { get; }
        bool Dreaming { get; }
        bool Transitioning { get; }
        int CoreMode { get; }
        Vector2? PlayerPosition { get; }
        ISourceEntityPosition FirstPlayer { get; }
        bool Raining { get; set; }
        bool GetFlag(string flag);
        void NextColorGrade(string name);
        void SnapColorGrade(string name);
    }
}

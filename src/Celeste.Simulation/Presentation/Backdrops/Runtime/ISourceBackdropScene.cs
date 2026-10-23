using System.Numerics;
using Celeste.Core;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Presentation.Backdrops.Runtime
{
    public interface ISourceBackdropScene : ISourceScene, ISourceEngineContextScene
    {
        global::Celeste.Graphics.Geometry.TwoD.Camera.CameraState Camera { get; }
        Vector2 CameraPosition { get; }
        Vector2 Wind { get; }
        IntRect Bounds { get; }
        string Level { get; }
        bool Dreaming { get; }
        bool Transitioning { get; }
        int CoreMode { get; }
        Vector2? PlayerPosition { get; }
        global::Celeste.Core.Components.ISourceEntityPosition FirstPlayer { get; }
        bool Raining { get; set; }
        bool GetFlag(string flag);
        void NextColorGrade(string name);
        void SnapColorGrade(string name);
    }
}

using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Game.Execution.Levels.Transitions;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceBackdropScene
    {
        public BackdropRendererPresentation Background;
        public BackdropRendererPresentation Foreground;
        public OriginalLevelTransitionSequence TransitionSequence { get; }

        public void ConstructSourceBackdropRenderers()
        {
            Background = new();
            Foreground = new();
            Renderers.Add(Background);
            Renderers.Add(Foreground);
        }

        CameraState ISourceBackdropScene.Camera => Camera;
        Vector2 ISourceBackdropScene.CameraPosition => Camera.Position;
        Vector2 ISourceBackdropScene.Wind => Wind;
        IntRect ISourceBackdropScene.Bounds => Bounds;
        string ISourceBackdropScene.Level => Session.Level;
        bool ISourceBackdropScene.Dreaming => Session.Dreaming;
        bool ISourceBackdropScene.Transitioning => Transitioning;
        int ISourceBackdropScene.CoreMode => (int)CoreMode;

        bool ISourceBackdropScene.Raining
        {
            get => Raining;
            set => Raining = value;
        }

        bool ISourceBackdropScene.GetFlag(string flag)
        {
            return Session.GetFlag(flag);
        }

        void ISourceBackdropScene.NextColorGrade(string name)
        {
            NextColorGrade(name);
        }

        void ISourceBackdropScene.SnapColorGrade(string name)
        {
            SnapColorGrade(name);
        }

        ISourceEntityPosition ISourceBackdropScene.FirstPlayer
            => Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(RoomPlayerSession).FullName);


        Vector2? ISourceBackdropScene.PlayerPosition
        {
            get
            {
                var player =
                    Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                return player == null ? null : player.Position;
            }
        }
    }
}

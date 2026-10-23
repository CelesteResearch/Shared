using System;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceBackdropScene
    {
        public BackdropRendererPresentation Background;
        public BackdropRendererPresentation Foreground;
        public Transitions.OriginalLevelTransitionSequence TransitionSequence { get; }

        public void ConstructSourceBackdropRenderers()
        {
            Background = new BackdropRendererPresentation();
            Foreground = new BackdropRendererPresentation();
            Renderers.Add(Background);
            Renderers.Add(Foreground);
        }

        global::Celeste.Graphics.Geometry.TwoD.Camera.CameraState ISourceBackdropScene.Camera => Camera;
        System.Numerics.Vector2 ISourceBackdropScene.CameraPosition => Camera.Position;
        System.Numerics.Vector2 ISourceBackdropScene.Wind => Wind;
        global::Celeste.Core.Geometry.IntRect ISourceBackdropScene.Bounds => Bounds;
        string ISourceBackdropScene.Level => Session.Level;
        bool ISourceBackdropScene.Dreaming => Session.Dreaming;
        bool ISourceBackdropScene.Transitioning => Transitioning;
        int ISourceBackdropScene.CoreMode => (int)CoreMode;

        bool ISourceBackdropScene.Raining
        {
            get => Raining;
            set => Raining = value;
        }

        bool ISourceBackdropScene.GetFlag(string flag) => Session.GetFlag(flag);
        void ISourceBackdropScene.NextColorGrade(string name) => NextColorGrade(name);
        void ISourceBackdropScene.SnapColorGrade(string name) => SnapColorGrade(name);

        global::Celeste.Core.Components.ISourceEntityPosition ISourceBackdropScene.FirstPlayer
            => Scheduler.Entities.GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);


        System.Numerics.Vector2? ISourceBackdropScene.PlayerPosition
        {
            get
            {
                var player =
                    Scheduler.Entities.GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                return player == null ? null : player.Position;
            }
        }
    }
}

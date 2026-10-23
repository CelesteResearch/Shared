using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Simulation.Presentation.Effects.Mirrors;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Moving
{
    public class OriginalBladeTrackSpinnerState : OriginalTrackSpinnerState
    {
        public Sprite Sprite;
        private bool _hasStarted;
        private bool _trail;

        public OriginalBladeTrackSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(data, offset, engine)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("templeBlade"));
            Sprite.Play("idle");
            Depth = -50;
            OwnedComponents.Add(new MirrorReflectionState());
        }

        public override void Update()
        {
            base.Update();
            var level = (OriginalLevelSceneRoot)Scene;
            if (_trail && level.Clock.OnInterval(.04f, Engine))
                level.ParticlesBG.Emit(((IOriginalGameplayProcess)Engine).ParticleTypes.BladeTrackSpinner.P_Trail, 2,
                    Position, Vector2.One * 3f);
        }

        public override void OnTrackStart()
        {
            Sprite.Play("spin");
            if (_hasStarted)
            {
                var process = (IOriginalGameplayProcess)Engine;
                process.AudioSession.Play("event:/game/05_mirror_temple/bladespinner_spin", Position,
                    process.SaveContext);
            }

            _hasStarted = true;
            _trail = true;
        }

        public override void OnTrackEnd()
        {
            _trail = false;
        }
    }
}

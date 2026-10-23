using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Simulation.Presentation.Effects.Mirrors;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Moving
{
    public class OriginalStarRotateSpinnerState : OriginalRotateSpinnerState
    {
        public Sprite Sprite;
        private int _colorId;

        public OriginalStarRotateSpinnerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(data, offset, engine)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("moonBlade"));
            _colorId = ((ISourceRandomEnvironment)engine).Random.Next(3);
            Sprite.Play("idle" + _colorId);
            Depth = -50;
            OwnedComponents.Add(new MirrorReflectionState());
        }

        public override void Update()
        {
            base.Update();
            var level = (OriginalLevelSceneRoot)Scene;
            if (Moving && level.Clock.OnInterval(.03f, Engine))
                level.ParticlesBG.Emit(
                    ((IOriginalGameplayProcess)Engine).ParticleTypes.StarTrackSpinner.P_Trail[_colorId],
                    1, Position, Vector2.One * 3f);
            if (level.Clock.OnInterval(.8f, Engine))
            {
                _colorId++;
                _colorId %= 3;
                Sprite.Play("spin" + _colorId);
            }
        }
    }
}

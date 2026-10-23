using Celeste.Core.Randomness;
using System;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries
{
    public interface IOriginalStrawberryProcess : ISourceEngineContext,
        ISourceGameGraphicsEnvironment, ISourceWigglerPoolScope,
        ISourceScalarEnvironment, ISourceEasingEnvironment, ISourceCurveEnvironment,
        ISourceRumbleEnvironment, ISourceVectorEnvironment
    {
        ISourceRandom SpriteRandom { get; }
        OriginalParticleCatalog ParticleTypes { get; }
        OriginalGameAudioSession AudioSession { get; }
        IOriginalGameSaveContext SaveContext { get; }
        bool CheckStrawberry(Celeste.Core.Maps.MapEntityId id);
        void RegisterMoonBerryAchievement();
    }
}

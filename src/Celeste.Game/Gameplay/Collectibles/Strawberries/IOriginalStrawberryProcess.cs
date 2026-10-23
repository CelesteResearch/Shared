using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Oscillation;

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
        bool CheckStrawberry(MapEntityId id);
        void RegisterMoonBerryAchievement();
    }
}

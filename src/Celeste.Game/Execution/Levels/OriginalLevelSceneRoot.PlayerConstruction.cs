using System.Numerics;
using Celeste.Game.Audio;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Input.Gameplay;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Scene.Construction;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerConstructionScene
    {
        public RoomPlayerSession CreatePlayer(Vector2 position, PlayerSpriteMode spriteMode)
        {
            return ((IOriginalLevelLoadOverrideEnvironment)EngineContext)
                .LevelLoadOverrides.CreatePlayer(this, position, spriteMode);
        }

        public RoomPlayerSession CreateOriginalPlayer(Vector2 position, PlayerSpriteMode spriteMode)
        {
            return new(position,
                (IPlayerAssistSettings)EngineContext, ((IGameInputEnvironment)EngineContext).Input,
                EngineContext, PlatformWorld,
                OriginalAudioHandles.ChaseSounds,
                spriteMode);
        }
    }
}

using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Simulation.Gameplay.Hazards;

namespace Celeste.Game.Stories.Reflection.Fall
{
    public interface IReflectionFallWorld
    {
        Vector2 Position { get; }
        bool IgnoreJumpThrus { get; set; }
        bool InWater { get; }
        bool OnInterval(float interval);
        void CreateTrail();
        void RemoveAllFeathers();

        IDestructibleHazard FirstSpinnerAt(
            IntRect area);

        void Shake();
        void Rumble(ReflectionFallRumble rumble);
        void Freeze(float duration);
        void PlayAnimation(string id);
        void ShowFallEffects(bool visible);
        void StartCutscene(Action skip);
        void EndCutscene();
        void SetMusic(string eventName);
        void ApplySessionAudio();
        void AtEndOfFrame(Action action);
        void RemovePlayer();
        void UnloadLevel();
        void SetSessionRoom(string name);
        Bounds RoomBounds { get; }
        Vector2 GetSpawnPoint(Vector2 from);
        void SetRespawnPoint(Vector2 point);
        void LoadLevelWithoutIntro();
    }
}

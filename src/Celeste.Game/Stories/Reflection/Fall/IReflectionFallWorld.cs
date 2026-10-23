using System;
using System.Collections;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

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

        global::Celeste.Simulation.Gameplay.Hazards.IDestructibleHazard FirstSpinnerAt(
            global::Celeste.Core.Geometry.IntRect area);

        void Shake();
        void Rumble(global::Celeste.Game.Stories.Reflection.Fall.ReflectionFallRumble rumble);
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
        global::Celeste.Core.Geometry.Bounds RoomBounds { get; }
        Vector2 GetSpawnPoint(Vector2 from);
        void SetRespawnPoint(Vector2 point);
        void LoadLevelWithoutIntro();
    }
}

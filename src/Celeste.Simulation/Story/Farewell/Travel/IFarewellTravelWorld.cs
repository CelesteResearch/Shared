using System;
using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Simulation.Story.Farewell.Travel
{
    public interface IFarewellTravelWorld
    {
        Vector2 LevelOffset { get; }
        Bounds Bounds { get; }
        Vector2 CameraPosition { get; set; }
        bool Dreaming { set; }
        string SessionLevel { set; }
        Vector2 RespawnPoint { set; }
        bool FirstLevel { set; }
        int InventoryDashes { set; }
        bool HasWipe { get; }
        Vector4 WipeColor { set; }
        void QueueEndOfFrame(Action action);
        void RemovePlayer(IFarewellTravelPlayer player);
        void UnloadLevel();
        Vector2 GetSpawnPoint(Vector2 from);
        void LoadTransition();
        void AddPlayer(IFarewellTravelPlayer player);
        void CancelWipe();
        void FlashWhite();
        void Shake();
        void AddLightningStrike(Vector2 position, int seed, float height, float delay);
        void PlaySound(string name);
        void StartFadeOut(float duration, Action onComplete);

        void TeleportTransition(IFarewellTravelPlayer player,
            string room);
    }
}

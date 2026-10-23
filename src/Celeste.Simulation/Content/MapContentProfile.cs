using System;
using Celeste.Core.Maps;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Moving;
using System.Collections.Generic;

namespace Celeste.Simulation.Content
{
    // Runtime facts supplied once by the game-content loader; no file-format or engine dependencies.
    public sealed class MapContentProfile
    {
        public Func<Func<string, bool>, bool> TheoPedestalReleased { get; }
        public bool InventoryDreamDash { get; }
        public Func<int, MapElement, MapElement, bool> IsCrystalSpinner { get; }
        public Func<int, MapElement, CrystalSpinnerColor> CrystalSpinnerColor { get; }
        public Func<int, string, MapElement, MovingSpinnerStyle> MovingSpinnerStyle { get; }
        public Func<string, bool> PortalNormalMode { get; }
        public RidgeGateCollectiblesRule RidgeGateCollectibles { get; }
        public ConditionBlockRule ConditionBlock { get; }
        public ITriggerSourceIdentity TriggerSourceIdentity { get; }
        public IRoomSessionName RoomSessionName { get; }
        public IChapterStartRoomPolicy StartRoomPolicy { get; }
        public IRoomSceneSourceIdentity SceneSourceIdentity { get; }
        public IRuntimeRoomNamePolicy RuntimeRoomNamePolicy { get; }

        public global::Celeste.Simulation.Gameplay.Collectibles.Strawberry.IStrawberryPersistencePolicy
            StrawberryPersistencePolicy { get; }

        public IReadOnlyDictionary<string, string> EntityTypes { get; }
        public IReadOnlyDictionary<string, string> UnloadedEntityTypes { get; }

        public MapContentProfile(bool inventoryDreamDash,
            Func<int, MapElement, MapElement, bool> isCrystalSpinner,
            Func<int, MapElement, CrystalSpinnerColor> crystalSpinnerColor,
            Func<int, string, MapElement, MovingSpinnerStyle> movingSpinnerStyle,
            Func<string, bool> portalNormalMode,
            RidgeGateCollectiblesRule ridgeGateCollectibles, ConditionBlockRule conditionBlock,
            ITriggerSourceIdentity triggerSourceIdentity,
            IRoomSessionName roomSessionName, IChapterStartRoomPolicy startRoomPolicy,
            IRoomSceneSourceIdentity sceneSourceIdentity, IRuntimeRoomNamePolicy runtimeRoomNamePolicy,
            global::Celeste.Simulation.Gameplay.Collectibles.Strawberry.IStrawberryPersistencePolicy
                strawberryPersistencePolicy,
            IReadOnlyDictionary<string, string> entityTypes = null,
            IReadOnlyDictionary<string, string> unloadedEntityTypes = null,
            Func<Func<string, bool>, bool> theoPedestalReleased = null)
        {
            StrawberryPersistencePolicy = strawberryPersistencePolicy ??
                                          throw new ArgumentNullException(nameof(strawberryPersistencePolicy));
            TheoPedestalReleased = theoPedestalReleased;
            InventoryDreamDash = inventoryDreamDash;
            IsCrystalSpinner = isCrystalSpinner ?? throw new ArgumentNullException(nameof(isCrystalSpinner));
            CrystalSpinnerColor = crystalSpinnerColor ?? throw new ArgumentNullException(nameof(crystalSpinnerColor));
            MovingSpinnerStyle = movingSpinnerStyle ?? throw new ArgumentNullException(nameof(movingSpinnerStyle));
            PortalNormalMode = portalNormalMode ?? throw new ArgumentNullException(nameof(portalNormalMode));
            ConditionBlock = conditionBlock ?? throw new ArgumentNullException(nameof(conditionBlock));
            RidgeGateCollectibles =
                ridgeGateCollectibles ?? throw new ArgumentNullException(nameof(ridgeGateCollectibles));
            TriggerSourceIdentity =
                triggerSourceIdentity ?? throw new ArgumentNullException(nameof(triggerSourceIdentity));
            RoomSessionName = roomSessionName ?? throw new ArgumentNullException(nameof(roomSessionName));
            StartRoomPolicy = startRoomPolicy ?? throw new ArgumentNullException(nameof(startRoomPolicy));
            SceneSourceIdentity = sceneSourceIdentity ?? throw new ArgumentNullException(nameof(sceneSourceIdentity));
            RuntimeRoomNamePolicy =
                runtimeRoomNamePolicy ?? throw new ArgumentNullException(nameof(runtimeRoomNamePolicy));
            EntityTypes = entityTypes;
            UnloadedEntityTypes = unloadedEntityTypes ?? entityTypes;
        }

        public string ResolveEntityType(string sourceName, bool unloaded = false)
        {
            var types = unloaded ? UnloadedEntityTypes : EntityTypes;
            return sourceName != null && types != null && types.TryGetValue(sourceName, out string name)
                ? name
                : null;
        }
    }
}

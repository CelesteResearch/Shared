using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Scene.Tracking;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Formats.Map.Identifiers;

namespace Celeste.Everest.Gameplay.Platforms.Cassette
{
    public sealed class InstalledCassetteListenerState : SourceComponentState
    {
        private static OriginalCassetteBlockManagerState FirstManager(List<object> entities) =>
            entities.Count == 0 ? null : entities[0] as OriginalCassetteBlockManagerState;

        public enum Modes
        {
            Enabled,
            WillDisable,
            Disabled,
            WillEnable
        }

        public Action<bool> OnStart;
        public Action OnFinish;
        public Action OnWillActivate;
        public Action OnWillDeactivate;
        public Action OnActivated;
        public Action OnDeactivated;
        public int Index;
        public bool Activated;
        public Modes Mode;
        public MapEntityId ID;
        public float Tempo;

        public InstalledCassetteListenerState(int index, float tempo = 1f)
            : this(EntityIdCodec.None, index, tempo)
        {
        }

        public InstalledCassetteListenerState(MapEntityId id, int index, float tempo = 1f)
            : base(false, false)
        {
            Index = index;
            Tempo = tempo;
            ID = id;
        }

        public void SetActivated(bool activated)
        {
            if (activated != Activated)
            {
                Activated = activated;
                if (activated)
                {
                    Mode = Modes.Enabled;
                    OnActivated?.Invoke();
                }
                else
                {
                    Mode = Modes.Disabled;
                    OnDeactivated?.Invoke();
                }
            }
        }

        public void Start(bool activated)
        {
            Activated = activated;
            Mode = ((!activated) ? Modes.Disabled : Modes.Enabled);
            OnStart?.Invoke(activated);
        }

        public void Finish()
        {
            Activated = false;
            Mode = Modes.Disabled;
            OnFinish?.Invoke();
        }

        public void WillToggle()
        {
            if (Activated)
            {
                Mode = Modes.WillDisable;
                OnWillDeactivate?.Invoke();
            }
            else
            {
                Mode = Modes.WillEnable;
                OnWillActivate?.Invoke();
            }
        }

        public override void EntityAdded(object scene)
        {
            base.EntityAdded(scene);
            if (scene is IInstalledCassetteManagerScene level)
            {
                level.HasCassetteBlocks = true;
                level.CassetteBlockBeats = Math.Max(Index + 1, level.CassetteBlockBeats);
                if (level.CassetteBlockTempo == 1f)
                {
                    level.CassetteBlockTempo = Tempo;
                }

                var scheduler = ((ISourceScene)scene).SourceScene;
                if (level.ShouldCreateCassetteManager &&
                    FirstManager(scheduler.Entities.GetTrackedEntities("Celeste.CassetteBlockManager")) == null &&
                    !scheduler.Entities.Entities.Any(e => e is OriginalCassetteBlockManagerState) &&
                    !scheduler.GetToAdd().Any(e => e is OriginalCassetteBlockManagerState))
                {
                    scheduler.QueueSourceEntity(((IOriginalCassetteManagerEnvironment)level.EngineContext)
                        .CassetteManagers
                        .Create());
                }
            }
        }
    }
}

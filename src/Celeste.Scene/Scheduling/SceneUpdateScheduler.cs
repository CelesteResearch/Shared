using System;
using System.Collections.Generic;
using System.Threading;
using Celeste.Core.Components;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Components;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler : ISourceScene
    {
        private readonly List<object> toAdd = [];
        private readonly List<object> toAwake = [];
        private readonly List<object> toRemove = [];
        private readonly HashSet<object> adding = [];
        private readonly HashSet<object> removing = [];
        private readonly ISourceEntityQueuePolicy queuePolicy;
        private readonly ISourceEntityAddMetadata addMetadata;
        private readonly SourceEntityListProcessState entityListProcess;
        private readonly List<object>[] tagLists;
        private readonly bool[] tagUnsorted;
        private bool areAnyUnsorted;

        private object actualSceneIdentity;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public object ActualSceneIdentity => actualSceneIdentity;
        public SceneUpdateScheduler SourceScene => this;
        public ISourceComponentIndex ComponentIndex => Components;
        public SceneEntityRegistry Entities { get; }
        public SceneEntityCatalog Catalog { get; }
        public SceneComponentTracker Components { get; }
        public SceneUpdatePolicy Policy { get; }
        public SceneClock Clock { get; } = new();
        public bool Paused { get; set; }
        public bool Focused { get; private set; }
        public Action OnEndOfFrame;

        public SceneUpdateScheduler(SceneEntityCatalog catalog, SceneUpdatePolicy policy,
            ISourceEntityQueuePolicy queuePolicy, ISourceEntityAddMetadata addMetadata,
            SourceEntityListProcessState entityListProcess)
        {
            Catalog = catalog;
            Policy = policy;
            runPasses = policy?.EntityUpdateEvents == true ? RunInstalledPasses : RunPasses;
            this.queuePolicy = queuePolicy;
            this.addMetadata = addMetadata;
            this.entityListProcess = entityListProcess;
            tagLists = new List<object>[entityListProcess.BitTags.TotalTags];
            tagUnsorted = new bool[entityListProcess.BitTags.TotalTags];
            for (var i = 0; i < tagLists.Length; i++) tagLists[i] = [];
            var trackingSnapshot = catalog.CaptureTrackingSnapshot();
            Entities = new(catalog, entityListProcess, trackingSnapshot);
            Components = new(catalog, trackingSnapshot);
            catalog.Initialize(Entities);
            Entities.BindSourceTrackerScene(this);
        }

        public void BindActualSceneIdentity(object scene)
        {
            if (scene is not ISourceScene owner || !ReferenceEquals(owner.SourceScene, this))
                throw new ArgumentException("The actual source Scene must own this EntityList.", nameof(scene));
            if (ReferenceEquals(ActualSceneIdentity, scene)) return;
            if (ActualSceneIdentity != null || Entities.Entities.Count != 0 || toAdd.Count != 0)
                throw new InvalidOperationException("Bind the actual Scene before it queues entities.");
            actualSceneIdentity = scene;
            var metadata = Catalog.CollectionMetadata.BindScene(Catalog, scene);
            Entities.BindCollectionMetadata(metadata);
            Components.BindCollectionMetadata(metadata);
            Entities.RegisterSourceEntityEnumerable(toAdd);
            Entities.RegisterSourceEntityEnumerable(toAwake);
            Entities.RegisterSourceEntityEnumerable(toRemove);
            foreach (var list in tagLists) Entities.RegisterSourceEntityEnumerable(list);
        }

        public List<object> GetToAdd()
        {
            return toAdd;
        }

        public List<object> GetToRemove()
        {
            return toRemove;
        }

        public void QueueSourceEntity(ISourceEntityUpdate entity)
        {
            AddEntity(entity);
        }

        public void AddEntity(object entity)
        {
            if (queuePolicy.RejectNullEntity && entity == null)
                throw new ArgumentNullException("entity");
            if (!adding.Contains(entity) && !Entities.Contains(entity))
            {
                addMetadata.Handle((ISourceEntitySourceData)entity);
                adding.Add(entity);
                toAdd.Add(entity);
            }
        }

        public bool RemoveEntity(object entity)
        {
            if (!removing.Contains(entity) && Entities.Contains(entity))
            {
                removing.Add(entity);
                toRemove.Add(entity);
                return true;
            }

            return false;
        }

        public bool RemoveScheduledEntity(object entity)
        {
            return RemoveEntity(entity);
        }

        public void AddEntities(IEnumerable<object> entities)
        {
            foreach (var entity in entities) AddEntity(entity);
        }

        public void RemoveEntities(IEnumerable<object> entities)
        {
            foreach (var entity in entities) RemoveEntity(entity);
        }

        public void AddEntities(params object[] entities)
        {
            foreach (var entity in entities) AddEntity(entity);
        }

        public void RemoveEntities(params object[] entities)
        {
            foreach (var entity in entities) RemoveEntity(entity);
        }

        public void CommitQueuedEntityLists()
        {
            if (toAdd.Count > 0)
            {
                for (var i = 0; i < toAdd.Count; i++)
                {
                    var entity = toAdd[i];
                    if (!Entities.Contains(entity))
                    {
                        Entities.AddCommitted(entity);
                        if (ActualSceneIdentity != null)
                        {
                            TagAdded(entity);
                            Entities.Track(entity);
                            DispatchEntityAdded(entity);
                        }
                    }
                }

                Entities.MarkUnsorted();
            }

            if (toRemove.Count > 0)
            {
                for (var i = 0; i < toRemove.Count; i++)
                {
                    var entity = toRemove[i];
                    if (Entities.RemoveCommitted(entity) && ActualSceneIdentity != null)
                    {
                        DispatchEntityRemoved(entity);
                        TagRemoved(entity);
                        Entities.Untrack(entity);
                        ((ISourceEngineContextScene)ActualSceneIdentity)
                            .EngineContext.EntityPools.EntityRemoved(entity);
                    }
                }

                toRemove.Clear();
                removing.Clear();
            }

            Entities.UpdateLists();
            if (toAdd.Count > 0)
            {
                toAwake.AddRange(toAdd);
                toAdd.Clear();
                adding.Clear();
                var diagnostics = SourceFrameDiagnostics.Current;
                long awakeStarted = 0;
                var measuringAwake = diagnostics?.BeginLevelLoadAwake(out awakeStarted) ?? false;
                try
                {
                    foreach (var entity in toAwake)
                        if (ReferenceEquals(((ISceneEntityAssociation)entity).Scene, ActualSceneIdentity))
                            DispatchEntityAwake(entity);
                }
                finally
                {
                    if (measuringAwake) diagnostics.EndLevelLoadAwake(awakeStarted);
                }

                toAwake.Clear();
            }
        }

        private void DispatchEntityAdded(object entity)
        {
            if (entity is SceneEntityState actual) actual.Added(ActualSceneIdentity);
            else ((ISourceEntityAdded)entity).Added(ActualSceneIdentity, () => CommitEntityAdded(entity));
        }

        public void CommitEntityAdded(object entity)
        {
            ((ISceneEntityAssociation)entity).Scene = ActualSceneIdentity;
            foreach (var component in ((ISourceOwnedComponentList)entity).OwnedComponents)
                component.EntityAdded(ActualSceneIdentity);
            ((ISceneEntityDepthScene)((ISceneEntityAssociation)entity).Scene).SetEntityActualDepth(entity,
                ((ISceneEntityDepth)entity).DepthState);
        }

        private void DispatchEntityRemoved(object entity)
        {
            if (entity is SceneEntityState actual) actual.Removed(ActualSceneIdentity);
            else ((ISourceEntityRemoved)entity).Removed(ActualSceneIdentity, () => CommitEntityRemoved(entity));
        }

        public void CommitEntityRemoved(object entity)
        {
            foreach (var component in ((ISourceOwnedComponentList)entity).OwnedComponents)
                component.EntityRemoved(ActualSceneIdentity);
            ((ISceneEntityAssociation)entity).Scene = null;
        }

        private void DispatchEntityAwake(object entity)
        {
            if (entity is SceneEntityState actual) actual.Awake(ActualSceneIdentity);
            else
                ((ISourceEntityAwake)entity).Awake(() =>
                {
                    foreach (var component in ((ISourceOwnedComponentList)entity).OwnedComponents)
                        component.EntityAwake();
                });
        }

        public void DispatchSceneBegin()
        {
            Focused = true;
            foreach (var entity in Entities.Entities)
                if (entity is SceneEntityState actual) actual.SceneBegin(ActualSceneIdentity);
                else ((ISceneEntityBeginLifecycle)entity).SceneBegin(ActualSceneIdentity);
        }

        public void DispatchSceneEnd()
        {
            Focused = false;
            foreach (var entity in Entities.Entities)
                if (entity is SceneEntityState actual) actual.SceneEnd(ActualSceneIdentity);
                else
                    ((ISourceEntitySceneEnd)entity).SceneEnd(ActualSceneIdentity, () =>
                    {
                        foreach (var component in ((ISourceOwnedComponentList)entity).OwnedComponents)
                            component.SceneEnd(ActualSceneIdentity);
                    });
        }

        public void ClearCommittedEntitiesAfterSceneEnd()
        {
            foreach (var entity in Entities.Entities)
                ((ISceneEntityAssociation)entity).Scene = null;
            Entities.ClearCommittedListAfterSceneEnd();
        }

        private void TagAdded(object entity)
        {
            for (var i = 0; i < entityListProcess.BitTags.TotalTags; i++)
                if ((((ISceneEntityTags)entity).Tags.Bits & (1 << i)) != 0)
                {
                    tagLists[i].Add(entity);
                    areAnyUnsorted = true;
                    tagUnsorted[i] = true;
                }
        }

        private void TagRemoved(object entity)
        {
            for (var i = 0; i < entityListProcess.BitTags.TotalTags; i++)
                if ((((ISceneEntityTags)entity).Tags.Bits & (1 << i)) != 0)
                    tagLists[i].Remove(entity);
        }

        public void SetEntityActualDepth(object entity, SceneEntityDepthState fields)
        {
            Entities.AllocateSourceActualDepth(fields);
            Entities.MarkUnsorted();
            for (var i = 0; i < entityListProcess.BitTags.TotalTags; i++)
                if ((((ISceneEntityTags)entity).Tags.Bits & (1 << i)) != 0)
                    MarkTagUnsorted(i);
        }

        public void SetEntityDepth(object entity, int depth)
        {
            ((ISceneEntityDepth)entity).DepthState.SetDepth(depth, ((ISceneEntityAssociation)entity).Scene, entity);
        }

        public void SetEntityRawDepth(object entity, int depth)
        {
            ((ISceneEntityDepth)entity).DepthState.RawDepth = depth;
        }

        public void SetEntityRawTags(object entity, SceneTagSet tags)
        {
            ((ISceneEntityTagFields)entity).SetRawTags(tags);
        }

        public int CountTaggedEntities(int tagIndex)
        {
            return tagLists[tagIndex].Count;
        }

        internal void MarkTagUnsorted(int index)
        {
            areAnyUnsorted = true;
            tagUnsorted[index] = true;
        }

        public void SetEntityTags(object identity, SceneTagSet value)
        {
            for (var i = 0; i < entityListProcess.BitTags.TotalTags; i++)
            {
                var bit = 1 << i;
                var now = ((int)value & bit) != 0;
                var before = ((int)((ISceneEntityTags)identity).Tags & bit) != 0;
                if (before == now) continue;
                if (now) tagLists[i].Add(identity);
                else tagLists[i].Remove(identity);
            }
        }

        public void HandleEntityGraphicsReset()
        {
            foreach (var entity in Entities.Entities)
                ((ISourceEntityGraphicsLifecycle)entity).HandleGraphicsReset();
        }

        public void HandleEntityGraphicsCreate()
        {
            foreach (var entity in Entities.Entities)
                ((ISourceEntityGraphicsLifecycle)entity).HandleGraphicsCreate();
        }

        public void BeforeUpdate(float deltaTime, float rawDeltaTime,
            Action afterClock = null, Action rendererUpdateLists = null)
        {
            Clock.BeforeUpdate(deltaTime, rawDeltaTime, Paused);
            afterClock?.Invoke();
            BeginSceneFrame();
            rendererUpdateLists?.Invoke();
        }

        public void BeginSceneFrame()
        {
            CommitQueuedEntityLists();
            UpdateTagLists();
        }

        public void CommitEntityListsForLevel()
        {
            CommitQueuedEntityLists();
        }

        public void DispatchAfterUpdate()
        {
            Interlocked.Exchange(ref OnEndOfFrame, null)?.Invoke();
        }

        private readonly Action<SceneUpdatePass[]> runPasses;

        private void RunPasses(SceneUpdatePass[] passes)
        {
            foreach (var pass in passes)
            {
                var tagIndex = pass.TagIndex;
                var list = tagIndex < 0 ? Entities.Entities : tagLists[tagIndex];
                var requiredMembershipIndex = pass.RequiredMembershipIndex;
                var required = requiredMembershipIndex < 0 ? null : tagLists[requiredMembershipIndex];
                foreach (var entity in list)
                    if ((required == null || required.Contains(entity)) &&
                        (!pass.CheckActive || ((ISourceEntityUpdate)entity).Active))
                        ((ISourceEntityUpdate)entity).Update();
            }
        }

        private void RunInstalledPasses(SceneUpdatePass[] passes)
        {
            foreach (var pass in passes)
            {
                var tagIndex = pass.TagIndex;
                var list = tagIndex < 0 ? Entities.Entities : tagLists[tagIndex];
                var requiredMembershipIndex = pass.RequiredMembershipIndex;
                var required = requiredMembershipIndex < 0 ? null : tagLists[requiredMembershipIndex];
                if (tagIndex >= 0)
                {
                    foreach (var identity in list)
                        if ((required == null || required.Contains(identity)) &&
                            (!pass.CheckActive || ((ISourceEntityUpdate)identity).Active))
                            ((ISourceEntityUpdate)identity).Update();
                }
                else
                {
                    foreach (var identity in list)
                    {
                        if (required != null && !required.Contains(identity)) continue;
                        var entity = (ISourceEntityUpdate)identity;
                        entity.BeforeEntityUpdate();
                        if (!pass.CheckActive || entity.Active) entity.Update();
                        entity.AfterEntityUpdate();
                    }
                }
            }
        }

        private void UpdateTagLists()
        {
            if (!areAnyUnsorted) return;
            for (var i = 0; i < tagLists.Length; i++)
                if (tagUnsorted[i])
                {
                    tagLists[i].Sort(entityListProcess.CompareDepth);
                    tagUnsorted[i] = false;
                }

            areAnyUnsorted = false;
        }

        public void UpdateCommitted(SceneModeKey mode = default)
        {
            runPasses(Policy.Passes(mode, false, false));
        }

        public void Update(SceneModeKey mode = default)
        {
            UpdateCommitted(mode);
        }

        public void UpdateWithoutCommit(SceneModeKey mode, bool alternate = false)
        {
            runPasses(Policy.Passes(mode, true, alternate));
        }
    }
}

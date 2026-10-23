using System;
using System.Numerics;
using System.Threading;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Everest.Runtime.Levels.Update
{
    public sealed class EverestLevelUpdateEvents
    {
        public delegate void TransitionToHandler(OriginalLevelSceneRoot level, OriginalLevelRoomData next,
            Vector2 direction);

        public event TransitionToHandler OnTransitionTo;

        public void TransitionTo(OriginalLevelSceneRoot level, OriginalLevelRoomData next, Vector2 direction)
        {
            OnTransitionTo?.Invoke(level, next, direction);
        }

        public delegate BackdropPresentation
            LoadBackdropHandler(
                OriginalChapterMapData map,
                BinaryPackerElement child,
                BinaryPackerElement above);

        public event LoadBackdropHandler OnLoadBackdrop;

        public BackdropPresentation LoadBackdrop(
            OriginalChapterMapData map,
            BinaryPackerElement child,
            BinaryPackerElement above)
        {
            var handler = OnLoadBackdrop;
            if (handler == null) return null;
            var args = new object[] { map, child, above };
            var invocationList = handler.GetInvocationList();
            for (var index = 0; index < invocationList.Length; index++)
            {
                var value =
                    (BackdropPresentation)invocationList[
                            index]
                        .DynamicInvoke(args);
                if (value != null) return value;
            }

            return null;
        }

        public delegate bool LoadEntityHandler(OriginalLevelSceneRoot level,
            OriginalLevelRoomData levelData, Vector2 offset, OriginalLevelEntityData entityData);

        private LoadEntityInvocationSnapshot loadEntityInvocation;

        public event LoadEntityHandler OnLoadEntity
        {
            add
            {
                LoadEntityInvocationSnapshot previous, next;
                do
                {
                    previous = Volatile.Read(ref loadEntityInvocation);
                    var handler = (LoadEntityHandler)Delegate.Combine(previous?.Handler, value);
                    if (ReferenceEquals(handler, previous?.Handler)) return;
                    next = handler == null ? null : new LoadEntityInvocationSnapshot(handler);
                } while (!ReferenceEquals(Interlocked.CompareExchange(ref loadEntityInvocation, next, previous),
                             previous));
            }
            remove
            {
                LoadEntityInvocationSnapshot previous, next;
                do
                {
                    previous = Volatile.Read(ref loadEntityInvocation);
                    var handler = (LoadEntityHandler)Delegate.Remove(previous?.Handler, value);
                    if (ReferenceEquals(handler, previous?.Handler)) return;
                    next = handler == null ? null : new LoadEntityInvocationSnapshot(handler);
                } while (!ReferenceEquals(Interlocked.CompareExchange(ref loadEntityInvocation, next, previous),
                             previous));
            }
        }

        public bool LoadEntity(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
            Vector2 offset, OriginalLevelEntityData entityData)
        {
            var snapshot = Volatile.Read(ref loadEntityInvocation);
            if (snapshot == null)
                return false;
            var invocationList = snapshot.InvocationList;
            for (var i = 0; i < invocationList.Length; i++)
                if (((LoadEntityHandler)invocationList[i])(level, levelData, offset, entityData))
                    return true;
            return false;
        }

        public event Action<OriginalLevelSceneRoot> OnBeforeUpdate;
        public event Action<OriginalLevelSceneRoot> OnAfterUpdate;

        internal void BeforeUpdate(OriginalLevelSceneRoot level)
        {
            OnBeforeUpdate?.Invoke(level);
        }

        internal void AfterUpdate(OriginalLevelSceneRoot level)
        {
            OnAfterUpdate?.Invoke(level);
        }
    }
}

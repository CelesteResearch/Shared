using System;
using System.Diagnostics;

namespace Celeste.Core.Framework.Timing
{
    // All operations run on the game thread, including DebugRC's scheduled Lua commands.
    public sealed class SourceFrameDiagnostics
    {
        public const int Capacity = 16384;
        private SourceFrameSample[] samples;
        private int count;
        private long sequence;
        private ISourceThreadCycleClock threadCycleClock;

        internal void BindThreadCycleClock(ISourceThreadCycleClock clock) => threadCycleClock = clock;

        internal ulong ReadThreadCycles(byte bit, ref byte validity)
        {
            if (threadCycleClock != null && threadCycleClock.TryRead(out ulong cycles))
            {
                validity |= bit;
                return cycles;
            }

            return 0;
        }

        private long audioUpdateTicks;
        private int audioUpdateDepth, audioUpdateCount;
        private long sceneEntityUpdateTicks;
        private int sceneEntityUpdateDepth, sceneEntityUpdateCount;
        private long reflectionTentaclesUpdateTicks;
        private int reflectionTentaclesUpdateDepth, reflectionTentaclesUpdateCount;
        private long reflectionTentaclesVerticesTicks;
        private int reflectionTentaclesVerticesDepth, reflectionTentaclesVerticesCount;

        private long lightOccludeUpdateTicks;
        private int lightOccludeUpdateDepth, lightOccludeUpdateCount;
        private long cassetteBlockVisualUpdateTicks;
        private int cassetteBlockVisualUpdateDepth, cassetteBlockVisualUpdateCount;

        private long reflectionTentaclesRenderTicks;
        private int reflectionTentaclesRenderDepth, reflectionTentaclesRenderCount;
        private long customBatchEntityRenderTicks;
        private int customBatchEntityRenderDepth, customBatchEntityRenderCount;
        private long primitiveNativeSubmitTicks;
        private int primitiveNativeSubmitDepth, primitiveNativeSubmitCount;
        private long primitivePresentationRecordTicks;
        private int primitivePresentationRecordDepth, primitivePresentationRecordCount;

        private long transitionEndOfFrameTicks;
        private int transitionEndOfFrameDepth, transitionEndOfFrameCount;
        private long transitionStartTicks;
        private int transitionStartDepth, transitionStartCount;
        private long transitionEventsTicks;
        private int transitionEventsDepth, transitionEventsCount;

        [ThreadStatic] private static SourceFrameDiagnostics current;
        private SourceLevelLoadSample levelLoads;
        private int loadDepth;
        private long loadStarted;
        private SourceLevelLoadPhase loadPhase;
        private long loadPhaseStarted;
        private int loadAwakeDepth;
        private int loadPlatformAttachmentDepth;
        private int loadGroupAwakeDepth;
        private int frameSubmissions;
        private long submissionTicks;
        private long engineBeforeRenderTicks;
        private int engineBeforeRenderDepth;
        private long sceneRenderTicks;
        private int sceneRenderDepth;
        private long engineAfterRenderTicks;
        private int engineAfterRenderDepth;
        private long gameplayRenderTicks;
        private int gameplayRenderDepth;
        private long lightingRenderTicks;
        private int lightingRenderDepth;
        private long gameplayEntityRenderTicks;
        private int gameplayEntityRenderDepth;
        private long gameplayEndBatchTicks;
        private int gameplayEndBatchDepth;
        private long customBatchEntryFlushTicks;
        private int customBatchEntryFlushDepth;
        private long customBatchCaptureTicks;
        private int customBatchCaptureDepth;
        private long customBatchMaskTicks;
        private int customBatchMaskDepth;
        private long customBatchFilterTicks;
        private int customBatchFilterDepth;
        private int spriteBatchQuads, spriteBatchTextureGroups, spriteBatchFlushCount;
        private long spriteBatchFlushTicks;
        private int spriteBatchFlushDepth;


        public static SourceFrameDiagnostics Current => current;
        private bool MeasuringLoad => Enabled && loadDepth > 0;

        internal void BeginFrame()
        {
            levelLoads = default;
            loadDepth = 0;
            loadAwakeDepth = 0;
            loadPlatformAttachmentDepth = 0;
            loadGroupAwakeDepth = 0;
            frameSubmissions = 0;
            submissionTicks = 0;
            engineBeforeRenderTicks = 0;
            engineBeforeRenderDepth = 0;
            sceneRenderTicks = 0;
            sceneRenderDepth = 0;
            engineAfterRenderTicks = 0;
            engineAfterRenderDepth = 0;
            gameplayRenderTicks = 0;
            gameplayRenderDepth = 0;
            lightingRenderTicks = 0;
            gameplayEntityRenderTicks = 0;
            gameplayEndBatchTicks = 0;
            customBatchEntryFlushTicks = 0;
            customBatchCaptureTicks = 0;
            customBatchMaskTicks = 0;
            customBatchFilterTicks = 0;
            spriteBatchQuads = 0;
            spriteBatchTextureGroups = 0;
            spriteBatchFlushCount = 0;
            spriteBatchFlushTicks = 0;

            lightingRenderDepth = 0;
            gameplayEntityRenderDepth = 0;
            gameplayEndBatchDepth = 0;
            customBatchEntryFlushDepth = 0;
            customBatchCaptureDepth = 0;
            customBatchMaskDepth = 0;
            customBatchFilterDepth = 0;
            spriteBatchFlushDepth = 0;


            reflectionTentaclesRenderTicks = 0;
            reflectionTentaclesRenderDepth = 0;
            reflectionTentaclesRenderCount = 0;
            customBatchEntityRenderTicks = 0;
            customBatchEntityRenderDepth = 0;
            customBatchEntityRenderCount = 0;
            primitiveNativeSubmitTicks = 0;
            primitiveNativeSubmitDepth = 0;
            primitiveNativeSubmitCount = 0;
            primitivePresentationRecordTicks = 0;
            primitivePresentationRecordDepth = 0;
            primitivePresentationRecordCount = 0;

            audioUpdateTicks = 0;
            audioUpdateDepth = 0;
            audioUpdateCount = 0;
            sceneEntityUpdateTicks = 0;
            sceneEntityUpdateDepth = 0;
            sceneEntityUpdateCount = 0;
            reflectionTentaclesUpdateTicks = 0;
            reflectionTentaclesUpdateDepth = 0;
            reflectionTentaclesUpdateCount = 0;
            reflectionTentaclesVerticesTicks = 0;
            reflectionTentaclesVerticesDepth = 0;
            reflectionTentaclesVerticesCount = 0;

            lightOccludeUpdateTicks = 0;
            lightOccludeUpdateDepth = 0;
            lightOccludeUpdateCount = 0;
            cassetteBlockVisualUpdateTicks = 0;
            cassetteBlockVisualUpdateDepth = 0;
            cassetteBlockVisualUpdateCount = 0;

            transitionEndOfFrameTicks = 0;
            transitionEndOfFrameDepth = 0;
            transitionEndOfFrameCount = 0;
            transitionStartTicks = 0;
            transitionStartDepth = 0;
            transitionStartCount = 0;
            transitionEventsTicks = 0;
            transitionEventsDepth = 0;
            transitionEventsCount = 0;

            current = this;
        }

        internal void EndFrame()
        {
            current = null;
            lightOccludeUpdateDepth = 0;
            cassetteBlockVisualUpdateDepth = 0;
            audioUpdateDepth = 0;
            sceneEntityUpdateDepth = 0;
            reflectionTentaclesUpdateDepth = 0;
            reflectionTentaclesVerticesDepth = 0;
            transitionEndOfFrameDepth = 0;
            transitionStartDepth = 0;
            transitionEventsDepth = 0;
            reflectionTentaclesRenderDepth = 0;
            customBatchEntityRenderDepth = 0;
            primitiveNativeSubmitDepth = 0;
            primitivePresentationRecordDepth = 0;
            loadDepth = 0;
            loadAwakeDepth = 0;
            loadPlatformAttachmentDepth = 0;
            loadGroupAwakeDepth = 0;
            engineBeforeRenderDepth = 0;
            sceneRenderDepth = 0;
            engineAfterRenderDepth = 0;
            gameplayRenderDepth = 0;
            lightingRenderDepth = 0;
            gameplayEntityRenderDepth = 0;
            gameplayEndBatchDepth = 0;
            customBatchEntryFlushDepth = 0;
            customBatchCaptureDepth = 0;
            customBatchMaskDepth = 0;
            customBatchFilterDepth = 0;
            spriteBatchFlushDepth = 0;
        }

        private System.Collections.Generic.Dictionary<Type, int> entityUpdateTypeSlots;
        private Type[] entityUpdateTypes;
        private long[] entityUpdateTypeTicks;
        private int[] entityUpdateTypeCounts;
        private bool entityUpdateTypesEnabled;
        private int entityUpdateTypePassDepth, entityUpdateTypePassLimit;
        private int entityUpdateTypePassCount, entityUpdateTypeUncoveredCount, entityUpdateTypeNestedPassCount;

        public readonly struct EntityUpdateTypeSample
        {
            public readonly Type ActualType;
            public readonly long Ticks;
            public readonly int Count;

            internal EntityUpdateTypeSample(Type actualType, long ticks, int count)
            {
                ActualType = actualType;
                Ticks = ticks;
                Count = count;
            }
        }

        public void StartEntityUpdateTypes(Type[] actualTypes, int maximumPasses = 60)
        {
            if (entityRenderTypesEnabled || entityRenderTypePassActive)
                throw new InvalidOperationException(
                    "Stop render type sampling before replacing the shared type table.");
            if (!Enabled || entityUpdateTypePassDepth != 0)
                throw new InvalidOperationException("Start type diagnostics after Start, outside an entity pass.");
            if (actualTypes == null) throw new ArgumentNullException(nameof(actualTypes));
            if (maximumPasses < 1 || maximumPasses > 60)
                throw new ArgumentOutOfRangeException(nameof(maximumPasses));
            var slots = new System.Collections.Generic.Dictionary<Type, int>(actualTypes.Length);
            foreach (var type in actualTypes)
            {
                if (type == null)
                    throw new ArgumentException("Actual entity types cannot contain null.", nameof(actualTypes));
                if (!slots.ContainsKey(type)) slots.Add(type, slots.Count);
            }

            var types = new Type[slots.Count];
            foreach (var entry in slots) types[entry.Value] = entry.Key;
            entityUpdateTypeSlots = slots;
            entityUpdateTypes = types;
            entityUpdateTypeTicks = new long[types.Length];
            entityUpdateTypeCounts = new int[types.Length];
            entityUpdateTypePassLimit = maximumPasses;
            entityUpdateTypePassCount = entityUpdateTypeUncoveredCount = entityUpdateTypeNestedPassCount = 0;
            entityUpdateTypesEnabled = true;
        }

        public void StopEntityUpdateTypes() => entityUpdateTypesEnabled = false;

        private void ResetEntityUpdateTypes()
        {
            if (entityUpdateTypePassDepth != 0)
                throw new InvalidOperationException("Restart diagnostics outside an entity pass.");
            entityUpdateTypesEnabled = false;
            entityUpdateTypeSlots = null;
            entityUpdateTypes = null;
            entityUpdateTypeTicks = null;
            entityUpdateTypeCounts = null;
            entityUpdateTypePassLimit = entityUpdateTypePassDepth = 0;
            entityUpdateTypePassCount = entityUpdateTypeUncoveredCount = entityUpdateTypeNestedPassCount = 0;
        }

        public bool BeginEntityUpdateTypePass()
        {
            if (!Enabled || !entityUpdateTypesEnabled) return false;
            if (entityUpdateTypePassDepth != 0)
            {
                entityUpdateTypePassDepth++;
                entityUpdateTypeNestedPassCount++;
                return true;
            }

            if (entityUpdateTypePassCount >= entityUpdateTypePassLimit) return false;
            entityUpdateTypePassCount++;
            entityUpdateTypePassDepth = 1;
            return true;
        }

        public void EndEntityUpdateTypePass() => entityUpdateTypePassDepth--;

        public bool BeginEntityUpdateType(object entity, out int slot, out long started)
        {
            slot = -1;
            started = 0;
            if (!Enabled || !entityUpdateTypesEnabled || entityUpdateTypePassDepth != 1) return false;
            if (!entityUpdateTypeSlots.TryGetValue(entity.GetType(), out slot))
            {
                slot = -1;
                entityUpdateTypeUncoveredCount++;
                return false;
            }

            started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndEntityUpdateType(int slot, long started)
        {
            entityUpdateTypeTicks[slot] += Stopwatch.GetTimestamp() - started;
            entityUpdateTypeCounts[slot]++;
        }

        public EntityUpdateTypeSample[] TakeEntityUpdateTypes(out int sampledPasses, out int uncoveredUpdates,
            out int excludedNestedPasses)
        {
            if (entityUpdateTypePassDepth != 0)
                throw new InvalidOperationException("Take type diagnostics outside an entity pass.");
            StopEntityUpdateTypes();
            sampledPasses = entityUpdateTypePassCount;
            uncoveredUpdates = entityUpdateTypeUncoveredCount;
            excludedNestedPasses = entityUpdateTypeNestedPassCount;
            var result = new EntityUpdateTypeSample[entityUpdateTypes?.Length ?? 0];
            for (int i = 0; i < result.Length; i++)
                result[i] = new EntityUpdateTypeSample(entityUpdateTypes[i], entityUpdateTypeTicks[i],
                    entityUpdateTypeCounts[i]);
            return result;
        }


        private const int EntityRenderTypeStackCapacity = 32;
        private bool entityRenderTypesEnabled, entityRenderTypePassActive;
        private int entityRenderTypePassCount, entityRenderTypePassLimit, entityRenderTypeStackDepth;
        private int entityRenderTypeUncoveredCount, entityRenderTypeOverflowCount, entityRenderTypeOverflowDepth;
        private long entityRenderTypeOverflowStarted, entityRenderTypeOverflowTicks;
        private long[] entityRenderTypeTicks, entityRenderTypeStarted, entityRenderTypeChildren;
        private int[] entityRenderTypeCounts, entityRenderTypeStackSlots;
        private Type[] entityRenderTypes;

        public bool EntityRenderTypePassActive => Enabled && entityRenderTypesEnabled && entityRenderTypePassActive;

        public void StartEntityRenderTypes(Type[] actualTypes, int maximumPasses = 60)
        {
            ResetEntityRenderTypes();
            StartEntityUpdateTypes(actualTypes, maximumPasses);
            StopEntityUpdateTypes();
            entityRenderTypes = entityUpdateTypes;
            entityRenderTypeTicks = new long[entityUpdateTypes.Length + 1];
            entityRenderTypeCounts = new int[entityUpdateTypes.Length + 1];
            entityRenderTypeStarted = new long[EntityRenderTypeStackCapacity];
            entityRenderTypeChildren = new long[EntityRenderTypeStackCapacity];
            entityRenderTypeStackSlots = new int[EntityRenderTypeStackCapacity];
            entityRenderTypePassLimit = maximumPasses;
            entityRenderTypesEnabled = true;
        }

        public void StopEntityRenderTypes() => entityRenderTypesEnabled = false;

        private void ResetEntityRenderTypes()
        {
            if (entityRenderTypePassActive || entityRenderTypeStackDepth != 0 || entityRenderTypeOverflowDepth != 0)
                throw new InvalidOperationException("Reset render types outside a gameplay render pass.");
            entityRenderTypesEnabled = false;
            entityRenderTypePassCount = entityRenderTypePassLimit = 0;
            entityRenderTypeUncoveredCount = entityRenderTypeOverflowCount = 0;
            entityRenderTypeOverflowStarted = entityRenderTypeOverflowTicks = 0;
            entityRenderTypeTicks = entityRenderTypeStarted = entityRenderTypeChildren = null;
            entityRenderTypeCounts = entityRenderTypeStackSlots = null;
            entityRenderTypes = null;
        }

        private void BeginEntityRenderTypePass()
        {
            if (!Enabled || !entityRenderTypesEnabled || entityRenderTypePassCount >= entityRenderTypePassLimit)
                return;
            entityRenderTypePassCount++;
            entityRenderTypePassActive = true;
        }

        private void EndEntityRenderTypePass() => entityRenderTypePassActive = false;

        public int BeginEntityRenderType(object entity)
        {
            if (!EntityRenderTypePassActive) return -1;
            if (entityRenderTypeOverflowDepth != 0)
            {
                entityRenderTypeOverflowDepth++;
                entityRenderTypeOverflowCount++;
                return -2;
            }

            if (entityRenderTypeStackDepth == EntityRenderTypeStackCapacity)
            {
                entityRenderTypeOverflowDepth = 1;
                entityRenderTypeOverflowCount++;
                entityRenderTypeOverflowStarted = Stopwatch.GetTimestamp();
                return -2;
            }

            if (!entityUpdateTypeSlots.TryGetValue(entity.GetType(), out int slot))
            {
                slot = entityRenderTypes.Length;
                entityRenderTypeUncoveredCount++;
            }

            int index = entityRenderTypeStackDepth++;
            entityRenderTypeStackSlots[index] = slot;
            entityRenderTypeChildren[index] = 0;
            entityRenderTypeStarted[index] = Stopwatch.GetTimestamp();
            return index;
        }

        public void EndEntityRenderType(int token)
        {
            if (token == -1) return;
            if (token == -2)
            {
                if (--entityRenderTypeOverflowDepth == 0)
                {
                    long elapsed = Stopwatch.GetTimestamp() - entityRenderTypeOverflowStarted;
                    entityRenderTypeChildren[entityRenderTypeStackDepth - 1] += elapsed;
                    entityRenderTypeOverflowTicks += elapsed;
                }

                return;
            }

            long inclusive = Stopwatch.GetTimestamp() - entityRenderTypeStarted[token];
            int slot = entityRenderTypeStackSlots[token];
            entityRenderTypeTicks[slot] += inclusive - entityRenderTypeChildren[token];
            entityRenderTypeCounts[slot]++;
            entityRenderTypeStackDepth--;
            if (token > 0) entityRenderTypeChildren[token - 1] += inclusive;
        }

        public EntityUpdateTypeSample[] TakeEntityRenderTypes(out int sampledPasses, out int uncoveredRenders,
            out int overflowRenders, out long overflowTicks)
        {
            if (entityRenderTypePassActive || entityRenderTypeStackDepth != 0 || entityRenderTypeOverflowDepth != 0)
                throw new InvalidOperationException("Take render types outside a gameplay render pass.");
            StopEntityRenderTypes();
            sampledPasses = entityRenderTypePassCount;
            uncoveredRenders = entityRenderTypeUncoveredCount;
            overflowRenders = entityRenderTypeOverflowCount;
            overflowTicks = entityRenderTypeOverflowTicks;
            var result = new EntityUpdateTypeSample[entityRenderTypeTicks?.Length ?? 0];
            for (int i = 0; i < result.Length; i++)
                result[i] = new EntityUpdateTypeSample(i < entityRenderTypes.Length ? entityRenderTypes[i] : null,
                    entityRenderTypeTicks[i], entityRenderTypeCounts[i]);
            return result;
        }


        public bool BeginAudioUpdate(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (audioUpdateDepth++ == 0)
            {
                audioUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndAudioUpdate(long started)
        {
            audioUpdateDepth--;
            if (started != 0) audioUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginSceneEntityUpdate(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (sceneEntityUpdateDepth++ == 0)
            {
                sceneEntityUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndSceneEntityUpdate(long started)
        {
            sceneEntityUpdateDepth--;
            if (started != 0) sceneEntityUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginReflectionTentaclesUpdate(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (reflectionTentaclesUpdateDepth++ == 0)
            {
                reflectionTentaclesUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndReflectionTentaclesUpdate(long started)
        {
            reflectionTentaclesUpdateDepth--;
            if (started != 0) reflectionTentaclesUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginReflectionTentaclesVertices(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (reflectionTentaclesVerticesDepth++ == 0)
            {
                reflectionTentaclesVerticesCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndReflectionTentaclesVertices(long started)
        {
            reflectionTentaclesVerticesDepth--;
            if (started != 0) reflectionTentaclesVerticesTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLightOccludeUpdate(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (lightOccludeUpdateDepth++ == 0)
            {
                lightOccludeUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndLightOccludeUpdate(long started)
        {
            lightOccludeUpdateDepth--;
            if (started != 0) lightOccludeUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCassetteBlockVisualUpdate(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (cassetteBlockVisualUpdateDepth++ == 0)
            {
                cassetteBlockVisualUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndCassetteBlockVisualUpdate(long started)
        {
            cassetteBlockVisualUpdateDepth--;
            if (started != 0) cassetteBlockVisualUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginReflectionTentaclesRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (reflectionTentaclesRenderDepth++ == 0)
            {
                reflectionTentaclesRenderCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndReflectionTentaclesRender(long started)
        {
            reflectionTentaclesRenderDepth--;
            if (started != 0) reflectionTentaclesRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchEntityRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (customBatchEntityRenderDepth++ == 0)
            {
                customBatchEntityRenderCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndCustomBatchEntityRender(long started)
        {
            customBatchEntityRenderDepth--;
            if (started != 0) customBatchEntityRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginPrimitiveNativeSubmit(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (primitiveNativeSubmitDepth++ == 0)
            {
                primitiveNativeSubmitCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndPrimitiveNativeSubmit(long started)
        {
            primitiveNativeSubmitDepth--;
            if (started != 0) primitiveNativeSubmitTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginPrimitivePresentationRecord(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (primitivePresentationRecordDepth++ == 0)
            {
                primitivePresentationRecordCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndPrimitivePresentationRecord(long started)
        {
            primitivePresentationRecordDepth--;
            if (started != 0) primitivePresentationRecordTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginTransitionEndOfFrame(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (transitionEndOfFrameDepth++ == 0)
            {
                transitionEndOfFrameCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndTransitionEndOfFrame(long started)
        {
            transitionEndOfFrameDepth--;
            if (started != 0) transitionEndOfFrameTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginTransitionStart(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (transitionStartDepth++ == 0)
            {
                transitionStartCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndTransitionStart(long started)
        {
            transitionStartDepth--;
            if (started != 0) transitionStartTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginTransitionEvents(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (transitionEventsDepth++ == 0)
            {
                transitionEventsCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndTransitionEvents(long started)
        {
            transitionEventsDepth--;
            if (started != 0) transitionEventsTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginEngineBeforeRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (engineBeforeRenderDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndEngineBeforeRender(long started)
        {
            engineBeforeRenderDepth--;
            if (started != 0) engineBeforeRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginSceneRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (sceneRenderDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndSceneRender(long started)
        {
            sceneRenderDepth--;
            if (started != 0) sceneRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginEngineAfterRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (engineAfterRenderDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndEngineAfterRender(long started)
        {
            engineAfterRenderDepth--;
            if (started != 0) engineAfterRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginGameplayRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (gameplayRenderDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndGameplayRender(long started)
        {
            gameplayRenderDepth--;
            if (started != 0) gameplayRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLightingRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (lightingRenderDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLightingRender(long started)
        {
            lightingRenderDepth--;
            if (started != 0) lightingRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginGameplayEntityRender(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (gameplayEntityRenderDepth++ == 0)
            {
                started = Stopwatch.GetTimestamp();
                BeginEntityRenderTypePass();
            }

            return true;
        }

        public void EndGameplayEntityRender(long started)
        {
            gameplayEntityRenderDepth--;
            if (gameplayEntityRenderDepth == 0) EndEntityRenderTypePass();
            if (started != 0) gameplayEntityRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginGameplayEndBatch(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (gameplayEndBatchDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndGameplayEndBatch(long started)
        {
            gameplayEndBatchDepth--;
            if (started != 0) gameplayEndBatchTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchEntryFlush(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (customBatchEntryFlushDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchEntryFlush(long started)
        {
            customBatchEntryFlushDepth--;
            if (started != 0) customBatchEntryFlushTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchCapture(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (customBatchCaptureDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchCapture(long started)
        {
            customBatchCaptureDepth--;
            if (started != 0) customBatchCaptureTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchMask(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (customBatchMaskDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchMask(long started)
        {
            customBatchMaskDepth--;
            if (started != 0) customBatchMaskTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchFilter(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            if (customBatchFilterDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchFilter(long started)
        {
            customBatchFilterDepth--;
            if (started != 0) customBatchFilterTicks += Stopwatch.GetTimestamp() - started;
        }

        public void RecordSpriteBatchGroup(int quads)
        {
            if (!Enabled) return;
            spriteBatchQuads += quads;
            spriteBatchTextureGroups++;
        }

        public bool BeginSpriteBatchFlush(out long started)
        {
            started = 0;
            if (!Enabled) return false;
            spriteBatchFlushCount++;
            if (spriteBatchFlushDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndSpriteBatchFlush(long started)
        {
            spriteBatchFlushDepth--;
            if (started != 0) spriteBatchFlushTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLevelLoad(string room)
        {
            if (!Enabled) return false;
            if (loadDepth++ == 0)
            {
                loadStarted = loadPhaseStarted = Stopwatch.GetTimestamp();
                loadPhase = SourceLevelLoadPhase.Setup;
            }

            if (levelLoads.Count++ == 0) levelLoads.FirstRoom = room;
            levelLoads.LastRoom = room;
            return true;
        }

        public void EndLevelLoad()
        {
            if (loadDepth == 0) return;
            if (--loadDepth == 0)
            {
                long completed = Stopwatch.GetTimestamp();
                RecordLevelLoadPhase(completed);
                levelLoads.ElapsedTicks += completed - loadStarted;
            }
        }

        public void ChangeLevelLoadPhase(SourceLevelLoadPhase phase)
        {
            if (!Enabled || loadDepth != 1) return;
            long completed = Stopwatch.GetTimestamp();
            RecordLevelLoadPhase(completed);
            loadPhase = phase;
            loadPhaseStarted = completed;
        }

        private void RecordLevelLoadPhase(long completed)
        {
            long elapsed = completed - loadPhaseStarted;
            switch (loadPhase)
            {
                case SourceLevelLoadPhase.Setup: levelLoads.SetupTicks += elapsed; break;
                case SourceLevelLoadPhase.MapEntity: levelLoads.MapEntityTicks += elapsed; break;
                case SourceLevelLoadPhase.MapRemainder: levelLoads.MapRemainderTicks += elapsed; break;
                case SourceLevelLoadPhase.MapClutter:
                    levelLoads.MapClutterTicks += elapsed;
                    levelLoads.MapRemainderTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.MapTriggers:
                    levelLoads.MapTriggersTicks += elapsed;
                    levelLoads.MapRemainderTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.MapDecals:
                    levelLoads.MapDecalsTicks += elapsed;
                    levelLoads.MapRemainderTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.ActorPrepare: levelLoads.ActorPrepareTicks += elapsed; break;
                case SourceLevelLoadPhase.EntityCommit: levelLoads.EntityCommitTicks += elapsed; break;
                case SourceLevelLoadPhase.ActorFinalize: levelLoads.ActorFinalizeTicks += elapsed; break;
                case SourceLevelLoadPhase.ObjectTile: levelLoads.ObjectTileTicks += elapsed; break;
                case SourceLevelLoadPhase.PostLoad: levelLoads.PostLoadTicks += elapsed; break;
            }
        }

        public bool BeginLevelLoadAwake(out long started)
        {
            started = 0;
            if (!Enabled || loadDepth != 1 || loadPhase != SourceLevelLoadPhase.EntityCommit) return false;
            if (loadAwakeDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLevelLoadAwake(long started)
        {
            loadAwakeDepth--;
            if (started != 0) levelLoads.AwakeTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLoadPlatformAttachment(out long started)
        {
            started = 0;
            if (!MeasuringLoad) return false;
            if (loadPlatformAttachmentDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLoadPlatformAttachment(long started)
        {
            loadPlatformAttachmentDepth--;
            if (started != 0) levelLoads.PlatformAttachmentTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLoadGroupAwake(out long started)
        {
            started = 0;
            if (!MeasuringLoad) return false;
            if (loadGroupAwakeDepth++ == 0) started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLoadGroupAwake(long started)
        {
            loadGroupAwakeDepth--;
            if (started != 0) levelLoads.GroupAwakeTicks += Stopwatch.GetTimestamp() - started;
        }

        public void RecordLoadWrite(uint owned)
        {
            if (!MeasuringLoad) return;
            if (owned == 0) levelLoads.BorrowedWrites++;
            else levelLoads.OwnedWrites++;
        }

        public void RecordLoadUpload(bool texture, long bytes)
        {
            if (!MeasuringLoad) return;
            if (texture)
            {
                levelLoads.TextureUploads++;
                levelLoads.TextureBytes += bytes;
            }
            else
            {
                levelLoads.BufferUploads++;
                levelLoads.BufferBytes += bytes;
            }
        }

        public void RecordLoadResource(bool texture, bool dispose)
        {
            if (!MeasuringLoad) return;
            if (texture)
            {
                if (dispose) levelLoads.TextureDisposes++;
                else levelLoads.TextureCreates++;
            }
            else
            {
                if (dispose) levelLoads.BufferDisposes++;
                else levelLoads.BufferCreates++;
            }
        }

        public void RecordLoadRead(uint owned)
        {
            if (!MeasuringLoad) return;
            levelLoads.Reads++;
            if (owned == 0) levelLoads.ReadSplits++;
        }

        public long BeginFrameSubmission() => Enabled ? Stopwatch.GetTimestamp() : 0;

        public long BeginLoadSubmission(long started) => MeasuringLoad ? started : 0;

        public void EndFrameSubmission(long started, long completed)
        {
            if (started == 0) return;
            frameSubmissions++;
            submissionTicks += completed - started;
        }

        public long BeginLoadSubmission() => MeasuringLoad ? Stopwatch.GetTimestamp() : 0;

        public void EndLoadSubmission(long started) => EndLoadSubmission(started,
            started == 0 ? 0 : Stopwatch.GetTimestamp());

        public void EndLoadSubmission(long started, long completed)
        {
            if (started == 0) return;
            levelLoads.Submissions++;
            levelLoads.SubmitTicks += completed - started;
        }

        public bool Enabled { get; private set; }
        public object Marker { get; set; }
        public long TimestampFrequency => Stopwatch.Frequency;
        public int Count => count;

        public void Start()
        {
            ResetEntityRenderTypes();
            ResetEntityUpdateTypes();
            if (samples == null) samples = new SourceFrameSample[Capacity];
            else Array.Clear(samples, 0, samples.Length);
            count = 0;
            sequence = 0;
            Enabled = true;
        }

        public void Stop()
        {
            Enabled = false;
            StopEntityUpdateTypes();
            StopEntityRenderTypes();
        }

        // Stop before copying: the copy/serialization itself is not a sampled game tick.
        public SourceFrameSample[] TakeSamples()
        {
            Enabled = false;
            StopEntityUpdateTypes();
            StopEntityRenderTypes();
            var result = new SourceFrameSample[count];
            int first = (int)((sequence - count) & (Capacity - 1));
            int firstCount = Math.Min(count, Capacity - first);
            Array.Copy(samples ?? Array.Empty<SourceFrameSample>(), first, result, 0, firstCount);
            if (firstCount < count) Array.Copy(samples, 0, result, firstCount, count - firstCount);
            if (samples != null) Array.Clear(samples, 0, samples.Length);
            count = 0;
            return result;
        }

        public int ExportCsv(string path)
        {
            SourceFrameSample[] snapshot = TakeSamples();
            SourceFrameSampleCsvWriter.Write(path, snapshot);
            return snapshot.Length;
        }

        internal void Record(long timestamp, int updateCount, long updateTicks, long drawTicks,
            long endDrawTicks, long beginDrawTicks, long waitTicks, int gc0, int gc1, int gc2, object marker,
            ulong cyclesAtStart = 0, ulong cyclesAtWaitEnd = 0, ulong cyclesAtEnd = 0, byte cycleValidity = 0)
        {
            // A scheduled Stop/Take during Update must not append its own observation tick.
            if (!Enabled) return;
            if ((cycleValidity & 3) == 3 && cyclesAtWaitEnd < cyclesAtStart)
                cycleValidity &= 5;
            if ((cycleValidity & 4) != 0 &&
                (((cycleValidity & 1) != 0 && cyclesAtEnd < cyclesAtStart) ||
                 ((cycleValidity & 2) != 0 && cyclesAtEnd < cyclesAtWaitEnd)))
                cycleValidity &= 3;
            samples[(int)(sequence & (Capacity - 1))] = new SourceFrameSample(timestamp, sequence,
                Stopwatch.GetTimestamp() - timestamp, updateCount, updateTicks, drawTicks, endDrawTicks,
                beginDrawTicks, waitTicks, GC.CollectionCount(0) - gc0,
                GC.CollectionCount(1) - gc1, GC.CollectionCount(2) - gc2, gc0, gc1, gc2, marker, levelLoads,
                frameSubmissions, submissionTicks,
                engineBeforeRenderTicks, sceneRenderTicks, engineAfterRenderTicks, gameplayRenderTicks,
                lightingRenderTicks, gameplayEntityRenderTicks, gameplayEndBatchTicks,
                customBatchEntryFlushTicks, customBatchCaptureTicks, customBatchMaskTicks, customBatchFilterTicks,
                spriteBatchQuads, spriteBatchTextureGroups, spriteBatchFlushTicks, spriteBatchFlushCount,
                reflectionTentaclesRenderTicks, reflectionTentaclesRenderCount,
                customBatchEntityRenderTicks, customBatchEntityRenderCount,
                primitiveNativeSubmitTicks, primitiveNativeSubmitCount,
                primitivePresentationRecordTicks, primitivePresentationRecordCount,
                transitionEndOfFrameTicks, transitionEndOfFrameCount,
                transitionStartTicks, transitionStartCount,
                transitionEventsTicks, transitionEventsCount,
                audioUpdateTicks, audioUpdateCount,
                sceneEntityUpdateTicks, sceneEntityUpdateCount,
                reflectionTentaclesUpdateTicks, reflectionTentaclesUpdateCount,
                reflectionTentaclesVerticesTicks, reflectionTentaclesVerticesCount,
                lightOccludeUpdateTicks, lightOccludeUpdateCount,
                cassetteBlockVisualUpdateTicks, cassetteBlockVisualUpdateCount,
                cyclesAtStart, cyclesAtWaitEnd, cyclesAtEnd, cycleValidity);
            sequence++;
            if (count < Capacity) count++;
        }
    }
}

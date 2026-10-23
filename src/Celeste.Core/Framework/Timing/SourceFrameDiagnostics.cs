using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Celeste.Core.Framework.Timing
{
    // All operations run on the game thread, including DebugRC's scheduled Lua commands.
    public sealed class SourceFrameDiagnostics
    {
        public const int Capacity = 16384;
        private SourceFrameSample[] _samples;
        private int _count;
        private long _sequence;
        private ISourceThreadCycleClock _threadCycleClock;

        internal void BindThreadCycleClock(ISourceThreadCycleClock clock)
        {
            _threadCycleClock = clock;
        }

        internal ulong ReadThreadCycles(byte bit, ref byte validity)
        {
            if (_threadCycleClock != null && _threadCycleClock.TryRead(out var cycles))
            {
                validity |= bit;
                return cycles;
            }

            return 0;
        }

        private long _audioUpdateTicks;
        private int _audioUpdateDepth, _audioUpdateCount;
        private long _sceneEntityUpdateTicks;
        private int _sceneEntityUpdateDepth, _sceneEntityUpdateCount;
        private long _reflectionTentaclesUpdateTicks;
        private int _reflectionTentaclesUpdateDepth, _reflectionTentaclesUpdateCount;
        private long _reflectionTentaclesVerticesTicks;
        private int _reflectionTentaclesVerticesDepth, _reflectionTentaclesVerticesCount;
        private long _lightOccludeUpdateTicks;
        private int _lightOccludeUpdateDepth, _lightOccludeUpdateCount;
        private long _cassetteBlockVisualUpdateTicks;
        private int _cassetteBlockVisualUpdateDepth, _cassetteBlockVisualUpdateCount;
        private long _reflectionTentaclesRenderTicks;
        private int _reflectionTentaclesRenderDepth, _reflectionTentaclesRenderCount;
        private long _customBatchEntityRenderTicks;
        private int _customBatchEntityRenderDepth, _customBatchEntityRenderCount;
        private long _primitiveNativeSubmitTicks;
        private int _primitiveNativeSubmitDepth, _primitiveNativeSubmitCount;
        private long _primitivePresentationRecordTicks;
        private int _primitivePresentationRecordDepth, _primitivePresentationRecordCount;
        private long _transitionEndOfFrameTicks;
        private int _transitionEndOfFrameDepth, _transitionEndOfFrameCount;
        private long _transitionStartTicks;
        private int _transitionStartDepth, _transitionStartCount;
        private long _transitionEventsTicks;
        private int _transitionEventsDepth, _transitionEventsCount;

        [ThreadStatic] private static SourceFrameDiagnostics _current;

        private SourceLevelLoadSample _levelLoads;
        private int _loadDepth;
        private long _loadStarted;
        private SourceLevelLoadPhase _loadPhase;
        private long _loadPhaseStarted;
        private int _loadAwakeDepth;
        private int _loadPlatformAttachmentDepth;
        private int _loadGroupAwakeDepth;
        private int _frameSubmissions;
        private long _submissionTicks;
        private long _engineBeforeRenderTicks;
        private int _engineBeforeRenderDepth;
        private long _sceneRenderTicks;
        private int _sceneRenderDepth;
        private long _engineAfterRenderTicks;
        private int _engineAfterRenderDepth;
        private long _gameplayRenderTicks;
        private int _gameplayRenderDepth;
        private long _lightingRenderTicks;
        private int _lightingRenderDepth;
        private long _gameplayEntityRenderTicks;
        private int _gameplayEntityRenderDepth;
        private long _gameplayEndBatchTicks;
        private int _gameplayEndBatchDepth;
        private long _customBatchEntryFlushTicks;
        private int _customBatchEntryFlushDepth;
        private long _customBatchCaptureTicks;
        private int _customBatchCaptureDepth;
        private long _customBatchMaskTicks;
        private int _customBatchMaskDepth;
        private long _customBatchFilterTicks;
        private int _customBatchFilterDepth;
        private int _spriteBatchQuads, _spriteBatchTextureGroups, _spriteBatchFlushCount;
        private long _spriteBatchFlushTicks;
        private int _spriteBatchFlushDepth;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public static SourceFrameDiagnostics Current => _current;
        private bool MeasuringLoad => Enabled && _loadDepth > 0;

        internal void BeginFrame()
        {
            _levelLoads = default;
            _loadDepth = 0;
            _loadAwakeDepth = 0;
            _loadPlatformAttachmentDepth = 0;
            _loadGroupAwakeDepth = 0;
            _frameSubmissions = 0;
            _submissionTicks = 0;
            _engineBeforeRenderTicks = 0;
            _engineBeforeRenderDepth = 0;
            _sceneRenderTicks = 0;
            _sceneRenderDepth = 0;
            _engineAfterRenderTicks = 0;
            _engineAfterRenderDepth = 0;
            _gameplayRenderTicks = 0;
            _gameplayRenderDepth = 0;
            _lightingRenderTicks = 0;
            _gameplayEntityRenderTicks = 0;
            _gameplayEndBatchTicks = 0;
            _customBatchEntryFlushTicks = 0;
            _customBatchCaptureTicks = 0;
            _customBatchMaskTicks = 0;
            _customBatchFilterTicks = 0;
            _spriteBatchQuads = 0;
            _spriteBatchTextureGroups = 0;
            _spriteBatchFlushCount = 0;
            _spriteBatchFlushTicks = 0;
            _lightingRenderDepth = 0;
            _gameplayEntityRenderDepth = 0;
            _gameplayEndBatchDepth = 0;
            _customBatchEntryFlushDepth = 0;
            _customBatchCaptureDepth = 0;
            _customBatchMaskDepth = 0;
            _customBatchFilterDepth = 0;
            _spriteBatchFlushDepth = 0;
            _reflectionTentaclesRenderTicks = 0;
            _reflectionTentaclesRenderDepth = 0;
            _reflectionTentaclesRenderCount = 0;
            _customBatchEntityRenderTicks = 0;
            _customBatchEntityRenderDepth = 0;
            _customBatchEntityRenderCount = 0;
            _primitiveNativeSubmitTicks = 0;
            _primitiveNativeSubmitDepth = 0;
            _primitiveNativeSubmitCount = 0;
            _primitivePresentationRecordTicks = 0;
            _primitivePresentationRecordDepth = 0;
            _primitivePresentationRecordCount = 0;
            _audioUpdateTicks = 0;
            _audioUpdateDepth = 0;
            _audioUpdateCount = 0;
            _sceneEntityUpdateTicks = 0;
            _sceneEntityUpdateDepth = 0;
            _sceneEntityUpdateCount = 0;
            _reflectionTentaclesUpdateTicks = 0;
            _reflectionTentaclesUpdateDepth = 0;
            _reflectionTentaclesUpdateCount = 0;
            _reflectionTentaclesVerticesTicks = 0;
            _reflectionTentaclesVerticesDepth = 0;
            _reflectionTentaclesVerticesCount = 0;
            _lightOccludeUpdateTicks = 0;
            _lightOccludeUpdateDepth = 0;
            _lightOccludeUpdateCount = 0;
            _cassetteBlockVisualUpdateTicks = 0;
            _cassetteBlockVisualUpdateDepth = 0;
            _cassetteBlockVisualUpdateCount = 0;
            _transitionEndOfFrameTicks = 0;
            _transitionEndOfFrameDepth = 0;
            _transitionEndOfFrameCount = 0;
            _transitionStartTicks = 0;
            _transitionStartDepth = 0;
            _transitionStartCount = 0;
            _transitionEventsTicks = 0;
            _transitionEventsDepth = 0;
            _transitionEventsCount = 0;
            _current = this;
        }

        internal void EndFrame()
        {
            _current = null;
            _lightOccludeUpdateDepth = 0;
            _cassetteBlockVisualUpdateDepth = 0;
            _audioUpdateDepth = 0;
            _sceneEntityUpdateDepth = 0;
            _reflectionTentaclesUpdateDepth = 0;
            _reflectionTentaclesVerticesDepth = 0;
            _transitionEndOfFrameDepth = 0;
            _transitionStartDepth = 0;
            _transitionEventsDepth = 0;
            _reflectionTentaclesRenderDepth = 0;
            _customBatchEntityRenderDepth = 0;
            _primitiveNativeSubmitDepth = 0;
            _primitivePresentationRecordDepth = 0;
            _loadDepth = 0;
            _loadAwakeDepth = 0;
            _loadPlatformAttachmentDepth = 0;
            _loadGroupAwakeDepth = 0;
            _engineBeforeRenderDepth = 0;
            _sceneRenderDepth = 0;
            _engineAfterRenderDepth = 0;
            _gameplayRenderDepth = 0;
            _lightingRenderDepth = 0;
            _gameplayEntityRenderDepth = 0;
            _gameplayEndBatchDepth = 0;
            _customBatchEntryFlushDepth = 0;
            _customBatchCaptureDepth = 0;
            _customBatchMaskDepth = 0;
            _customBatchFilterDepth = 0;
            _spriteBatchFlushDepth = 0;
        }

        private Dictionary<Type, int> _entityUpdateTypeSlots;
        private Type[] _entityUpdateTypes;
        private long[] _entityUpdateTypeTicks;
        private int[] _entityUpdateTypeCounts;
        private bool _entityUpdateTypesEnabled;
        private int _entityUpdateTypePassDepth, _entityUpdateTypePassLimit;
        private int _entityUpdateTypePassCount, _entityUpdateTypeUncoveredCount, _entityUpdateTypeNestedPassCount;

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
            if (_entityRenderTypesEnabled || _entityRenderTypePassActive)
                throw new InvalidOperationException(
                    "Stop render type sampling before replacing the shared type table.");
            if (!Enabled || _entityUpdateTypePassDepth != 0)
                throw new InvalidOperationException("Start type diagnostics after Start, outside an entity pass.");
            if (actualTypes == null)
                throw new ArgumentNullException(nameof(actualTypes));
            if (maximumPasses < 1 || maximumPasses > 60)
                throw new ArgumentOutOfRangeException(nameof(maximumPasses));
            var slots = new Dictionary<Type, int>(actualTypes.Length);
            foreach (var type in actualTypes)
            {
                if (type == null)
                    throw new ArgumentException("Actual entity types cannot contain null.", nameof(actualTypes));
                if (!slots.ContainsKey(type))
                    slots.Add(type, slots.Count);
            }

            var types = new Type[slots.Count];
            foreach (var entry in slots)
                types[entry.Value] = entry.Key;
            _entityUpdateTypeSlots = slots;
            _entityUpdateTypes = types;
            _entityUpdateTypeTicks = new long[types.Length];
            _entityUpdateTypeCounts = new int[types.Length];
            _entityUpdateTypePassLimit = maximumPasses;
            _entityUpdateTypePassCount = _entityUpdateTypeUncoveredCount = _entityUpdateTypeNestedPassCount = 0;
            _entityUpdateTypesEnabled = true;
        }

        public void StopEntityUpdateTypes()
        {
            _entityUpdateTypesEnabled = false;
        }

        private void ResetEntityUpdateTypes()
        {
            if (_entityUpdateTypePassDepth != 0)
                throw new InvalidOperationException("Restart diagnostics outside an entity pass.");
            _entityUpdateTypesEnabled = false;
            _entityUpdateTypeSlots = null;
            _entityUpdateTypes = null;
            _entityUpdateTypeTicks = null;
            _entityUpdateTypeCounts = null;
            _entityUpdateTypePassLimit = _entityUpdateTypePassDepth = 0;
            _entityUpdateTypePassCount = _entityUpdateTypeUncoveredCount = _entityUpdateTypeNestedPassCount = 0;
        }

        public bool BeginEntityUpdateTypePass()
        {
            if (!Enabled || !_entityUpdateTypesEnabled)
                return false;
            if (_entityUpdateTypePassDepth != 0)
            {
                _entityUpdateTypePassDepth++;
                _entityUpdateTypeNestedPassCount++;
                return true;
            }

            if (_entityUpdateTypePassCount >= _entityUpdateTypePassLimit)
                return false;
            _entityUpdateTypePassCount++;
            _entityUpdateTypePassDepth = 1;
            return true;
        }

        public void EndEntityUpdateTypePass()
        {
            _entityUpdateTypePassDepth--;
        }

        public bool BeginEntityUpdateType(object entity, out int slot, out long started)
        {
            slot = -1;
            started = 0;
            if (!Enabled || !_entityUpdateTypesEnabled || _entityUpdateTypePassDepth != 1)
                return false;
            if (!_entityUpdateTypeSlots.TryGetValue(entity.GetType(), out slot))
            {
                slot = -1;
                _entityUpdateTypeUncoveredCount++;
                return false;
            }

            started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndEntityUpdateType(int slot, long started)
        {
            _entityUpdateTypeTicks[slot] += Stopwatch.GetTimestamp() - started;
            _entityUpdateTypeCounts[slot]++;
        }

        public EntityUpdateTypeSample[] TakeEntityUpdateTypes(out int sampledPasses, out int uncoveredUpdates,
            out int excludedNestedPasses)
        {
            if (_entityUpdateTypePassDepth != 0)
                throw new InvalidOperationException("Take type diagnostics outside an entity pass.");
            StopEntityUpdateTypes();
            sampledPasses = _entityUpdateTypePassCount;
            uncoveredUpdates = _entityUpdateTypeUncoveredCount;
            excludedNestedPasses = _entityUpdateTypeNestedPassCount;
            var result = new EntityUpdateTypeSample[_entityUpdateTypes?.Length ?? 0];
            for (var i = 0; i < result.Length; i++)
                result[i] = new(_entityUpdateTypes[i], _entityUpdateTypeTicks[i], _entityUpdateTypeCounts[i]);
            return result;
        }

        private const int EntityRenderTypeStackCapacity = 32;
        private bool _entityRenderTypesEnabled, _entityRenderTypePassActive;
        private int _entityRenderTypePassCount, _entityRenderTypePassLimit, _entityRenderTypeStackDepth;
        private int _entityRenderTypeUncoveredCount, _entityRenderTypeOverflowCount, _entityRenderTypeOverflowDepth;
        private long _entityRenderTypeOverflowStarted, _entityRenderTypeOverflowTicks;
        private long[] _entityRenderTypeTicks, _entityRenderTypeStarted, _entityRenderTypeChildren;
        private int[] _entityRenderTypeCounts, _entityRenderTypeStackSlots;
        private Type[] _entityRenderTypes;
        public bool EntityRenderTypePassActive => Enabled && _entityRenderTypesEnabled && _entityRenderTypePassActive;

        public void StartEntityRenderTypes(Type[] actualTypes, int maximumPasses = 60)
        {
            ResetEntityRenderTypes();
            StartEntityUpdateTypes(actualTypes, maximumPasses);
            StopEntityUpdateTypes();
            _entityRenderTypes = _entityUpdateTypes;
            _entityRenderTypeTicks = new long[_entityUpdateTypes.Length + 1];
            _entityRenderTypeCounts = new int[_entityUpdateTypes.Length + 1];
            _entityRenderTypeStarted = new long[EntityRenderTypeStackCapacity];
            _entityRenderTypeChildren = new long[EntityRenderTypeStackCapacity];
            _entityRenderTypeStackSlots = new int[EntityRenderTypeStackCapacity];
            _entityRenderTypePassLimit = maximumPasses;
            _entityRenderTypesEnabled = true;
        }

        public void StopEntityRenderTypes()
        {
            _entityRenderTypesEnabled = false;
        }

        private void ResetEntityRenderTypes()
        {
            if (_entityRenderTypePassActive || _entityRenderTypeStackDepth != 0 || _entityRenderTypeOverflowDepth != 0)
                throw new InvalidOperationException("Reset render types outside a gameplay render pass.");
            _entityRenderTypesEnabled = false;
            _entityRenderTypePassCount = _entityRenderTypePassLimit = 0;
            _entityRenderTypeUncoveredCount = _entityRenderTypeOverflowCount = 0;
            _entityRenderTypeOverflowStarted = _entityRenderTypeOverflowTicks = 0;
            _entityRenderTypeTicks = _entityRenderTypeStarted = _entityRenderTypeChildren = null;
            _entityRenderTypeCounts = _entityRenderTypeStackSlots = null;
            _entityRenderTypes = null;
        }

        private void BeginEntityRenderTypePass()
        {
            if (!Enabled || !_entityRenderTypesEnabled || _entityRenderTypePassCount >= _entityRenderTypePassLimit)
                return;
            _entityRenderTypePassCount++;
            _entityRenderTypePassActive = true;
        }

        private void EndEntityRenderTypePass()
        {
            _entityRenderTypePassActive = false;
        }

        public int BeginEntityRenderType(object entity)
        {
            if (!EntityRenderTypePassActive)
                return -1;
            if (_entityRenderTypeOverflowDepth != 0)
            {
                _entityRenderTypeOverflowDepth++;
                _entityRenderTypeOverflowCount++;
                return -2;
            }

            if (_entityRenderTypeStackDepth == EntityRenderTypeStackCapacity)
            {
                _entityRenderTypeOverflowDepth = 1;
                _entityRenderTypeOverflowCount++;
                _entityRenderTypeOverflowStarted = Stopwatch.GetTimestamp();
                return -2;
            }

            if (!_entityUpdateTypeSlots.TryGetValue(entity.GetType(), out var slot))
            {
                slot = _entityRenderTypes.Length;
                _entityRenderTypeUncoveredCount++;
            }

            var index = _entityRenderTypeStackDepth++;
            _entityRenderTypeStackSlots[index] = slot;
            _entityRenderTypeChildren[index] = 0;
            _entityRenderTypeStarted[index] = Stopwatch.GetTimestamp();
            return index;
        }

        public void EndEntityRenderType(int token)
        {
            if (token == -1)
                return;
            if (token == -2)
            {
                if (--_entityRenderTypeOverflowDepth == 0)
                {
                    var elapsed = Stopwatch.GetTimestamp() - _entityRenderTypeOverflowStarted;
                    _entityRenderTypeChildren[_entityRenderTypeStackDepth - 1] += elapsed;
                    _entityRenderTypeOverflowTicks += elapsed;
                }

                return;
            }

            var inclusive = Stopwatch.GetTimestamp() - _entityRenderTypeStarted[token];
            var slot = _entityRenderTypeStackSlots[token];
            _entityRenderTypeTicks[slot] += inclusive - _entityRenderTypeChildren[token];
            _entityRenderTypeCounts[slot]++;
            _entityRenderTypeStackDepth--;
            if (token > 0)
                _entityRenderTypeChildren[token - 1] += inclusive;
        }

        public EntityUpdateTypeSample[] TakeEntityRenderTypes(out int sampledPasses, out int uncoveredRenders,
            out int overflowRenders, out long overflowTicks)
        {
            if (_entityRenderTypePassActive || _entityRenderTypeStackDepth != 0 || _entityRenderTypeOverflowDepth != 0)
                throw new InvalidOperationException("Take render types outside a gameplay render pass.");
            StopEntityRenderTypes();
            sampledPasses = _entityRenderTypePassCount;
            uncoveredRenders = _entityRenderTypeUncoveredCount;
            overflowRenders = _entityRenderTypeOverflowCount;
            overflowTicks = _entityRenderTypeOverflowTicks;
            var result = new EntityUpdateTypeSample[_entityRenderTypeTicks?.Length ?? 0];
            for (var i = 0; i < result.Length; i++)
                result[i] = new(i < _entityRenderTypes.Length ? _entityRenderTypes[i] : null, _entityRenderTypeTicks[i],
                    _entityRenderTypeCounts[i]);
            return result;
        }

        public bool BeginAudioUpdate(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_audioUpdateDepth++ == 0)
            {
                _audioUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndAudioUpdate(long started)
        {
            _audioUpdateDepth--;
            if (started != 0)
                _audioUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginSceneEntityUpdate(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_sceneEntityUpdateDepth++ == 0)
            {
                _sceneEntityUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndSceneEntityUpdate(long started)
        {
            _sceneEntityUpdateDepth--;
            if (started != 0)
                _sceneEntityUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginReflectionTentaclesUpdate(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_reflectionTentaclesUpdateDepth++ == 0)
            {
                _reflectionTentaclesUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndReflectionTentaclesUpdate(long started)
        {
            _reflectionTentaclesUpdateDepth--;
            if (started != 0)
                _reflectionTentaclesUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginReflectionTentaclesVertices(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_reflectionTentaclesVerticesDepth++ == 0)
            {
                _reflectionTentaclesVerticesCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndReflectionTentaclesVertices(long started)
        {
            _reflectionTentaclesVerticesDepth--;
            if (started != 0)
                _reflectionTentaclesVerticesTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLightOccludeUpdate(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_lightOccludeUpdateDepth++ == 0)
            {
                _lightOccludeUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndLightOccludeUpdate(long started)
        {
            _lightOccludeUpdateDepth--;
            if (started != 0)
                _lightOccludeUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCassetteBlockVisualUpdate(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_cassetteBlockVisualUpdateDepth++ == 0)
            {
                _cassetteBlockVisualUpdateCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndCassetteBlockVisualUpdate(long started)
        {
            _cassetteBlockVisualUpdateDepth--;
            if (started != 0)
                _cassetteBlockVisualUpdateTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginReflectionTentaclesRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_reflectionTentaclesRenderDepth++ == 0)
            {
                _reflectionTentaclesRenderCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndReflectionTentaclesRender(long started)
        {
            _reflectionTentaclesRenderDepth--;
            if (started != 0)
                _reflectionTentaclesRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchEntityRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_customBatchEntityRenderDepth++ == 0)
            {
                _customBatchEntityRenderCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndCustomBatchEntityRender(long started)
        {
            _customBatchEntityRenderDepth--;
            if (started != 0)
                _customBatchEntityRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginPrimitiveNativeSubmit(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_primitiveNativeSubmitDepth++ == 0)
            {
                _primitiveNativeSubmitCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndPrimitiveNativeSubmit(long started)
        {
            _primitiveNativeSubmitDepth--;
            if (started != 0)
                _primitiveNativeSubmitTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginPrimitivePresentationRecord(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_primitivePresentationRecordDepth++ == 0)
            {
                _primitivePresentationRecordCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndPrimitivePresentationRecord(long started)
        {
            _primitivePresentationRecordDepth--;
            if (started != 0)
                _primitivePresentationRecordTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginTransitionEndOfFrame(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_transitionEndOfFrameDepth++ == 0)
            {
                _transitionEndOfFrameCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndTransitionEndOfFrame(long started)
        {
            _transitionEndOfFrameDepth--;
            if (started != 0)
                _transitionEndOfFrameTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginTransitionStart(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_transitionStartDepth++ == 0)
            {
                _transitionStartCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndTransitionStart(long started)
        {
            _transitionStartDepth--;
            if (started != 0)
                _transitionStartTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginTransitionEvents(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_transitionEventsDepth++ == 0)
            {
                _transitionEventsCount++;
                started = Stopwatch.GetTimestamp();
            }

            return true;
        }

        public void EndTransitionEvents(long started)
        {
            _transitionEventsDepth--;
            if (started != 0)
                _transitionEventsTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginEngineBeforeRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_engineBeforeRenderDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndEngineBeforeRender(long started)
        {
            _engineBeforeRenderDepth--;
            if (started != 0)
                _engineBeforeRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginSceneRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_sceneRenderDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndSceneRender(long started)
        {
            _sceneRenderDepth--;
            if (started != 0)
                _sceneRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginEngineAfterRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_engineAfterRenderDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndEngineAfterRender(long started)
        {
            _engineAfterRenderDepth--;
            if (started != 0)
                _engineAfterRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginGameplayRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_gameplayRenderDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndGameplayRender(long started)
        {
            _gameplayRenderDepth--;
            if (started != 0)
                _gameplayRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLightingRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_lightingRenderDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLightingRender(long started)
        {
            _lightingRenderDepth--;
            if (started != 0)
                _lightingRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginGameplayEntityRender(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_gameplayEntityRenderDepth++ == 0)
            {
                started = Stopwatch.GetTimestamp();
                BeginEntityRenderTypePass();
            }

            return true;
        }

        public void EndGameplayEntityRender(long started)
        {
            _gameplayEntityRenderDepth--;
            if (_gameplayEntityRenderDepth == 0)
                EndEntityRenderTypePass();
            if (started != 0)
                _gameplayEntityRenderTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginGameplayEndBatch(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_gameplayEndBatchDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndGameplayEndBatch(long started)
        {
            _gameplayEndBatchDepth--;
            if (started != 0)
                _gameplayEndBatchTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchEntryFlush(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_customBatchEntryFlushDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchEntryFlush(long started)
        {
            _customBatchEntryFlushDepth--;
            if (started != 0)
                _customBatchEntryFlushTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchCapture(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_customBatchCaptureDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchCapture(long started)
        {
            _customBatchCaptureDepth--;
            if (started != 0)
                _customBatchCaptureTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchMask(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_customBatchMaskDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchMask(long started)
        {
            _customBatchMaskDepth--;
            if (started != 0)
                _customBatchMaskTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginCustomBatchFilter(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            if (_customBatchFilterDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndCustomBatchFilter(long started)
        {
            _customBatchFilterDepth--;
            if (started != 0)
                _customBatchFilterTicks += Stopwatch.GetTimestamp() - started;
        }

        public void RecordSpriteBatchGroup(int quads)
        {
            if (!Enabled)
                return;
            _spriteBatchQuads += quads;
            _spriteBatchTextureGroups++;
        }

        public bool BeginSpriteBatchFlush(out long started)
        {
            started = 0;
            if (!Enabled)
                return false;
            _spriteBatchFlushCount++;
            if (_spriteBatchFlushDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndSpriteBatchFlush(long started)
        {
            _spriteBatchFlushDepth--;
            if (started != 0)
                _spriteBatchFlushTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLevelLoad(string room)
        {
            if (!Enabled)
                return false;
            if (_loadDepth++ == 0)
            {
                _loadStarted = _loadPhaseStarted = Stopwatch.GetTimestamp();
                _loadPhase = SourceLevelLoadPhase.Setup;
            }

            if (_levelLoads.Count++ == 0)
                _levelLoads.FirstRoom = room;
            _levelLoads.LastRoom = room;
            return true;
        }

        public void EndLevelLoad()
        {
            if (_loadDepth == 0)
                return;
            if (--_loadDepth == 0)
            {
                var completed = Stopwatch.GetTimestamp();
                RecordLevelLoadPhase(completed);
                _levelLoads.ElapsedTicks += completed - _loadStarted;
            }
        }

        public void ChangeLevelLoadPhase(SourceLevelLoadPhase phase)
        {
            if (!Enabled || _loadDepth != 1)
                return;
            var completed = Stopwatch.GetTimestamp();
            RecordLevelLoadPhase(completed);
            _loadPhase = phase;
            _loadPhaseStarted = completed;
        }

        private void RecordLevelLoadPhase(long completed)
        {
            var elapsed = completed - _loadPhaseStarted;
            switch (_loadPhase)
            {
                case SourceLevelLoadPhase.Setup:
                    _levelLoads.SetupTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.MapEntity:
                    _levelLoads.MapEntityTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.MapRemainder:
                    _levelLoads.MapRemainderTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.MapClutter:
                    _levelLoads.MapClutterTicks += elapsed;
                    _levelLoads.MapRemainderTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.MapTriggers:
                    _levelLoads.MapTriggersTicks += elapsed;
                    _levelLoads.MapRemainderTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.MapDecals:
                    _levelLoads.MapDecalsTicks += elapsed;
                    _levelLoads.MapRemainderTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.ActorPrepare:
                    _levelLoads.ActorPrepareTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.EntityCommit:
                    _levelLoads.EntityCommitTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.ActorFinalize:
                    _levelLoads.ActorFinalizeTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.ObjectTile:
                    _levelLoads.ObjectTileTicks += elapsed;
                    break;
                case SourceLevelLoadPhase.PostLoad:
                    _levelLoads.PostLoadTicks += elapsed;
                    break;
            }
        }

        public bool BeginLevelLoadAwake(out long started)
        {
            started = 0;
            if (!Enabled || _loadDepth != 1 || _loadPhase != SourceLevelLoadPhase.EntityCommit)
                return false;
            if (_loadAwakeDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLevelLoadAwake(long started)
        {
            _loadAwakeDepth--;
            if (started != 0)
                _levelLoads.AwakeTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLoadPlatformAttachment(out long started)
        {
            started = 0;
            if (!MeasuringLoad)
                return false;
            if (_loadPlatformAttachmentDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLoadPlatformAttachment(long started)
        {
            _loadPlatformAttachmentDepth--;
            if (started != 0)
                _levelLoads.PlatformAttachmentTicks += Stopwatch.GetTimestamp() - started;
        }

        public bool BeginLoadGroupAwake(out long started)
        {
            started = 0;
            if (!MeasuringLoad)
                return false;
            if (_loadGroupAwakeDepth++ == 0)
                started = Stopwatch.GetTimestamp();
            return true;
        }

        public void EndLoadGroupAwake(long started)
        {
            _loadGroupAwakeDepth--;
            if (started != 0)
                _levelLoads.GroupAwakeTicks += Stopwatch.GetTimestamp() - started;
        }

        public void RecordLoadWrite(uint owned)
        {
            if (!MeasuringLoad)
                return;
            if (owned == 0)
                _levelLoads.BorrowedWrites++;
            else
                _levelLoads.OwnedWrites++;
        }

        public void RecordLoadUpload(bool texture, long bytes)
        {
            if (!MeasuringLoad)
                return;
            if (texture)
            {
                _levelLoads.TextureUploads++;
                _levelLoads.TextureBytes += bytes;
            }
            else
            {
                _levelLoads.BufferUploads++;
                _levelLoads.BufferBytes += bytes;
            }
        }

        public void RecordLoadResource(bool texture, bool dispose)
        {
            if (!MeasuringLoad)
                return;
            if (texture)
            {
                if (dispose)
                    _levelLoads.TextureDisposes++;
                else
                    _levelLoads.TextureCreates++;
            }
            else
            {
                if (dispose)
                    _levelLoads.BufferDisposes++;
                else
                    _levelLoads.BufferCreates++;
            }
        }

        public void RecordLoadRead(uint owned)
        {
            if (!MeasuringLoad)
                return;
            _levelLoads.Reads++;
            if (owned == 0)
                _levelLoads.ReadSplits++;
        }

        public long BeginFrameSubmission()
        {
            return Enabled ? Stopwatch.GetTimestamp() : 0;
        }

        public long BeginLoadSubmission(long started)
        {
            return MeasuringLoad ? started : 0;
        }

        public void EndFrameSubmission(long started, long completed)
        {
            if (started == 0)
                return;
            _frameSubmissions++;
            _submissionTicks += completed - started;
        }

        public long BeginLoadSubmission()
        {
            return MeasuringLoad ? Stopwatch.GetTimestamp() : 0;
        }

        public void EndLoadSubmission(long started)
        {
            EndLoadSubmission(started, started == 0 ? 0 : Stopwatch.GetTimestamp());
        }

        public void EndLoadSubmission(long started, long completed)
        {
            if (started == 0)
                return;
            _levelLoads.Submissions++;
            _levelLoads.SubmitTicks += completed - started;
        }

        public bool Enabled { get; private set; }
        public object Marker { get; set; }
        public long TimestampFrequency => Stopwatch.Frequency;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Count => _count;

        public void Start()
        {
            ResetEntityRenderTypes();
            ResetEntityUpdateTypes();
            if (_samples == null)
                _samples = new SourceFrameSample[Capacity];
            else
                Array.Clear(_samples, 0, _samples.Length);
            _count = 0;
            _sequence = 0;
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
            var result = new SourceFrameSample[Count];
            var first = (int)((_sequence - Count) & (Capacity - 1));
            var firstCount = Math.Min(Count, Capacity - first);
            Array.Copy(_samples ?? [], first, result, 0, firstCount);
            if (firstCount < Count)
                Array.Copy(_samples, 0, result, firstCount, Count - firstCount);
            if (_samples != null)
                Array.Clear(_samples, 0, _samples.Length);
            _count = 0;
            return result;
        }

        public int ExportCsv(string path)
        {
            var snapshot = TakeSamples();
            SourceFrameSampleCsvWriter.Write(path, snapshot);
            return snapshot.Length;
        }

        internal void Record(long timestamp, int updateCount, long updateTicks, long drawTicks, long endDrawTicks,
            long beginDrawTicks, long waitTicks, int gc0, int gc1, int gc2, object marker, ulong cyclesAtStart = 0,
            ulong cyclesAtWaitEnd = 0, ulong cyclesAtEnd = 0, byte cycleValidity = 0)
        {
            // A scheduled Stop/Take during Update must not append its own observation tick.
            if (!Enabled)
                return;
            if ((cycleValidity & 3) == 3 && cyclesAtWaitEnd < cyclesAtStart)
                cycleValidity &= 5;
            if ((cycleValidity & 4) != 0 && (((cycleValidity & 1) != 0 && cyclesAtEnd < cyclesAtStart) ||
                                             ((cycleValidity & 2) != 0 && cyclesAtEnd < cyclesAtWaitEnd)))
                cycleValidity &= 3;
            _samples[(int)(_sequence & (Capacity - 1))] = new(timestamp, _sequence,
                Stopwatch.GetTimestamp() - timestamp, updateCount, updateTicks, drawTicks, endDrawTicks, beginDrawTicks,
                waitTicks, GC.CollectionCount(0) - gc0, GC.CollectionCount(1) - gc1, GC.CollectionCount(2) - gc2, gc0,
                gc1, gc2, marker, _levelLoads, _frameSubmissions, _submissionTicks, _engineBeforeRenderTicks,
                _sceneRenderTicks, _engineAfterRenderTicks, _gameplayRenderTicks, _lightingRenderTicks,
                _gameplayEntityRenderTicks, _gameplayEndBatchTicks, _customBatchEntryFlushTicks,
                _customBatchCaptureTicks, _customBatchMaskTicks, _customBatchFilterTicks, _spriteBatchQuads,
                _spriteBatchTextureGroups, _spriteBatchFlushTicks, _spriteBatchFlushCount,
                _reflectionTentaclesRenderTicks, _reflectionTentaclesRenderCount, _customBatchEntityRenderTicks,
                _customBatchEntityRenderCount, _primitiveNativeSubmitTicks, _primitiveNativeSubmitCount,
                _primitivePresentationRecordTicks, _primitivePresentationRecordCount, _transitionEndOfFrameTicks,
                _transitionEndOfFrameCount, _transitionStartTicks, _transitionStartCount, _transitionEventsTicks,
                _transitionEventsCount, _audioUpdateTicks, _audioUpdateCount, _sceneEntityUpdateTicks,
                _sceneEntityUpdateCount, _reflectionTentaclesUpdateTicks, _reflectionTentaclesUpdateCount,
                _reflectionTentaclesVerticesTicks, _reflectionTentaclesVerticesCount, _lightOccludeUpdateTicks,
                _lightOccludeUpdateCount, _cassetteBlockVisualUpdateTicks, _cassetteBlockVisualUpdateCount,
                cyclesAtStart, cyclesAtWaitEnd, cyclesAtEnd, cycleValidity);
            _sequence++;
            if (Count < Capacity)
                _count++;
        }
    }
}

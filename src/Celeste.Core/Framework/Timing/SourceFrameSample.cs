namespace Celeste.Core.Framework.Timing
{
    public readonly struct SourceFrameSample
    {
        public readonly long Timestamp,
            Sequence,
            TotalTicks,
            UpdateTicks,
            DrawTicks,
            EndDrawTicks,
            BeginDrawTicks,
            WaitTicks;

        public readonly int UpdateCount, Gen0Collections, Gen1Collections, Gen2Collections;
        public readonly int Gen0CollectionsAtStart, Gen1CollectionsAtStart, Gen2CollectionsAtStart;
        public readonly object Marker;
        public readonly SourceLevelLoadSample LevelLoads;
        public readonly int FrameSubmissions;
        public readonly long SubmissionTicks;

        public readonly long EngineBeforeRenderTicks,
            SceneRenderTicks,
            EngineAfterRenderTicks,
            GameplayRenderTicks,
            LightingRenderTicks;

        public readonly long GameplayEntityRenderTicks, GameplayEndBatchTicks;

        public readonly long CustomBatchEntryFlushTicks,
            CustomBatchCaptureTicks,
            CustomBatchMaskTicks,
            CustomBatchFilterTicks;

        public readonly int SpriteBatchQuads, SpriteBatchTextureGroups, SpriteBatchFlushCount;
        public readonly long SpriteBatchFlushTicks;

        public readonly long ReflectionTentaclesRenderTicks;
        public readonly int ReflectionTentaclesRenderCount;
        public readonly long CustomBatchEntityRenderTicks;
        public readonly int CustomBatchEntityRenderCount;
        public readonly long PrimitiveNativeSubmitTicks;
        public readonly int PrimitiveNativeSubmitCount;
        public readonly long PrimitivePresentationRecordTicks;
        public readonly int PrimitivePresentationRecordCount;

        public readonly long TransitionEndOfFrameTicks;
        public readonly int TransitionEndOfFrameCount;
        public readonly long TransitionStartTicks;
        public readonly int TransitionStartCount;
        public readonly long TransitionEventsTicks;
        public readonly int TransitionEventsCount;

        public readonly long AudioUpdateTicks;
        public readonly int AudioUpdateCount;
        public readonly long SceneEntityUpdateTicks;
        public readonly int SceneEntityUpdateCount;
        public readonly long ReflectionTentaclesUpdateTicks;
        public readonly int ReflectionTentaclesUpdateCount;
        public readonly long ReflectionTentaclesVerticesTicks;
        public readonly int ReflectionTentaclesVerticesCount;

        public readonly long LightOccludeUpdateTicks;
        public readonly int LightOccludeUpdateCount;
        public readonly long CassetteBlockVisualUpdateTicks;
        public readonly int CassetteBlockVisualUpdateCount;

        public readonly ulong ThreadCyclesAtStart, ThreadCyclesAtWaitEnd, ThreadCyclesAtEnd;
        public readonly byte ThreadCycleValidity;

        internal SourceFrameSample(long timestamp, long sequence, long totalTicks, int updateCount,
            long updateTicks, long drawTicks, long endDrawTicks, long beginDrawTicks, long waitTicks,
            int gen0, int gen1, int gen2, int gc0AtStart, int gc1AtStart, int gc2AtStart, object marker,
            SourceLevelLoadSample levelLoads, int frameSubmissions, long submissionTicks,
            long engineBeforeRenderTicks, long sceneRenderTicks, long engineAfterRenderTicks,
            long gameplayRenderTicks, long lightingRenderTicks,
            long gameplayEntityRenderTicks, long gameplayEndBatchTicks,
            long customBatchEntryFlushTicks, long customBatchCaptureTicks, long customBatchMaskTicks,
            long customBatchFilterTicks,
            int spriteBatchQuads, int spriteBatchTextureGroups, long spriteBatchFlushTicks, int spriteBatchFlushCount,
            long reflectionTentaclesRenderTicks, int reflectionTentaclesRenderCount,
            long customBatchEntityRenderTicks, int customBatchEntityRenderCount,
            long primitiveNativeSubmitTicks, int primitiveNativeSubmitCount,
            long primitivePresentationRecordTicks, int primitivePresentationRecordCount,
            long transitionEndOfFrameTicks, int transitionEndOfFrameCount,
            long transitionStartTicks, int transitionStartCount,
            long transitionEventsTicks, int transitionEventsCount,
            long audioUpdateTicks, int audioUpdateCount,
            long sceneEntityUpdateTicks, int sceneEntityUpdateCount,
            long reflectionTentaclesUpdateTicks, int reflectionTentaclesUpdateCount,
            long reflectionTentaclesVerticesTicks, int reflectionTentaclesVerticesCount,
            long lightOccludeUpdateTicks, int lightOccludeUpdateCount,
            long cassetteBlockVisualUpdateTicks, int cassetteBlockVisualUpdateCount,
            ulong cyclesAtStart = 0, ulong cyclesAtWaitEnd = 0, ulong cyclesAtEnd = 0, byte cycleValidity = 0)
        {
            Timestamp = timestamp;
            Sequence = sequence;
            TotalTicks = totalTicks;
            UpdateCount = updateCount;
            UpdateTicks = updateTicks;
            DrawTicks = drawTicks;
            EndDrawTicks = endDrawTicks;
            BeginDrawTicks = beginDrawTicks;
            WaitTicks = waitTicks;
            Gen0Collections = gen0;
            Gen1Collections = gen1;
            Gen2Collections = gen2;
            Gen0CollectionsAtStart = gc0AtStart;
            Gen1CollectionsAtStart = gc1AtStart;
            Gen2CollectionsAtStart = gc2AtStart;
            Marker = marker;
            LevelLoads = levelLoads;
            FrameSubmissions = frameSubmissions;
            SubmissionTicks = submissionTicks;
            EngineBeforeRenderTicks = engineBeforeRenderTicks;
            SceneRenderTicks = sceneRenderTicks;
            EngineAfterRenderTicks = engineAfterRenderTicks;
            GameplayRenderTicks = gameplayRenderTicks;
            LightingRenderTicks = lightingRenderTicks;
            GameplayEntityRenderTicks = gameplayEntityRenderTicks;
            GameplayEndBatchTicks = gameplayEndBatchTicks;
            CustomBatchEntryFlushTicks = customBatchEntryFlushTicks;
            CustomBatchCaptureTicks = customBatchCaptureTicks;
            CustomBatchMaskTicks = customBatchMaskTicks;
            CustomBatchFilterTicks = customBatchFilterTicks;
            SpriteBatchQuads = spriteBatchQuads;
            SpriteBatchTextureGroups = spriteBatchTextureGroups;
            SpriteBatchFlushTicks = spriteBatchFlushTicks;
            SpriteBatchFlushCount = spriteBatchFlushCount;
            ReflectionTentaclesRenderTicks = reflectionTentaclesRenderTicks;
            ReflectionTentaclesRenderCount = reflectionTentaclesRenderCount;
            CustomBatchEntityRenderTicks = customBatchEntityRenderTicks;
            CustomBatchEntityRenderCount = customBatchEntityRenderCount;
            PrimitiveNativeSubmitTicks = primitiveNativeSubmitTicks;
            PrimitiveNativeSubmitCount = primitiveNativeSubmitCount;
            PrimitivePresentationRecordTicks = primitivePresentationRecordTicks;
            PrimitivePresentationRecordCount = primitivePresentationRecordCount;
            TransitionEndOfFrameTicks = transitionEndOfFrameTicks;
            TransitionEndOfFrameCount = transitionEndOfFrameCount;
            TransitionStartTicks = transitionStartTicks;
            TransitionStartCount = transitionStartCount;
            TransitionEventsTicks = transitionEventsTicks;
            TransitionEventsCount = transitionEventsCount;
            AudioUpdateTicks = audioUpdateTicks;
            AudioUpdateCount = audioUpdateCount;
            SceneEntityUpdateTicks = sceneEntityUpdateTicks;
            SceneEntityUpdateCount = sceneEntityUpdateCount;
            ReflectionTentaclesUpdateTicks = reflectionTentaclesUpdateTicks;
            ReflectionTentaclesUpdateCount = reflectionTentaclesUpdateCount;
            ReflectionTentaclesVerticesTicks = reflectionTentaclesVerticesTicks;
            ReflectionTentaclesVerticesCount = reflectionTentaclesVerticesCount;
            LightOccludeUpdateTicks = lightOccludeUpdateTicks;
            LightOccludeUpdateCount = lightOccludeUpdateCount;
            CassetteBlockVisualUpdateTicks = cassetteBlockVisualUpdateTicks;
            CassetteBlockVisualUpdateCount = cassetteBlockVisualUpdateCount;
            ThreadCyclesAtStart = cyclesAtStart;
            ThreadCyclesAtWaitEnd = cyclesAtWaitEnd;
            ThreadCyclesAtEnd = cyclesAtEnd;
            ThreadCycleValidity = cycleValidity;
        }
    }
}

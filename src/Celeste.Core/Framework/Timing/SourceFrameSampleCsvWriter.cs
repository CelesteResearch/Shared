using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Celeste.Core.Framework.Timing
{
    public static class SourceFrameSampleCsvWriter
    {
        public static void Write(string path, SourceFrameSample[] samples)
        {
            if (samples == null) throw new ArgumentNullException(nameof(samples));
            using (var writer = new StreamWriter(path, false, new UTF8Encoding(false)))
            {
                writer.Write(
                    "sequence,timestamp,totalTicks,updateCount,updateTicks,drawTicks,endDrawTicks,beginDrawTicks,waitTicks,gc0,gc1,gc2,gc0AtStart,gc1AtStart,gc2AtStart,marker,loadCount,loadFirstRoom,loadLastRoom,loadTicks,ownedWrites,borrowedWrites,textureUploads,bufferUploads,textureBytes,bufferBytes,textureCreates,bufferCreates,textureDisposes,bufferDisposes,reads,readSplits,submissions,submitTicks,frameSubmissions,submissionTicks,setupTicks,mapEntityTicks,mapRemainderTicks,actorPrepareTicks,entityCommitTicks,actorFinalizeTicks,objectTileTicks,postLoadTicks,awakeTicks,platformAttachmentTicks,groupAwakeTicks,engineBeforeRenderTicks,sceneRenderTicks,engineAfterRenderTicks,gameplayRenderTicks,lightingRenderTicks,gameplayEntityRenderTicks,gameplayEndBatchTicks,customBatchEntryFlushTicks,customBatchCaptureTicks,customBatchMaskTicks,customBatchFilterTicks,spriteBatchQuads,spriteBatchTextureGroups,spriteBatchFlushTicks,spriteBatchFlushCount,reflectionTentaclesRenderTicks,reflectionTentaclesRenderCount,customBatchEntityRenderTicks,customBatchEntityRenderCount,primitiveNativeSubmitTicks,primitiveNativeSubmitCount,primitivePresentationRecordTicks,primitivePresentationRecordCount,transitionEndOfFrameTicks,transitionEndOfFrameCount,transitionStartTicks,transitionStartCount,transitionEventsTicks,transitionEventsCount,audioUpdateTicks,audioUpdateCount,sceneEntityUpdateTicks,sceneEntityUpdateCount,reflectionTentaclesUpdateTicks,reflectionTentaclesUpdateCount,reflectionTentaclesVerticesTicks,reflectionTentaclesVerticesCount,lightOccludeUpdateTicks,lightOccludeUpdateCount,cassetteBlockVisualUpdateTicks,cassetteBlockVisualUpdateCount,threadCyclesAtStart,threadCyclesAtWaitEnd,threadCyclesAtEnd,threadCycleValidity");
                writer.Write('\n');
                for (int i = 0; i < samples.Length; i++)
                {
                    ref readonly SourceFrameSample sample = ref samples[i];
                    ref readonly SourceLevelLoadSample loads = ref sample.LevelLoads;
                    WriteNumber(writer, sample.Sequence);
                    WriteNumber(writer, sample.Timestamp);
                    WriteNumber(writer, sample.TotalTicks);
                    WriteNumber(writer, sample.UpdateCount);
                    WriteNumber(writer, sample.UpdateTicks);
                    WriteNumber(writer, sample.DrawTicks);
                    WriteNumber(writer, sample.EndDrawTicks);
                    WriteNumber(writer, sample.BeginDrawTicks);
                    WriteNumber(writer, sample.WaitTicks);
                    WriteNumber(writer, sample.Gen0Collections);
                    WriteNumber(writer, sample.Gen1Collections);
                    WriteNumber(writer, sample.Gen2Collections);
                    WriteNumber(writer, sample.Gen0CollectionsAtStart);
                    WriteNumber(writer, sample.Gen1CollectionsAtStart);
                    WriteNumber(writer, sample.Gen2CollectionsAtStart);
                    WriteField(writer, Convert.ToString(sample.Marker, CultureInfo.InvariantCulture));
                    WriteNumber(writer, loads.Count);
                    WriteField(writer, loads.FirstRoom);
                    WriteField(writer, loads.LastRoom);
                    WriteNumber(writer, loads.ElapsedTicks);
                    WriteNumber(writer, loads.OwnedWrites);
                    WriteNumber(writer, loads.BorrowedWrites);
                    WriteNumber(writer, loads.TextureUploads);
                    WriteNumber(writer, loads.BufferUploads);
                    WriteNumber(writer, loads.TextureBytes);
                    WriteNumber(writer, loads.BufferBytes);
                    WriteNumber(writer, loads.TextureCreates);
                    WriteNumber(writer, loads.BufferCreates);
                    WriteNumber(writer, loads.TextureDisposes);
                    WriteNumber(writer, loads.BufferDisposes);
                    WriteNumber(writer, loads.Reads);
                    WriteNumber(writer, loads.ReadSplits);
                    WriteNumber(writer, loads.Submissions);
                    WriteNumber(writer, loads.SubmitTicks);
                    WriteNumber(writer, sample.FrameSubmissions);
                    WriteNumber(writer, sample.SubmissionTicks);
                    WriteNumber(writer, loads.SetupTicks);
                    WriteNumber(writer, loads.MapEntityTicks);
                    WriteNumber(writer, loads.MapRemainderTicks);
                    WriteNumber(writer, loads.ActorPrepareTicks);
                    WriteNumber(writer, loads.EntityCommitTicks);
                    WriteNumber(writer, loads.ActorFinalizeTicks);
                    WriteNumber(writer, loads.ObjectTileTicks);
                    WriteNumber(writer, loads.PostLoadTicks);
                    WriteNumber(writer, loads.AwakeTicks);
                    WriteNumber(writer, loads.PlatformAttachmentTicks);
                    WriteNumber(writer, loads.GroupAwakeTicks);
                    WriteNumber(writer, sample.EngineBeforeRenderTicks);
                    WriteNumber(writer, sample.SceneRenderTicks);
                    WriteNumber(writer, sample.EngineAfterRenderTicks);
                    WriteNumber(writer, sample.GameplayRenderTicks);
                    WriteNumber(writer, sample.LightingRenderTicks);
                    WriteNumber(writer, sample.GameplayEntityRenderTicks);
                    WriteNumber(writer, sample.GameplayEndBatchTicks);
                    WriteNumber(writer, sample.CustomBatchEntryFlushTicks);
                    WriteNumber(writer, sample.CustomBatchCaptureTicks);
                    WriteNumber(writer, sample.CustomBatchMaskTicks);
                    WriteNumber(writer, sample.CustomBatchFilterTicks);
                    WriteNumber(writer, sample.SpriteBatchQuads);
                    WriteNumber(writer, sample.SpriteBatchTextureGroups);
                    WriteNumber(writer, sample.SpriteBatchFlushTicks);
                    WriteNumber(writer, sample.SpriteBatchFlushCount);
                    WriteNumber(writer, sample.ReflectionTentaclesRenderTicks);
                    WriteNumber(writer, sample.ReflectionTentaclesRenderCount);
                    WriteNumber(writer, sample.CustomBatchEntityRenderTicks);
                    WriteNumber(writer, sample.CustomBatchEntityRenderCount);
                    WriteNumber(writer, sample.PrimitiveNativeSubmitTicks);
                    WriteNumber(writer, sample.PrimitiveNativeSubmitCount);
                    WriteNumber(writer, sample.PrimitivePresentationRecordTicks);
                    WriteNumber(writer, sample.PrimitivePresentationRecordCount);
                    WriteNumber(writer, sample.TransitionEndOfFrameTicks);
                    WriteNumber(writer, sample.TransitionEndOfFrameCount);
                    WriteNumber(writer, sample.TransitionStartTicks);
                    WriteNumber(writer, sample.TransitionStartCount);
                    WriteNumber(writer, sample.TransitionEventsTicks);
                    WriteNumber(writer, sample.TransitionEventsCount);
                    WriteNumber(writer, sample.AudioUpdateTicks);
                    WriteNumber(writer, sample.AudioUpdateCount);
                    WriteNumber(writer, sample.SceneEntityUpdateTicks);
                    WriteNumber(writer, sample.SceneEntityUpdateCount);
                    WriteNumber(writer, sample.ReflectionTentaclesUpdateTicks);
                    WriteNumber(writer, sample.ReflectionTentaclesUpdateCount);
                    WriteNumber(writer, sample.ReflectionTentaclesVerticesTicks);
                    WriteNumber(writer, sample.ReflectionTentaclesVerticesCount);
                    WriteNumber(writer, sample.LightOccludeUpdateTicks);
                    WriteNumber(writer, sample.LightOccludeUpdateCount);
                    WriteNumber(writer, sample.CassetteBlockVisualUpdateTicks);
                    WriteNumber(writer, sample.CassetteBlockVisualUpdateCount);
                    WriteUnsignedNumber(writer, sample.ThreadCyclesAtStart);
                    WriteUnsignedNumber(writer, sample.ThreadCyclesAtWaitEnd);
                    WriteUnsignedNumber(writer, sample.ThreadCyclesAtEnd);
                    WriteNumber(writer, sample.ThreadCycleValidity, false);

                    writer.Write('\n');
                }
            }
        }

        private static void WriteNumber(StreamWriter writer, long value, bool separator = true)
        {
            Span<char> characters = stackalloc char[20];
            value.TryFormat(characters, out int length, default, CultureInfo.InvariantCulture);
            writer.Write(characters.Slice(0, length));
            if (separator) writer.Write(',');
        }

        private static void WriteUnsignedNumber(StreamWriter writer, ulong value)
        {
            Span<char> characters = stackalloc char[20];
            value.TryFormat(characters, out int length, default, CultureInfo.InvariantCulture);
            writer.Write(characters.Slice(0, length));
            writer.Write(',');
        }

        private static void WriteField(StreamWriter writer, string value)
        {
            if (string.IsNullOrEmpty(value)) value = "nil";
            bool quoted = value.IndexOf(',') >= 0 || value.IndexOf('"') >= 0 ||
                          value.IndexOf('\r') >= 0 || value.IndexOf('\n') >= 0;
            if (quoted) writer.Write('"');
            for (int i = 0; i < value.Length; i++)
            {
                char character = value[i];
                if (quoted && character == '"') writer.Write('"');
                writer.Write(character);
            }

            if (quoted) writer.Write('"');
            writer.Write(',');
        }
    }
}

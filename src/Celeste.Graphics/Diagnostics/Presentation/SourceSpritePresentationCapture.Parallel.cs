using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using Celeste.Core.Rendering.Observation;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    public sealed partial class SourceSpritePresentationCapture
    {
        private const int MinimumParallelRecords = 8192;
        private readonly bool parallelRecords;
        private bool parallelRecordsUnavailable;
        private BatchCopyJob copyJob;

        public SourceSpritePresentationCapture()
        {
        }

        // Hosts opt in only when managed worker threads are available.
        public SourceSpritePresentationCapture(bool parallelRecords)
        {
            this.parallelRecords = parallelRecords;
        }

        private sealed class BatchCopyJob
        {
            internal const int Waiting = 0, Started = 1, Cancelled = 2, Completed = 3;
            internal SourceSpritePresentationQuad[] Output;
            internal int[] Groups;
            internal SourceTexture2DResource[] Textures;
            internal SourceSpriteQuad[] Quads;
            internal SourceRenderObservationScope[] Owners;
            internal SourceSpritePresentationQuad.Header Header;
            internal int Destination, Group, End, State, InFlight;
            internal ExceptionDispatchInfo Error;
            internal readonly ManualResetEventSlim Done = new(false);
            internal static readonly WaitCallback Callback = value => ((BatchCopyJob)value).Run();

            private void Run()
            {
                if (Interlocked.CompareExchange(ref State, Started, Waiting) != Waiting)
                {
                    Volatile.Write(ref InFlight, 0);
                    return;
                }

                try
                {
                    CopyRows(Header, Textures, Quads, Owners, Output, Groups, Destination, 0, End, Group);
                }
                catch (Exception error)
                {
                    Error = ExceptionDispatchInfo.Capture(error);
                }
                finally
                {
                    Volatile.Write(ref State, Completed);
                    Done.Set();
                    Volatile.Write(ref InFlight, 0);
                }
            }

            internal void CancelOrJoin()
            {
                if (Interlocked.CompareExchange(ref State, Cancelled, Waiting) != Waiting &&
                    Volatile.Read(ref State) != Cancelled) Done.Wait();
            }

            internal void ReleaseInputs()
            {
                Output = null;
                Groups = null;
                Textures = null;
                Quads = null;
                Owners = null;
                Header = null;
                Error = null;
            }
        }

        private static void CopyRows(SourceSpritePresentationQuad.Header header, SourceTexture2DResource[] textures,
            SourceSpriteQuad[] quads, SourceRenderObservationScope[] owners, SourceSpritePresentationQuad[] output,
            int[] groups, int destination, int first, int end, int group)
        {
            for (var index = first; index < end; index++)
            {
                var recorded = new SourceSpritePresentationQuad(header, textures[index],
                    in quads[index], in owners[index]);
                output[destination + index] = recorded;
                groups[destination + index] = group;
            }
        }

        private bool TryRecordBatchParallel(SourceSpritePresentationQuad.Header header,
            SourceTexture2DResource[] textures, SourceSpriteQuad[] quads, SourceRenderObservationScope[] owners,
            int count)
        {
            // Growth and malformed arrays retain the original sequential exception/write order.
            if (parallelRecordsUnavailable || pending == null || pendingBatchGroups == null || textures == null ||
                quads == null || owners == null || (uint)pendingCount > (uint)pending.Length ||
                (uint)pendingCount > (uint)pendingBatchGroups.Length || count > pending.Length - pendingCount ||
                count > pendingBatchGroups.Length - pendingCount || count > textures.Length ||
                count > quads.Length || count > owners.Length) return false;

            BatchCopyJob job;
            try
            {
                job = copyJob ??= new();
            }
            catch (OutOfMemoryException)
            {
                parallelRecordsUnavailable = true;
                return false;
            }

            // A cancelled callback must acknowledge its old submission before this slot can be reused.
            if (Volatile.Read(ref job.InFlight) != 0) return false;
            int destination = pendingCount, group = pendingCount + 1, split = count / 2;
            job.Output = pending;
            job.Groups = pendingBatchGroups;
            job.Textures = textures;
            job.Quads = quads;
            job.Owners = owners;
            job.Header = header;
            job.Destination = destination;
            job.Group = group;
            job.End = split;
            job.Done.Reset();
            Volatile.Write(ref job.State, BatchCopyJob.Waiting);
            Volatile.Write(ref job.InFlight, 1);
            var published = false;
            try
            {
                if (!ThreadPool.UnsafeQueueUserWorkItem(BatchCopyJob.Callback, job))
                {
                    Volatile.Write(ref job.State, BatchCopyJob.Cancelled);
                    Volatile.Write(ref job.InFlight, 0);
                    return false;
                }

                CopyRows(header, textures, quads, owners, pending, pendingBatchGroups, destination, split, count,
                    group);
                // Do not wait for a queued task to start. A late callback only acknowledges cancellation.
                if (Interlocked.CompareExchange(ref job.State, BatchCopyJob.Cancelled, BatchCopyJob.Waiting) ==
                    BatchCopyJob.Waiting)
                    CopyRows(header, textures, quads, owners, pending, pendingBatchGroups, destination, 0, split,
                        group);
                else job.Done.Wait();
                job.Error?.Throw();
                pendingCount += count;
                published = true;
                return true;
            }
            catch (NotSupportedException)
            {
                parallelRecordsUnavailable = true;
                return false;
            }
            catch (OutOfMemoryException)
            {
                parallelRecordsUnavailable = true;
                return false;
            }
            finally
            {
                job.CancelOrJoin();
                if (!published)
                {
                    Array.Clear(pending, destination, count);
                    Array.Clear(pendingBatchGroups, destination, count);
                }

                job.ReleaseInputs();
            }
        }

        private void ReleaseParallelCopyResources()
        {
            var job = copyJob;
            if (job == null || Volatile.Read(ref job.InFlight) != 0) return;
            job.Done.Dispose();
            copyJob = null;
        }
    }
}

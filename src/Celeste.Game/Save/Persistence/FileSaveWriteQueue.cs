using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.Storage;

namespace Celeste.Game.Save.Persistence
{
    // FileSaveCodec serialization belongs to the gameplay thread. This queue owns
    // only UserIO's ordered, verified disk writes and has no engine dependency.
    public sealed class FileSaveWriteQueue
    {
        private sealed class Request
        {
            public FileSaveStorage Storage;
            public int Slot;
            public byte[] Progress;
            public byte[] Settings;
            public FileSaveWriteOrder Order;
        }

        private readonly IOriginalSaveInitializationPolicy filenames;
        private readonly IOriginalAreaKeyPolicy areaKeys;
        private readonly OriginalSessionFactory sessions;
        private readonly IOriginalSaveAllocationPolicy allocation;

        public FileSaveWriteQueue(IOriginalSaveInitializationPolicy filenames,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions,
            IOriginalSaveAllocationPolicy allocation)
        {
            this.filenames = filenames;
            this.areaKeys = areaKeys;
            this.sessions = sessions;
            this.allocation = allocation;
        }

        private readonly object gate = new();
        private readonly Queue<Request> pending = new();
        private Thread worker;
        private Exception failure;
        private Request failedRequest;

        public bool Writing
        {
            get
            {
                lock (gate)
                {
                    return worker != null;
                }
            }
        }

        public bool Failed
        {
            get
            {
                lock (gate)
                {
                    return failure != null;
                }
            }
        }

        public Exception Failure
        {
            get
            {
                lock (gate)
                {
                    return failure;
                }
            }
        }

        public void Enqueue(FileSaveStorage storage, int slot, byte[] progress, byte[] settings = null,
            FileSaveWriteOrder order = null)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (progress == null && settings == null) throw new ArgumentException("No save data was provided.");
            lock (gate)
            {
                ThrowIfFailedLocked();
                pending.Enqueue(new()
                {
                    Storage = storage, Slot = slot,
                    Progress = progress == null ? null : (byte[])progress.Clone(),
                    Settings = settings == null ? null : (byte[])settings.Clone(),
                    Order = order,
                });
                StartWorkerLocked();
            }
        }

        public void RetryFailed()
        {
            lock (gate)
            {
                if (failure == null || failedRequest == null)
                    throw new InvalidOperationException("There is no failed save to retry.");
                var rest = pending.ToArray();
                pending.Clear();
                pending.Enqueue(failedRequest);
                foreach (var request in rest) pending.Enqueue(request);
                failedRequest = null;
                failure = null;
                StartWorkerLocked();
            }
        }

        public void IgnoreFailure()
        {
            lock (gate)
            {
                if (failure == null)
                    throw new InvalidOperationException("There is no failed save to ignore.");
                failedRequest = null;
                failure = null;
                StartWorkerLocked();
            }
        }

        private void StartWorkerLocked()
        {
            if (worker != null || pending.Count == 0) return;
            worker = new(WritePending) { Name = "USER_IO", IsBackground = false };
            try
            {
                worker.Start();
            }
            catch (Exception error)
            {
                failure = error;
                worker = null;
                ThrowIfFailedLocked();
            }
        }

        public void ThrowIfFailed()
        {
            lock (gate)
            {
                ThrowIfFailedLocked();
            }
        }

        private void ThrowIfFailedLocked()
        {
            if (failure != null) throw new IOException("Saving the selected file failed.", failure);
        }

        // Useful at a deliberate process-exit boundary and in isolated IO probes.
        // Ordinary scene changes do not wait for the disk worker.
        public void WaitForIdle()
        {
            while (true)
            {
                Thread active;
                lock (gate)
                {
                    ThrowIfFailedLocked();
                    active = worker;
                    if (active == null) return;
                }

                active.Join();
            }
        }

        private void WritePending()
        {
            while (true)
            {
                Request request;
                lock (gate)
                {
                    if (pending.Count == 0)
                    {
                        worker = null;
                        return;
                    }

                    request = pending.Dequeue();
                }

                try
                {
                    if (request.Order == null)
                        request.Storage.Write(filenames.GetFilename(request.Slot), request.Progress, areaKeys, sessions,
                            allocation, request.Settings);
                    else
                        request.Order.Write(request.Storage, filenames.GetFilename(request.Slot), request.Progress,
                            request.Settings, areaKeys, sessions, allocation);
                }
                catch (Exception error)
                {
                    lock (gate)
                    {
                        failedRequest = request;
                        failure = error;
                        worker = null;
                    }

                    return;
                }
            }
        }
    }
}

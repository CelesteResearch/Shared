using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Celeste.Graphics.Threading
{
    public sealed class GraphicsOwnerDispatcher : IDisposable
    {
        private readonly int ownerThread;
        private readonly ConcurrentQueue<GraphicsDispatchRequest> requests = new();
        private readonly object requestGate = new();
        private bool acceptingWorkerRequests = true;
        private bool disposed;

        public GraphicsOwnerDispatcher(int ownerThread)
        {
            if (ownerThread <= 0) throw new ArgumentOutOfRangeException(nameof(ownerThread));
            this.ownerThread = ownerThread;
        }

        public bool IsOwnerThread => Thread.CurrentThread.ManagedThreadId == ownerThread;

        public void RequireOwnerThread()
        {
            if (disposed) throw new ObjectDisposedException(nameof(GraphicsOwnerDispatcher));
            if (!IsOwnerThread)
                throw new InvalidOperationException("Physical graphics operations require their actual owner thread.");
        }

        public void Invoke(Action operation)
        {
            if (IsOwnerThread)
            {
                RequireOwnerThread();
                operation();
                return;
            }

            var request = new GraphicsDispatchRequest(operation);
            lock (requestGate)
            {
                if (disposed || !acceptingWorkerRequests)
                    throw new ObjectDisposedException(nameof(GraphicsOwnerDispatcher));
                requests.Enqueue(request);
            }

            request.Wait();
        }

        public void Pump()
        {
            RequireOwnerThread();
            while (requests.TryDequeue(out var request)) request.Execute();
        }

        public void StopWorkerRequests()
        {
            RequireOwnerThread();
            lock (requestGate)
            {
                acceptingWorkerRequests = false;
                CancelPendingRequests();
            }
        }

        public void Dispose()
        {
            if (!IsOwnerThread)
                throw new InvalidOperationException("Dispose the graphics dispatcher on its owner thread.");
            lock (requestGate)
            {
                if (disposed) return;
                disposed = true;
                acceptingWorkerRequests = false;
                CancelPendingRequests();
            }
        }

        private void CancelPendingRequests()
        {
            while (requests.TryDequeue(out var request))
                request.Cancel(new ObjectDisposedException(nameof(GraphicsOwnerDispatcher)));
        }
    }
}

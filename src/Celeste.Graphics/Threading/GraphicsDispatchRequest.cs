using System;
using System.Threading.Tasks;

namespace Celeste.Graphics.Threading
{
    internal sealed class GraphicsDispatchRequest
    {
        private readonly Action operation;
        private readonly TaskCompletionSource<bool> completed = new(TaskCreationOptions.RunContinuationsAsynchronously);

        internal GraphicsDispatchRequest(Action operation)
        {
            this.operation = operation;
        }

        internal void Execute()
        {
            try
            {
                operation();
                completed.TrySetResult(true);
            }
            catch (Exception error)
            {
                completed.TrySetException(error);
            }
        }

        internal void Cancel(Exception error)
        {
            completed.TrySetException(error);
        }

        internal void Wait()
        {
            completed.Task.GetAwaiter().GetResult();
        }
    }
}

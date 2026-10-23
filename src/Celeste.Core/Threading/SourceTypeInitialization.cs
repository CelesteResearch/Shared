using System;

namespace Celeste.Core.Threading
{
    public sealed class SourceTypeInitialization<T>
    {
        private readonly object initializationLock = new object();
        private readonly string sourceTypeName;
        private readonly ISourceTypeInitializationFactory<T> factory;
        private T instance;
        private InitializationState state;
        private Exception failure;

        private enum InitializationState
        {
            Uninitialized,
            Initializing,
            Initialized,
            Failed
        }

        public SourceTypeInitialization(string sourceTypeName, ISourceTypeInitializationFactory<T> factory)
        {
            this.sourceTypeName = sourceTypeName ?? throw new ArgumentNullException(nameof(sourceTypeName));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public T Value
        {
            get
            {
                lock (initializationLock)
                {
                    if (state == InitializationState.Initialized)
                        return instance;
                    if (state == InitializationState.Failed)
                        throw failure;
                    // Initialization holds the same monitor for its complete body.
                    // Only its own executing thread can reenter this branch.
                    if (state == InitializationState.Initializing)
                        return instance;

                    state = InitializationState.Initializing;
                    try
                    {
                        instance = factory.Allocate();
                        factory.Initialize(instance);
                    }
                    catch (Exception exception)
                    {
                        // Publish permanent failure even if allocating its source
                        // TypeInitializationException itself cannot complete.
                        failure = exception;
                        state = InitializationState.Failed;
                        failure = new TypeInitializationException(sourceTypeName, exception);
                        throw failure;
                    }

                    state = InitializationState.Initialized;
                    return instance;
                }
            }
        }
    }
}

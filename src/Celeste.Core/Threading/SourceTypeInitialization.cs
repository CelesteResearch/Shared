using System;

namespace Celeste.Core.Threading
{
    public sealed class SourceTypeInitialization<T>
    {
        private readonly object _initializationLock = new();
        private readonly string _sourceTypeName;
        private readonly ISourceTypeInitializationFactory<T> _factory;
        private T _instance;
        private InitializationState _state;
        private Exception _failure;

        private enum InitializationState
        {
            Uninitialized,
            Initializing,
            Initialized,
            Failed,
        }

        public SourceTypeInitialization(string sourceTypeName, ISourceTypeInitializationFactory<T> factory)
        {
            _sourceTypeName = sourceTypeName ?? throw new ArgumentNullException(nameof(sourceTypeName));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public T Value
        {
            get
            {
                lock (_initializationLock)
                {
                    if (_state == InitializationState.Initialized)
                        return _instance;
                    if (_state == InitializationState.Failed)
                        throw _failure;
                    // Initialization holds the same monitor for its complete body.
                    // Only its own executing thread can reenter this branch.
                    if (_state == InitializationState.Initializing)
                        return _instance;

                    _state = InitializationState.Initializing;
                    try
                    {
                        _instance = _factory.Allocate();
                        _factory.Initialize(_instance);
                    }
                    catch (Exception exception)
                    {
                        // Publish permanent failure even if allocating its source
                        // TypeInitializationException itself cannot complete.
                        _failure = exception;
                        _state = InitializationState.Failed;
                        _failure = new TypeInitializationException(_sourceTypeName, exception);
                        throw _failure;
                    }

                    _state = InitializationState.Initialized;
                    return _instance;
                }
            }
        }
    }
}

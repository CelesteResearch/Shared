using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Hosting.Runtime
{
    public sealed class BackgroundEmbeddedGameSession : IEmbeddedGameSession
    {
        private readonly object _gate = new();
        private readonly EmbeddedGameConfiguration _configuration;
        private readonly Func<EmbeddedGameConfiguration, IEmbeddedGameSession> _create;

        private readonly TaskCompletionSource<bool> _disposedCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        private readonly Queue<char> _text = new();
        private BackgroundInputFrame? _head;
        private BackgroundInputFrame? _tail;
        private BackgroundInputFrame? _free;
        private bool _disposeRequested;
        private bool _suspended;
        private bool _releaseRequested;
        private long _controlVersion;
        private volatile bool _loading = true;
        private volatile bool _running = true;
        private volatile bool _textActive;
        private volatile Exception? _failure;
        private byte[] _publishedPixels = [];
        private int _publishedWidth;
        private int _publishedHeight;
        private long _publishedFrameNumber = -1;

        private byte[] _consumerPixels = [];

        private int _consumerWidth;

        private int _consumerHeight;

        private long _consumerFrameNumber = -1;

        public BackgroundEmbeddedGameSession(EmbeddedGameConfiguration configuration,
            Func<EmbeddedGameConfiguration, IEmbeddedGameSession> create)
        {
            _configuration = configuration;
            _create = create;
            _consumerWidth = configuration.Width;
            _consumerHeight = configuration.Height;
            new Thread(Run) { IsBackground = true, Name = "Embedded game" }.Start();
        }

        public bool IsLoading => _loading;
        public Exception? InitializationError => _failure;
        public Task DisposedCompletion => _disposedCompletion.Task;
        public bool IsRunning => _running;
        public bool IsTextInputActive => _textActive;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Width => _consumerWidth;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Height => _consumerHeight;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public byte[] FrameRgba => _consumerPixels;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public long FrameNumber => _consumerFrameNumber;

        public void Advance(int[] pressedKeys, int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused)
        {
            lock (_gate)
            {
                if (_publishedFrameNumber != FrameNumber)
                {
                    if (FrameRgba.Length != _publishedPixels.Length)
                        _consumerPixels = new byte[_publishedPixels.Length];
                    Buffer.BlockCopy(_publishedPixels, 0, FrameRgba, 0, _publishedPixels.Length);
                    _consumerWidth = _publishedWidth;
                    _consumerHeight = _publishedHeight;
                    _consumerFrameNumber = _publishedFrameNumber;
                }

                if (_loading || _disposeRequested || _suspended || _failure != null || !_running) return;
                if (_tail != null && _tail.Matches(pressedKeys, mouseX, mouseY, mouseButtons, wheelDelta, focused))
                {
                    _tail.Updates++;
                }
                else
                {
                    var frame = _free ?? new BackgroundInputFrame();
                    _free = frame.Next;
                    frame.Next = null;
                    frame.Set(pressedKeys, mouseX, mouseY, mouseButtons, wheelDelta, focused);
                    if (_tail == null) _head = frame;
                    else _tail.Next = frame;
                    _tail = frame;
                }

                Monitor.Pulse(_gate);
            }
        }

        public void PushTextInput(char character)
        {
            lock (_gate)
            {
                if (_loading || _disposeRequested || _suspended || _failure != null || !_running) return;
                _text.Enqueue(character);
                Monitor.Pulse(_gate);
            }
        }

        public void SetSuspended(bool value)
        {
            lock (_gate)
            {
                if (_disposeRequested || _suspended == value) return;
                _suspended = value;
                _controlVersion++;
                if (value)
                {
                    _releaseRequested = true;
                    _textActive = false;
                    ClearPending();
                }

                Monitor.Pulse(_gate);
            }
        }

        public void Dispose()
        {
            lock (_gate)
            {
                _disposeRequested = true;
                _running = false;
                _textActive = false;
                ClearPending();
                Monitor.Pulse(_gate);
            }
        }

        private void ClearPending()
        {
            if (_tail != null)
            {
                _tail.Next = _free;
                _free = _head;
                _head = _tail = null;
            }

            _text.Clear();
        }

        private void Run()
        {
            IEmbeddedGameSession? actual = null;
            Exception? error = null;
            try
            {
                actual = _create(_configuration);
                _loading = false;
                var appliedVersion = -1L;
                while (true)
                {
                    BackgroundInputFrame? frame;
                    bool desiredSuspend;
                    bool releaseInput;
                    long version;
                    char[] characters;
                    lock (_gate)
                    {
                        while (!_disposeRequested && _controlVersion == appliedVersion && _head == null &&
                               _text.Count == 0)
                            Monitor.Wait(_gate);
                        if (_disposeRequested) break;
                        desiredSuspend = _suspended;
                        releaseInput = _releaseRequested;
                        _releaseRequested = false;
                        version = _controlVersion;
                        frame = _head;
                        if (frame != null)
                        {
                            _head = frame.Next;
                            if (_head == null) _tail = null;
                            frame.Next = null;
                        }

                        characters = _text.Count == 0
                            ? []
                            : /* ReSharper disable once UseCollectionExpression */ _text.ToArray();
                        _text.Clear();
                    }

                    if (version != appliedVersion)
                    {
                        if (releaseInput) actual.SetSuspended(true);
                        if (!releaseInput || !desiredSuspend) actual.SetSuspended(desiredSuspend);
                        appliedVersion = version;
                    }

                    if (!desiredSuspend)
                    {
                        foreach (var character in characters) actual.PushTextInput(character);
                        if (frame != null)
                            for (var update = 0L; update < frame.Updates; update++)
                            {
                                lock (_gate)
                                {
                                    if (_disposeRequested || _controlVersion != version)
                                        break;
                                }

                                actual.Advance(frame.Keys, frame.MouseX, frame.MouseY, frame.Buttons,
                                    update == 0 ? frame.Wheel : 0, frame.Focused);
                                Publish(actual);
                                if (!actual.IsRunning) break;
                            }
                    }

                    if (frame != null)
                        lock (_gate)
                        {
                            frame.Next = _free;
                            _free = frame;
                        }

                    if (!actual.IsRunning) break;
                }
            }
            catch (Exception exception)
            {
                error = exception;
            }
            finally
            {
                try
                {
                    actual?.Dispose();
                }
                catch (Exception exception)
                {
                    error = error == null ? exception : new AggregateException(error, exception);
                }

                _loading = false;
                _running = false;
                _textActive = false;
                lock (_gate)
                {
                    ClearPending();
                }

                if (error == null)
                {
                    _disposedCompletion.TrySetResult(true);
                }
                else
                {
                    _failure = error;
                    try
                    {
                        _configuration.ReportError("Embedded game", error.ToString());
                    }
                    catch
                    {
                        /* A host logger must not prevent native cleanup completion. */
                    }

                    _disposedCompletion.TrySetException(error);
                }
            }
        }

        private void Publish(IEmbeddedGameSession actual)
        {
            lock (_gate)
            {
                if (actual.FrameNumber != _publishedFrameNumber)
                {
                    var pixels = actual.FrameRgba;
                    if (_publishedPixels.Length != pixels.Length) _publishedPixels = new byte[pixels.Length];
                    Buffer.BlockCopy(pixels, 0, _publishedPixels, 0, pixels.Length);
                    _publishedWidth = actual.Width;
                    _publishedHeight = actual.Height;
                    _publishedFrameNumber = actual.FrameNumber;
                }

                _textActive = actual.IsTextInputActive;
                if (!_disposeRequested) _running = actual.IsRunning;
            }
        }
    }
}

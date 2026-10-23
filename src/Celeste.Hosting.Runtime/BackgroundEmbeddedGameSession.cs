using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Celeste.Hosting.Runtime
{
    public sealed class BackgroundEmbeddedGameSession : IEmbeddedGameSession
    {
        private readonly object gate = new();
        private readonly EmbeddedGameConfiguration configuration;
        private readonly Func<EmbeddedGameConfiguration, IEmbeddedGameSession> create;

        private readonly TaskCompletionSource<bool> disposedCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        private readonly Queue<char> text = new();
        private BackgroundInputFrame? head;
        private BackgroundInputFrame? tail;
        private BackgroundInputFrame? free;
        private bool disposeRequested;
        private bool suspended;
        private bool releaseRequested;
        private long controlVersion;
        private volatile bool loading = true;
        private volatile bool running = true;
        private volatile bool textActive;
        private volatile Exception? failure;
        private byte[] publishedPixels = [];
        private int publishedWidth;
        private int publishedHeight;
        private long publishedFrameNumber = -1;
        private byte[] consumerPixels = [];
        private int consumerWidth;
        private int consumerHeight;
        private long consumerFrameNumber = -1;

        public BackgroundEmbeddedGameSession(EmbeddedGameConfiguration configuration,
            Func<EmbeddedGameConfiguration, IEmbeddedGameSession> create)
        {
            this.configuration = configuration;
            this.create = create;
            consumerWidth = configuration.Width;
            consumerHeight = configuration.Height;
            new Thread(Run) { IsBackground = true, Name = "Embedded game" }.Start();
        }

        public bool IsLoading => loading;
        public Exception? InitializationError => failure;
        public Task DisposedCompletion => disposedCompletion.Task;
        public bool IsRunning => running;
        public bool IsTextInputActive => textActive;
        public int Width => consumerWidth;
        public int Height => consumerHeight;
        public byte[] FrameRgba => consumerPixels;
        public long FrameNumber => consumerFrameNumber;

        public void Advance(int[] pressedKeys, int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused)
        {
            lock (gate)
            {
                if (publishedFrameNumber != consumerFrameNumber)
                {
                    if (consumerPixels.Length != publishedPixels.Length)
                        consumerPixels = new byte[publishedPixels.Length];
                    Buffer.BlockCopy(publishedPixels, 0, consumerPixels, 0, publishedPixels.Length);
                    consumerWidth = publishedWidth;
                    consumerHeight = publishedHeight;
                    consumerFrameNumber = publishedFrameNumber;
                }

                if (loading || disposeRequested || suspended || failure != null || !running) return;
                if (tail != null && tail.Matches(pressedKeys, mouseX, mouseY, mouseButtons, wheelDelta, focused))
                {
                    tail.Updates++;
                }
                else
                {
                    var frame = free ?? new BackgroundInputFrame();
                    free = frame.Next;
                    frame.Next = null;
                    frame.Set(pressedKeys, mouseX, mouseY, mouseButtons, wheelDelta, focused);
                    if (tail == null) head = frame;
                    else tail.Next = frame;
                    tail = frame;
                }

                Monitor.Pulse(gate);
            }
        }

        public void PushTextInput(char character)
        {
            lock (gate)
            {
                if (loading || disposeRequested || suspended || failure != null || !running) return;
                text.Enqueue(character);
                Monitor.Pulse(gate);
            }
        }

        public void SetSuspended(bool value)
        {
            lock (gate)
            {
                if (disposeRequested || suspended == value) return;
                suspended = value;
                controlVersion++;
                if (value)
                {
                    releaseRequested = true;
                    textActive = false;
                    ClearPending();
                }

                Monitor.Pulse(gate);
            }
        }

        public void Dispose()
        {
            lock (gate)
            {
                disposeRequested = true;
                running = false;
                textActive = false;
                ClearPending();
                Monitor.Pulse(gate);
            }
        }

        private void ClearPending()
        {
            if (tail != null)
            {
                tail.Next = free;
                free = head;
                head = tail = null;
            }

            text.Clear();
        }

        private void Run()
        {
            IEmbeddedGameSession? actual = null;
            Exception? error = null;
            try
            {
                actual = create(configuration);
                loading = false;
                var appliedVersion = -1L;
                while (true)
                {
                    BackgroundInputFrame? frame;
                    bool desiredSuspend;
                    bool releaseInput;
                    long version;
                    char[] characters;
                    lock (gate)
                    {
                        while (!disposeRequested && controlVersion == appliedVersion && head == null && text.Count == 0)
                            Monitor.Wait(gate);
                        if (disposeRequested) break;
                        desiredSuspend = suspended;
                        releaseInput = releaseRequested;
                        releaseRequested = false;
                        version = controlVersion;
                        frame = head;
                        if (frame != null)
                        {
                            head = frame.Next;
                            if (head == null) tail = null;
                            frame.Next = null;
                        }

                        characters = text.Count == 0 ? [] : text.ToArray();
                        text.Clear();
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
                                lock (gate)
                                    if (disposeRequested || controlVersion != version)
                                        break;
                                actual.Advance(frame.Keys, frame.MouseX, frame.MouseY, frame.Buttons,
                                    update == 0 ? frame.Wheel : 0, frame.Focused);
                                Publish(actual);
                                if (!actual.IsRunning) break;
                            }
                    }

                    if (frame != null)
                        lock (gate)
                        {
                            frame.Next = free;
                            free = frame;
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

                loading = false;
                running = false;
                textActive = false;
                lock (gate) ClearPending();
                if (error == null) disposedCompletion.TrySetResult(true);
                else
                {
                    failure = error;
                    try
                    {
                        configuration.ReportError("Embedded game", error.ToString());
                    }
                    catch
                    {
                        /* A host logger must not prevent native cleanup completion. */
                    }

                    disposedCompletion.TrySetException(error);
                }
            }
        }

        private void Publish(IEmbeddedGameSession actual)
        {
            lock (gate)
            {
                if (actual.FrameNumber != publishedFrameNumber)
                {
                    var pixels = actual.FrameRgba;
                    if (publishedPixels.Length != pixels.Length) publishedPixels = new byte[pixels.Length];
                    Buffer.BlockCopy(pixels, 0, publishedPixels, 0, pixels.Length);
                    publishedWidth = actual.Width;
                    publishedHeight = actual.Height;
                    publishedFrameNumber = actual.FrameNumber;
                }

                textActive = actual.IsTextInputActive;
                if (!disposeRequested) running = actual.IsRunning;
            }
        }
    }
}

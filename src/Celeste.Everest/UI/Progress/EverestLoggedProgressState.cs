using Celeste.Core.Display;
using Celeste.Graphics.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Celeste.Core.Geometry;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Controls.Source;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Graphics.Text;
using Celeste.Graphics.Display;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Everest.UI.Progress
{
    public class EverestLoggedProgressState : OuiState
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;
        private SourceDrawState Draw => ((ISourceDrawScope)Context).Draw;

        public EverestLoggedProgressState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        private void Rect(float x, float y, float width, float height, PackedColor color)
            => SourcePrimitiveDrawing.Rect(Context, this, x, y, width, height, color);

        private void Rect(IntRect bounds, PackedColor color)
            => Rect(bounds.X, bounds.Y, bounds.Width, bounds.Height, color);

        public string Title;

        public Task Task;

        public List<string> Lines;

        public int Progress;

        public int ProgressMax;

        public bool WaitForConfirmOnFinish;

        private Action gotoAction;

        private float alpha;

        private float time;

        private string audioPrevMusic;

        private string audioPrevAmbience;

        private IntRect logBounds = new IntRect(0, 0, 1792, 768);

        private VirtualRenderTarget logBuffer;

        public event Action OnFinish;

        public EverestLoggedProgressState Init<T>(string title, Action task, int max) where T : OuiState
        {
            return Init<T>(title, new Task(task), max);
        }

        public EverestLoggedProgressState Init<T>(string title, Task task, int max) where T : OuiState
        {
            Title = title;
            Task = task;
            Lines = new List<string>();
            Progress = 0;
            ProgressMax = max;
            OnFinish += (gotoAction = delegate { base.Overworld.Goto<T>(); });
            if (task.Status == TaskStatus.Created)
            {
                task.Start();
            }

            return this;
        }

        public EverestLoggedProgressState SwitchGoto<T>() where T : OuiState
        {
            if (gotoAction != null)
            {
                OnFinish -= gotoAction;
            }

            OnFinish += (gotoAction = delegate { base.Overworld.Goto<T>(); });
            return this;
        }

        public void LogLine(string line, bool logToLogger = true)
        {
            if (logToLogger)
            {
                Logger.Log(EverestLogLevel.Verbose, "progress", line);
            }

            int num;
            while ((num = line.IndexOf('\n')) != -1)
            {
                LogLine(line.Substring(0, num), logToLogger: false);
                line = line.Substring(num + 1);
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (!ActiveFont.Font.Get(ActiveFont.BaseSize * 0.5f).Characters.ContainsKey(c))
                {
                    c = ' ';
                }

                stringBuilder.Append(c);
            }

            Lines.Add(stringBuilder.ToString());
        }

        public override IEnumerator Enter(OuiState from)
        {
            Overworld.ShowInputUI = false;
            audioPrevMusic = Audio.GetEventName(Audio.CurrentMusicEventInstance);
            Audio.SetMusic(null);
            audioPrevAmbience = Audio.GetEventName(Audio.CurrentAmbienceEventInstance);
            Audio.SetAmbience(null);
            Visible = true;
            for (float t = 0f; t < 1f; t += engine.DeltaTime * 4f)
            {
                alpha = Easing.CubeOut(t);
                yield return null;
            }
        }

        public override IEnumerator Leave(OuiState next)
        {
            Overworld.ShowInputUI = true;
            Audio.SetMusic(audioPrevMusic);
            Audio.SetAmbience(audioPrevAmbience);
            Audio.Play("event:/ui/main/whoosh_large_out");
            for (float t = 0f; t < 1f; t += engine.DeltaTime * 4f)
            {
                alpha = 1f - Easing.CubeIn(t);
                yield return null;
            }

            Visible = false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Add(new BeforeRenderCallbackComponentState(BeforeRender));
        }

        public override void Removed(object scene)
        {
            logBuffer?.Dispose();
            logBuffer = null;
            base.Removed(scene);
        }

        public override void Update()
        {
            if (Task != null && (Task.IsCompleted || Task.IsCanceled || Task.IsFaulted))
            {
                if (Task.IsFaulted)
                {
                    LogLine(">>>>> FATAL ERROR: WORKER TASK HAS FAULTED - THIS IS A BUG <<<<<");
                    WaitForConfirmOnFinish = true;
                }

                if (!WaitForConfirmOnFinish || Input.MenuConfirm.Pressed)
                {
                    this.OnFinish?.Invoke();
                    Task = null;
                }
            }

            time += engine.DeltaTime;
            base.Update();
        }

        public void BeforeRender()
        {
            if (Focused && Visible && Lines != null)
            {
                if (logBuffer == null)
                {
                    logBuffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget(
                        "loggedprogress-log", logBounds.Width, logBounds.Height);
                }

                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(logBuffer.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
                Draw.SpriteBatch.Begin();
                for (int i = 0; i < Lines.Count; i++)
                {
                    ActiveFont.Draw(Context, this, Lines[i],
                        new Vector2(8f, (float)logBuffer.Height - 8f - 30f * (float)(Lines.Count - i)), Vector2.Zero,
                        Vector2.One * 0.5f, PackedColor.White);
                }

                Draw.SpriteBatch.End();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
            {
                Rect(-10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.6f);
            }

            base.Render(context);
            if (Lines == null)
            {
                return;
            }

            ActiveFont.DrawEdgeOutline(Context, this, Title, new Vector2(960f, 128f), new Vector2(0.5f, 0.5f),
                Vector2.One * 2f, PackedColor.Gray * alpha, 4f, PackedColor.DarkSlateBlue * alpha, 2f,
                PackedColor.Black * (alpha * alpha * alpha));
            Rect(64f, 194f, 1792f, 4f, PackedColor.Black * alpha * 0.8f);
            if (ProgressMax > 0)
            {
                Rect(64f, 192f, (float)Progress / (float)ProgressMax * 1792f, 8f, PackedColor.White * alpha * 0.8f);
            }
            else
            {
                float num = time * 4f % 2f;
                if (num < 1f)
                {
                    Rect(64f, 192f, num * 1792f, 8f, PackedColor.White * alpha * 0.8f);
                }
                else
                {
                    num -= 1f;
                    Rect(64f + num * 1792f, 192f, (1f - num) * 1792f, 8f, PackedColor.White * alpha * 0.8f);
                }
            }

            IntRect rectangle = new IntRect(960 - logBounds.Width / 2, 208, logBounds.Width, logBounds.Height);
            Rect(rectangle, PackedColor.Black * alpha * 0.8f);
            if (logBuffer != null)
            {
                Draw.SpriteBatch.Draw(logBuffer.Target, rectangle, (PackedColor.White * alpha).PackedValue);
            }
        }
    }
}

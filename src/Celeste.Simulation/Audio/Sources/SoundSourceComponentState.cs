using Celeste.Core.Display;
using Celeste.Core.Audio;
using Celeste.Core.Scheduling;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using System.Numerics;


namespace Celeste.Simulation.Audio.Sources
{
    public class SoundSourceComponentState : SourceComponentState
    {
        private readonly ISourceEngineContext engine;
        private ISourceSoundSourceAudio Audio => ((ISourceSoundSourceAudioEnvironment)engine).SoundSourceAudio;
        public string EventName;

        public Vector2 Position = Vector2.Zero;

        public bool DisposeOnTransition = true;

        public bool RemoveOnOneshotEnd;

        private ISourceAudioEventReference instance;

        private bool is3D;

        private bool isOneshot;

        public bool Playing { get; private set; }

        public bool Is3D => is3D;

        public bool IsOneshot => isOneshot;

        public bool InstancePlaying
        {
            get
            {
                if (instance != null)
                {
                    var state = instance.PlaybackState;
                    if (state == SourceAudioPlaybackState.Playing || state == SourceAudioPlaybackState.Starting ||
                        state == SourceAudioPlaybackState.Sustaining)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public SoundSourceComponentState(ISourceEngineContext engine)
            : base(active: true, visible: false)
        {
            this.engine = engine;
        }

        public SoundSourceComponentState(ISourceEngineContext engine, string path)
            : this(engine)
        {
            Play(path);
        }

        public SoundSourceComponentState(ISourceEngineContext engine, Vector2 offset, string path)
            : this(engine)
        {
            Position = offset;
            Play(path);
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            UpdateSfxPosition();
        }

        public SoundSourceComponentState Play(string path, string param = null, float value = 0f)
        {
            Stop();
            EventName = path;
            Audio.CreateInstance(path, ref instance, ref is3D, ref isOneshot);
            if (instance != null)
            {
                if (is3D)
                {
                    Vector2 position = Position;
                    if (base.Entity != null)
                    {
                        position += ((ISourceEntityPosition)base.Entity).Position;
                    }

                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Position(instance, position);
                }

                if (param != null)
                {
                    instance.SetParameter(param, value);
                }

                instance.Start();
                Playing = true;
            }

            return this;
        }

        public SoundSourceComponentState Param(string param, float value)
        {
            if (instance != null)
            {
                instance.SetParameter(param, value);
            }

            return this;
        }

        public SoundSourceComponentState Pause()
        {
            if (instance != null)
            {
                instance.SetPaused(paused: true);
            }

            Playing = false;
            return this;
        }

        public SoundSourceComponentState SetVolume(float volume)
        {
            instance?.SetVolume(volume);
            return this;
        }

        public SoundSourceComponentState Resume()
        {
            if (instance != null)
            {
                bool paused = instance.GetPaused();
                if (paused)
                {
                    instance.SetPaused(paused: false);
                    Playing = true;
                }
            }

            return this;
        }

        public SoundSourceComponentState Stop(bool allowFadeout = true)
        {
            Audio.Stop(instance, allowFadeout);
            instance = null;
            Playing = false;
            return this;
        }

        public void UpdateSfxPosition()
        {
            if (is3D && instance != null)
            {
                Vector2 position = Position;
                if (base.Entity != null)
                {
                    position += ((ISourceEntityPosition)base.Entity).Position;
                }

                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Position(instance, position);
            }
        }

        public override void Update()
        {
            UpdateSfxPosition();
            if (!isOneshot || !(instance != null))
            {
                return;
            }

            var state = instance.PlaybackState;
            if (state == SourceAudioPlaybackState.Stopped)
            {
                instance.Release();
                instance = null;
                Playing = false;
                if (RemoveOnOneshotEnd)
                {
                    RemoveSelf();
                }
            }
        }

        public override void EntityRemoved(object scene)
        {
            base.EntityRemoved(scene);
            Stop();
        }

        public override void Removed(object entity)
        {
            base.Removed(entity);
            Stop();
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            Stop(allowFadeout: false);
        }

        public override void DebugRender(ISourceRenderContext context, object camera)
        {
            Vector2 position = Position;
            if (base.Entity != null)
            {
                position += ((ISourceEntityPosition)base.Entity).Position;
            }

            if (instance != null && Playing)
            {
                SourcePrimitiveDrawing.Circle(context, this, position,
                    4f + ((ISourceScene)base.Scene).SourceScene.Clock.RawTimeActive * 2f % 1f * 16f,
                    new PackedColor(138, 43, 226, 255), 16,
                    ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic);
            }

            SourcePrimitiveDrawing.HollowRect(context, this, position.X - 2f, position.Y - 2f,
                4f, 4f, new PackedColor(138, 43, 226, 255));
        }
    }
}

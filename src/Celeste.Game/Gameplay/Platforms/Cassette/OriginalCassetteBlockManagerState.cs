using Celeste.Input.Gameplay.Feedback;
using System;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Cassette;
using Celeste.Core.Audio;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Engine.Actions;

namespace Celeste.Game.Gameplay.Platforms.Cassette
{
    public class OriginalCassetteBlockManagerState : SceneEntityState, IOriginalCassetteMusicAdvance
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameAudioSession audio => ((IOriginalGameplayProcess)engine).AudioSession;
        protected readonly IRumbleSession rumble;
        protected IOriginalCassetteManagerScene Level => (IOriginalCassetteManagerScene)Scene;
        protected int currentIndex;
        public int CurrentIndex => currentIndex;
        public int BeatIndex => beatIndex;

        protected float beatTimer;

        protected int beatIndex;

        protected float tempoMult;

        public float TempoMultiplier
        {
            get => tempoMult;
            set => tempoMult = value;
        }

        protected int leadBeats;

        protected int maxBeat;

        protected bool isLevelMusic;

        protected int beatIndexOffset;

        protected ISourceAudioEventReference sfx;

        protected ISourceAudioEventReference snapshot;

        public OriginalCassetteBlockManagerState(ISourceEngineContext engine, IRumbleSession rumble)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.rumble = rumble;
            Tags = ((Celeste.Scene.Scheduling.ExecutionTags.ISourceGlobalFrozenExecutionTagsEnvironment)engine)
                .GlobalFrozenExecutionTags.Global.Value;
            OwnedComponents.Add(new RoomTransitionListener
            {
                OnOutBegin = delegate
                {
                    if (!Level.HasCassetteBlocks)
                    {
                        RemoveSelf();
                    }
                    else
                    {
                        maxBeat = Level.CassetteBlockBeats;
                        tempoMult = Level.CassetteBlockTempo;
                    }
                }
            });
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            isLevelMusic = Level.CassetteSong == null;
            if (isLevelMusic)
            {
                leadBeats = 0;
                beatIndexOffset = 5;
            }
            else
            {
                beatIndexOffset = 0;
                leadBeats = 16;
                snapshot = audio.CreateSnapshot("snapshot:/music_mains_mute");
            }

            maxBeat = Level.CassetteBlockBeats;
            tempoMult = Level.CassetteBlockTempo;
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            if (!isLevelMusic)
            {
                audio.Stop(snapshot);
                audio.Stop(sfx);
            }
        }

        public override void SceneEnd(object scene)
        {
            base.SceneEnd(scene);
            if (!isLevelMusic)
            {
                audio.Stop(snapshot);
                audio.Stop(sfx);
            }
        }

        protected void UpdateSourceEntityBase() => base.Update();

        public override void Update()
        {
            UpdateSourceEntityBase();
            if (isLevelMusic)
            {
                sfx = audio.CurrentMusicEventInstance;
            }

            if (sfx == null && !isLevelMusic)
            {
                string cassetteSong = Level.CassetteSong;
                sfx = audio.CreateInstance(cassetteSong, null, null);
                audio.Play("event:/game/general/cassette_block_switch_2");
            }
            else
            {
                AdvanceMusic(engine.DeltaTime * tempoMult);
            }
        }

        public virtual void AdvanceMusic(float time)
        {
            _ = beatTimer;
            beatTimer += time;
            if (!(beatTimer >= 1f / 6f))
            {
                return;
            }

            beatTimer -= 1f / 6f;
            beatIndex++;
            beatIndex %= 256;
            if (beatIndex % 8 == 0)
            {
                currentIndex++;
                currentIndex %= maxBeat;
                SetActiveIndex(currentIndex);
                if (!isLevelMusic)
                {
                    audio.Play("event:/game/general/cassette_block_switch_2");
                }

                rumble.Rumble(1, 0);
            }
            else if ((beatIndex + 1) % 8 == 0)
            {
                SetWillActivate((currentIndex + 1) % maxBeat);
            }
            else if ((beatIndex + 4) % 8 == 0 && !isLevelMusic)
            {
                audio.Play("event:/game/general/cassette_block_switch_1");
            }

            if (leadBeats > 0)
            {
                leadBeats--;
                if (leadBeats == 0)
                {
                    beatIndex = 0;
                    if (!isLevelMusic)
                    {
                        sfx.Start();
                    }
                }
            }

            if ((global::Celeste.Core.Scheduling.SourceRuntimeExtensions
                    .Get<global::Celeste.Core.Audio.ISourceCassetteTimingPolicy>(engine)
                    ?.TransformLeadBeats(leadBeats) ?? leadBeats) <= 0)
            {
                sfx.SetParameter("sixteenth_note", GetSixteenthNote());
            }
        }

        public virtual int GetSixteenthNote()
        {
            return (beatIndex + beatIndexOffset) % 256 + 1;
        }

        public virtual void StopBlocks()
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
            {
                entity.Finish();
            }

            if (!isLevelMusic)
            {
                audio.Stop(sfx);
            }
        }

        public void Finish()
        {
            if (!isLevelMusic)
            {
                audio.Stop(snapshot);
            }

            RemoveSelf();
        }

        public virtual void OnLevelStart()
        {
            maxBeat = Level.CassetteBlockBeats;
            tempoMult = Level.CassetteBlockTempo;
            if (beatIndex % 8 >= 5)
            {
                currentIndex = maxBeat - 2;
            }
            else
            {
                currentIndex = maxBeat - 1;
            }

            SilentUpdateBlocks();
        }

        protected virtual void SilentUpdateBlocks()
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
            {
                if (entity.ID.Level == Level.SessionRoom)
                {
                    entity.SetActivatedSilently(entity.Index == currentIndex);
                }
            }
        }

        public virtual void SetActiveIndex(int index)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
            {
                entity.Activated = entity.Index == index;
            }
        }

        public virtual void SetWillActivate(int index)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
            {
                if (entity.Index == index || entity.Activated)
                {
                    entity.WillToggle();
                }
            }
        }
    }
}

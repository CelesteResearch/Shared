using Celeste.Core.Audio;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Identifiers;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Everest.Gameplay.Platforms.Cassette
{
    public sealed class InstalledCassetteBlockManagerState : OriginalCassetteBlockManagerState
    {
        public InstalledCassetteBlockManagerState(ISourceEngineContext engine, IRumbleSession rumble)
            : base(engine, rumble)
        {
        }

        private int beatsPerTick;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int BeatsPerTick => beatsPerTick;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int TicksPerSwap => ticksPerSwap;
        private int ticksPerSwap;

        private int beatIndexMax;

        public override void Awake(object scene)
        {
            var areaData = (IInstalledCassetteManagerScene)Scene;
            if (areaData.CassetteSong == "-" || string.IsNullOrWhiteSpace(areaData.CassetteSong))
                areaData.CassetteSong = null;

            base.Awake(scene);
            beatsPerTick = 4;
            ticksPerSwap = 2;
            beatIndexMax = 256;
            var mapMetaCassetteModifier = areaData.CassetteModifier;
            if (mapMetaCassetteModifier == null) return;

            if (mapMetaCassetteModifier.OldBehavior)
            {
                tempoMult = mapMetaCassetteModifier.TempoMult;
                maxBeat = mapMetaCassetteModifier.Blocks;
            }

            leadBeats = mapMetaCassetteModifier.LeadBeats;
            beatsPerTick = mapMetaCassetteModifier.BeatsPerTick;
            ticksPerSwap = mapMetaCassetteModifier.TicksPerSwap;
            beatIndexMax = mapMetaCassetteModifier.BeatsMax;
            beatIndexOffset = mapMetaCassetteModifier.BeatIndexOffset;
            if (!mapMetaCassetteModifier.ActiveDuringTransitions) return;

            var transitionListener = OwnedComponents.Get<RoomTransitionListener>();
            if (transitionListener == null) return;

            transitionListener.OnOut = delegate
            {
                if (Scene != null) Update();
            };
        }

        public override void Update()
        {
            UpdateSourceEntityBase();
            if (isLevelMusic) sfx = audio.CurrentMusicEventInstance;

            if (sfx == null && !isLevelMusic)
            {
                var cassetteSong = Level.CassetteSong;
                sfx = audio.CreateInstance(cassetteSong, null, null);
                audio.Play("event:/game/general/cassette_block_switch_2");
                if (leadBeats == 0)
                {
                    beatIndex = 0;
                    sfx?.Start();
                }
            }
            else
            {
                AdvanceMusic(engine.DeltaTime * tempoMult);
            }
        }

        public override void AdvanceMusic(float time)
        {
            beatTimer += time;
            if (beatTimer < 1f / 6f) return;

            beatTimer -= 1f / 6f;
            beatIndex++;
            beatIndex %= beatIndexMax;
            if (beatIndex % (BeatsPerTick * TicksPerSwap) == 0)
            {
                currentIndex++;
                currentIndex %= maxBeat;
                SetActiveIndex(currentIndex);
                if (!isLevelMusic) audio.Play("event:/game/general/cassette_block_switch_2");

                rumble.Rumble(1, 0);
            }
            else
            {
                if ((beatIndex + 1) % (BeatsPerTick * TicksPerSwap) == 0) SetWillActivate((currentIndex + 1) % maxBeat);

                if (beatIndex % BeatsPerTick == 0 && !isLevelMusic)
                    audio.Play("event:/game/general/cassette_block_switch_1");
            }

            if (leadBeats > 0)
            {
                leadBeats--;
                if (leadBeats == 0)
                {
                    beatIndex = 0;
                    if (!isLevelMusic) sfx?.Start();
                }
            }

            if ((SourceRuntimeExtensions
                    .Get<ISourceCassetteTimingPolicy>(engine)
                    ?.TransformLeadBeats(leadBeats) ?? leadBeats) <= 0)
                sfx?.SetParameter("sixteenth_note", GetSixteenthNote());
        }

        public override int GetSixteenthNote()
        {
            return (beatIndex + beatIndexOffset) % beatIndexMax + 1;
        }

        public override void StopBlocks()
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
                entity.Finish();

            foreach (InstalledCassetteListenerState component in ((ISourceScene)Scene).SourceScene.Components
                     .GetTrackedComponents("Celeste.Mod.Entities.CassetteListener"))
                component.Finish();

            if (!isLevelMusic) audio.Stop(sfx);
        }

        public override void OnLevelStart()
        {
            var level = (IInstalledCassetteManagerScene)Scene;
            var mapMetaCassetteModifier = level.CassetteModifier;
            if (mapMetaCassetteModifier is { OldBehavior: true })
            {
                currentIndex = maxBeat - 1 - beatIndex / BeatsPerTick % maxBeat;
            }
            else
            {
                maxBeat = level.CassetteBlockBeats;
                tempoMult = level.CassetteBlockTempo;
                if (beatIndex % (BeatsPerTick * TicksPerSwap) > BeatsPerTick * TicksPerSwap / 2)
                    currentIndex = maxBeat - 2;
                else
                    currentIndex = maxBeat - 1;
            }

            SilentUpdateBlocks();
        }

        protected override void SilentUpdateBlocks()
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
                if (entity.ID.Level == Level.SessionRoom)
                    entity.SetActivatedSilently(entity.Index == currentIndex);

            foreach (InstalledCassetteListenerState component in ((ISourceScene)Scene).SourceScene.Components
                     .GetTrackedComponents("Celeste.Mod.Entities.CassetteListener"))
                if (component.ID.ID == EntityIdCodec.None.ID || component.ID.Level == Level.SessionRoom)
                    component.Start(component.Index == currentIndex);
        }

        public override void SetActiveIndex(int index)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
                entity.Activated = entity.Index == index;

            foreach (InstalledCassetteListenerState component in ((ISourceScene)Scene).SourceScene.Components
                     .GetTrackedComponents("Celeste.Mod.Entities.CassetteListener"))
                component.SetActivated(component.Index == index);
        }

        public override void SetWillActivate(int index)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
                if (entity.Index == index || entity.Activated)
                    entity.WillToggle();

            foreach (InstalledCassetteListenerState component in ((ISourceScene)Scene).SourceScene.Components
                     .GetTrackedComponents("Celeste.Mod.Entities.CassetteListener"))
                if (component.Index == index || component.Activated)
                    component.WillToggle();
        }
    }
}

using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Components.Talking;
using Celeste.Game.Settings;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroLobbyState : OriginalNpcState
    {
        private float startX;

        public OriginalOshiroLobbyState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            OwnedComponents.Add(Sprite = new OshiroSpriteState(engine, -1));
            Sprite.Visible = false;
            var texture = ((IOriginalTalkProcess)engine).GuiAtlas["hover/resort"];
            if (((IOriginalTalkProcess)engine).GuiAtlas.Has("hover/resort_" +
                                                            ((ISettingsContext)engine).Settings.LanguageId))
                texture = ((IOriginalTalkProcess)engine).GuiAtlas[
                    "hover/resort_" + ((ISettingsContext)engine).Settings.LanguageId];

            OwnedComponents.Add(Talker = new((IOriginalTalkProcess)engine,
                new(-30, -16, 42, 32), new(-12f, -24f), OnTalk, new()
                {
                    Texture = texture,
                    InputPosition = new(0f, -75f),
                    SfxIn = "event:/ui/game/hotspot_note_in",
                    SfxOut = "event:/ui/game/hotspot_note_out",
                }));
            Talker.PlayerMustBeFacing = false;
            MoveAnim = "move";
            IdleAnim = "idle";
            Depth = 9001;
        }

        public OriginalOshiroLobbyState(EntityData data, Vector2 offset, ISourceEngineContext engine) : this(
            engine, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("oshiro_resort_talked_1"))
            {
                Session.Audio.Music.Event = "event:/music/lvl3/explore";
                Session.Audio.Music.SetProgress(1);
                OriginalAudioSession.Apply(Session.Audio, Process.AudioSession.ChannelOutput,
                    Process.AudioApplyPolicy);
                RemoveSelf();
            }
            else
            {
                Session.Audio.Music.Event = null;
                OriginalAudioSession.Apply(Session.Audio, Process.AudioSession.ChannelOutput,
                    Process.AudioApplyPolicy);
            }

            Level.Scheduler.QueueSourceEntity(
                new OriginalOshiroLobbyBellState(Engine, new(X - 14f, Y)));
            startX = Position.X;
        }

        private void OnTalk(RoomPlayerSession player)
        {
            Level.Scheduler.QueueSourceEntity(new CS03OshiroLobbyState(Engine, player, this));
            Talker.Enabled = false;
        }

        public override void Update()
        {
            base.Update();
            if (X >= startX + 12f) Depth = 1000;
        }
    }
}

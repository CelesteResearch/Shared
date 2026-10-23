using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Game.Audio;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Formats.Map.Entities.Structure;

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
            AtlasEntry texture = ((IOriginalTalkProcess)engine).GuiAtlas["hover/resort"];
            if (((IOriginalTalkProcess)engine).GuiAtlas.Has("hover/resort_" +
                                                            ((ISettingsContext)engine).Settings.LanguageId))
            {
                texture = ((IOriginalTalkProcess)engine).GuiAtlas[
                    "hover/resort_" + ((ISettingsContext)engine).Settings.LanguageId];
            }

            OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)engine,
                new IntRect(-30, -16, 42, 32), new Vector2(-12f, -24f), OnTalk, new OriginalTalkComponent.HoverDisplay
                {
                    Texture = texture,
                    InputPosition = new Vector2(0f, -75f),
                    SfxIn = "event:/ui/game/hotspot_note_in",
                    SfxOut = "event:/ui/game/hotspot_note_out"
                }));
            Talker.PlayerMustBeFacing = false;
            MoveAnim = "move";
            IdleAnim = "idle";
            base.Depth = 9001;
        }

        public OriginalOshiroLobbyState(EntityData data, Vector2 offset, ISourceEngineContext engine) : this(
            engine, data.Position + offset)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (base.Session.GetFlag("oshiro_resort_talked_1"))
            {
                base.Session.Audio.Music.Event = "event:/music/lvl3/explore";
                base.Session.Audio.Music.SetProgress(1);
                OriginalAudioSession.Apply(base.Session.Audio, Process.AudioSession.ChannelOutput,
                    Process.AudioApplyPolicy);
                RemoveSelf();
            }
            else
            {
                base.Session.Audio.Music.Event = null;
                OriginalAudioSession.Apply(base.Session.Audio, Process.AudioSession.ChannelOutput,
                    Process.AudioApplyPolicy);
            }

            Level.Scheduler.QueueSourceEntity(
                new OriginalOshiroLobbyBellState(Engine, new Vector2(base.X - 14f, base.Y)));
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
            if (base.X >= startX + 12f)
            {
                base.Depth = 1000;
            }
        }
    }
}

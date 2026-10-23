using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Physics.Collision.Shapes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Npcs.Theo;
using Celeste.Game.Stories.Temple.Cutscenes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Interactions
{
    public class OriginalInteractTriggerState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public const string FlagPrefix = "it_";

        public OriginalTalkComponent Talker;

        public List<string> Events;

        private int eventIndex;

        private float timeout;

        private bool used;

        public OriginalInteractTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            Events = new List<string>();
            Events.Add(EntityAttributeReader.Attr(data.Values, "event"));
            base.Collider = new HitboxColliderGeometry(data.Width, data.Height);
            for (int i = 2;
                 i < 100 && EntityAttributeReader.Has(data.Values, "event_" + i) &&
                 !string.IsNullOrEmpty(EntityAttributeReader.Attr(data.Values, "event_" + i));
                 i++)
            {
                Events.Add(EntityAttributeReader.Attr(data.Values, "event_" + i));
            }

            Vector2 drawAt = new Vector2(data.Width / 2, 0f);
            if (data.Nodes.Length != 0)
            {
                drawAt = SourceVector2Math.Subtract(data.Nodes[0], data.Position);
            }

            OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)engine,
                new IntRect(0, 0, data.Width, data.Height), drawAt, OnTalk));
            Talker.PlayerMustBeFacing = false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session =
                (scene as OriginalLevelSceneRoot).Session;
            for (int i = 0; i < Events.Count; i++)
            {
                if (session.GetFlag("it_" + Events[i]))
                {
                    eventIndex++;
                }
            }

            if (eventIndex >= Events.Count)
            {
                RemoveSelf();
            }
            else if (Events[eventIndex] == "ch5_theo_phone")
            {
                ((ISourceScene)scene).SourceScene.QueueSourceEntity(new OriginalTheoPhoneState(engine,
                    Position + new Vector2(base.Width / 2f - 8f, base.Height - 1f)));
            }
        }

        public void OnTalk(RoomPlayerSession player)
        {
            if (used)
            {
                return;
            }

            bool flag = true;
            switch (Events[eventIndex])
            {
                case "ch2_poem":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS02JournalState(engine, player));
                    flag = false;
                    break;
                case "ch3_guestbook":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS03GuestbookState(engine, player));
                    flag = false;
                    break;
                case "ch3_memo":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS03MemoState(engine, player));
                    flag = false;
                    break;
                case "ch3_diary":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS03DiaryState(engine, player));
                    flag = false;
                    break;
                case "ch5_theo_phone":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS05TheoPhoneState(engine, player,
                        base.Center.X));
                    break;
                case "ch5_mirror_reflection":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS05Reflection1State(engine, player));
                    break;
                case "ch5_see_theo":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS05SeeTheoState(engine, player, 0));
                    break;
                case "ch5_see_theo_b":
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new CS05SeeTheoState(engine, player, 1));
                    break;
            }

            if (flag)
            {
                (base.Scene as OriginalLevelSceneRoot).Session.SetFlag("it_" + Events[eventIndex]);
                eventIndex++;
                if (eventIndex >= Events.Count)
                {
                    used = true;
                    timeout = 0.25f;
                }
            }
        }

        public override void Update()
        {
            if (used)
            {
                timeout -= engine.DeltaTime;
                if (timeout <= 0f)
                {
                    RemoveSelf();
                }
            }
            else
            {
                while (eventIndex < Events.Count &&
                       (base.Scene as OriginalLevelSceneRoot).Session.GetFlag("it_" + Events[eventIndex]))
                {
                    eventIndex++;
                }

                if (eventIndex >= Events.Count)
                {
                    RemoveSelf();
                }
            }

            base.Update();
        }
    }
}

using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Npcs.Theo;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Stories.Temple.Cutscenes;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
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
            Events = [];
            // ReSharper disable once AppendToCollectionExpression
            Events.Add(EntityAttributeReader.Attr(data.Values, "event"));
            Collider = new HitboxColliderGeometry(data.Width, data.Height);
            for (var i = 2;
                 i < 100 && EntityAttributeReader.Has(data.Values, "event_" + i) &&
                 !string.IsNullOrEmpty(EntityAttributeReader.Attr(data.Values, "event_" + i));
                 i++)
                Events.Add(EntityAttributeReader.Attr(data.Values, "event_" + i));

            var drawAt = new Vector2(data.Width / 2, 0f);
            if (data.Nodes.Length != 0) drawAt = SourceVector2Math.Subtract(data.Nodes[0], data.Position);

            OwnedComponents.Add(Talker = new((IOriginalTalkProcess)engine,
                new(0, 0, data.Width, data.Height), drawAt, OnTalk));
            Talker.PlayerMustBeFacing = false;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var session =
                (scene as OriginalLevelSceneRoot).Session;
            for (var i = 0; i < Events.Count; i++)
                if (session.GetFlag("it_" + Events[i]))
                    eventIndex++;

            if (eventIndex >= Events.Count)
                RemoveSelf();
            else if (Events[eventIndex] == "ch5_theo_phone")
                ((ISourceScene)scene).SourceScene.QueueSourceEntity(new OriginalTheoPhoneState(engine,
                    Position + new Vector2(Width / 2f - 8f, Height - 1f)));
        }

        public void OnTalk(RoomPlayerSession player)
        {
            if (used) return;

            var flag = true;
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
                        Center.X));
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
                (Scene as OriginalLevelSceneRoot).Session.SetFlag("it_" + Events[eventIndex]);
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
                if (timeout <= 0f) RemoveSelf();
            }
            else
            {
                while (eventIndex < Events.Count &&
                       (Scene as OriginalLevelSceneRoot).Session.GetFlag("it_" + Events[eventIndex]))
                    eventIndex++;

                if (eventIndex >= Events.Count) RemoveSelf();
            }

            base.Update();
        }
    }
}

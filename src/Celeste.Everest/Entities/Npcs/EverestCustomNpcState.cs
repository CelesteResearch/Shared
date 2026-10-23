using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using Celeste.Core.Display;
using Celeste.Core.Maps;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Everest.Entities.Npcs
{
    [CustomEntity("everest/npc")]
    public class EverestCustomNpcState : OriginalNpcState
    {
        private readonly string spritePath;

        private readonly float spriteRate;

        private readonly string dialogEntry;

        private readonly bool onlyOnce;

        private readonly bool endLevel;

        private readonly string name;

        private readonly MapEntityId id;

        private readonly bool approachWhenTalking;

        private readonly int approachDistance;

        private readonly string[] dialogs;

        private readonly bool animated;

        private float frame;

        private Vector2 scale = new(1f, 1f);

        protected List<AtlasEntry> TextureFrames { get; set; }

        protected Vector2 NpcScale
        {
            get => scale;
            set => scale = value;
        }

        protected virtual IEnumerator CreateDialogueRoutine(string dialog)
        {
            return TextboxState.Say(dialog, Engine, null);
        }

        private readonly Vector2 indicatorOffset = Vector2.Zero;

        private SimulationCoroutine talkRoutine;

        public event Action<int> OnStart;

        public event Action OnEnd;

        public EverestCustomNpcState(EntityData data, Vector2 offset, MapEntityId id,
            ISourceEngineContext engine)
            : base(engine, data.Position + offset)
        {
            this.id = id;
            spritePath = data.Attr("sprite");
            spriteRate = data.Float("spriteRate", 1f);
            dialogEntry = data.Attr("dialogId");
            dialogs = dialogEntry.Split(',');
            onlyOnce = data.Bool("onlyOnce", true);
            endLevel = data.Bool("endLevel");
            indicatorOffset.X = data.Float("indicatorOffsetX");
            indicatorOffset.Y = data.Float("indicatorOffsetY");
            approachWhenTalking = data.Bool("approachWhenTalking");
            approachDistance = data.Int("approachDistance", 16);
            if (data.Bool("flipX")) scale.X = -1f;

            if (data.Bool("flipY")) scale.Y = -1f;

            if (!string.IsNullOrEmpty(spritePath))
            {
                var extension = Path.GetExtension(spritePath);
                if (!string.IsNullOrEmpty(extension)) spritePath = spritePath.Replace(extension, "");

                spritePath = Path.Combine("characters", spritePath).Replace('\\', '/');
                name = Regex.Replace(spritePath, "\\d+$", string.Empty);
                TextureFrames = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)Engine).GameGraphics)
                    .GameAtlas
                    .GetAtlasSubtextures(name);
                if (TextureFrames != null && TextureFrames.Count > 1) animated = true;
            }
            else
            {
                spritePath = null;
                name = null;
                TextureFrames = null;
            }

            frame = 0f;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var session = (scene as OriginalLevelSceneRoot).Session;
            var entityId = id;
            if (!session.GetFlag("DoNotTalk" + entityId))
            {
                var num = 0f;
                var num2 = 0f;
                if (TextureFrames != null && TextureFrames.Count > 0)
                {
                    num = TextureFrames[0].FrameWidth * scale.X;
                    num2 = TextureFrames[0].FrameHeight * scale.Y;
                }

                OwnedComponents.Add(Talker = new((IOriginalTalkProcess)Engine,
                    new(-(int)num / 2 - 48, (int)(0f - num2) - 16, (int)num + 96, (int)num2 + 32),
                    new(-0.5f + indicatorOffset.X, (0f - num2) / 2f + indicatorOffset.Y), OnTalk));
            }
        }

        public override void Update()
        {
            base.Update();
            if (!(animated && TextureFrames != null && TextureFrames.Count > 0))
                return;
            frame += spriteRate * Engine.DeltaTime;
            frame %= TextureFrames.Count;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (TextureFrames != null && TextureFrames.Count > 0)
                SourceAtlasDrawing.DrawJustified(context, this, TextureFrames[(int)frame], Position, new(0.5f, 1f),
                    PackedColor.White, scale);
        }

        private void OnTalk(RoomPlayerSession player)
        {
            if (onlyOnce)
            {
                MapEntityId entityId;
                if (dialogs.Length != 1)
                {
                    var session = Session;
                    entityId = id;
                    if (session.GetCounter(entityId + "DialogCounter") <= dialogs.Length - 2) goto IL_007c;
                }

                var session2 = (Scene as OriginalLevelSceneRoot).Session;
                entityId = id;
                session2.SetFlag("DoNotTalk" + entityId);
            }

            goto IL_007c;
            IL_007c:
            if (endLevel) (Scene as OriginalLevelSceneRoot).RegisterAreaComplete();

            player.Machine.State = 11;
            var action = OnStart;
            if (action != null)
            {
                var session3 = Session;
                var entityId = id;
                action(session3.GetCounter(entityId + "DialogCounter"));
            }

            Level.StartCutscene(OnTalkEnd);
            OwnedComponents.Add(talkRoutine = new(Engine, Talk(player)));
        }

        private void OnTalkEnd(OriginalLevelSceneRoot level)
        {
            var entity =
                ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
            }

            talkRoutine.Cancel();
            talkRoutine.RemoveSelf();
            var session = Session;
            var entityId = id;
            session.IncrementCounter(entityId + "DialogCounter");
            if (endLevel)
            {
                if (dialogs.Length != 1)
                {
                    var session2 = Session;
                    entityId = id;
                    if (session2.GetCounter(entityId + "DialogCounter") <= dialogs.Length - 1) goto IL_00ca;
                }

                level.CompleteArea();
                entity.Machine.State = 11;
            }

            goto IL_00ca;
            IL_018d:
            OnEnd?.Invoke();
            return;
            IL_00ca:
            if (onlyOnce)
            {
                if (dialogs.Length != 1)
                {
                    var session3 = Session;
                    entityId = id;
                    if (session3.GetCounter(entityId + "DialogCounter") <= dialogs.Length - 1) goto IL_018d;
                }

                OwnedComponents.Remove(Talker);
            }
            else
            {
                var session4 = Session;
                entityId = id;
                if (session4.GetCounter(entityId + "DialogCounter") > dialogs.Length - 1 ||
                    dialogs.Length == 1)
                {
                    var session5 = Session;
                    entityId = id;
                    session5.SetCounter(entityId + "DialogCounter", 0);
                }
            }

            goto IL_018d;
        }

        private IEnumerator Talk(RoomPlayerSession player)
        {
            if (approachWhenTalking)
            {
                if (scale.X > 0f)
                    yield return PlayerApproachRightSide(player, true, approachDistance);
                else
                    yield return PlayerApproachLeftSide(player, true, approachDistance);
            }

            var array = dialogs;
            var session = Session;
            var entityId = id;
            yield return CreateDialogueRoutine(array[session.GetCounter(entityId + "DialogCounter")]);
            Level.EndCutscene();
            OnTalkEnd(Level);
        }

        // Physical construction adapter for the existing source entity-loader ABI.
        public static SceneEntityState Load(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
            Vector2 offset, OriginalLevelEntityData entityData)
        {
            return new EverestCustomNpcState(entityData, offset, level.CreateEntityId(levelData, entityData),
                level.EngineContext);
        }
    }
}

using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.Entities.Npcs
{
    [CustomEntity(new string[] { "everest/npc" })]
    public class EverestCustomNpcState : OriginalNpcState
    {
        private string spritePath;

        private float spriteRate;

        private string dialogEntry;

        private bool onlyOnce;

        private bool endLevel;

        private List<AtlasEntry> textures;

        private string name;

        private MapEntityId id;

        private bool approachWhenTalking;

        private int approachDistance;

        private string[] dialogs;

        private bool animated;

        private float frame;

        private Vector2 scale = new Vector2(1f, 1f);

        protected List<AtlasEntry> TextureFrames
        {
            get => textures;
            set => textures = value;
        }

        protected Vector2 NpcScale
        {
            get => scale;
            set => scale = value;
        }

        protected virtual IEnumerator CreateDialogueRoutine(string dialog)
            => TextboxState.Say(dialog, Engine, (Func<IEnumerator>[])null);

        private Vector2 indicatorOffset = Vector2.Zero;

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
            onlyOnce = data.Bool("onlyOnce", defaultValue: true);
            endLevel = data.Bool("endLevel");
            indicatorOffset.X = data.Float("indicatorOffsetX");
            indicatorOffset.Y = data.Float("indicatorOffsetY");
            approachWhenTalking = data.Bool("approachWhenTalking");
            approachDistance = data.Int("approachDistance", 16);
            if (data.Bool("flipX"))
            {
                scale.X = -1f;
            }

            if (data.Bool("flipY"))
            {
                scale.Y = -1f;
            }

            if (!string.IsNullOrEmpty(spritePath))
            {
                string extension = Path.GetExtension(spritePath);
                if (!string.IsNullOrEmpty(extension))
                {
                    spritePath = spritePath.Replace(extension, "");
                }

                spritePath = Path.Combine("characters", spritePath).Replace('\\', '/');
                name = Regex.Replace(spritePath, "\\d+$", string.Empty);
                textures = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)Engine).GameGraphics)
                    .GameAtlas
                    .GetAtlasSubtextures(name);
                if (textures != null && textures.Count > 1)
                {
                    animated = true;
                }
            }
            else
            {
                spritePath = null;
                name = null;
                textures = null;
            }

            frame = 0f;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ChapterCompletionSession session = (scene as OriginalLevelSceneRoot).Session;
            MapEntityId entityID = id;
            if (!session.GetFlag("DoNotTalk" + entityID.ToString()))
            {
                float num = 0f;
                float num2 = 0f;
                if (textures != null && textures.Count > 0)
                {
                    num = (float)textures[0].FrameWidth * scale.X;
                    num2 = (float)textures[0].FrameHeight * scale.Y;
                }

                OwnedComponents.Add(Talker = new OriginalTalkComponent((IOriginalTalkProcess)Engine,
                    new IntRect(-(int)num / 2 - 48, (int)(0f - num2) - 16, (int)num + 96, (int)num2 + 32),
                    new Vector2(-0.5f + indicatorOffset.X, (0f - num2) / 2f + indicatorOffset.Y), OnTalk));
            }
        }

        public override void Update()
        {
            base.Update();
            if (animated && textures != null && textures.Count > 0)
            {
                frame += spriteRate * Engine.DeltaTime;
                frame %= textures.Count;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (textures != null && textures.Count > 0)
            {
                SourceAtlasDrawing.DrawJustified(context, this, textures[(int)frame], Position, new Vector2(0.5f, 1f),
                    PackedColor.White, scale);
            }
        }

        private void OnTalk(RoomPlayerSession player)
        {
            if (onlyOnce)
            {
                MapEntityId entityID;
                if (dialogs.Length != 1)
                {
                    ChapterCompletionSession session = base.Session;
                    entityID = id;
                    if (session.GetCounter(entityID.ToString() + "DialogCounter") <= dialogs.Length - 2)
                    {
                        goto IL_007c;
                    }
                }

                ChapterCompletionSession session2 = (base.Scene as OriginalLevelSceneRoot).Session;
                entityID = id;
                session2.SetFlag("DoNotTalk" + entityID.ToString());
            }

            goto IL_007c;
            IL_007c:
            if (endLevel)
            {
                (base.Scene as OriginalLevelSceneRoot).RegisterAreaComplete();
            }

            player.Machine.State = 11;
            Action<int> action = this.OnStart;
            if (action != null)
            {
                ChapterCompletionSession session3 = base.Session;
                MapEntityId entityID = id;
                action(session3.GetCounter(entityID.ToString() + "DialogCounter"));
            }

            Level.StartCutscene(OnTalkEnd);
            OwnedComponents.Add(talkRoutine = new SimulationCoroutine(Engine, Talk(player)));
        }

        private void OnTalkEnd(OriginalLevelSceneRoot level)
        {
            RoomPlayerSession entity =
                ((OriginalLevelSceneRoot)base.Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null)
            {
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
            }

            talkRoutine.Cancel();
            talkRoutine.RemoveSelf();
            ChapterCompletionSession session = base.Session;
            MapEntityId entityID = id;
            session.IncrementCounter(entityID.ToString() + "DialogCounter");
            if (endLevel)
            {
                if (dialogs.Length != 1)
                {
                    ChapterCompletionSession session2 = base.Session;
                    entityID = id;
                    if (session2.GetCounter(entityID.ToString() + "DialogCounter") <= dialogs.Length - 1)
                    {
                        goto IL_00ca;
                    }
                }

                level.CompleteArea();
                entity.Machine.State = 11;
            }

            goto IL_00ca;
            IL_018d:
            this.OnEnd?.Invoke();
            return;
            IL_00ca:
            if (onlyOnce)
            {
                if (dialogs.Length != 1)
                {
                    ChapterCompletionSession session3 = base.Session;
                    entityID = id;
                    if (session3.GetCounter(entityID.ToString() + "DialogCounter") <= dialogs.Length - 1)
                    {
                        goto IL_018d;
                    }
                }

                OwnedComponents.Remove(Talker);
            }
            else
            {
                ChapterCompletionSession session4 = base.Session;
                entityID = id;
                if (session4.GetCounter(entityID.ToString() + "DialogCounter") > dialogs.Length - 1 ||
                    dialogs.Length == 1)
                {
                    ChapterCompletionSession session5 = base.Session;
                    entityID = id;
                    session5.SetCounter(entityID.ToString() + "DialogCounter", 0);
                }
            }

            goto IL_018d;
        }

        private IEnumerator Talk(RoomPlayerSession player)
        {
            if (approachWhenTalking)
            {
                if (scale.X > 0f)
                {
                    yield return PlayerApproachRightSide(player, turnToFace: true, approachDistance);
                }
                else
                {
                    yield return PlayerApproachLeftSide(player, turnToFace: true, approachDistance);
                }
            }

            string[] array = dialogs;
            ChapterCompletionSession session = Session;
            MapEntityId entityID = id;
            yield return CreateDialogueRoutine(array[session.GetCounter(entityID.ToString() + "DialogCounter")]);
            Level.EndCutscene();
            OnTalkEnd(Level);
        }

        // Physical construction adapter for the existing source entity-loader ABI.
        public static SceneEntityState Load(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
            Vector2 offset, OriginalLevelEntityData entityData)
            => new EverestCustomNpcState(entityData, offset, level.CreateEntityId(levelData, entityData),
                level.EngineContext);
    }
}

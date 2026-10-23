using Celeste.Core.Display;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Formats.Graphics.Xml;
using Celeste.Graphics.Content.Xml;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Dialogs.Nodes;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using global::Celeste.Game.Execution;

namespace Celeste.Game.UI.Dialogue.MiniTextboxes
{
    public class MiniTextboxState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private int start;
        private TextAnchorPosition anchor;
        private MiniTextboxBehavior Behavior => ((IOriginalMiniTextboxProcess)engine).MiniTextboxBehavior;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private OriginalGameGraphicsResources Graphics
            => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalGameTextProcess TextProcess => ((IOriginalGameTextEnvironment)engine).Text;

        public const float TextScale = 0.75f;

        public const float BoxWidth = 1688f;

        public const float BoxHeight = 144f;

        public const float HudElementHeight = 180f;

        private int index;

        private RichTextLayout text;

        private AtlasEntry box;

        private float ease;

        private bool closing;

        private SimulationCoroutine routine;

        private Sprite portrait;

        private DialogPortrait portraitData;

        private float portraitSize;

        private float portraitScale;

        private SoundSourceComponentState talkerSfx;

        public static bool Displayed(ISourceEngineContext engine)
        {
            foreach (MiniTextboxState entity in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene.Entities
                     .GetTrackedEntities("Celeste.MiniTextbox"))
            {
                if (!entity.closing && entity.ease > 0.25f)
                {
                    return true;
                }
            }

            return false;
        }

        public MiniTextboxState(string dialogId, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate
                   .Value;
            portraitSize = 112f;
            box = Graphics.PortraitsAtlas.Entries["textbox/default_mini"];
            text = OriginalFancyTextParser.Parse(TextProcess.Dialog.Get(dialogId.Trim()),
                (int)(1688f - portraitSize - 32f), 2, 1f, null,
                OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
            foreach (RichTextNode node in text.Nodes)
            {
                if (node is DialogPortrait)
                {
                    DialogPortrait portrait = (portraitData = node as DialogPortrait);
                    this.portrait = Graphics.PortraitsSpriteBank.Create("portrait_" + portrait.Sprite);
                    XmlElement xML = Graphics.PortraitsSpriteBank.SpriteData["portrait_" + portrait.Sprite].Sources[0]
                        .XML;
                    portraitScale = portraitSize / xML.AttrFloat("size", 160f);
                    string id = "textbox/" + xML.Attr("textbox", "default") + "_mini";
                    if (Graphics.PortraitsAtlas.Has(id))
                    {
                        box = Graphics.PortraitsAtlas.Entries[id];
                    }

                    Add(this.portrait);
                }
            }

            Add(routine = new SimulationCoroutine(engine, Routine()));
            routine.UseRawDeltaTime = true;
            Add(new RoomTransitionListener
            {
                OnOutBegin = delegate
                {
                    if (!closing)
                    {
                        routine.Replace(Close());
                    }
                }
            });
            if (Process.AudioSession.DialogSnapshot == null)
            {
                Process.AudioSession.DialogSnapshot =
                    Process.AudioSession.CreateSnapshot("snapshot:/dialogue_in_progress", start: false);
            }

            Process.AudioSession.ResumeSnapshot(Process.AudioSession.DialogSnapshot);
            if (Behavior == MiniTextboxBehavior.Everest)
            {
                foreach (RichTextNode node in text.Nodes)
                    if (node is RichTextAnchor actualAnchor)
                        anchor = actualAnchor.Position;
            }
        }

        private IEnumerator Routine()
        {
            List<object> entities =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.MiniTextbox");
            foreach (MiniTextboxState item in entities)
            {
                if (item != this)
                {
                    item.Add(new SimulationCoroutine(engine, item.Close()));
                }
            }

            if (entities.Count > 0)
            {
                yield return 0.3f;
            }

            while ((ease += engine.DeltaTime * 4f) < 1f)
            {
                if (Behavior == MiniTextboxBehavior.Everest && closing)
                    yield break;
                yield return null;
            }

            ease = 1f;
            if (portrait != null)
            {
                string beginAnim = "begin_" + portraitData.Animation;
                if (portrait.Has(beginAnim))
                {
                    portrait.Play(beginAnim);
                    while (portrait.CurrentAnimationID == beginAnim && portrait.Animating)
                    {
                        yield return null;
                    }
                }

                portrait.Play("talk_" + portraitData.Animation);
                talkerSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create().Play(portraitData.SfxEvent);
                talkerSfx.Param("dialogue_portrait", portraitData.SfxExpression);
                talkerSfx.Param("dialogue_end", 0f);
                Add(talkerSfx);
            }

            float num = 0f;
            while (index < text.Nodes.Count)
            {
                if (Behavior == MiniTextboxBehavior.Everest) StartTalking();
                if (text.Nodes[index] is RichTextGlyph)
                {
                    num += (text.Nodes[index] as RichTextGlyph).Delay;
                }

                if (Behavior == MiniTextboxBehavior.Everest) HandleDialogNode(ref num);
                index++;
                if (num > 0.016f)
                {
                    yield return num;
                    num = 0f;
                }
            }

            if (portrait != null)
            {
                portrait.Play("idle_" + portraitData.Animation);
            }

            if (talkerSfx != null)
            {
                talkerSfx.Param("dialogue_portrait", 0f);
                talkerSfx.Param("dialogue_end", 1f);
            }

            Process.AudioSession.EndSnapshot(Process.AudioSession.DialogSnapshot);
            yield return 3f;
            yield return Close();
        }

        private IEnumerator Close()
        {
            if (!closing)
            {
                closing = true;
                while ((ease -= engine.DeltaTime * 4f) > 0f)
                {
                    yield return null;
                }

                ease = 0f;
                RemoveSelf();
            }
        }

        public override void Update()
        {
            if ((base.Scene as OriginalLevelSceneRoot).RetryPlayerCorpse != null && !closing)
            {
                routine.Replace(Close());
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (ease <= 0f)
            {
                return;
            }

            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            if (!level.FrozenOrPaused && level.RetryPlayerCorpse == null && !level.Cutscene.SkippingCutscene)
            {
                Vector2 vector = new Vector2(EngineRuntime.Width / 2,
                    72f + ((float)EngineRuntime.Width - 1688f) / 4f);
                if (Behavior == MiniTextboxBehavior.Everest) ApplyAnchor(ref vector);
                Vector2 vector2 = vector + new Vector2(-828f, -56f);
                SourceAtlasDrawing.DrawCentered(context, this, box, vector, PackedColor.White, new Vector2(1f, ease));
                if (portrait != null)
                {
                    portrait.Scale = new Vector2(1f, ease) * portraitScale;
                    portrait.RenderPosition = vector2 + new Vector2(portraitSize / 2f, portraitSize / 2f);
                    portrait.Render(context);
                }

                text.Draw(context, this, (ISourceRichTextDrawProcess)engine,
                    new Vector2(vector2.X + portraitSize + 32f, vector.Y), new Vector2(0f, 0.5f),
                    new Vector2(1f, ease) * 0.75f, 1f, Behavior == MiniTextboxBehavior.Everest ? start : 0, index);
            }
        }

        public override void Removed(object scene)
        {
            Process.AudioSession.EndSnapshot(Process.AudioSession.DialogSnapshot);
            base.Removed(scene);
        }

        public override void SceneEnd(object scene)
        {
            Process.AudioSession.EndSnapshot(Process.AudioSession.DialogSnapshot);
            base.SceneEnd(scene);
        }

        private void StartTalking()
        {
            talkerSfx?.Param("dialogue_portrait", ((float?)portraitData?.SfxExpression) ?? 1f);
            talkerSfx?.Param("dialogue_end", 0f);
            if (portrait != null && portraitData != null && portrait.Has(portraitData.TalkAnimation) &&
                portrait.CurrentAnimationID != portraitData.TalkAnimation)
            {
                portrait.Play(portraitData.TalkAnimation);
            }
        }

        private void HandleDialogNode(ref float delay)
        {
            if (text[index] is RichTextPause wait)
            {
                delay += wait.Duration;
            }
            else if (text[index] is RichTextPageBreak)
            {
                start = index + 1;
            }

            if (delay > 0.5f)
            {
                talkerSfx?.Param("dialogue_portrait", 0f);
                talkerSfx?.Param("dialogue_end", 1f);
                if (portrait != null && portraitData != null && portrait.Has(portraitData.IdleAnimation) &&
                    portrait.CurrentAnimationID != portraitData.IdleAnimation)
                {
                    portrait.Play(portraitData.IdleAnimation);
                }
            }
        }

        private void ApplyAnchor(ref Vector2 center)
        {
            if (anchor == TextAnchorPosition.Bottom)
            {
                center = new Vector2(EngineRuntime.Width / 2,
                    (float)EngineRuntime.Height - 72f - ((float)EngineRuntime.Width - 1688f) / 4f);
            }
            else if (anchor == TextAnchorPosition.Middle)
            {
                center = new Vector2(EngineRuntime.Width / 2, EngineRuntime.Height / 2);
            }
        }
    }
}

using System.Collections;
using Celeste.Core.Components;
using Celeste.Game.Controls.Source;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities;
using Celeste.Game.Entities.Postcards;
using Celeste.Game.Presentation.Hud;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public sealed class LevelEnterSequence : SourceSceneState
    {
        public ChapterCompletionSession Session;
        public bool FromSaveData;
        public PostcardState Postcard;
        private readonly IOriginalLevelEnterProcess process;

        public LevelEnterSequence(ChapterCompletionSession session, bool fromSaveData,
            IOriginalLevelEnterProcess process)
            : base(process, ((ISourceSceneCatalogEnvironment)process).SceneCatalog,
                ((global::Celeste.Scene.Scheduling.ISourceSceneUpdatePolicyEnvironment)process).PlainScenePolicy)
        {
            Session = session;
            FromSaveData = fromSaveData;
            this.process = process;
            var routineEntity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)process).EntitySourceDataRegistration);
            routineEntity.OwnedComponents.Add(new SimulationCoroutine(process, Routine()));
            SourceScene.QueueSourceEntity(routineEntity);
            Renderers.Add(new HudRendererState());
        }

        public static void Go(ChapterCompletionSession session, bool fromSaveData, IOriginalLevelEnterProcess process)
            => process.LevelEnterPolicy.Go(session, fromSaveData, process);

        public static LevelEnterSequence ForceCreate(ChapterCompletionSession session, bool fromSaveData,
            IOriginalLevelEnterProcess process)
            => new LevelEnterSequence(session, fromSaveData, process);

        // Installed Routine is a selector called while constructing Coroutine, not an iterator.
        private IEnumerator Routine() => process.LevelEnterPolicy.SelectRoutine(this);

        public IEnumerator OriginalRoutine()
        {
            int area = -1;
            if (Session.StartedFromBeginning && !FromSaveData && Session.Mode == 0 &&
                (!process.SaveCounters.GetAreasSafe(process.SaveContext.CurrentSave)[Session.AreaID].Modes[0]
                     .Completed ||
                 process.SaveContext.CurrentSave.DebugMode) && Session.AreaID >= 1 && Session.AreaID <= 6)
                area = Session.AreaID;
            if (area >= 0)
            {
                yield return 1f;
                Postcard = new PostcardState(process, process.Text.Dialog.Get("postcard_area_" + area), area);
                SourceScene.QueueSourceEntity(Postcard);
                yield return Postcard.DisplayRoutine();
            }

            if (Session.StartedFromBeginning && !FromSaveData && Session.Mode == 1)
            {
                var title = new BSideTitleState(Session, process);
                SourceScene.QueueSourceEntity(title);
                process.AudioSession.Play("event:/ui/main/bside_intro_text");
                yield return title.EaseIn();
                yield return .25f;
                yield return title.EaseOut();
                yield return .25f;
            }

            ((IOriginalGameInputProcessEnvironment)process).InputSource.SetLightbarColor(
                process.AreaKeys.GetArea(process.AreaKeys.GetSessionArea(Session)).TitleBaseColor);
            process.Frame.Scenes.NextScene = process.LevelLoaders.CreateLevelLoader(Session);
        }

        public IEnumerator EnterWithPostcardRoutine(string message, string soundId, string postcardTexture)
        {
            yield return 1f;
            var postcard = new PostcardState(process, message, soundId);
            if (postcardTexture != null)
                postcard.Postcard =
                    ((global::Celeste.Graphics.Content.Gui.ISourceGuiAtlasResources)
                        ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)process).GameGraphics)
                    .GuiAtlas[postcardTexture];
            Postcard = postcard;
            SourceScene.QueueSourceEntity(Postcard);
            yield return Postcard.DisplayRoutine();
            IEnumerator inner = OriginalRoutine();
            while (inner.MoveNext())
                yield return inner.Current;
        }

        public IEnumerator ErrorRoutine(string message)
        {
            process.AudioSession.ChannelOutput.SetMusic(null);
            process.AudioSession.ChannelOutput.SetAmbience(null);
            yield return 1f;
            Postcard = new PostcardState(process, message,
                "event:/ui/main/postcard_csides_in", "event:/ui/main/postcard_csides_out");
            SourceScene.QueueSourceEntity(Postcard);
            yield return Postcard.DisplayRoutine();
            var area = process.AreaKeys.GetArea(process.AreaKeys.GetSessionArea(Session)) != null
                ? process.AreaKeys.GetSessionArea(Session)
                : process.AreaKeys.SetSID(process.AreaKeys.Create(1), "");
            Session = process.Sessions.CreateSession(area);
            process.SaveSessionSelection.SetCurrentSessionSafe(process.SaveContext.CurrentSave, Session);
            process.SaveSessionSelection.SetLastAreaSafe(process.SaveContext.CurrentSave,
                process.AreaKeys.GetSessionArea(Session));
            process.Frame.Scenes.NextScene = process.OverworldLoaders.CreateOverworldLoader(
                global::Celeste.Game.Menus.Overworld.OverworldStartMode.AreaQuit);
        }

        public override void BeforeRender()
        {
            base.BeforeRender();
            Postcard?.BeforeRender();
        }
    }
}

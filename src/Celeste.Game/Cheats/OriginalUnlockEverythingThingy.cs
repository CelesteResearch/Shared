using Celeste.Core.Display;
using System.Numerics;
using Celeste.Scene.Entities.Input;
using Celeste.Input.Gameplay;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Cheats
{
    public class OriginalUnlockEverythingThingy : SourceCheatListenerState
    {
        private readonly IOriginalUnlockEverythingProcess engine;

        public OriginalUnlockEverythingThingy(IOriginalUnlockEverythingProcess engine)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            AddInput('u', () => engine.InputSource.MenuUp.Pressed && !engine.InputSource.MenuUp.Repeating);
            AddInput('d', () => engine.InputSource.MenuDown.Pressed && !engine.InputSource.MenuDown.Repeating);
            AddInput('r', () => engine.InputSource.MenuRight.Pressed && !engine.InputSource.MenuRight.Repeating);
            AddInput('l', () => engine.InputSource.MenuLeft.Pressed && !engine.InputSource.MenuLeft.Repeating);
            AddInput('A', () => engine.InputSource.MenuConfirm.Pressed);
            AddInput('L', () => engine.InputSource.MenuJournal.Pressed);
            AddInput('R', () => engine.InputSource.Grab.Pressed && !engine.InputSource.MenuJournal.Pressed);
            AddCheat("lrLRuudlRA", EnteredCheat);
            Logging = true;
        }

        public void EnteredCheat()
        {
            OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
            level.PauseLock = true;
            level.Frozen = true;
            level.Flash(global::Celeste.Core.Display.PackedColor.White);
            engine.AudioSession.Play("event:/game/06_reflection/feather_bubble_get",
                (base.Scene as OriginalLevelSceneRoot).Camera.Position + new Vector2(160f, 90f), engine.SaveContext);
            new FadeWipePresentation((global::Celeste.Scene.Rendering.ISourceRendererScene)base.Scene, wipeIn: false,
                delegate { UnlockEverything(level); }).Duration = 2f;
            RemoveSelf();
        }

        public void UnlockEverything(OriginalLevelSceneRoot level)
            => engine.UnlockEverythingPolicy.UnlockEverything(level, engine);
    }
}

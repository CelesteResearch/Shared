using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities.Input;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Cheats
{
    public class OriginalUnlockEverythingThingy : SourceCheatListenerState
    {
        private readonly IOriginalUnlockEverythingProcess engine;

        public OriginalUnlockEverythingThingy(IOriginalUnlockEverythingProcess engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
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
            var level = Scene as OriginalLevelSceneRoot;
            level.PauseLock = true;
            level.Frozen = true;
            level.Flash(PackedColor.White);
            engine.AudioSession.Play("event:/game/06_reflection/feather_bubble_get",
                (Scene as OriginalLevelSceneRoot).Camera.Position + new Vector2(160f, 90f), engine.SaveContext);
            new FadeWipePresentation((ISourceRendererScene)Scene, false,
                delegate { UnlockEverything(level); }).Duration = 2f;
            RemoveSelf();
        }

        public void UnlockEverything(OriginalLevelSceneRoot level)
        {
            engine.UnlockEverythingPolicy.UnlockEverything(level, engine);
        }
    }
}

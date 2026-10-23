using Celeste.Scene.Components;
using Celeste.Scene.Scheduling;
using System;
using System.Collections.Generic;

namespace Celeste.Game.Execution.Levels.Update
{
    public sealed class OriginalLevelUpdateCallbacks
    {
        // Read again after Prelude: pause input and cutscene code can change the
        // branch on the current frame. The initial frame remains the fallback.
        public Func<OriginalLevelUpdateFrame> ReadFrame;
        public Action<float, float> BeforeScene, AfterScene;
        public Action BeforeLevel, AfterLevel, FixChaserStateTimestamps;
        public Action BeforeFreezeFrame, AfterFreezeFrame;
        public Action<bool> SetInputDisabled;

        public Action BeginTaggedInput, EndTaggedInput;

        // Persist Level.unpauseTimer when ReadFrame returns a fresh snapshot.
        public Action<float> SetUnpauseTimer;

        // Level.Update processes speed snapshot and pause input before UpdateTime.
        public Action<float> PauseInputAndAssist;

        // Some hosts own an existing LevelPauseSequence that decrements the timer
        // and calls UpdateTime itself. Supplying this replaces the fallback pair.
        public Action<float> AdvanceUnpauseDelay;
        public Action UpdateTime, EntityLists;
        public Action<float> Overlay, SavingAndScenePrelude, SkipCoroutine, RetryCorpse, Transition;
        public Action<float, float> Renderers, Wipe, HiresSnow;

        public Action<float, float> HudAndWind, AfterHair;

        // Optional override for an already committed entity pass. The default
        // uses SceneUpdateScheduler.UpdateCommitted, never its auto-commit Update.
        public Action<float, SceneModeKey> RunEntities;
        public Action RunPostUpdateHooks;
        public Action<OriginalLevelUpdateBranch> TraceBranch;
        public readonly List<SceneComponentUpdate> PostUpdateHooks = new List<SceneComponentUpdate>();
        public Action<float> PlayerHair;
    }
}

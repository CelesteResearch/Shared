using System;
using Celeste.Core.Scheduling;
using Celeste.Core.Framework.Components;
using Celeste.Core.Framework.Timing;
using Celeste.Game.Execution.Engine.Timing;

namespace Celeste.Game.Execution.Engine.Update
{
    public sealed class OriginalEngineFrame
    {
        public readonly SourceEngineFrameState State;
        public bool ExitOnEscapeKeypress;
        public Action OverloadGameLoop;
        private readonly IOriginalEngineFrameInput input;
        private readonly IOriginalEngineFrameDevice device;
        private readonly global::Celeste.Framework.Diagnostics.Commands.SourceCommands commands;
        private readonly ISourceEngineSceneTransition transition;
        private readonly IOriginalEngineUpdateHooks hooks;
        private readonly SourceGameFrameworkState framework;
        private readonly SourceGameLoopState loop;
        private readonly IOriginalEngineTimeRatePolicy timeRatePolicy;
        private readonly global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic extrema;

        public OriginalEngineFrame(SourceEngineFrameState state, IOriginalEngineFrameInput input,
            IOriginalEngineFrameDevice device, global::Celeste.Framework.Diagnostics.Commands.SourceCommands commands,
            ISourceEngineSceneTransition transition, IOriginalEngineTimeRatePolicy timeRatePolicy,
            SourceGameFrameworkState framework, SourceGameLoopState loop,
            global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic extrema,
            IOriginalEngineUpdateHooks hooks = null)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
            this.input = input ?? throw new ArgumentNullException(nameof(input));
            this.device = device ?? throw new ArgumentNullException(nameof(device));
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.transition = transition ?? throw new ArgumentNullException(nameof(transition));
            this.timeRatePolicy = timeRatePolicy ?? throw new ArgumentNullException(nameof(timeRatePolicy));
            this.framework = framework ?? throw new ArgumentNullException(nameof(framework));
            this.loop = loop ?? throw new ArgumentNullException(nameof(loop));
            this.extrema = extrema ?? throw new ArgumentNullException(nameof(extrema));
            this.hooks = hooks;
        }

        public void Update(SourceGameTime gameTime)
        {
            UpdateSourceBody(gameTime);
            if (hooks is global::Celeste.Core.Scheduling.Hooks.ISourceUpdateMethodHooksEnvironment sourceHooks)
                sourceHooks.SourceEngineUpdateHooks.InvokeAfterUpdate();
        }

        private void UpdateSourceBody(SourceGameTime gameTime)
        {
            float rawDeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var sample = timeRatePolicy.Sample(rawDeltaTime, State.Effects, State.Scenes.CurrentScene);
            State.RawDeltaTime = sample.RawDeltaTime;
            State.DeltaTime = sample.DeltaTime;
            State.Effects.EffectiveTimeRate = sample.EffectiveTimeRate;
            State.FrameCounter = unchecked(State.FrameCounter + 1);
            State.FrozenThisFrame = false;
            State.SceneUpdatedThisFrame = false;
            input.Update(State.DeltaTime);
            if (hooks?.PausedAfterInput == true)
            {
                return;
            }

            hooks?.PreEngineUpdate();
            if (ExitOnEscapeKeypress && input.EscapePressed)
            {
                loop.Exit();
                hooks?.PostEngineUpdate();
                return;
            }

            if (OverloadGameLoop != null)
            {
                OverloadGameLoop();
                framework.UpdateComponents(gameTime);
                device.FrameworkDispatcherUpdate();
                hooks?.PostEngineUpdate();
                return;
            }

            if (State.Effects.DashAssistFreeze)
            {
                if (input.DashHeld || !State.Effects.DashAssistFreezePress)
                {
                    if (input.DashHeld) State.Effects.DashAssistFreezePress = true;
                    if (State.Scenes.CurrentScene != null)
                    {
                        var dashScene = State.Scenes.CurrentScene as IOriginalEngineDashAssistScene
                                        ?? throw new InvalidOperationException(
                                            "The actual scene has no source DashAssist Tracker/EntityList capability.");
                        dashScene.UpdateFirstTrackedDashAssist();
                        if (State.Scenes.CurrentScene is IOriginalEngineLevelTimeScene level) level.UpdateLevelTime();
                        dashScene.CommitEntityLists();
                    }
                }
                else State.Effects.DashAssistFreeze = false;
            }

            if (!State.Effects.DashAssistFreeze)
            {
                if (State.Effects.FreezeTimer > 0)
                {
                    State.FrozenThisFrame = true;
                    hooks?.BeforeFreezeTimerDecrement(State.Scenes.CurrentScene);
                    State.Effects.FreezeTimer = extrema.Max(State.Effects.FreezeTimer - State.RawDeltaTime, 0f);
                }
                else if (State.Scenes.CurrentScene != null)
                {
                    State.SceneUpdatedThisFrame = true;
                    State.Scenes.CurrentScene.BeforeUpdate();
                    State.Scenes.CurrentScene.Update();
                    State.Scenes.CurrentScene.AfterUpdate();
                }
            }

            if (commands.Open) commands.UpdateOpen();
            else if (commands.Enabled) commands.UpdateClosed();
            State.Scenes.ApplyTransition(transition);
            framework.UpdateComponents(gameTime);
            device.FrameworkDispatcherUpdate();
            hooks?.PostEngineUpdate();
        }
    }
}

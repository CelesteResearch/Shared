using System;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OshiroSpriteState : Sprite
    {
        public bool AllowSpriteChanges = true;
        public bool AllowTurnInvisible = true;
        private WigglerComponent wiggler;
        private readonly ISourceEngineContext engine;

        public OshiroSpriteState(ISourceEngineContext engine, int facing) : base(engine, null, "")
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Scale.X = facing;
            ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .SpriteFactory.CreateOn(this, "oshiro");
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.3f, 2f, f =>
            {
                Scale.X = Math.Sign(Scale.X) * (1f + f * .2f);
                Scale.Y = 1f - f * .2f;
            });
            ((ISourceOwnedComponentList)entity).OwnedComponents.Add(wiggler);
        }

        public override void Update()
        {
            base.Update();
            if (AllowSpriteChanges)
            {
                var text = ((OriginalLevelSceneRoot)Scene).Scheduler.Entities
                    .GetTrackedEntity<TextboxState>("Celeste.Textbox");
                if (text != null)
                {
                    if (text.PortraitName.Equals("oshiro", StringComparison.OrdinalIgnoreCase) &&
                        text.PortraitAnimation.StartsWith("side", StringComparison.OrdinalIgnoreCase))
                    {
                        if (CurrentAnimationID.Equals("idle")) Pop("side", true);
                    }
                    else if (CurrentAnimationID.Equals("side"))
                    {
                        Pop("idle", true);
                    }
                }
            }

            if (AllowTurnInvisible && Visible)
            {
                var level = Scene as OriginalLevelSceneRoot;
                Visible = RenderPosition.X > level.Bounds.Left - 8 &&
                          RenderPosition.Y > level.Bounds.Top - 8 &&
                          RenderPosition.X < level.Bounds.Right + 8 &&
                          RenderPosition.Y < level.Bounds.Bottom + 16;
            }
        }

        public void Wiggle()
        {
            wiggler.Start();
        }

        public void Pop(string name, bool flip)
        {
            if (CurrentAnimationID.Equals(name)) return;
            Play(name);
            if (flip)
            {
                Scale.X = 0f - Scale.X;
                var process = (IOriginalGameplayProcess)engine;
                process.AudioSession.Play(
                    Scale.X < 0f ? "event:/char/oshiro/chat_turn_left" : "event:/char/oshiro/chat_turn_right",
                    ((ISourceEntityPosition)Entity).Position,
                    process.SaveContext);
            }

            wiggler.Start();
        }
    }
}

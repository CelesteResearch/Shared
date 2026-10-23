using Celeste.Simulation;
using Celeste.Scene.Components.Oscillation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Game.Entities.BadelineDummy
{
    public class BadelineAutoAnimatorPresentation : global::Celeste.Core.Components.SourceComponentState
    {
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        public bool Enabled = true;

        public BadelineAutoAnimatorPresentation(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(true, false)
        {
            this.engine = engine;
        }

        public string LastAnimation { get; private set; }
        public bool WasSyncingSprite { get; private set; }
        public WigglerComponent Pop { get; private set; }

        private global::Celeste.Graphics.Animation.Sprite FindSprite()
            => ((global::Celeste.Core.Components.ISourceOwnedComponentList)Entity).OwnedComponents
                .Get<global::Celeste.Graphics.Animation.Sprite>();

        public override void Added(object entity)
        {
            base.Added(entity);
            var list = ((global::Celeste.Core.Components.ISourceOwnedComponentList)entity).OwnedComponents;
            Pop = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.5f, 4f, value =>
            {
                var sprite = FindSprite();
                if (sprite != null) sprite.Scale = new Vector2(Math.Sign(sprite.Scale.X), 1f) * (1f + .25f * value);
            });
            list.Add(Pop);
        }

        public override void Removed(object entity)
        {
            ((global::Celeste.Core.Components.ISourceOwnedComponentList)entity).OwnedComponents.Remove(Pop);
            base.Removed(entity);
        }

        private static bool IsAngryPortrait(string animation) =>
            string.Equals(animation, "yell", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(animation, "freakA", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(animation, "freakB", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(animation, "freakC", StringComparison.InvariantCultureIgnoreCase);

        public void SetReturnToAnimation(string animation) => LastAnimation = animation;

        public override void Update()
        {
            var sprite = FindSprite();
            if (Scene == null || sprite == null) return;
            var textbox =
                ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities
                .GetTrackedEntity<global::Celeste.Game.UI.Dialogue.Textboxes.TextboxState>("Celeste.Textbox");
            bool syncing = false;
            if (Enabled && textbox != null && string.Equals(textbox.PortraitName, "badeline",
                    StringComparison.InvariantCultureIgnoreCase))
            {
                if (string.Equals(textbox.PortraitAnimation, "scoff", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!WasSyncingSprite) LastAnimation = sprite.CurrentAnimationID;
                    sprite.Play("laugh");
                    syncing = WasSyncingSprite = true;
                }
                else if (IsAngryPortrait(textbox.PortraitAnimation))
                {
                    if (!WasSyncingSprite)
                    {
                        Pop.Start();
                        LastAnimation = sprite.CurrentAnimationID;
                    }

                    sprite.Play("angry");
                    syncing = WasSyncingSprite = true;
                }
            }

            if (WasSyncingSprite && !syncing)
            {
                WasSyncingSprite = false;
                if (string.IsNullOrEmpty(LastAnimation) || LastAnimation == "spin") LastAnimation = "fallSlow";
                if (sprite.CurrentAnimationID == "angry") Pop.Start();
                sprite.Play(LastAnimation);
            }
        }
    }
}

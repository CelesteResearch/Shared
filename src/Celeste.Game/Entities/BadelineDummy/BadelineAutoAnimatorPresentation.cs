using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.BadelineDummy
{
    public class BadelineAutoAnimatorPresentation : SourceComponentState
    {
        private readonly ISourceEngineContext engine;
        public bool Enabled = true;

        public BadelineAutoAnimatorPresentation(ISourceEngineContext engine)
            : base(true, false)
        {
            this.engine = engine;
        }

        public string LastAnimation { get; private set; }
        public bool WasSyncingSprite { get; private set; }
        public WigglerComponent Pop { get; private set; }

        private Sprite FindSprite()
        {
            return ((ISourceOwnedComponentList)Entity).OwnedComponents
                .Get<Sprite>();
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            var list = ((ISourceOwnedComponentList)entity).OwnedComponents;
            Pop = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.5f, 4f, value =>
            {
                var sprite = FindSprite();
                if (sprite != null) sprite.Scale = new Vector2(Math.Sign(sprite.Scale.X), 1f) * (1f + .25f * value);
            });
            list.Add(Pop);
        }

        public override void Removed(object entity)
        {
            ((ISourceOwnedComponentList)entity).OwnedComponents.Remove(Pop);
            base.Removed(entity);
        }

        private static bool IsAngryPortrait(string animation)
        {
            return string.Equals(animation, "yell", StringComparison.InvariantCultureIgnoreCase) ||
                   string.Equals(animation, "freakA", StringComparison.InvariantCultureIgnoreCase) ||
                   string.Equals(animation, "freakB", StringComparison.InvariantCultureIgnoreCase) ||
                   string.Equals(animation, "freakC", StringComparison.InvariantCultureIgnoreCase);
        }

        public void SetReturnToAnimation(string animation)
        {
            LastAnimation = animation;
        }

        public override void Update()
        {
            var sprite = FindSprite();
            if (Scene == null || sprite == null) return;
            var textbox =
                ((ISourceScene)Scene).SourceScene.Entities
                .GetTrackedEntity<TextboxState>("Celeste.Textbox");
            var syncing = false;
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

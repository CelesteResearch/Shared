using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Talking;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Lookout;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Lookouts
{
    public partial class OriginalLookoutState : SceneEntityState, ISourceLookoutInteraction, ILookoutInteractionState
    {
        private OriginalLookoutHud hud;
        protected OriginalTalkComponent talk;
        private readonly Sprite sprite;
        private readonly SourceTweenState lightTween;
        private bool interacting;
        private readonly bool onlyY;
        private readonly List<Vector2> nodes;
        private readonly bool summit;
        private string animPrefix = "";
        private readonly IOriginalLookoutProcess process;

        public OriginalLookoutState(EntityData data, Vector2 offset, IOriginalLookoutProcess process)
            : base(((ISourceEntitySourceDataEnvironment)process.EngineContext).EntitySourceDataRegistration,
                data.Position + offset)
        {
            this.process = process;
            Depth = -8500;
            OwnedComponents.Add(talk = new(process, new(-24, -8, 48, 8),
                new(-0.5f, -20f), Interact));
            talk.PlayerMustBeFacing = false;
            summit = EntityAttributeReader.Bool(data.Values, "summit");
            onlyY = EntityAttributeReader.Bool(data.Values, "onlyY");
            Collider = new HitboxColliderGeometry(4f, 4f, -2f, -4f);
            var light = new VertexLightState(process.EngineContext, new(-1f, -11f),
                PackedColor.White, 0.8f, 16, 24);
            OwnedComponents.Add(light);
            lightTween = light.CreatePulseTween(process.EngineContext);
            OwnedComponents.Add(lightTween);
            OwnedComponents.Add(sprite = process.SpriteBank.Create("lookout"));
            sprite.OnFrameChange = animation =>
            {
                switch (animation)
                {
                    case "idle":
                    case "badeline_idle":
                    case "nobackpack_idle":
                        if (sprite.CurrentAnimationFrame == sprite.CurrentAnimationTotalFrames - 1)
                            lightTween.Start();
                        break;
                }
            };
            var points = data.NodesOffset(offset);
            if (points != null && points.Length != 0) nodes = [.. points];
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            if (!interacting)
                return;
            var player = ((ISourceScene)scene).SourceScene.Entities
                .FindFirst<RoomPlayerSession>();
            if (player != null) player.Machine.State = 0;
        }

        private void Interact(RoomPlayerSession player)
        {
            if (player.DefaultSpriteMode == PlayerSpriteMode.MadelineAsBadeline ||
                process.CurrentSave.Assists.PlayAsBadeline)
                animPrefix = "badeline_";
            else if (player.DefaultSpriteMode == PlayerSpriteMode.MadelineNoBackpack) animPrefix = "nobackpack_";
            else animPrefix = "";
            var coroutine = new SimulationCoroutine(process.EngineContext, LookRoutine(player));
            coroutine.RemoveOnComplete = true;
            OwnedComponents.Add(coroutine);
            interacting = true;
        }

        public void StopInteracting()
        {
            interacting = false;
            sprite.Play(animPrefix + "idle");
        }

        public override void Update()
        {
            UpdateComponentsAndSprite();
            if (!(talk != null && CollideCheck("Celeste.Solid")))
                return;
            OwnedComponents.Remove(talk);
            talk = null;
        }

        protected void UpdateComponentsAndSprite()
        {
            base.Update();
            var player = ((ISourceScene)Scene).SourceScene.Entities
                .FindFirst<RoomPlayerSession>();
            if (!(player != null))
                return;
            sprite.Active = interacting || player.Machine.State != 11;
            if (!sprite.Active) sprite.SetAnimationFrame(0);
        }

        SceneEntityState ILookoutInteractionState.Entity => this;
        IOriginalLookoutProcess ILookoutInteractionState.Process => process;

        ILookoutHudState ILookoutInteractionState.Hud
        {
            get => hud;
            set => hud = (OriginalLookoutHud)value;
        }

        Sprite ILookoutInteractionState.Sprite => sprite;

        bool ILookoutInteractionState.Interacting
        {
            get => interacting;
            set => interacting = value;
        }

        bool ILookoutInteractionState.OnlyY => onlyY;
        List<Vector2> ILookoutInteractionState.Nodes => nodes;

        int ILookoutInteractionState.Node { get; set; }

        float ILookoutInteractionState.NodePercent { get; set; }

        bool ILookoutInteractionState.Summit => summit;
        string ILookoutInteractionState.AnimationPrefix => animPrefix;
        float ILookoutInteractionState.Acceleration => 800f;
        float ILookoutInteractionState.MaximumSpeed => 240f;

        ILookoutHudState ILookoutInteractionState.CreateHud()
        {
            return new OriginalLookoutHud(process);
        }

        void ILookoutInteractionState.OnViewStarted()
        {
        }

        void ILookoutInteractionState.OnViewEnded()
        {
        }
    }
}

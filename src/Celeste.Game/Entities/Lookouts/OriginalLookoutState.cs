using Celeste.Core.Display;
using Celeste.Core.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Lookout;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Game.Components.Talking;

namespace Celeste.Game.Entities.Lookouts
{
    public partial class OriginalLookoutState : SceneEntityState, ISourceLookoutInteraction, ILookoutInteractionState
    {
        private OriginalLookoutHud hud;
        protected OriginalTalkComponent talk;
        private Sprite sprite;
        private SourceTweenState lightTween;
        private bool interacting;
        private bool onlyY;
        private List<Vector2> nodes;
        private int node;
        private float nodePercent;
        private bool summit;
        private string animPrefix = "";
        private readonly IOriginalLookoutProcess process;

        public OriginalLookoutState(EntityData data, Vector2 offset, IOriginalLookoutProcess process)
            : base(((ISourceEntitySourceDataEnvironment)process.EngineContext).EntitySourceDataRegistration,
                data.Position + offset)
        {
            this.process = process;
            Depth = -8500;
            OwnedComponents.Add(talk = new OriginalTalkComponent(process, new IntRect(-24, -8, 48, 8),
                new Vector2(-0.5f, -20f), Interact));
            talk.PlayerMustBeFacing = false;
            summit = EntityAttributeReader.Bool(data.Values, "summit");
            onlyY = EntityAttributeReader.Bool(data.Values, "onlyY");
            Collider = new HitboxColliderGeometry(4f, 4f, -2f, -4f);
            var light = new VertexLightState(process.EngineContext, new Vector2(-1f, -11f),
                global::Celeste.Core.Display.PackedColor.White, 0.8f, 16, 24);
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
            Vector2[] points = data.NodesOffset(offset);
            if (points != null && points.Length != 0) nodes = new List<Vector2>(points);
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            if (interacting)
            {
                RoomPlayerSession player = ((ISourceScene)scene).SourceScene.Entities
                    .FindFirst<RoomPlayerSession>();
                if (player != null) player.Machine.State = 0;
            }
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
            if (talk != null && CollideCheck("Celeste.Solid"))
            {
                OwnedComponents.Remove(talk);
                talk = null;
            }
        }

        protected void UpdateComponentsAndSprite()
        {
            base.Update();
            RoomPlayerSession player = ((ISourceScene)Scene).SourceScene.Entities
                .FindFirst<RoomPlayerSession>();
            if (player != null)
            {
                sprite.Active = interacting || player.Machine.State != 11;
                if (!sprite.Active) sprite.SetAnimationFrame(0);
            }
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

        int ILookoutInteractionState.Node
        {
            get => node;
            set => node = value;
        }

        float ILookoutInteractionState.NodePercent
        {
            get => nodePercent;
            set => nodePercent = value;
        }

        bool ILookoutInteractionState.Summit => summit;
        string ILookoutInteractionState.AnimationPrefix => animPrefix;
        float ILookoutInteractionState.Acceleration => 800f;
        float ILookoutInteractionState.MaximumSpeed => 240f;
        ILookoutHudState ILookoutInteractionState.CreateHud() => new OriginalLookoutHud(process);

        void ILookoutInteractionState.OnViewStarted()
        {
        }

        void ILookoutInteractionState.OnViewEnded()
        {
        }
    }
}

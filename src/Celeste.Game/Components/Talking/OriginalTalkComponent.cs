using Celeste.Core.Display;
using Celeste.Game.Controls.Source;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Components.Talking
{
    public class OriginalTalkComponent : SourceComponentState
    {
        public class HoverDisplay
        {
            public AtlasEntry Texture;
            public Vector2 InputPosition;
            public string SfxIn = "event:/ui/game/hotspot_main_in";
            public string SfxOut = "event:/ui/game/hotspot_main_out";
        }

        public static OriginalTalkComponent PlayerOver;
        public bool Enabled = true;
        public IntRect Bounds;
        public Vector2 DrawAt;
        public Action<RoomPlayerSession> OnTalk;
        public bool PlayerMustBeFacing = true;
        public OriginalTalkUiEntity UI;
        public HoverDisplay HoverUI;
        private float cooldown;
        private float hoverTimer;
        private float disableDelay;
        internal readonly IOriginalTalkProcess Process;

        public OriginalTalkComponent(IOriginalTalkProcess process, IntRect bounds, Vector2 drawAt,
            Action<RoomPlayerSession> onTalk, HoverDisplay hoverDisplay = null) : base(true, true)
        {
            Process = process;
            Bounds = bounds;
            DrawAt = drawAt;
            OnTalk = onTalk;
            if (hoverDisplay == null)
            {
                HoverUI = new HoverDisplay
                {
                    Texture = process.GuiAtlas.Entries["hover/highlight"],
                    InputPosition = new Vector2(0f, -75f)
                };
            }
            else HoverUI = hoverDisplay;
        }

        public override void Update()
        {
            if (UI == null)
                ((ISourceScene)((ISourceEntityScene)Entity).Scene).SourceScene
                    .QueueSourceEntity(UI = new OriginalTalkUiEntity(this));
            RoomPlayerSession player = ((ISourceScene)Scene).SourceScene.Entities
                .GetTrackedEntity<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            bool over = disableDelay < 0.05f && player != null
                                             && SourceEntityCollision.CheckRect((ISourceEntityCollider)player,
                                                 new IntRect(
                                                     (int)(((ISourceEntityPosition)Entity).Position.X +
                                                           (float)Bounds.X),
                                                     (int)(((ISourceEntityPosition)Entity).Position.Y +
                                                           (float)Bounds.Y),
                                                     Bounds.Width, Bounds.Height))
                                             && player.OnGround()
                                             && player.Bottom < ((ISourceEntityPosition)Entity).Position.Y +
                                             (float)Bounds.Bottom + 4f
                                             && player.Machine.State == 0
                                             && (!PlayerMustBeFacing || Math.Abs(player.Position.X -
                                                                         ((ISourceEntityPosition)Entity).Position
                                                                         .X) <= 16f
                                                                     || player.Facing ==
                                                                     Math.Sign(((ISourceEntityPosition)Entity).Position
                                                                               .X -
                                                                               player.Position.X))
                                             && (PlayerOver == null || PlayerOver == this);
            if (over) hoverTimer += Process.EngineContext.DeltaTime;
            else if (UI.Display) hoverTimer = 0f;
            if (PlayerOver == this && !over) PlayerOver = null;
            else if (over) PlayerOver = this;
            if (over && cooldown <= 0f && player != null && player.Machine.State == 0
                && ((IOriginalGameInputProcessEnvironment)Process.EngineContext).InputSource.Talk.Pressed && Enabled &&
                !((ISourceScene)Scene).SourceScene.Paused)
            {
                cooldown = 0.1f;
                if (OnTalk != null) OnTalk(player);
            }

            if (over && player.Machine.State == 0) cooldown -= Process.EngineContext.DeltaTime;
            if (!Enabled) disableDelay += Process.EngineContext.DeltaTime;
            else disableDelay = 0f;
            UI.Highlighted = over && hoverTimer > 0.1f;
            base.Update();
        }

        public override void Removed(object entity)
        {
            Dispose();
            base.Removed(entity);
        }

        public override void EntityRemoved(object scene)
        {
            Dispose();
            base.EntityRemoved(scene);
        }

        public override void SceneEnd(object scene)
        {
            Dispose();
            base.SceneEnd(scene);
        }

        private void Dispose()
        {
            if (PlayerOver == this) PlayerOver = null;
            ((ISceneEntityRemovalScene)Scene).RemoveEntity(UI);
            UI = null;
        }

        public override void DebugRender(ISourceRenderContext context, object camera)
        {
            base.DebugRender(context, camera);
            SourcePrimitiveDrawing.HollowRect(context, Entity,
                ((ISourceEntityPosition)Entity).Position.X + (float)Bounds.X,
                ((ISourceEntityPosition)Entity).Position.Y + (float)Bounds.Y,
                Bounds.Width, Bounds.Height, new global::Celeste.Core.Display.PackedColor(0, 128, 0, 255));
        }
    }
}

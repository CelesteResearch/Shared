using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Graphics.Content;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public class OriginalReflectionGrannyState : OriginalNpcState
    {
        public OriginalHahahaState Hahaha;

        private int cutsceneIndex;

        public OriginalReflectionGrannyState(ISourceEngineContext engine, EntityData data, Vector2 position)
            : base(engine, data.Position + position)
        {
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)Engine).GameGraphics.SpriteFactory.Create("granny"));
            Sprite.Scale.X = -1f;
            Sprite.Play("idle");
            OwnedComponents.Add(new OriginalGrannyLaughSfxState(Engine, Sprite));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(Hahaha =
                new(Engine, Position + new Vector2(8f, -4f)));
            Hahaha.Enabled = false;
            while (Session.GetFlag("granny_" + cutsceneIndex)) cutsceneIndex++;

            OwnedComponents.Add(Talker = new((IOriginalTalkProcess)Engine,
                new(-20, -8, 30, 8), new(0f, -24f), OnTalk));
            Talker.Enabled = cutsceneIndex > 0 && cutsceneIndex < 3;
        }

        public override void Update()
        {
            if (cutsceneIndex == 0)
            {
                var entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);
                if (entity != null && entity.X > X - 60f) OnTalk(entity);
            }

            Hahaha.Enabled = Sprite.CurrentAnimationID == "laugh";
            base.Update();
        }

        private void OnTalk(RoomPlayerSession player)
        {
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                new OriginalReflectionGrannyCutscene(Engine, this, player, cutsceneIndex));
            cutsceneIndex++;
            Talker.Enabled = cutsceneIndex > 0 && cutsceneIndex < 3;
        }
    }
}

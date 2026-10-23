using Celeste.Simulation;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Content.Dialogs;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Startup;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Scene;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text;
using Celeste.Physics.Collision.Shapes;
using Image = Celeste.Graphics.Animation.SpriteImage;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;

namespace Celeste.Game.Entities.Memorials
{
    public class MemorialState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private Image sprite;

        private MemorialTextState text;

        private Sprite dreamyText;

        private bool wasShowing;

        private SoundSource loopingSfx;

        public MemorialState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            OwnedComponents.Add(sprite =
                new Image(((ISourceGameGraphicsEnvironment)engine).GameGraphics
                    .GameAtlas["scenery/memorial/memorial"]));
            sprite.Origin = new Vector2(sprite.Width / 2f, sprite.Height);
            base.Depth = 100;
            base.Collider = new HitboxColliderGeometry(60f, 80f, -30f, -60f);
            OwnedComponents.Add(loopingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
        }

        public MemorialState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            OriginalLevelSceneRoot level = scene as OriginalLevelSceneRoot;
            level.SourceScene.QueueSourceEntity(text = new MemorialTextState(this, level.Session.Dreaming, engine));
            if (level.Session.Dreaming)
            {
                OwnedComponents.Add(dreamyText = AtlasSpriteFactory.Create(engine,
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas, "scenery/memorial/floatytext"));
                dreamyText.AddLoop("dreamy", "", 0.1f);
                dreamyText.Play("dreamy");
                dreamyText.Position = new Vector2((0f - dreamyText.Width) / 2f, -33f);
            }

            if (((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session).ID == 1 &&
                ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session).Mode ==
                (int)OriginalAreaMode.Normal)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("end", 1f);
            }
        }

        public override void Update()
        {
            base.Update();
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            if (level.Paused)
            {
                loopingSfx.Pause();
                return;
            }

            RoomPlayerSession entity =
                level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            bool dreaming = level.Session.Dreaming;
            wasShowing = text.Show;
            text.Show = entity != null && global::Celeste.Physics.Collision.SourceEntityCollision.Check(this, entity);
            if (text.Show && !wasShowing)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play(dreaming
                    ? "event:/ui/game/memorial_dream_text_in"
                    : "event:/ui/game/memorial_text_in");
                if (dreaming)
                {
                    loopingSfx.Play("event:/ui/game/memorial_dream_loop");
                    loopingSfx.Param("end", 0f);
                }
            }
            else if (!text.Show && wasShowing)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play(dreaming
                    ? "event:/ui/game/memorial_dream_text_out"
                    : "event:/ui/game/memorial_text_out");
                loopingSfx.Param("end", 1f);
                loopingSfx.Stop();
            }

            loopingSfx.Resume();
        }
    }
}

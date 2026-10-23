using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Text;
using Celeste.Localization.Lookup;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Image = Celeste.Graphics.Animation.SpriteImage;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;

namespace Celeste.Everest.Entities.Memorials
{
    /// <summary>
    ///     Based on Memorial, to be used by custom maps.
    ///     Checks for the following new attributes:
    ///     - `string dialog` (default: `memorial`)
    ///     - `string sprite` (default: `scenery/memorial/memorial`)
    /// </summary>
    [CustomEntity("everest/memorial")]
    public class CustomMemorialState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private ActiveBitmapFont ActiveFont => ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;

        private DialogCatalog Dialog =>
            ((IOriginalGameTextEnvironment)engine).Text.Dialog;

        private OriginalGameAudioSession Audio =>
            ((IOriginalGameplayProcess)engine).AudioSession;

        private readonly Image sprite;

        private CustomMemorialTextState text;

        private Sprite dreamyText;

        private bool wasShowing;

        private readonly SoundSource loopingSfx;

        private readonly string textText;

        private readonly float textSpacing;

        public CustomMemorialState(Vector2 position, string texture, string dialog, float spacing,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value;
            if (!string.IsNullOrWhiteSpace(texture))
            {
                OwnedComponents.Add(sprite =
                    new(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[texture]));
                sprite.Origin = new(sprite.Width / 2f, sprite.Height);
            }

            textText = Dialog.Clean(dialog);
            textSpacing = spacing;
            Depth = 100;
            Collider = new HitboxColliderGeometry(60f, 80f, -30f, -60f);
            OwnedComponents.Add(loopingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
        }

        public CustomMemorialState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset,
                EntityAttributeReader.Attr(data.Values, "sprite", "scenery/memorial/memorial"),
                EntityAttributeReader.Attr(data.Values, "dialog", "memorial"),
                EntityAttributeReader.Float(data.Values, "spacing", 8f), engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var level = (OriginalLevelSceneRoot)scene;
            level.SourceScene.QueueSourceEntity(text =
                new(this, level.Session.Dreaming, textText, textSpacing, engine));
            if (level.Session.Dreaming)
            {
                OwnedComponents.Add(dreamyText = AtlasSpriteFactory.Create(engine,
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas, "scenery/memorial/floatytext"));
                dreamyText.AddLoop("dreamy", "", 0.1f);
                dreamyText.Play("dreamy");
                dreamyText.Position = new((0f - dreamyText.Width) / 2f, -33f);
            }

            if (level.Session.AreaID == 1 && level.Session.Mode == 0) Audio.SetMusicParam("end", 1f);
        }

        public override void Update()
        {
            base.Update();
            var level = (OriginalLevelSceneRoot)Scene;
            if (level.Paused)
            {
                loopingSfx.Pause();
                return;
            }

            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            var dreaming = level.Session.Dreaming;
            wasShowing = text.Show;
            text.Show = entity != null && SourceEntityCollision.Check(this, entity);
            if (text.Show && !wasShowing)
            {
                Audio.Play(dreaming ? "event:/ui/game/memorial_dream_text_in" : "event:/ui/game/memorial_text_in");
                if (dreaming)
                {
                    loopingSfx.Play("event:/ui/game/memorial_dream_loop");
                    loopingSfx.Param("end", 0f);
                }
            }
            else if (!text.Show && wasShowing)
            {
                Audio.Play(dreaming ? "event:/ui/game/memorial_dream_text_out" : "event:/ui/game/memorial_text_out");
                loopingSfx.Param("end", 1f);
                loopingSfx.Stop();
            }

            loopingSfx.Resume();
        }
    }
}

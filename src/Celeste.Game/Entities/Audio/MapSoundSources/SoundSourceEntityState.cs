using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Startup;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Entities.Audio.MapSoundSources
{
    public class SoundSourceEntityState : SceneEntityState
    {
        private string eventName;
        private SoundSourceComponentState sfx;

        public SoundSourceEntityState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            OwnedComponents.Add(sfx = new SoundSourceComponentState(engine));
            eventName = ((IOriginalSfxEnvironment)engine).Sfx.EventnameByHandle(
                EntityAttributeReader.Attr(data.Values, "sound"));
            Visible = true;
            Depth = -8500;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            sfx.Play(eventName);
        }
    }
}

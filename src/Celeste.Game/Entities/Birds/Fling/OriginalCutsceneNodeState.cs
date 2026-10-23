using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Birds.Fling
{
    public class OriginalCutsceneNodeState : SceneEntityState
    {
        public string Name;

        public OriginalCutsceneNodeState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            Name = EntityAttributeReader.Attr(data.Values, "nodeName");
        }

        public static OriginalCutsceneNodeState Find(ISourceEngineContext engine, string name)
        {
            foreach (OriginalCutsceneNodeState entity in ((ISourceScene)engine.Frame.Scenes.CurrentScene).SourceScene
                     .Entities.GetTrackedEntities("Celeste.CutsceneNode"))
                if (entity.Name != null && entity.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return entity;
            return null;
        }
    }
}

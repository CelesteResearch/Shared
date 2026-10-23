using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Lights
{
    public class OriginalPropLightState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        public OriginalPropLightState(Vector2 position, PackedColor color, float alpha, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            Add(new VertexLightState(engine, color, alpha, 128, 256));
        }

        public OriginalPropLightState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, ReadMapColor(data), EntityAttributeReader.Float(data.Values, "alpha"),
                engine)
        {
        }

        private static PackedColor ReadMapColor(EntityData data)
        {
            if (data.Values.TryGetValue("color", out var value))
            {
                string text = value.ToString();
                if (text.Length == 6)
                    return SourceHexColor.HexToColor(text);
            }

            return default;
        }
    }
}

using System;
using Celeste.Simulation.Presentation.Drawing.VertexEffects;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Geometry
{
    public sealed class TexturedGeometry
    {
        public int Depth { get; private set; }
        public string TexturePage { get; private set; }
        public ReflectionTentacleVertex[] Vertices { get; private set; }
        public int VertexCount { get; private set; }
        public int Count => VertexCount;

        public RoomVertexEffect Effect { get; private set; }

        public TexturedGeometry(int depth, string texturePage,
            ReflectionTentacleVertex[] vertices, int vertexCount,
            RoomVertexEffect effect = RoomVertexEffect.FxTexture)
        {
            Update(depth, texturePage, vertices, vertexCount, effect);
        }

        internal void Update(int depth, string texturePage,
            ReflectionTentacleVertex[] vertices, int vertexCount,
            RoomVertexEffect effect)
        {
            if (string.IsNullOrEmpty(texturePage))
                throw new ArgumentException("Texture page is required.", nameof(texturePage));
            if (vertices == null) throw new ArgumentNullException(nameof(vertices));
            if (vertexCount < 0 || vertexCount > vertices.Length || vertexCount % 3 != 0)
                throw new ArgumentOutOfRangeException(nameof(vertexCount));
            Depth = depth;
            TexturePage = texturePage;
            Vertices = vertices;
            VertexCount = vertexCount;
            Effect = effect;
        }
    }
}

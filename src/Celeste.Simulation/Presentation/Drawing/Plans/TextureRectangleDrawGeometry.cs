using Celeste.Graphics.Display;
using Celeste.Simulation.Presentation.Drawing.VertexEffects;
using Celeste.Simulation.Presentation.Geometry;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Drawing.Plans
{
    // One engine-owned scratch. Draw sinks snapshot it synchronously before reusing it.
    public sealed class TextureRectangleDrawGeometry
    {
        private readonly ReflectionTentacleVertex[] vertices = new ReflectionTentacleVertex[6];
        private readonly TexturedGeometry geometry;

        public TextureRectangleDrawGeometry()
        {
            geometry = new(0, "__unbound_texture_rectangle", vertices, 6);
        }

        public TexturedGeometry Build(in TextureRectangleDraw draw)
        {
            var box = draw.Source;
            float left = box.X / (float)draw.Texture.Width, right = (box.X + box.Width) / (float)draw.Texture.Width;
            float top = box.Y / (float)draw.Texture.Height, bottom = (box.Y + box.Height) / (float)draw.Texture.Height;
            float x = draw.Position.X, y = draw.Position.Y;
            var a = new ReflectionTentacleVertex
                { Position = new(x, y, 0), UV = new(left, top), Color = draw.Color };
            var b = new ReflectionTentacleVertex
                { Position = new(x + box.Width, y, 0), UV = new(right, top), Color = draw.Color };
            var c = new ReflectionTentacleVertex
                { Position = new(x, y + box.Height, 0), UV = new(left, bottom), Color = draw.Color };
            var e = new ReflectionTentacleVertex
            {
                Position = new(x + box.Width, y + box.Height, 0), UV = new(right, bottom),
                Color = draw.Color,
            };
            vertices[0] = a;
            vertices[1] = b;
            vertices[2] = c;
            vertices[3] = b;
            vertices[4] = e;
            vertices[5] = c;
            geometry.Update(draw.Depth, draw.Texture.Atlas.Page, vertices, 6,
                RoomVertexEffect.FxTexture);
            return geometry;
        }
    }
}

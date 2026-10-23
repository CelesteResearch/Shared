using System;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Drawing.VertexEffects
{
    // GFX.DrawVertices(vertices, count, GFX.FxTexture) consumes a triangle list
    // with normalized atlas UVs and per-vertex colors. A draw command retains
    // the source array and its live prefix; the simulation updates that buffer
    // before render, so hosts must consume it before the next simulation tick.
    public enum RoomVertexEffect
    {
        FxTexture,
        SpriteBatch
    }
}

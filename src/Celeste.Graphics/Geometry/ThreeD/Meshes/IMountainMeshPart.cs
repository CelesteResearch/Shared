namespace Celeste.Graphics.Geometry.ThreeD.Meshes
{
    public interface IMountainMeshPart
    {
        string Name { get; set; }
        int VertexStart { get; set; }
        int VertexCount { get; set; }
    }
}

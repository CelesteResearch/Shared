namespace Celeste.Physics.Collision
{
    public interface ISourcePixelPlatformEntity<out TPlatform> where TPlatform : PixelPlatform
    {
        TPlatform Platform { get; }
    }
}

using System.Collections.Generic;

namespace Celeste.Physics.Collision
{
    public interface IPixelPlatformSource<TPlatform> where TPlatform : PixelPlatform
    {
        List<object> GetSolids();
        List<object> GetJumpThrus();
    }
}

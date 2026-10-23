using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public interface IOriginalBadelineOldsiteEnvironment
    {
        BadelineOldsiteStaticState BadelineOldsiteStatics { get; }
        IOriginalBadelineOldsiteFactory BadelineOldsites { get; }
    }
}

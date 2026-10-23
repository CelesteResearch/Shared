#nullable enable annotations

using System;

namespace Celeste.Game.Entities.StarJump
{
    public interface IOriginalTheoPlateauAwakeInterceptionEnvironment
    {
        Func<bool>? BeforeTheoPlateauCampfire { get; }
    }
}

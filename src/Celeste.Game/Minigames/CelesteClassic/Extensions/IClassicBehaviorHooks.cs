using Celeste.Game.Minigames.CelesteClassic.Gameplay;
using Celeste.Game.Minigames.CelesteClassic.Emulation;

namespace Celeste.Game.Minigames.CelesteClassic.Extensions
{
    public interface IClassicBehaviorHooks
    {
        void EmulatorConstructing();
        void ClassicInitialized(Pico8Classic game, ClassicConsoleRuntime emulator);
        void ClassicUpdated(Pico8Classic game);
        void BeforeBalloonInit(Pico8Classic game);
        void AfterBalloonInit();
        bool BeforeChestUpdate(Pico8Classic game, float timer);
        void AfterChestUpdate(bool running);
    }
}

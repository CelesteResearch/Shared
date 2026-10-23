namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public interface IOriginalBadelineOldsiteEnvironment
    {
        BadelineOldsiteStaticState BadelineOldsiteStatics { get; }
        IOriginalBadelineOldsiteFactory BadelineOldsites { get; }
    }
}

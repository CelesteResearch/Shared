namespace Celeste.Core.Framework.Time
{
    public interface ISourceTimeSpanEnvironment
    {
        ISourceTimeSpanPolicy TimeSpans { get; }
    }
}

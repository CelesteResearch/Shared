namespace Celeste.Core.Framework.Time
{
    public sealed class NetCoreifierTimeSpanPolicy : SourceTimeSpanPolicy
    {
        protected override string CannotBeNaNMessage => "TimeSpan does not accept floating point Not-a-Number values.";
        protected override string OverflowMessage => "TimeSpan overflowed because the duration is too long.";
    }
}

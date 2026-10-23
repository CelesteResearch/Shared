namespace Celeste.Core.Framework.Time
{
    public sealed class FrameworkTimeSpanPolicy(ISourceFrameworkTimeResources resources) : SourceTimeSpanPolicy
    {
        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly ISourceFrameworkTimeResources _resources = resources;
        protected override string CannotBeNaNMessage => _resources.GetResourceString("Arg_CannotBeNaN");
        protected override string OverflowMessage => _resources.GetResourceString("Overflow_TimeSpanTooLong");
    }
}

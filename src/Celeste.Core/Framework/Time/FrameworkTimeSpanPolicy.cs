namespace Celeste.Core.Framework.Time
{
    public sealed class FrameworkTimeSpanPolicy : SourceTimeSpanPolicy
    {
        private readonly ISourceFrameworkTimeResources resources;

        public FrameworkTimeSpanPolicy(ISourceFrameworkTimeResources resources)
        {
            this.resources = resources;
        }

        protected override string CannotBeNaNMessage => resources.GetResourceString("Arg_CannotBeNaN");
        protected override string OverflowMessage => resources.GetResourceString("Overflow_TimeSpanTooLong");
    }
}

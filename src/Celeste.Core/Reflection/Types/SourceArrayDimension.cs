namespace Celeste.Core.Reflection.Types
{
    public sealed class SourceArrayDimension
    {
        public int? LowerBound { get; }
        public int? UpperBound { get; }

        public SourceArrayDimension(int? lowerBound, int? upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
    }
}

namespace Celeste.Core.Reflection.Types
{
    public sealed class SourceArrayDimension(int? lowerBound, int? upperBound)
    {
        public int? LowerBound { get; }
            = lowerBound;

        public int? UpperBound { get; }
            = upperBound;
    }
}

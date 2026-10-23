namespace Celeste.Core.Rendering
{
    public static class SourceMultisampleMath
    {
        public static int ClosestMSAAPower(int value)
        {
            if (value == 1) return 0;
            var number = value - 1;
            number |= number >> 1;
            number |= number >> 2;
            number |= number >> 4;
            number |= number >> 8;
            number |= number >> 16;
            number++;
            if (number == value) return number;
            return number >> 1;
        }
    }
}

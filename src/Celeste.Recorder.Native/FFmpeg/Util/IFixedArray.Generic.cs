namespace FFmpeg.Util
{
    internal interface IFixedArray<T> : IFixedArray
    {
        T this[uint index] { get; set; }

        T[] ToArray();

        void UpdateFrom(T[] array);
    }
}

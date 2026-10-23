namespace Celeste.Core.Input
{
    public interface ISourceVirtualButton
    {
        bool Check { get; }
        bool Pressed { get; }
        bool Released { get; }
        bool Repeating { get; }
        float BufferTime { get; set; }
        void ConsumeBuffer();
        void ConsumePress();
        void SetRepeat(float repeatTime);
        void SetRepeat(float firstRepeatTime, float multiRepeatTime);
    }
}

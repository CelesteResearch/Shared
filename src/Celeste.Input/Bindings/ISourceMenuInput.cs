namespace Celeste.Input.Bindings
{
    public interface ISourceMenuInput
    {
        SourceVirtualButton MenuDown { get; }
        SourceVirtualButton MenuUp { get; }
        SourceVirtualButton MenuLeft { get; }
        SourceVirtualButton MenuRight { get; }
        SourceVirtualButton MenuConfirm { get; }
        SourceVirtualButton MenuCancel { get; }
        SourceVirtualButton MenuJournal { get; }
        SourceVirtualButton Pause { get; }
        SourceVirtualButton ESC { get; }
    }
}

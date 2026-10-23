namespace Celeste.Input.Devices.Text
{
    public interface ISourceClipboardIO
    {
        string GetClipboardText();
        void SetClipboardText(string value);
    }
}

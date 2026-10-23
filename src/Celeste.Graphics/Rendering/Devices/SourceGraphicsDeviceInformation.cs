namespace Celeste.Graphics.Rendering.Devices
{
    public class SourceGraphicsDeviceInformation
    {
        public SourceGraphicsAdapter Adapter { get; set; }
        public SourceGraphicsProfile GraphicsProfile { get; set; }
        public SourcePresentationParameters PresentationParameters { get; set; }

        public SourceGraphicsDeviceInformation Clone()
        {
            return new()
            {
                Adapter = Adapter,
                GraphicsProfile = GraphicsProfile,
                PresentationParameters = PresentationParameters.Clone(),
            };
        }
    }
}

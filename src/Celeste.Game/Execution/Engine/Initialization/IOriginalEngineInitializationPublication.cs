using Celeste.Core.Pooling;

namespace Celeste.Game.Execution.Engine.Initialization
{
    public interface IOriginalEngineInitializationPublication
    {
        void PublishSourcePooler(SourceEntityPoolRegistry actualPooler);
        void ConfigureSourcePoolConstructors();
        void ConstructSourceCommands();
        void CompleteSourceEngineInitialization();
    }
}

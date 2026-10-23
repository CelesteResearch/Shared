using Celeste.Input.Bindings;

namespace Celeste.Everest.Entities.Birds.Tutorials
{
    public interface IEverestCustomBirdTutorialEnvironment
    {
        EverestCustomBirdTutorialEvents CustomBirdTutorialEvents { get; }
        SourceVirtualButton ReadCustomBirdInputField(string name);
    }
}

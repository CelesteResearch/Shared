using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Formats.Graphics.Models;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceObjModelEnvironment
    {
        ISourceObjModelPolicy ISourceObjModelEnvironment.ObjModelPolicy =>
            SourceProfile == GameProfile.Original
                ? ObjectModelPolicy.Instance
                : EverestObjModelPolicy.Instance;
    }
}

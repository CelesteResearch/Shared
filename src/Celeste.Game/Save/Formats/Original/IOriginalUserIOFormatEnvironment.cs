using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;

namespace Celeste.Game.Save.Formats.Original
{
// The same process owns these five roles. A settings load does not read save roles.
    public interface IOriginalUserIOFormatEnvironment
    {
        IOriginalAreaKeyPolicy AreaKeys { get; }
        OriginalSessionFactory Sessions { get; }
        IOriginalSaveAllocationPolicy SaveAllocation { get; }
        ISettingsFactory SettingsAllocation { get; }
        IOriginalSaveXmlFormatPolicy SaveXmlFormat { get; }
    }
}

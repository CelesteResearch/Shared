using Celeste.Game.Controls.Source;

namespace Celeste.Game.Save.Data
{
    public partial class OriginalSaveDataState
    {
        public static void NoFileAssistChecks(OriginalGameInputProcess actualInput)
        {
            actualInput.MoveX.Inverted = (actualInput.Aim.InvertedX = (actualInput.Feather.InvertedX = false));
        }
    }
}

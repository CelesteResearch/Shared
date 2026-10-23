using Celeste.Everest.Content.Maps.Registry;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Presentation.Completion.Titles
{
    public static class EverestAreaCompleteTitle
    {
        public static string GetCustomTitle(ChapterCompletionSession session,
            IOriginalAreaDataResolver areas, OriginalGameTextProcess textProcess)
        {
            var title = ((EverestArea)areas.Get(session.AreaID))?.Metadata?.CompleteScreen?.Title;
            if (title == null)
                return null;
            string text = null;
            switch (session.Mode)
            {
                case 0:
                    text = !session.FullClear ? title.ASide : title.FullClear;
                    break;
                case 1:
                    text = title.BSide;
                    break;
                case 2:
                    text = title.CSide;
                    break;
            }

            if (text == null)
                return null;
            return textProcess.CleanDialog(text);
        }
    }
}

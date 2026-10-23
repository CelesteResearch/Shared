namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        private bool CanExecuteChoice(UserChoice choice)
        {
            var available = !failedChoices.Contains(choice);
            if (available)
                available = choice switch
                {
                    UserChoice.FlushSaveData => process.Saves.CurrentSave != null && !hasFlushedSaveData,
                    UserChoice.RetryLevel => Session != null,
                    UserChoice.SaveAndQuit => process.Saves.CurrentSave != null && Session != null,
                    UserChoice.ReturnToMainMenu => true,
                    _ => false,
                };

            return available;
        }
    }
}

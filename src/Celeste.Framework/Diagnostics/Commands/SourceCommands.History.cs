using System;
using Celeste.Core.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public string ReadCommandHistory(int index)
        {
            return commandHistory[index];
        }

        public void InsertSourceCommandHistory(int index, string text)
        {
            commandHistory.Insert(index, text);
        }

        public void RemoveSourceCommandHistoryAt(int index)
        {
            commandHistory.RemoveAt(index);
        }

        protected virtual void EnterCommand()
        {
            var array = currentText.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
            if (commandHistory.Count == 0 || commandHistory[0] != currentText) commandHistory.Insert(0, currentText);

            drawCommands.Insert(0, new(currentText, PackedColor.Aqua));
            currentText = "";
            seekIndex = -1;
            var array2 = new string[array.Length - 1];
            for (var i = 1; i < array.Length; i++) array2[i - 1] = array[i];

            ExecuteCommand(array[0].ToLower(), array2);
        }

        private void FindFirstTab()
        {
            for (var i = 0; i < sorted.Count; i++)
                if (tabSearch == "" || sorted[i].IndexOf(tabSearch) == 0)
                {
                    tabIndex = i;
                    break;
                }
        }

        private void FindLastTab()
        {
            for (var i = 0; i < sorted.Count; i++)
                if (tabSearch == "" || sorted[i].IndexOf(tabSearch) == 0)
                    tabIndex = i;
        }
    }
}

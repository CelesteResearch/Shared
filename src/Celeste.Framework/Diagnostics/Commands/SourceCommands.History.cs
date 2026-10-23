using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public string ReadCommandHistory(int index) => commandHistory[index];
        public void InsertSourceCommandHistory(int index, string text) => commandHistory.Insert(index, text);
        public void RemoveSourceCommandHistoryAt(int index) => commandHistory.RemoveAt(index);

        protected virtual void EnterCommand()
        {
            string[] array = currentText.Split(new char[2] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandHistory.Count == 0 || commandHistory[0] != currentText)
            {
                commandHistory.Insert(0, currentText);
            }

            drawCommands.Insert(0, new SourceCommandLine(currentText, PackedColor.Aqua));
            currentText = "";
            seekIndex = -1;
            string[] array2 = new string[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
            {
                array2[i - 1] = array[i];
            }

            ExecuteCommand(array[0].ToLower(), array2);
        }

        private void FindFirstTab()
        {
            for (int i = 0; i < sorted.Count; i++)
            {
                if (tabSearch == "" || sorted[i].IndexOf(tabSearch) == 0)
                {
                    tabIndex = i;
                    break;
                }
            }
        }

        private void FindLastTab()
        {
            for (int i = 0; i < sorted.Count; i++)
            {
                if (tabSearch == "" || sorted[i].IndexOf(tabSearch) == 0)
                {
                    tabIndex = i;
                }
            }
        }
    }
}

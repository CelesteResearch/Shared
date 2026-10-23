using System;
using System.Collections.Generic;
using Celeste.Core.Components;
using Celeste.Core.Diagnostics;

namespace Celeste.Scene.Entities.Input
{
    public class SourceCheatListenerState : SceneEntityState
    {
        public string CurrentInput;

        public bool Logging;

        private readonly List<Tuple<char, Func<bool>>> inputs;

        private readonly List<Tuple<string, Action>> cheats;

        private int maxInput;

        public SourceCheatListenerState(
            ISourceEntitySourceDataRegistration registration)
            : base(registration)
        {
            Visible = false;
            CurrentInput = "";
            inputs = [];
            cheats = [];
        }

        public override void Update()
        {
            var flag = false;
            foreach (var input in inputs)
                if (input.Item2())
                {
                    CurrentInput += input.Item1;
                    flag = true;
                }

            if (!flag) return;

            if (CurrentInput.Length > maxInput) CurrentInput = CurrentInput.Substring(CurrentInput.Length - maxInput);

            if (Logging) SourceDebugLog.Log(CurrentInput);

            foreach (var cheat in cheats)
                if (CurrentInput.Contains(cheat.Item1))
                {
                    CurrentInput = "";
                    if (cheat.Item2 != null) cheat.Item2();

                    cheats.Remove(cheat);
                    if (Logging) SourceDebugLog.Log("Cheat Activated: " + cheat.Item1);

                    break;
                }
        }

        public void AddCheat(string code, Action onEntered = null)
        {
            cheats.Add(new(code, onEntered));
            maxInput = Math.Max(code.Length, maxInput);
        }

        public void AddInput(char id, Func<bool> checker)
        {
            inputs.Add(new(id, checker));
        }
    }
}

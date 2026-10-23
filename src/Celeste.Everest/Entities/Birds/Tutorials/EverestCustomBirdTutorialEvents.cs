namespace Celeste.Everest.Entities.Birds.Tutorials
{
    public sealed class EverestCustomBirdTutorialEvents
    {
        public delegate object ParseCommandHandler(string command);

        public event ParseCommandHandler OnParseCommand;

        public object ParseCommand(string command)
        {
            var handlers = OnParseCommand;
            if (handlers == null) return null;
            foreach (ParseCommandHandler handler in handlers.GetInvocationList())
            {
                object result = handler(command);
                if (result != null) return result;
            }

            return null;
        }
    }
}

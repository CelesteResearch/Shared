namespace Celeste.Everest.Scripting.Lua
{
    public partial class EverestLuaLoaderProcess
    {
        public void DisposeContext()
        {
            var context = Context;
            Context = null;
            context?.Dispose();
        }
    }
}

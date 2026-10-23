using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Game.Menus.Journal
{
    public abstract partial class OuiJournalPage
    {
        public const int PageWidth = 1610;

        public const int PageHeight = 1000;

        public readonly Vector2 TextJustify = new(0.5f, 0.5f);

        public const float TextScale = 0.5f;

        public readonly PackedColor TextColor = PackedColor.Black * 0.6f;

        public int PageIndex;

        public string PageTexture;

        public OuiJournalSequence Journal;
        protected ISourceEngineContext engine => Journal.engine;
        protected OriginalGameTextProcess Text => Journal.Text;
        protected OriginalMountainResources MountainResources => Journal.MountainResources;
        protected ISourceRenderContext Context => Journal.Context;


        public OuiJournalPage(OuiJournalSequence journal)
        {
            Journal = journal;
        }

        public virtual void Redraw(VirtualRenderTarget buffer)
        {
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice
                .SetRenderTarget(buffer.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice
                .Clear(PackedColor.Transparent);
        }

        public virtual void Update()
        {
        }
    }
}

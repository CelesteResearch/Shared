using Celeste.Graphics.Text.RichText.Nodes;

namespace Celeste.Simulation.Dialogs.Nodes
{
    public class DialogPortrait : RichTextNode
    {
        public int Side;

        public string Sprite;

        public string Animation;

        public bool UpsideDown;

        public bool Flipped;

        public bool Pop;

        public bool Glitchy;

        public string SfxEvent;

        public int SfxExpression = 1;

        public string SpriteId => "portrait_" + Sprite;

        public string BeginAnimation => "begin_" + Animation;

        public string IdleAnimation => "idle_" + Animation;

        public string TalkAnimation => "talk_" + Animation;
    }
}

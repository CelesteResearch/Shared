namespace Celeste.Scene.Entities
{
    public partial class SceneEntityState
    {
        public string PresentationRoom { get; set; }
        public SceneEntityState PresentationOwner { get; set; }
    }
}

namespace Celeste.Everest.UI.MapSearch
{
    public sealed class MapSearchItem
    {
        public MapSearchItemKind Kind;
        public int AreaID = -1;
        public string LevelSet, Title, Icon;
        public bool Selectable => Kind == MapSearchItemKind.Area;
    }
}

namespace Celeste.Everest.UI.MapSearch
{
    // AreaData supplies these values in its current table order. DisplayName is
    // DialogCleanOrNull(Name) ?? SpacedPascalCase(Name), not a cleaned SID.
    public sealed class MapSearchArea
    {
        public int ID;
        public string Name, DisplayName, LevelSet, DisplayLevelSet, Parent, Icon;
        public bool HasNormalMode;
    }
}

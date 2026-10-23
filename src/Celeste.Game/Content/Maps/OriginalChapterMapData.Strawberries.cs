namespace Celeste.Game.Content.Maps
{
    public partial class OriginalChapterMapData
    {
        public int[] GetStrawberries(out int total)
        {
            total = 0;
            int[] array = new int[10];
            foreach (var level in Levels)
            {
                foreach (var entity in level.Entities)
                {
                    if (entity.Name == "strawberry")
                    {
                        total++;
                        array[entity.Int("checkpointID")]++;
                    }
                }
            }

            return array;
        }
    }
}

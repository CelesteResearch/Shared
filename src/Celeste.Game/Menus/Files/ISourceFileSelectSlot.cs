using System.Numerics;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Menus.Files
{
    public interface ISourceFileSelectSlot
    {
        int FileSlot { get; }
        string Name { get; set; }
        bool AssistModeEnabled { get; set; }
        bool VariantModeEnabled { get; set; }
        bool Exists { get; set; }
        bool Corrupted { get; set; }
        bool StartingGame { get; set; }
        bool Renaming { get; set; }
        bool Assisting { get; set; }
        OriginalSaveDataState SaveData { get; }
        Vector2 Position { get; set; }
        float X { get; set; }
        float Y { get; set; }
        Vector2 IdlePosition { get; }
        Vector2 SelectedPosition { get; }
        Vector2 HiddenPosition(int x, int y);
        void CreateButtons();
        void Show();
        void Select(bool resetButtonIndex);
        void Unselect();
        void MoveTo(float x, float y);
        void Hide(int x, int y);
    }
}

using System;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Bounds = Celeste.Core.Geometry.Bounds;

namespace Celeste.Physics.Collision.Shapes
{
    public class GridColliderGeometry : ColliderGeometry
    {
        public VirtualMap<bool> Data;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public float CellWidth { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public float CellHeight { get; private set; }

        public bool this[int x, int y]
        {
            get
            {
                if (x >= 0 && y >= 0 && x < CellsX && y < CellsY) return Data[x, y];

                return false;
            }
            set => Data[x, y] = value;
        }

        public int CellsX => Data.Columns;

        public int CellsY => Data.Rows;

        public override float Width
        {
            get => CellWidth * CellsX;
            set => throw new NotImplementedException();
        }

        public override float Height
        {
            get => CellHeight * CellsY;
            set => throw new NotImplementedException();
        }

        public bool IsEmpty
        {
            get
            {
                for (var i = 0; i < CellsX; i++)
                for (var j = 0; j < CellsY; j++)
                    if (Data[i, j])
                        return false;

                return true;
            }
        }

        public override float Left
        {
            get => Position.X;
            set => Position.X = value;
        }

        public override float Top
        {
            get => Position.Y;
            set => Position.Y = value;
        }

        public override float Right
        {
            get => Position.X + Width;
            set => Position.X = value - Width;
        }

        public override float Bottom
        {
            get => Position.Y + Height;
            set => Position.Y = value - Height;
        }

        public GridColliderGeometry(int cellsX, int cellsY, float cellWidth, float cellHeight)
        {
            Data = new(cellsX, cellsY);
            CellWidth = cellWidth;
            CellHeight = cellHeight;
        }

        public GridColliderGeometry(float cellWidth, float cellHeight, string bitstring)
        {
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            var num = 0;
            var num2 = 0;
            var num3 = 1;
            for (var i = 0; i < bitstring.Length; i++)
                if (bitstring[i] == '\n')
                {
                    num3++;
                    num = Math.Max(num2, num);
                    num2 = 0;
                }
                else
                {
                    num2++;
                }

            Data = new(num, num3);
            LoadBitstring(bitstring);
        }

        public GridColliderGeometry(float cellWidth, float cellHeight, bool[,] data)
        {
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            Data = new(data);
        }

        public GridColliderGeometry(float cellWidth, float cellHeight, VirtualMap<bool> data)
        {
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            Data = data;
        }

        public void Extend(int left, int right, int up, int down)
        {
            Position -= new Vector2(left * CellWidth, up * CellHeight);
            var num = Data.Columns + left + right;
            var num2 = Data.Rows + up + down;
            if (num <= 0 || num2 <= 0)
            {
                Data = new(0, 0);
                return;
            }

            var virtualMap = new VirtualMap<bool>(num, num2);
            for (var i = 0; i < Data.Columns; i++)
            for (var j = 0; j < Data.Rows; j++)
            {
                var num3 = i + left;
                var num4 = j + up;
                if (num3 >= 0 && num3 < num && num4 >= 0 && num4 < num2) virtualMap[num3, num4] = Data[i, j];
            }

            for (var k = 0; k < left; k++)
            for (var l = 0; l < num2; l++)
                virtualMap[k, l] = Data[0, SourceCollisionMath.Clamp(l - up, 0, Data.Rows - 1)];

            for (var m = num - right; m < num; m++)
            for (var n = 0; n < num2; n++)
                virtualMap[m, n] = Data[Data.Columns - 1, SourceCollisionMath.Clamp(n - up, 0, Data.Rows - 1)];

            for (var num5 = 0; num5 < up; num5++)
            for (var num6 = 0; num6 < num; num6++)
                virtualMap[num6, num5] = Data[SourceCollisionMath.Clamp(num6 - left, 0, Data.Columns - 1), 0];

            for (var num7 = num2 - down; num7 < num2; num7++)
            for (var num8 = 0; num8 < num; num8++)
                virtualMap[num8, num7] =
                    Data[SourceCollisionMath.Clamp(num8 - left, 0, Data.Columns - 1), Data.Rows - 1];

            Data = virtualMap;
        }

        public void LoadBitstring(string bitstring)
        {
            var i = 0;
            var num = 0;
            for (var j = 0; j < bitstring.Length; j++)
                if (bitstring[j] == '\n')
                {
                    for (; i < CellsX; i++) Data[i, num] = false;

                    i = 0;
                    num++;
                    if (num >= CellsY) break;
                }
                else if (i < CellsX)
                {
                    if (bitstring[j] == '0')
                    {
                        Data[i, num] = false;
                        i++;
                    }
                    else
                    {
                        Data[i, num] = true;
                        i++;
                    }
                }
        }

        public string GetBitstring()
        {
            var text = "";
            for (var i = 0; i < CellsY; i++)
            {
                if (i != 0) text += "\n";

                for (var j = 0; j < CellsX; j++) text = !Data[j, i] ? text + "0" : text + "1";
            }

            return text;
        }

        public void Clear(bool to = false)
        {
            for (var i = 0; i < CellsX; i++)
            for (var j = 0; j < CellsY; j++)
                Data[i, j] = to;
        }

        public void SetRect(int x, int y, int width, int height, bool to = true)
        {
            if (x < 0)
            {
                width += x;
                x = 0;
            }

            if (y < 0)
            {
                height += y;
                y = 0;
            }

            if (x + width > CellsX) width = CellsX - x;

            if (y + height > CellsY) height = CellsY - y;

            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                Data[x + i, y + j] = to;
        }

        public bool CheckRect(int x, int y, int width, int height)
        {
            if (x < 0)
            {
                width += x;
                x = 0;
            }

            if (y < 0)
            {
                height += y;
                y = 0;
            }

            if (x + width > CellsX) width = CellsX - x;

            if (y + height > CellsY) height = CellsY - y;

            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                if (Data[x + i, y + j])
                    return true;

            return false;
        }

        public bool CheckColumn(int x)
        {
            for (var i = 0; i < CellsY; i++)
                if (!Data[x, i])
                    return false;

            return true;
        }

        public bool CheckRow(int y)
        {
            for (var i = 0; i < CellsX; i++)
                if (!Data[i, y])
                    return false;

            return true;
        }

        public override ColliderGeometry Clone()
        {
            return new GridColliderGeometry(CellWidth, CellHeight, Data.Clone());
        }

        public override void Render(object camera, PackedColor color,
            ISourceRenderContext context)
        {
            if (camera == null)
            {
                for (var i = 0; i < CellsX; i++)
                for (var j = 0; j < CellsY; j++)
                    if (Data[i, j])
                        SourcePrimitiveDrawing.HollowRect(context, Entity,
                            AbsoluteLeft + i * CellWidth, AbsoluteTop + j * CellHeight,
                            CellWidth, CellHeight, color);

                return;
            }

            var view = (ISourceCameraBounds)camera;
            var num = (int)Math.Max(0f, (view.Left - AbsoluteLeft) / CellWidth);
            var num2 = (int)Math.Min(CellsX - 1, Math.Ceiling((view.Right - AbsoluteLeft) / CellWidth));
            var num3 = (int)Math.Max(0f, (view.Top - AbsoluteTop) / CellHeight);
            var num4 = (int)Math.Min(CellsY - 1, Math.Ceiling((view.Bottom - AbsoluteTop) / CellHeight));
            for (var k = num; k <= num2; k++)
            for (var l = num3; l <= num4; l++)
                if (Data[k, l])
                    SourcePrimitiveDrawing.HollowRect(context, Entity,
                        AbsoluteLeft + k * CellWidth, AbsoluteTop + l * CellHeight,
                        CellWidth,
                        CellHeight, color);
        }

        public override bool Overlaps(Bounds rectangle, Vector2 entityPosition)
        {
            // Legacy positional entry intentionally does not mutate Entity/Position.
            float left = Left + entityPosition.X, top = Top + entityPosition.Y;
            var area = new Bounds((int)left, (int)top, (int)Width, (int)Height);
            if (!rectangle.Intersects(area)) return false;
            var x = (int)((rectangle.X - left) / CellWidth);
            var y = (int)((rectangle.Y - top) / CellHeight);
            var w = (int)((rectangle.Right - left - 1f) / CellWidth) - x + 1;
            var h = (int)((rectangle.Bottom - top - 1f) / CellHeight) - y + 1;
            return CheckRect(x, y, w, h);
        }

        public override bool Collide(Vector2 point)
        {
            if (point.X >= AbsoluteLeft && point.Y >= AbsoluteTop && point.X < AbsoluteRight &&
                point.Y < AbsoluteBottom)
                return Data[(int)((point.X - AbsoluteLeft) / CellWidth),
                    (int)((point.Y - AbsoluteTop) / CellHeight)];

            return false;
        }

        public override bool Collide(IntRect rect)
        {
            if (rect.Intersects(Bounds))
            {
                var num = (int)((rect.Left - AbsoluteLeft) / CellWidth);
                var num2 = (int)((rect.Top - AbsoluteTop) / CellHeight);
                var width = (int)((rect.Right - AbsoluteLeft - 1f) / CellWidth) - num + 1;
                var height = (int)((rect.Bottom - AbsoluteTop - 1f) / CellHeight) - num2 + 1;
                return CheckRect(num, num2, width, height);
            }

            return false;
        }

        public override bool Collide(Vector2 from, Vector2 to)
        {
            from -= AbsolutePosition;
            to -= AbsolutePosition;
            from /= new Vector2(CellWidth, CellHeight);
            to /= new Vector2(CellWidth, CellHeight);
            var flag = Math.Abs(to.Y - from.Y) > Math.Abs(to.X - from.X);
            if (flag)
            {
                var x = from.X;
                from.X = from.Y;
                from.Y = x;
                x = to.X;
                to.X = to.Y;
                to.Y = x;
            }

            if (from.X > to.X)
            {
                var vector = from;
                from = to;
                to = vector;
            }

            var num = 0f;
            var num2 = Math.Abs(to.Y - from.Y) / (to.X - from.X);
            var num3 = from.Y < to.Y ? 1 : -1;
            var num4 = (int)from.Y;
            var num5 = (int)to.X;
            for (var i = (int)from.X; i <= num5; i++)
            {
                if (flag)
                {
                    if (this[num4, i]) return true;
                }
                else if (this[i, num4])
                {
                    return true;
                }

                num += num2;
                if (num >= 0.5f)
                {
                    num4 += num3;
                    num -= 1f;
                }
            }

            return false;
        }

        public override bool CollideHitbox(Bounds absoluteHitbox)
        {
            return Collide(new IntRect((int)absoluteHitbox.X, (int)absoluteHitbox.Y,
                (int)absoluteHitbox.Width, (int)absoluteHitbox.Height));
        }

        public override bool Collide(HitboxColliderGeometry hitbox)
        {
            return Collide(hitbox.Bounds);
        }

        public override bool Collide(GridColliderGeometry grid)
        {
            throw new NotImplementedException();
        }

        public override bool Collide(CircleColliderGeometry circle)
        {
            return false;
        }

        public override bool Collide(ColliderListGeometry list)
        {
            return list.Collide(this);
        }

        public static bool IsBitstringEmpty(string bitstring)
        {
            for (var i = 0; i < bitstring.Length; i++)
                if (bitstring[i] == '1')
                    return false;

            return true;
        }
    }
}

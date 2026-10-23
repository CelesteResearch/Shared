using System.Numerics;

namespace Celeste.Scene.Entities
{
    public partial class SceneEntityState
    {
        public float X
        {
            get => Position.X;
            set
            {
                var position = Position;
                position.X = value;
                Position = position;
            }
        }

        public float Y
        {
            get => Position.Y;
            set
            {
                var position = Position;
                position.Y = value;
                Position = position;
            }
        }

        public float Width
        {
            get
            {
                if (Collider == null)
                {
                    return 0f;
                }

                return Collider.Width;
            }
        }

        public float Height
        {
            get
            {
                if (Collider == null)
                {
                    return 0f;
                }

                return Collider.Height;
            }
        }

        public float Left
        {
            get
            {
                if (Collider == null)
                {
                    return X;
                }

                return Position.X + Collider.Left;
            }
            set
            {
                if (Collider == null)
                {
                    X = value;
                }
                else
                {
                    X = value - Collider.Left;
                }
            }
        }

        public float Right
        {
            get
            {
                if (Collider == null)
                {
                    return Position.X;
                }

                return Position.X + Collider.Right;
            }
            set
            {
                if (Collider == null)
                {
                    X = value;
                }
                else
                {
                    X = value - Collider.Right;
                }
            }
        }

        public float Top
        {
            get
            {
                if (Collider == null)
                {
                    return Position.Y;
                }

                return Position.Y + Collider.Top;
            }
            set
            {
                if (Collider == null)
                {
                    Y = value;
                }
                else
                {
                    Y = value - Collider.Top;
                }
            }
        }

        public float Bottom
        {
            get
            {
                if (Collider == null)
                {
                    return Position.Y;
                }

                return Position.Y + Collider.Bottom;
            }
            set
            {
                if (Collider == null)
                {
                    Y = value;
                }
                else
                {
                    Y = value - Collider.Bottom;
                }
            }
        }

        public float CenterX
        {
            get
            {
                if (Collider == null)
                {
                    return Position.X;
                }

                return Position.X + Collider.CenterX;
            }
            set
            {
                if (Collider == null)
                {
                    X = value;
                }
                else
                {
                    X = value - Collider.CenterX;
                }
            }
        }

        public float CenterY
        {
            get
            {
                if (Collider == null)
                {
                    return Position.Y;
                }

                return Position.Y + Collider.CenterY;
            }
            set
            {
                if (Collider == null)
                {
                    Y = value;
                }
                else
                {
                    Y = value - Collider.CenterY;
                }
            }
        }

        public Vector2 TopLeft
        {
            get { return new Vector2(Left, Top); }
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public Vector2 TopRight
        {
            get { return new Vector2(Right, Top); }
            set
            {
                Right = value.X;
                Top = value.Y;
            }
        }

        public Vector2 BottomLeft
        {
            get { return new Vector2(Left, Bottom); }
            set
            {
                Left = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 BottomRight
        {
            get { return new Vector2(Right, Bottom); }
            set
            {
                Right = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 Center
        {
            get { return new Vector2(CenterX, CenterY); }
            set
            {
                CenterX = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 CenterLeft
        {
            get { return new Vector2(Left, CenterY); }
            set
            {
                Left = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 CenterRight
        {
            get { return new Vector2(Right, CenterY); }
            set
            {
                Right = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 TopCenter
        {
            get { return new Vector2(CenterX, Top); }
            set
            {
                CenterX = value.X;
                Top = value.Y;
            }
        }

        public Vector2 BottomCenter
        {
            get { return new Vector2(CenterX, Bottom); }
            set
            {
                CenterX = value.X;
                Bottom = value.Y;
            }
        }
    }
}

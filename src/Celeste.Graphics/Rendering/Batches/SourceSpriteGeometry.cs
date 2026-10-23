namespace Celeste.Graphics.Rendering.Batches
{
    public static class SourceSpriteGeometry
    {
        private static readonly float[] CornerOffsetX = [0f, 1f, 0f, 1f];
        private static readonly float[] CornerOffsetY = [0f, 0f, 1f, 1f];

        public static void Generate(ref SourceSpriteQuad sprite,
            float sourceX, float sourceY, float sourceW, float sourceH,
            float destinationX, float destinationY, float destinationW, float destinationH,
            uint color, float originX, float originY, float rotationSin, float rotationCos,
            float depth, byte effects)
        {
            var num = (0f - originX) * destinationW;
            var num2 = (0f - originY) * destinationH;
            sprite.Position0.X = (0f - rotationSin) * num2 + rotationCos * num + destinationX;
            sprite.Position0.Y = rotationCos * num2 + rotationSin * num + destinationY;
            num = (1f - originX) * destinationW;
            num2 = (0f - originY) * destinationH;
            sprite.Position1.X = (0f - rotationSin) * num2 + rotationCos * num + destinationX;
            sprite.Position1.Y = rotationCos * num2 + rotationSin * num + destinationY;
            num = (0f - originX) * destinationW;
            num2 = (1f - originY) * destinationH;
            sprite.Position2.X = (0f - rotationSin) * num2 + rotationCos * num + destinationX;
            sprite.Position2.Y = rotationCos * num2 + rotationSin * num + destinationY;
            num = (1f - originX) * destinationW;
            num2 = (1f - originY) * destinationH;
            sprite.Position3.X = (0f - rotationSin) * num2 + rotationCos * num + destinationX;
            sprite.Position3.Y = rotationCos * num2 + rotationSin * num + destinationY;
            sprite.TextureCoordinate0.X = CornerOffsetX[0 ^ effects] * sourceW + sourceX;
            sprite.TextureCoordinate0.Y = CornerOffsetY[0 ^ effects] * sourceH + sourceY;
            sprite.TextureCoordinate1.X = CornerOffsetX[1 ^ effects] * sourceW + sourceX;
            sprite.TextureCoordinate1.Y = CornerOffsetY[1 ^ effects] * sourceH + sourceY;
            sprite.TextureCoordinate2.X = CornerOffsetX[2 ^ effects] * sourceW + sourceX;
            sprite.TextureCoordinate2.Y = CornerOffsetY[2 ^ effects] * sourceH + sourceY;
            sprite.TextureCoordinate3.X = CornerOffsetX[3 ^ effects] * sourceW + sourceX;
            sprite.TextureCoordinate3.Y = CornerOffsetY[3 ^ effects] * sourceH + sourceY;
            sprite.Position0.Z = depth;
            sprite.Position1.Z = depth;
            sprite.Position2.Z = depth;
            sprite.Position3.Z = depth;
            sprite.Color0 = color;
            sprite.Color1 = color;
            sprite.Color2 = color;
            sprite.Color3 = color;
        }
    }
}

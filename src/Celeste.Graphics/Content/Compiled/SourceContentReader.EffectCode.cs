namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader
    {
        internal byte[] ReadEffectCode()
        {
            InitializeTypeReaders();
            int index = Read7BitEncodedInt();
            if (index <= 0 || index > typeReaders.Length || !(typeReaders[index - 1] is SourceEffectReader))
                throw new SourceContentLoadException("The compiled asset is not an Effect: " + AssetName);
            byte[] code = SourceEffectReader.ReadCode(this);
            ReadSharedResources();
            return code;
        }
    }
}

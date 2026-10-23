namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader
    {
        internal byte[] ReadEffectCode()
        {
            InitializeTypeReaders();
            var index = Read7BitEncodedInt();
            if (index <= 0 || index > TypeReaders.Length || TypeReaders[index - 1] is not SourceEffectReader)
                throw new SourceContentLoadException("The compiled asset is not an Effect: " + AssetName);
            var code = SourceEffectReader.ReadCode(this);
            ReadSharedResources();
            return code;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Celeste.Graphics.Content.Compiled
{
    public sealed partial class SourceContentReader
    {
        public T ReadObject<T>()
        {
            return ReadObject(default(T));
        }

        public T ReadObject<T>(SourceContentTypeReader typeReader)
        {
            var result = (T)typeReader.Read(this, default(T));
            RecordDisposable(result);
            return result;
        }

        public T ReadObject<T>(T existingInstance)
        {
            return InnerReadObject(existingInstance);
        }

        public T ReadObject<T>(SourceContentTypeReader typeReader, T existingInstance)
        {
            if (!typeReader.TargetType.IsValueType) return ReadObject(existingInstance);

            var result = (T)typeReader.Read(this, existingInstance);
            RecordDisposable(result);
            return result;
        }

        public void ReadSharedResource<T>(Action<T> fixup)
        {
            var num = Read7BitEncodedInt();
            if (num <= 0) return;

            sharedResourceFixups[num - 1].Add(delegate(object v)
            {
                if (!(v is T))
                    throw new SourceContentLoadException(
                        $"Error loading shared resource. Expected type {typeof(T).Name}, received type {v.GetType().Name}");

                fixup((T)v);
            });
        }

        internal object ReadAsset<T>()
        {
            InitializeTypeReaders();
            object result = ReadObject<T>();
            ReadSharedResources();
            return result;
        }

        internal void InitializeTypeReaders()
        {
            typeReaderManager = new(ContentManager.Process);
            typeReaders = typeReaderManager.LoadAssetReaders(this);
            sharedResourceCount = Read7BitEncodedInt();
            sharedResources = new object[sharedResourceCount];
            sharedResourceFixups = new List<Action<object>>[sharedResourceCount];
            for (var i = 0; i < sharedResourceCount; i++) sharedResourceFixups[i] = [];
        }

        internal void ReadSharedResources()
        {
            for (var i = 0; i < sharedResourceCount; i++) sharedResources[i] = InnerReadObject<object>(null);

            for (var j = 0; j < sharedResourceCount; j++)
            {
                var obj = sharedResources[j];
                foreach (var item in sharedResourceFixups[j]) item(obj);
            }
        }

        internal new int Read7BitEncodedInt()
        {
            return base.Read7BitEncodedInt();
        }

        private T InnerReadObject<T>(T existingInstance)
        {
            var num = Read7BitEncodedInt();
            if (num == 0) return existingInstance;

            if (num > TypeReaders.Length) throw new SourceContentLoadException("Incorrect type reader index found!");

            var result = (T)TypeReaders[num - 1].Read(this, default(T));
            RecordDisposable(result);
            return result;
        }

        private void RecordDisposable<T>(T result)
        {
            if (result is IDisposable disposable)
            {
                if (recordDisposableObject != null)
                    recordDisposableObject(disposable);
                else
                    ContentManager.RecordDisposable(disposable);
            }
        }
    }
}

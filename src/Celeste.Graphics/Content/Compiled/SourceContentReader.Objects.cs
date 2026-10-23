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
            T result = (T)typeReader.Read(this, default(T));
            RecordDisposable(result);
            return result;
        }

        public T ReadObject<T>(T existingInstance)
        {
            return InnerReadObject(existingInstance);
        }

        public T ReadObject<T>(SourceContentTypeReader typeReader, T existingInstance)
        {
            if (!typeReader.TargetType.IsValueType)
            {
                return ReadObject(existingInstance);
            }

            T result = (T)typeReader.Read(this, existingInstance);
            RecordDisposable(result);
            return result;
        }

        public void ReadSharedResource<T>(Action<T> fixup)
        {
            int num = Read7BitEncodedInt();
            if (num <= 0)
            {
                return;
            }

            sharedResourceFixups[num - 1].Add(delegate(object v)
            {
                if (!(v is T))
                {
                    throw new SourceContentLoadException(
                        $"Error loading shared resource. Expected type {typeof(T).Name}, received type {v.GetType().Name}");
                }

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
            typeReaderManager = new SourceContentTypeReaderManager(contentManager.Process);
            typeReaders = typeReaderManager.LoadAssetReaders(this);
            sharedResourceCount = Read7BitEncodedInt();
            sharedResources = new object[sharedResourceCount];
            sharedResourceFixups = new List<Action<object>>[sharedResourceCount];
            for (int i = 0; i < sharedResourceCount; i++)
            {
                sharedResourceFixups[i] = new List<Action<object>>();
            }
        }

        internal void ReadSharedResources()
        {
            for (int i = 0; i < sharedResourceCount; i++)
            {
                sharedResources[i] = InnerReadObject<object>(null);
            }

            for (int j = 0; j < sharedResourceCount; j++)
            {
                object obj = sharedResources[j];
                foreach (Action<object> item in sharedResourceFixups[j])
                {
                    item(obj);
                }
            }
        }

        internal new int Read7BitEncodedInt()
        {
            return base.Read7BitEncodedInt();
        }

        private T InnerReadObject<T>(T existingInstance)
        {
            int num = Read7BitEncodedInt();
            if (num == 0)
            {
                return existingInstance;
            }

            if (num > typeReaders.Length)
            {
                throw new SourceContentLoadException("Incorrect type reader index found!");
            }

            T result = (T)typeReaders[num - 1].Read(this, default(T));
            RecordDisposable(result);
            return result;
        }

        private void RecordDisposable<T>(T result)
        {
            if (result is IDisposable disposable)
            {
                if (recordDisposableObject != null)
                {
                    recordDisposableObject(disposable);
                }
                else
                {
                    contentManager.RecordDisposable(disposable);
                }
            }
        }
    }
}

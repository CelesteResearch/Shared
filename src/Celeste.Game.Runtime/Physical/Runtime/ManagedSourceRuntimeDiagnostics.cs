using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using Celeste.Core.Diagnostics.Runtime;

namespace Celeste.Game.Runtime.Physical.Runtime
{
    public sealed class ManagedSourceRuntimeDiagnostics : ISourceRuntimeDiagnosticsIO
    {
        private static readonly Func<SourceRuntimeGcMemorySnapshot>? ReadMemory = CreateMemoryReader();
        private static readonly Func<string>? ReadIdentifier = CreateIdentifierReader();
        private readonly ISourceRuntimeMemoryCapacity fallbackCapacity;

        public ManagedSourceRuntimeDiagnostics(ISourceRuntimeMemoryCapacity fallbackCapacity)
        {
            this.fallbackCapacity = fallbackCapacity ?? throw new ArgumentNullException(nameof(fallbackCapacity));
        }

        public SourceRuntimeMemoryAvailability Availability => ReadMemory != null
            ? SourceRuntimeMemoryAvailability.Available
            : SourceRuntimeMemoryAvailability.Unavailable;

        public SourceRuntimeIdentifierAvailability RuntimeIdentifierAvailability => ReadIdentifier != null
            ? SourceRuntimeIdentifierAvailability.Available
            : SourceRuntimeIdentifierAvailability.Unavailable;

        public string RuntimeIdentifier => ReadIdentifier != null
            ? ReadIdentifier()
            : throw new PlatformNotSupportedException(
                "This runtime does not expose RuntimeInformation.RuntimeIdentifier.");

        public SourceRuntimeGcMemorySnapshot? ReadMemoryInfo()
        {
            return ReadMemory != null ? ReadMemory() : (SourceRuntimeGcMemorySnapshot?)null;
        }

        public long ReadTotalAvailableMemoryBytes()
        {
            return ReadMemory != null
                ? ReadMemory().TotalAvailableMemoryBytes
                : fallbackCapacity.ReadTotalAvailableMemoryBytes();
        }

        private static Func<string>? CreateIdentifierReader()
        {
            var getter = typeof(RuntimeInformation)
                .GetProperty("RuntimeIdentifier", BindingFlags.Public | BindingFlags.Static)
                ?.GetGetMethod();
            return getter != null && getter.ReturnType == typeof(string)
                ? (Func<string>)getter.CreateDelegate(typeof(Func<string>))
                : null;
        }

        private static Func<SourceRuntimeGcMemorySnapshot>? CreateMemoryReader()
        {
            var method = typeof(GC).GetMethod("GetGCMemoryInfo", BindingFlags.Public | BindingFlags.Static,
                null, Type.EmptyTypes, null);
            if (method == null)
            {
                return null;
            }

            var heap = method.ReturnType.GetProperty("HeapSizeBytes");
            var committed = method.ReturnType.GetProperty("TotalCommittedBytes");
            var available = method.ReturnType.GetProperty("TotalAvailableMemoryBytes");
            if (heap?.PropertyType != typeof(long) || committed?.PropertyType != typeof(long) ||
                available?.PropertyType != typeof(long) || heap.GetGetMethod() == null ||
                committed.GetGetMethod() == null || available.GetGetMethod() == null)
            {
                return null;
            }

            var memory = Expression.Variable(method.ReturnType, "memory");
            var constructor =
                typeof(SourceRuntimeGcMemorySnapshot).GetConstructor(new[] { typeof(long), typeof(long), typeof(long) })
                !;
            var body = Expression.Block(new[] { memory }, Expression.Assign(memory, Expression.Call(method)),
                Expression.New(constructor, Expression.Property(memory, heap), Expression.Property(memory, committed),
                    Expression.Property(memory, available)));
            return Expression.Lambda<Func<SourceRuntimeGcMemorySnapshot>>(body).Compile();
        }
    }
}

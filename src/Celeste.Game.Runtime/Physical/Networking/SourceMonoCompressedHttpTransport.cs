using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Everest.Modules.Updating.Transport;
using MonoMod.RuntimeDetour;

namespace Celeste.Game.Runtime.Physical.Networking
{
    /// Mono physical HTTP capability. The HTTP/TLS/proxy/redirect implementation remains Mono's actual handler.
    public sealed class SourceMonoCompressedHttpTransport : IEverestCompressedHttpTransport, IDisposable
    {
        public static ConstructorInfo HookCreationFrame => typeof(OwnedHandler).GetConstructor(
                                                               BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                               Type.EmptyTypes, null)
                                                           ?? throw new MissingMethodException(
                                                               typeof(OwnedHandler).FullName, ".ctor");

        private readonly object gate = new();
        private readonly List<HttpMessageHandler> handlers = [];
        private bool disposed;

        public HttpMessageHandler CreateCompressedHandler()
        {
            lock (gate)
            {
                if (disposed) throw new ObjectDisposedException(nameof(SourceMonoCompressedHttpTransport));
                var handler = new OwnedHandler();
                handlers.Add(handler);
                return handler;
            }
        }

        public void Dispose()
        {
            lock (gate)
            {
                if (disposed) return;
                disposed = true;
                foreach (var handler in handlers) handler.Dispose();
                handlers.Clear();
            }
        }

        private sealed class OwnedHandler : DelegatingHandler
        {
            private readonly object gate = new();
            private readonly Dictionary<ServicePoint, ServicePoint> points = new();
            private readonly string group;
            private readonly Hook route;
            private readonly FieldInfo requestPoint;
            private readonly ConstructorInfo pointConstructor;
            private readonly ConstructorInfo keyConstructor;
            private readonly PropertyInfo usesProxy;
            private readonly PropertyInfo useConnect;
            private readonly FieldInfo pointDisposed;
            private bool disposed;

            internal OwnedHandler() : base(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.None,
            })
            {
                if (typeof(object).Assembly.GetType("Mono.Runtime") == null)
                    throw new PlatformNotSupportedException(
                        "This physical HTTP capability requires the actual Mono runtime.");
                var handler = (HttpClientHandler)InnerHandler;
                var inner = RequireField(typeof(HttpClientHandler), "_delegatingHandler").GetValue(handler);
                if (inner == null || inner.GetType().FullName != "System.Net.Http.MonoWebRequestHandler")
                    throw new PlatformNotSupportedException(
                        "The actual Mono WebRequest HTTP handler is not available.");
                group = (string)RequireField(inner.GetType(), "connectionGroupName").GetValue(inner);
                if (string.IsNullOrEmpty(group))
                    throw new InvalidOperationException("The real HTTP handler has no owned connection group.");
                var keyType = typeof(ServicePointManager).GetNestedType("SPKey", BindingFlags.NonPublic)
                              ?? throw new MissingMemberException(typeof(ServicePointManager).FullName, "SPKey");
                keyConstructor = keyType.GetConstructor(
                                     BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                                     null, [typeof(Uri), typeof(Uri), typeof(bool)], null)
                                 ?? throw new MissingMethodException(keyType.FullName, ".ctor");
                pointConstructor = typeof(ServicePoint).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                                       null, [keyType, typeof(Uri), typeof(int), typeof(int)], null)
                                   ?? throw new MissingMethodException(typeof(ServicePoint).FullName, ".ctor");
                usesProxy = RequireProperty(typeof(ServicePoint), "UsesProxy");
                useConnect = RequireProperty(typeof(ServicePoint), "UseConnect");
                pointDisposed = RequireField(typeof(ServicePoint), "disposed");
                requestPoint = RequireField(typeof(HttpWebRequest), "servicePoint");
                var getPoint = typeof(HttpWebRequest).GetMethod("GetServicePoint",
                                   BindingFlags.Instance | BindingFlags.NonPublic,
                                   null, Type.EmptyTypes, null) ??
                               throw new MissingMethodException(typeof(HttpWebRequest).FullName, "GetServicePoint");
                if (getPoint.ReturnType != typeof(ServicePoint) || requestPoint.FieldType != typeof(ServicePoint))
                    throw new InvalidOperationException("The actual Mono ServicePoint declaration differs.");
                route = new(getPoint,
                    (Func<Func<HttpWebRequest, ServicePoint>, HttpWebRequest, ServicePoint>)Route);
            }

            private ServicePoint Route(Func<HttpWebRequest, ServicePoint> original, HttpWebRequest request)
            {
                var actual = original(request);
                if (request.ConnectionGroupName != group) return actual;
                lock (gate)
                {
                    if (disposed) throw new ObjectDisposedException(nameof(OwnedHandler));
                    var previous = points.FirstOrDefault(entry => ReferenceEquals(entry.Value, actual));
                    if (previous.Key != null)
                    {
                        if (!(bool)pointDisposed.GetValue(actual)) return actual;
                        points.Remove(previous.Key);
                        requestPoint.SetValue(request, null);
                        actual = original(request);
                    }

                    if (points.TryGetValue(actual, out var expired) && (bool)pointDisposed.GetValue(expired))
                        points.Remove(actual);
                    if (!points.TryGetValue(actual, out var owned))
                    {
                        // Only the registry key is private. The connection address and proxy facts remain authentic.
                        // Mono removes by key alone: reusing the global origin key could remove another owner's pool.
                        var isolatedKey = keyConstructor.Invoke([
                            new Uri("http://" + Guid.NewGuid().ToString("N") + ".invalid/"), null, false,
                        ]);
                        owned = (ServicePoint)pointConstructor.Invoke([
                            isolatedKey, actual.Address, actual.ConnectionLimit, actual.MaxIdleTime,
                        ]);
                        usesProxy.SetValue(owned, usesProxy.GetValue(actual));
                        useConnect.SetValue(owned, useConnect.GetValue(actual));
                        owned.UseNagleAlgorithm = false;
                        owned.Expect100Continue = actual.Expect100Continue;
                        owned.ConnectionLeaseTimeout = actual.ConnectionLeaseTimeout;
                        owned.ReceiveBufferSize = actual.ReceiveBufferSize;
                        owned.BindIPEndPointDelegate = RejectNonIpv4;
                        points.Add(actual, owned);
                    }

                    requestPoint.SetValue(request, owned);
                    return owned;
                }
            }

            private static IPEndPoint RejectNonIpv4(ServicePoint point, IPEndPoint remote, int retryCount)
            {
                if (remote.AddressFamily != AddressFamily.InterNetwork)
                    throw new InvalidOperationException("no IPv4 address");
                // Mono catches callback rejection, closes that socket and tries the next DNS address.
                // No local Bind retry loop is entered, and IPv4 connects preserve Mono's cancellation path.
                return null;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                foreach (var encoding in new[] { "gzip", "deflate", "br" })
                    if (!request.Headers.AcceptEncoding.Any(value =>
                            value.Value.Equals(encoding, StringComparison.OrdinalIgnoreCase)))
                        request.Headers.AcceptEncoding.ParseAdd(encoding);
                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (response.Content != null && response.Content.Headers.ContentEncoding.LastOrDefault() is string last
                                             && (last.Equals("br", StringComparison.OrdinalIgnoreCase)
                                                 || last.Equals("gzip", StringComparison.OrdinalIgnoreCase)
                                                 || last.Equals("deflate", StringComparison.OrdinalIgnoreCase)))
                {
                    var content = response.Content;
                    var stream = await content.ReadAsStreamAsync().ConfigureAwait(false);
                    Stream decoder = last.Equals("br", StringComparison.OrdinalIgnoreCase)
                        ? new BrotliStream(stream, CompressionMode.Decompress)
                        : last.Equals("gzip", StringComparison.OrdinalIgnoreCase)
                            ? new GZipStream(stream, CompressionMode.Decompress)
                            : new SourceMonoHttpDeflateStream(stream);
                    // Match SocketsHttpHandler: decode only the outermost encoding and clear its encoded length.
                    var decoded = new OwnedDecodedContent(content, decoder);
                    foreach (var header in content.Headers)
                        if (!header.Key.Equals("Content-Length", StringComparison.OrdinalIgnoreCase)
                            && !header.Key.Equals("Content-Encoding", StringComparison.OrdinalIgnoreCase))
                            decoded.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    foreach (var encoding in
                             content.Headers.ContentEncoding.Take(content.Headers.ContentEncoding.Count - 1))
                        decoded.Headers.ContentEncoding.Add(encoding);
                    response.Content = decoded;
                }

                return response;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                    lock (gate)
                    {
                        if (!disposed)
                        {
                            disposed = true;
                            // Closing the real groups releases their sockets; FreeServicePoint alone would not.
                            foreach (var point in points.Values) point.CloseConnectionGroup(group);
                            points.Clear();
                        }
                    }

                if (disposing) route?.Dispose();
                base.Dispose(disposing);
            }

            private static FieldInfo RequireField(Type type, string name)
            {
                return type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)
                       ?? throw new MissingFieldException(type.FullName, name);
            }

            private static PropertyInfo RequireProperty(Type type, string name)
            {
                return type.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic)
                       ?? throw new MissingMemberException(type.FullName, name);
            }
        }

        private sealed class OwnedDecodedContent : StreamContent
        {
            private readonly HttpContent original;

            internal OwnedDecodedContent(HttpContent original, Stream stream) : base(stream)
            {
                this.original = original;
            }

            protected override void Dispose(bool disposing)
            {
                try
                {
                    base.Dispose(disposing);
                }
                finally
                {
                    if (disposing) original.Dispose();
                }
            }
        }
    }
}

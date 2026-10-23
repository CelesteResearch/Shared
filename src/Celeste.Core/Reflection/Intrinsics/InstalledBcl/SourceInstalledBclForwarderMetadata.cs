using System;
using Celeste.Core.Reflection.Forwarders;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceInstalledBclForwarderMetadata
    {
        public const string Profile = "InstalledEverest";

        public static void Publish(SourceTypeForwarderCatalog catalog)
        {
            if (catalog == null) throw new ArgumentNullException(nameof(catalog));
            if (catalog.SourceProfile != Profile)
                throw new InvalidOperationException(
                    "Installed runtime PE facts require the selected InstalledEverest source profile.");
            PublishRows0(catalog);
            PublishRows1(catalog);
            PublishRows2(catalog);
            PublishRows3(catalog);
            PublishRows4(catalog);
        }
    }
}

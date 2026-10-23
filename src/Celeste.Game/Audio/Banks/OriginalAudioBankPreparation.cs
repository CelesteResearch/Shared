using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.IO.Content;
using Celeste.Core.IO.Content.Manifests;

namespace Celeste.Game.Audio.Banks;

// Original startup loads these banks once and retains them through chapter changes.
// This object borrows the resident source; the host owns the source and its cached bytes.
public sealed class OriginalAudioBankPreparation : IDisposable
{
    private readonly ResidentContentSource source;
    private readonly string[] bankFiles;
    private readonly ContentFileInfo[] bankInfos;
    private readonly Func<ContentFileInfo, CancellationToken, Task> prepareFile;
    private readonly Func<string, bool> isReady;
    private readonly CancellationTokenSource lifetime;
    private readonly CancellationToken lifetimeToken;
    private int disposed;

    public IReadOnlyList<string> RequiredBankFiles { get; }
    public long RequiredBankBytes { get; }

    public OriginalAudioBankPreparation(ResidentContentSource source) : this(source, null, null)
    {
    }

    public OriginalAudioBankPreparation(ResidentContentSource source,
        Func<ContentFileInfo, CancellationToken, Task> prepareFile, Func<string, bool> isReady)
    {
        this.source = source ?? throw new ArgumentNullException(nameof(source));
        if ((prepareFile == null) != (isReady == null))
            throw new ArgumentException("File preparation and readiness must be supplied together.");
        this.prepareFile = prepareFile;
        this.isReady = isReady;
        var files = new List<string>();
        var infos = new List<ContentFileInfo>();
        var directory = Path.Combine(source.TitleLocation, "FMOD", "Desktop");
        foreach (var request in OriginalAudioBankProfile.Create(directory))
        {
            string logical = Path.GetRelativePath(source.TitleLocation, request.Path)
                .Replace(Path.DirectorySeparatorChar, '/').Replace(Path.AltDirectorySeparatorChar, '/');
            if (!source.Manifest.TryGetFile(logical, out var file))
                throw new FileNotFoundException("An original startup audio bank is absent from the manifest.", logical);
            files.Add(logical);
            infos.Add(file);
            RequiredBankBytes += file.Size;
        }

        bankFiles = files.ToArray();
        bankInfos = infos.ToArray();
        RequiredBankFiles = Array.AsReadOnly(bankFiles);
        lifetime = new CancellationTokenSource();
        lifetimeToken = lifetime.Token;
    }

    public ValueTask PrepareAdditionalResourcesAsync(string workName, CancellationToken cancellationToken)
    {
        lifetimeToken.ThrowIfCancellationRequested();
        cancellationToken.ThrowIfCancellationRequested();
        // SourceAudioProcess construction is lazy; Studio starts in GameLoader.LoadThread.
        if (workName == "BOOT") return default;
        if (workName == "GAME_LOADER") return new ValueTask(PrepareBanksAsync(cancellationToken));
        // Later original loading work uses the same prepared banks, including menu and DLC music.
        // Unknown labels do not imply a new audio scope or silently permit unprepared banks.
        foreach (string file in bankFiles)
            if (!(isReady == null ? source.IsReady(file) : isReady(file)))
                throw new InvalidOperationException(
                    $"Prepare original audio banks through GAME_LOADER before loading '{workName}'. Missing '{file}'.");
        return default;
    }

    private async Task PrepareBanksAsync(CancellationToken cancellationToken)
    {
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(lifetimeToken, cancellationToken);
        if (prepareFile == null)
            await source.PrepareFilesAsync(bankFiles, linked.Token);
        else
        {
            // Physical backends prepare one bank at a time without retaining resident copies.
            foreach (var file in bankInfos)
            {
                linked.Token.ThrowIfCancellationRequested();
                if (!isReady(file.Path)) await prepareFile(file, linked.Token);
                if (!isReady(file.Path))
                    throw new InvalidOperationException(
                        "The physical audio bank preparation did not publish readiness: " + file.Path);
            }

            linked.Token.ThrowIfCancellationRequested();
        }
    }

    public void Dispose()
    {
        if (Interlocked.Exchange(ref disposed, 1) != 0) return;
        try
        {
            lifetime.Cancel();
        }
        finally
        {
            lifetime.Dispose();
        }
    }
}

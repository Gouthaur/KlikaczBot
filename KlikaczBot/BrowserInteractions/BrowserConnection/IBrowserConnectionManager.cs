using PuppeteerSharp;

namespace KlikaczBot.BrowserInteractions.BrowserConnection;

public interface IBrowserConnectionManager
{
    RevisionInfo? RevisionInfo { get; }

    Task<IBrowser> ConnectToBrowserAsync();
}
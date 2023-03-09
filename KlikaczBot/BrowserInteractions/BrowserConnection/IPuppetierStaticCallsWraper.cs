using PuppeteerSharp;

namespace KlikaczBot.BrowserInteractions.BrowserConnection;

public interface IPuppetierStaticCallsWraper
{
    Task<IBrowser> ConnectToBrowserAsync(ConnectOptions options);
}
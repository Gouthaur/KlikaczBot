using PuppeteerSharp;

namespace KlikaczBot.BrowserInteractions.BrowserPageManager;

public interface IBrowserPageManager
{
    IPage Page { get; }

    Task ClosePageAsyc(PageCloseOptions pageCloseOptions);
    Task CreateAndGoToNewPageAsyc(string url, NavigationOptions options);
}
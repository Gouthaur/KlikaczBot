using PuppeteerSharp;

namespace KlikaczBot.BrowserInteractions.BrowserPageManager
{
    public interface IBrowserPageManager
    {
        IPage Page { get; }

        Task CreateAndGoToNewPage(string url, NavigationOptions options);
    }
}
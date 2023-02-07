using PuppeteerSharp;

namespace KlikaczBot.BrowserInteractions.BrowserPageManager
{
    public class BrowserPageManager : IBrowserPageManager
    {
        private IBrowser _browser;

        public BrowserPageManager(IBrowser browser)
        {
            _browser = browser;
        }

        public IPage? Page  { get; private set; }

        public async Task CreateAndGoToNewPage(string url, NavigationOptions options)
        {
            Page = await _browser.NewPageAsync();
            await Page.GoToAsync(url, options);
        }
    }
}
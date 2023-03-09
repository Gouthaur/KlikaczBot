using PuppeteerSharp;

namespace KlikaczBot.BrowserInteractions.BrowserPageManager;

public class BrowserPageManager : IBrowserPageManager
{
    private IBrowser _browser;

    public BrowserPageManager(IBrowser browser)
    {
        _browser = browser;
    }
    private IPage _page;
    
    public IPage? Page  
    {   get
        {
            return _page;
        }
        private set
        {
            if (value != null) 
            {
                _page = value;
            }
            else
            {
                throw new ArgumentNullException("Page object");
            }
            
        } 
    }

    public async Task ClosePageAsyc(PageCloseOptions pageCloseOptions)
    {
        await Page.CloseAsync(pageCloseOptions);
    }

    public async Task CreateAndGoToNewPageAsyc(string url, NavigationOptions options)
    {
        Page = await _browser.NewPageAsync();
        await Page.GoToAsync(url, options);
    }
}
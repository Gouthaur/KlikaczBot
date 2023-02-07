using PuppeteerSharp;

namespace KlikaczBot.BrowserInteractions.BrowserConnection
{
    public class PuppetierStaticCallsWraper : IPuppetierStaticCallsWraper
    {
        public async Task<IBrowser> ConnectToBrowserAsync(ConnectOptions options)
        {
          return await Puppeteer.ConnectAsync(options);
        }
    }
}
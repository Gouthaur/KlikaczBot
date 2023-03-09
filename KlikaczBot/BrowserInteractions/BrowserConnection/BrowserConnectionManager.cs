using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.BrowserInteractions.BrowserConnection;

public class BrowserConnectionManager : IBrowserConnectionManager
{
    public BrowserConnectionManager(string url, IBrowserFetcher fetcher,IPuppetierStaticCallsWraper puppetWraper)
    {
        _url = url;
        _fetcher = fetcher;
        _puppetWraper = puppetWraper;
    }

    private readonly string _url;
    private readonly IBrowserFetcher _fetcher;
    private readonly IPuppetierStaticCallsWraper _puppetWraper;

    public RevisionInfo? RevisionInfo { get; private set; }

    public async Task<IBrowser> ConnectToBrowserAsync()
    {
        RevisionInfo = await _fetcher.DownloadAsync();
        return await _puppetWraper.ConnectToBrowserAsync( 
            new ConnectOptions() { BrowserURL = _url, DefaultViewport = null });
    }
}

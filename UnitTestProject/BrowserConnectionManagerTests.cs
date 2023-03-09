using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlikaczBot.BrowserInteractions.BrowserConnection;
using Moq;
using PuppeteerSharp;
using System.Security.Cryptography.X509Certificates;

namespace UnitTestProject;

[TestFixture]
public class BrowserConnectionManagerTests
{
    private IBrowserConnectionManager? _classUnderTests;
    private const string _url = @"http://127.0.0.1:9222";
    private Mock<IBrowserFetcher> fetcherMock;
    private Mock<IPuppetierStaticCallsWraper> puppetWraper;
    
    [SetUp] 
    public void SetUp() 
    {
        fetcherMock = new Mock<IBrowserFetcher>();
        fetcherMock.Setup(x => x.DownloadAsync()).Returns(Task.FromResult(It.IsAny<RevisionInfo>()));
        
        puppetWraper = new Mock<IPuppetierStaticCallsWraper>();
        puppetWraper.Setup(x => 
        x.ConnectToBrowserAsync(It.IsAny<ConnectOptions>())).Returns(Task.FromResult(It.IsAny<IBrowser>()));
        
        _classUnderTests = new BrowserConnectionManager(_url, fetcherMock.Object, puppetWraper.Object);

       
    }
    
    [Test]  
    public async Task ConnectToBrowser_ShallCallConnectWithProperUrlAndViewWindowProps_WhenCalled()
    {
        await _classUnderTests.ConnectToBrowserAsync();
        puppetWraper.Verify(x => 
        x.ConnectToBrowserAsync(It.Is<ConnectOptions>(p => p.BrowserURL == _url && p.DefaultViewport == null )));
    }
    [Test]  
    public async Task ConnectToBrowser_ShallCallFetcherDownloadAsync_WhenWhenCalled()
    {
        await _classUnderTests.ConnectToBrowserAsync();
        fetcherMock.Verify(x=>x.DownloadAsync(),Times.Once);
    }

    [Test]
    public async Task ConnectToBrowser_ShallSaveRevisonData_WhenCalled()
    {
        var revisonInfo = new RevisionInfo() { Revision = "xD"};
        fetcherMock.Setup(x => x.DownloadAsync()).Returns(Task.FromResult(revisonInfo));
        await _classUnderTests.ConnectToBrowserAsync();                     
        Assert.AreSame(revisonInfo, _classUnderTests.RevisionInfo);        
    }

}

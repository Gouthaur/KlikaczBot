using KlikaczBot.BrowserInteractions.BrowserPageManager;
using Moq;
using NUnit.Framework;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTestProject;

[TestFixture]
public class BrowserPageManagerTests
{

    IBrowserPageManager _classUnderTest;
    private const string _url = "url";
    private Mock<IBrowser> _browserMock;
    
    [SetUp]
    public void SetUp() 
    {
        _browserMock = new Mock<IBrowser>();
        _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(It.IsAny<IPage>()));
        
        
        _classUnderTest = new BrowserPageManager(_browserMock.Object);

    }
    [Test]
    public async Task CreateAndGoToNewPageAsyc_CallBrowserNewPageAsync_WhenCalled()
    {
        var page = new Mock<IPage>().Object;
        _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(page));
        await _classUnderTest.CreateAndGoToNewPageAsyc(_url, new NavigationOptions());
        _browserMock.Verify(x=> x.NewPageAsync(),Times.Once);
    }

    [Test]
    public async Task CreateAndGoToNewPageAsyc_PopulatePageObjProp_WhenCreatingNewPage()
    {
        var page = new Mock<IPage>().Object;
        _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(page));
        await _classUnderTest.CreateAndGoToNewPageAsyc(_url, new NavigationOptions());
        Assert.AreSame(page,_classUnderTest.Page);
    }

      

    [Test]
    public async Task CreateAndGoToNewPageAsyc_CallBrowserGoToPageAsyc_WhenCalled()
    {
        var page = new Mock<IPage>();
        var navOptions = new NavigationOptions();
        
        page.Setup(x => x.GoToAsync(It.IsAny<string>(),new NavigationOptions())).Returns(Task.FromResult(It.IsAny<IResponse>()));
        _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(page.Object));
        
        await _classUnderTest.CreateAndGoToNewPageAsyc(_url, navOptions);
        page.Verify(x => x.GoToAsync(_url, navOptions), Times.Once);
    }

    [Test]
    public async Task ClosePageAsyc_ShallCallClosePageAsync_WhemCalled()
    {
        //Arange
        var page = new Mock<IPage>();
        var navOptions = new NavigationOptions();
        var pageCloseOptions = new PageCloseOptions();
        page.Setup(x => x.CloseAsync(It.IsAny<PageCloseOptions>()));
        _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(page.Object));
        //To populate page object
        await _classUnderTest.CreateAndGoToNewPageAsyc(_url, navOptions);
        //Act
        await _classUnderTest.ClosePageAsyc(pageCloseOptions);
        //Assert
        page.Verify(x => x.CloseAsync(pageCloseOptions),Times.Once);
    }
    [Test]
    public async Task ClosePageAsyc_()
    {

    }
}

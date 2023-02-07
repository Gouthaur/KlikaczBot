using KlikaczBot.BrowserInteractions.BrowserPageManager;
using Moq;
using NUnit.Framework;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
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
        public async Task CreateAndGoToNewPage_CallBrowserNewPageAsync_WhenCalled()
        {
            var page = new Mock<IPage>().Object;
            _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(page));
            await _classUnderTest.CreateAndGoToNewPage(_url, new NavigationOptions());
            _browserMock.Verify(x=> x.NewPageAsync(),Times.Once);
        }

        [Test]
        public async Task CreateAndGoToNewPage_PopulatePageObjProp_WhenCreatingNewPage()
        {
            var page = new Mock<IPage>().Object;
            _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(page));
            await _classUnderTest.CreateAndGoToNewPage(_url, new NavigationOptions());
            Assert.AreSame(page,_classUnderTest.Page);
        }

          

        [Test]
        public async Task CreateAndGoToNewPage_CallBrowserGoToPage_WhenCalled()
        {
            var page = new Mock<IPage>();
            var navOptions = new NavigationOptions();
            
            page.Setup(x => x.GoToAsync(It.IsAny<string>(),new NavigationOptions())).Returns(Task.FromResult(It.IsAny<IResponse>()));
            _browserMock.Setup(x => x.NewPageAsync()).Returns(Task.FromResult(page.Object));
            
            await _classUnderTest.CreateAndGoToNewPage(_url, navOptions);
            page.Verify(x => x.GoToAsync(_url, navOptions), Times.Once);
        }
    }
}

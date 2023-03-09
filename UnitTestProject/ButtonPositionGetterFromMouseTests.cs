using KlikaczBot.MouseButtonInteractionsClasses;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPosition.Unsused;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject;

[TestFixture]
public class ButtonPositionGetterFromMouseTests
{

    IButtonPositionGette _classUnderTests { get; set; }
    Mock<IMouseKeybordWraper> _mockMouseWraper { get; set; }

    [SetUp] 
    public void SetUp()
    {
        _mockMouseWraper = new Mock<IMouseKeybordWraper>();            
        _classUnderTests = new ButtonPositionFromMouse(_mockMouseWraper.Object);
        _mockMouseWraper.SetupSequence(x => x.CheckIfKeyIsPressed(It.IsAny<int>()))
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(true)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(false)
            .Returns(true);
        _mockMouseWraper.SetupSequence(x => x.GetMousePos())
            .Returns(new Point(100, 200))
            .Returns(new Point(400, 700));

    }

    ButtonPosSizeRecord buttonToCompare = new ButtonPosSizeRecord(100, 200, 300, 500);

    [Test] 
    public async Task Test_ButtonPositionFromMouse_Shall_GiveProperButton_WhenCalled()
    {     
        Assert.AreEqual( await _classUnderTests.GetButtonPosFromMouseAsync(8000), buttonToCompare);
    }
    [Test]  
    public void Test_ButtonPositionFromMouse_Shall_ThrowInvalidOperationExeption_OnTimeOut()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _classUnderTests.GetButtonPosFromMouseAsync(30));         
    }  

}

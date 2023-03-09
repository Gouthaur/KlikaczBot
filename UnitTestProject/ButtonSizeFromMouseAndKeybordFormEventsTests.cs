using KlikaczBot.MouseButtonInteractionsClasses;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPosition;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject;

public class ButtonSizeFromMouseAndKeybordFormEventsTests
{
    Mock<IMouseKeybordWraper> _mockMouseKeybordWraper;
    ButtonSizeFromMouseAndKeybordFormEvents classUnderTest;       
    
    [SetUp]
    public void SetUp()
    {
        _mockMouseKeybordWraper= new Mock<IMouseKeybordWraper>();
        _mockMouseKeybordWraper.SetupSequence(x=>x.GetMousePos())
            .Returns(new Point(100, 200))
            .Returns(new Point(400, 700))
            .Returns(new Point(99, 199))
            .Returns(new Point(399, 699));
        classUnderTest = new(_mockMouseKeybordWraper.Object);
    }
    ButtonPosSizeRecord buttonToCompare = new(100, 200, 300, 500);
    ButtonPosSizeRecord buttonToCompare2 = new(99, 199, 300, 500);
    [Test]  
    public void Test_CalibratePosFromMouse_ShallRead2PosFrom2CallsAndCalibreteButton_WhenCalled2tiems()
    {
        classUnderTest.CalibratePosFromMouse();
        classUnderTest.CalibratePosFromMouse();
        Assert.AreEqual(buttonToCompare,classUnderTest.CalibratedButton);
    }
    [Test]
    public void Test_CalibratePosFromMouse_ShallRead2PosFrom2CallsAndCalibreteButton_WhenCalled4tiems()
    {
        classUnderTest.CalibratePosFromMouse();
        classUnderTest.CalibratePosFromMouse();
        classUnderTest.CalibratePosFromMouse();
        classUnderTest.CalibratePosFromMouse();
        Assert.AreEqual(buttonToCompare2, classUnderTest.CalibratedButton);
    }

}

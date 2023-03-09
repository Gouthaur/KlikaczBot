using KlikaczBot.MouseButtonInteractionsClasses;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPointToClickGenerators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject;

[TestFixture]
public class RandomPointFormButtonPositionGeneratorTests
{
    [Test]
    [Repeat(100)]
    public void Test_GetButtonPointToClick_ShallReturnRandomPointWithinButtonRange_WhenGivenButtonPosition()
    {
        ButtonPosSizeRecord buttonPos = new(100,200,300,400);
        IButtonPointToClickGenerator classUnderTests = new RandomPointFormButtonPositionGenerator();
        Point pointToCompare = classUnderTests.GetButtonPointToClick(buttonPos);
        Assert.IsTrue(((pointToCompare.X >= buttonPos.X) && (pointToCompare.Y >= buttonPos.Y)));
        Assert.IsTrue(((pointToCompare.X <= buttonPos.X + buttonPos.Width) && (pointToCompare.Y <= buttonPos.Y + buttonPos.Height)));
    }
    [Test]
    [Repeat(100)]
    public void Test_GetButtonPointToClick_ShallReturnRandomPointWithinButtonRange_WhenGivenButtonPositionWithNegativeHighWidth()
    {
        ButtonPosSizeRecord buttonPos = new(100, 200, -300, -400);
        IButtonPointToClickGenerator classUnderTests = new RandomPointFormButtonPositionGenerator();
        Point pointToCompare = classUnderTests.GetButtonPointToClick(buttonPos);
        Assert.IsTrue(((pointToCompare.X <= buttonPos.X) && (pointToCompare.Y <= buttonPos.Y)));
        Assert.IsTrue(((pointToCompare.X >= buttonPos.X + buttonPos.Width) && (pointToCompare.Y >= buttonPos.Y + buttonPos.Height)));
    }
}

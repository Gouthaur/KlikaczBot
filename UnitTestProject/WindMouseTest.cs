using KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;
using KlikaczBot.SavingOptionsInFile;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject;

[TestFixture]
public  class WindMouseTest
{
    [Test]
    public async Task Test_WindMouse_()
    {
        AppOptData appOptData= new();
        appOptData.MinimalMouseSpeedValue = 30.25;
        appOptData.MaximalMouseSpeedValue = 50.25;

        var classUnderTests = new WindMouseMover(appOptData);
        await classUnderTests.MoveMousePretendingHumanityAsync(1.1,2.2,3.3,4.4,5.5,6.6,0);
        
    }

}

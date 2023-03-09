using KlikaczBot.BotLogic.BotLogicHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject;

[TestFixture]
public class CryptoSafeRandomValueProviderTests
{
    [Test]
    [Repeat(100)]
    public void Test_RandomIntProvider()
    {

        int min = 10;
        int max = 50;

        CryptoSafeRandomValueProvider classUnderTests = new();
        var randomInt = classUnderTests.GetRandomIntValue(min,max);


        Assert.IsTrue(randomInt >= min && randomInt < max);
    }

    [Test]
    [Repeat(100)]
    public void Test_GetRandomDoubleValue()
    {

        double min = 10.45d;
        double max = 50.23f;

        CryptoSafeRandomValueProvider classUnderTests = new();
        var randomInt = classUnderTests.GetRandomDoubleValue(min, max);


        Assert.IsTrue(randomInt >= min && randomInt < max);
    }

    [Test]
    [Repeat(100)]
    public void Test_GetRandomMilisecondFromDateTime()
    {

        DateTime min = new DateTime().AddMilliseconds(15);
        DateTime max = new DateTime().AddMilliseconds(115);

        CryptoSafeRandomValueProvider classUnderTests = new();
        var randomInt = classUnderTests.GetRandomMilisecondFromDateTime(min, max);


        Assert.IsTrue(randomInt >= min.Millisecond && randomInt < max.Millisecond);
    }


}

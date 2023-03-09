using KlikaczBot.BotLogic;
using KlikaczBot.BotLogic.BotLogicHelpers;
using KlikaczBot.MouseButtonInteractionsClasses;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPointToClickGenerators;
using KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;
using KlikaczBot.SavingOptionsInFile;
using Moq;
using NUnit.Framework;
using PuppeteerSharp.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject;

[TestFixture]
public class BotAlgorithmTest
{
    private Mock<IRandomValueProvider> _randomValueProvider;
    private IBotLogic _classUnderTests;
    private Mock<IMouseMover> _mockMouseMover;
    private Mock<IMoveToButtonPoint> _mockMoveToButtonPoint;
    private BotButtons _botButtons;


    public BotAlgorithmTest()
    {
         _botButtons = new()
         {
             AcceptEndOfRun = new(100, 200, 300, 400),
             BrowserInWindowsBar = new(201, 301, 401, 501),
             BrowserMinimalise = new(300, 400, 500, 600),
             SendWombat = new(10, 20, 30, 40),
             FiveMinRun = new(50, 100, 150, 200),
             ChangeRunTime = new(70, 80, 90, 100),
             FivteenMinRun = new(600, 900, 120, 220),
             NextTabInBrowser = new(234, 137, 99, 77),
             SixtyMinRun = new(333, 222, 111, 444),
             SendRunAfterTimeChange = new(33, 22, 11, 44),
             WombatTabInBrowser = new(454, 23, 213, 657),
             NextWindowInBar = new(54, 23, 21, 57)
         };

        _appOptData = new()
        {
            FiveMinRunDuration = new DateTime().AddMicroseconds(10),
            FivteenMinRunDuration = new DateTime().AddMicroseconds(11),
            MaximalDelayBetweenRuns = new DateTime().AddMicroseconds(12),
            MinimalDelayBetweenRuns = new DateTime().AddMicroseconds(13),
            SixtyMinuteRunDuration = new DateTime().AddMicroseconds(14),
            MaximalGravity = 2D,
            MinimalGravity = 1D,
            MinimalWind = 0.5D,
            MaximalWind = 1D,
            MinimalDelayBeforeClick = 15,
            MaximalDelayBeforeClick = 25,
            MinimalClickTime = 67,
            MaximalClickTime = 93,
            MaximalDelayAfterClick = 25,
            MinimalDelayAfterClick = 15,
            StaminaCost5MinRun = 5,
            StaminaCost15MinRun = 12,
            StaminaCost60MinRun = 18,
            ButtonPositions = _botButtons
        };

}
    private Mock<IButtonPointToClickGenerator> _mockPointToClickGenerator;

    Point _randomPointAcceptEndOfRun = new();
    Point _randomPointBrowserInWindowsBar = new();
    Point _randomPointBrowserMinimalise = new();
    Point _randomPointSendWombat = new();
    Point _randomPointFiveMinRun = new();
    Point _randomPointChangeRunTime = new();
    Point _randomPointFivteenMinRun = new();
    Point _randomPointNextTabInBrowser = new();
    Point _randomPointSixtyMinRun = new();
    Point _randomPointWombatTabInBrowser = new();


    AppOptData _appOptData;

    Mock<IMouseKeybordWraper> _mockMosueKeybordWraper;

    [SetUp]
    public void SetUp()
    {

        _appOptData.ButtonPositions = _botButtons;
        _mockPointToClickGenerator = new Mock<IButtonPointToClickGenerator>();
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.AcceptEndOfRun))
            .Returns(_randomPointAcceptEndOfRun);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.BrowserInWindowsBar))
            .Returns(_randomPointBrowserInWindowsBar);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.BrowserMinimalise))
            .Returns(_randomPointBrowserMinimalise);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.SendWombat))
            .Returns(_randomPointSendWombat);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.FiveMinRun))
            .Returns(_randomPointFiveMinRun);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.ChangeRunTime))
            .Returns(_randomPointChangeRunTime);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.FivteenMinRun))
            .Returns(_randomPointFivteenMinRun);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.NextTabInBrowser))
            .Returns(_randomPointNextTabInBrowser);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.SixtyMinRun))
           .Returns(_randomPointSixtyMinRun);
        _mockPointToClickGenerator.Setup(x => x.GetButtonPointToClick(_botButtons.WombatTabInBrowser))
           .Returns(_randomPointWombatTabInBrowser);

        var screenResulution = Screen.PrimaryScreen.Bounds; 
        Random mousePointgenerator= new Random();

        _mockMosueKeybordWraper = new Mock<IMouseKeybordWraper>();
        _mockMosueKeybordWraper.Setup(x => x.GetMousePos())
            .Returns(new Point(mousePointgenerator.Next(0,screenResulution.Right ),mousePointgenerator.Next(0,screenResulution.Bottom)));
        _mockMosueKeybordWraper.Setup(x => x.ClickMouseLeftButton(It.IsAny<Point>(),
            It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));



            _mockMouseMover = new Mock<IMouseMover>();
        _mockMouseMover.Setup(x=> x.MoveMousePretendingHumanityAsync(It.IsAny<Double>(), It.IsAny<Double>(),
            It.IsAny<Double>(), It.IsAny<Double>(),It.IsAny<Double>(), It.IsAny<Double>(), It.IsAny<Double>()));

        _mockMoveToButtonPoint = new Mock<IMoveToButtonPoint>();
        _mockMoveToButtonPoint.Setup(x=>x.GoAncClickButtonAsync(It.IsAny<ButtonPosSizeRecord>()));
        _mockMoveToButtonPoint.Setup(x => x.GoToRandomPointOnScreenAsync());
        _randomValueProvider = new Mock<IRandomValueProvider>();
        _randomValueProvider.Setup(x=>x.GetRandomIntValue(It.IsAny<int>(), It.IsAny<int>()));
        _randomValueProvider.Setup(x => x.GetRandomDoubleValue(It.IsAny<double>(), It.IsAny<double>()));

        _classUnderTests = new BotAlgorithm( _appOptData, _mockMoveToButtonPoint.Object, _randomValueProvider.Object);

    }
    [Test]
    public async Task Test_GoToSendWombatAndClickIt_ShallGoAndClickSendRun()
    {
        await _classUnderTests.GoToSendWombatAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.SendWombat));
       /*
        _mockMouseMover.Verify(x => x.MoveMousePretendingHumanity( It.IsAny<double>(), It.IsAny<double>(),
            (double)_randomPointSendWombat.X, (double)_randomPointSendWombat.Y,
            It.IsAny<Double>(), It.IsAny<Double>(), It.IsAny<Double>()));
        _mockMosueKeybordWraper.Verify(x => x.ClickMouseLeftButton(_randomPointSendWombat,
            It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
       */
    }

    [Test]
    public async Task Test_GoToAceptEndOfRunAndClickIt_ShallGoAndClickAceptEndOfRun()
    {
        await _classUnderTests.GoToAcceptEndOfRunAncClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.AcceptEndOfRun));
    }

    [Test]
    public async Task Test_GoToBrowserInWindowsBarAndClickIt_ShallGoAndClickAceptEndOfRun()
    {
        await _classUnderTests.GoToBrowserInWindowsBarAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.BrowserInWindowsBar));
    }


    [Test]
    public async Task Test_GoToBrowserMinimaliseAndClickIt_ShallGoAndClickBrowserMinimalise()
    {
        await _classUnderTests.GoToBrowserMinimaliseAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.BrowserMinimalise));
    }

    [Test]
    public async Task Test_GoToFiveMinRunAndClickIt_ShallGoAndClickFiveMinRun()
    {
        await _classUnderTests.GoToFiveMinRunAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.FiveMinRun));
    }


    [Test]
    public async Task Test_GoToChangeRunTimeAndClickIt_ShallGoAndClickChangeRunTime()
    {
        await _classUnderTests.GoToChangeRunTimeAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.ChangeRunTime));
    }

    [Test]
    public async Task Test_GoToFivteenMinRunAndClickIt_ShallGoAndClicFivteenMinRun()
    {
        await _classUnderTests.GoToFivteenMinRunAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.FivteenMinRun));
    }

    [Test]
    public async Task Test_GoToNextTabInBrowserAndClickIt_ShallGoAndClicNextTabInBrowser()
    {
        await _classUnderTests.GoToNextTabInBrowserAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.NextTabInBrowser));
    }

    [Test]
    public async Task Test_GoToSixtyMinRunAndClickIt_ShallGoAndClicSixtyMinRun()
    {
        await _classUnderTests.GoToSixtyMinRunAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.SixtyMinRun));
    }
    [Test]
    public async Task Test_GoToWombatTabInBrowserAndClickIt_ShallGoAndClicWombatTabInBrowser()
    {
        await _classUnderTests.GoToWombatTabInBrowserAndClickItAsync();
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.WombatTabInBrowser));
    }
    //Testcase2
    //5 min  Sta 40 Ilosc 8
    //15 min Sta 40 Ilość 3 Reszta 4
    //60 mim Sta 720 Ilosc 720/18 40 Reszta 0
    //Testcase3
    //5 min  Sta 115 Ilosc 23
    //15 min Sta 585 Ilość 48 Reszta 9   24   2  50
    //60 mim Sta 123 Ilosc 6  Reszta 15
    [TestCase(50, 20, 30, 677, 69, 11, 11)]
    [TestCase(5, 5, 90, 800, 8, 3, 40)]
    [TestCase(14, 71, 15, 825, 23, 50, 6)]
    [TestCase(35, 25, 40, 50, 3, 1, 1)]

    public async Task Test_StartBot_ShallCalcalateNumberOfDifrentRuns_WhenCalled(int percentageOf5MinRuns,int percentageOf15MinRuns,
      int percentageOf60MinRuns, int stamina, int runs5min, int runs15min,int runs60min)
    {
                        
        await _classUnderTests.StartBotAsync(percentageOf5MinRuns, percentageOf15MinRuns, percentageOf60MinRuns, stamina);
        Assert.AreEqual(runs5min, _classUnderTests.NumberOf5minRuns);
        Assert.AreEqual(runs15min, _classUnderTests.NumberOf15minRuns);
        Assert.AreEqual(runs60min, _classUnderTests.NumberOf60minRuns);
    }
    /*[TestCase(50, 20, 30, 677, 67, 11, 11)]
    [TestCase(5, 5, 90, 800, 8, 3, 40)]
    [TestCase(14, 71, 15, 825, 23, 50, 6)]
    public async Task Test_StartBot_ShallCall_WhenCalled(int percentageOf5MinRuns, int percentageOf15MinRuns,
      int percentageOf60MinRuns, int stamina, int runs5min, int runs15min, int runs60min)
    {

        await _classUnderTests.StartBot(percentageOf5MinRuns, percentageOf15MinRuns, percentageOf60MinRuns, stamina);
    }
    */

    //[TestCase(50, 20, 30, 677, 67, 11, 11)]
    //[TestCase(5, 5, 90, 800, 8, 3, 40)]
    [TestCase(50, 25, 25, 100, 11, 2, 1)] // 5min 50/5 = 10 15 25 /12 = 2 Reszta 1 1h 25/18 = 1 Reszta 7 czyli 1 dodatkowa 5         
    public async Task Test_StartBot_ShallDoAllRunns_WhenCallled(int percentageOf5MinRuns, int percentageOf15MinRuns,
          int percentageOf60MinRuns, int stamina, int runs5min, int runs15min, int runs60min)
    {

        await _classUnderTests.StartBotAsync(percentageOf5MinRuns, percentageOf15MinRuns, percentageOf60MinRuns, stamina);
        _mockMoveToButtonPoint.Verify(x=>x.GoAncClickButtonAsync(It.IsIn<ButtonPosSizeRecord>(_botButtons.SendWombat,_botButtons.SendRunAfterTimeChange)), Times.Exactly(14));
        //_mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.Dend));
    }

    // 5 runów w sceneriuszu
    // 1 run 60 min bez zmiany czasu
    // Send wombat
    // zmiana okna przeglądarki
    // 2 run 5min
    // powrót przez bara przegladarki
    // zmina czasu na 5
    // send wombat po zmianie czasu 
    // zminimalizowanie przeglądarki
    //3 run 15 min
    // powrót przez kilkniecie na bara wombata
    //zmiana czasu na 15 min
    //wysłanie wombata z zmiany czasu
    //zmiana taba przeglądarki
    //4 5 min 
    //powrót przez zmiane taba na wombata
    //zmiana czasu na 5 min
    //wysłanie wombata przez send wombat po zmianie czasu
    //minimalzacja przegladarki
    //5 5 min
    //powrót przez maksymializacje przeglądarki
    //Send run
    //nastpepne okno

    // 1 -Minimalizacja
    // 2- Nastepne okno 
    // 0 - zmiana taba


    [TestCase(35, 25, 40, 50, 3, 1, 1)]
    public async Task Test_StartBot_ShallPerformWholeWithChoosenRandomScenerio_WhenCallled(int percentageOf5MinRuns, int percentageOf15MinRuns,
          int percentageOf60MinRuns, int stamina, int runs5min, int runs15min, int runs60min)
    {
        _randomValueProvider.SetupSequence(x => x.GetRandomIntValue(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(4) //
            .Returns(2) //1
            .Returns(0) //
            .Returns(1) //2
            .Returns(2) //
            .Returns(0) //3
            .Returns(0) //
            .Returns(1) //4
            .Returns(1);//5


        await _classUnderTests.StartBotAsync(percentageOf5MinRuns, percentageOf15MinRuns, percentageOf60MinRuns, stamina);


        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.SendWombat), Times.Exactly(2));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.SendRunAfterTimeChange), Times.Exactly(3));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.AcceptEndOfRun), Times.Exactly(4));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.ChangeRunTime), Times.Exactly(3));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.FiveMinRun), Times.Exactly(2));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.FivteenMinRun), Times.Exactly(1));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.BrowserMinimalise), Times.Exactly(2));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.NextTabInBrowser), Times.Exactly(1));
        _mockMoveToButtonPoint.Verify(x => x.GoAncClickButtonAsync(_botButtons.WombatTabInBrowser), Times.Exactly(1));
     }
}

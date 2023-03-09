using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.BotLogic;

public interface IBotLogic
{
    Task GoToAcceptEndOfRunAncClickItAsync();
    Task GoToChangeRunTimeAndClickItAsync();
    Task GoToFiveMinRunAndClickItAsync();
    Task GoToBrowserInWindowsBarAndClickItAsync();
    Task GoToBrowserMinimaliseAndClickItAsync();
    Task GoToSendWombatAndClickItAsync();
    Task GoToFivteenMinRunAndClickItAsync();
    Task GoToNextTabInBrowserAndClickItAsync();
    Task GoToSixtyMinRunAndClickItAsync();
    Task GoToWombatTabInBrowserAndClickItAsync();
    Task GoToSendRunAfterTimeChangeAndClickItAsync();
    Task GoToRandomPointOnScreenAsync();
    Task StartBotAsync(int percentageOf5MinRuns, int percentageOf15MinRuns, int percentageOf60MinRuns, int stamina);
    int NumberOf5minRuns { get;  }
    int NumberOf15minRuns { get; }
    int NumberOf60minRuns { get; }
    int NumberOf5minRunsLeft { get;  }
    int NumberOf15minRunsLeft { get; }
    int NumberOf60minRunsLeft { get; }
    CancellationTokenSource CancelOperation { get; }
    event EventHandler<BotAlgorithm.BotRunTypeEnum> WaitTimeForRunStarted;
    event EventHandler<BotAlgorithm.DiffrentBotRoutesEnum> RouteTypeSelected;
    event EventHandler<BotAlgorithm.BotRunTypeEnum> RunTypeStarted;
    event EventHandler<int> WaitTimeBetweenRunsStarted;
}

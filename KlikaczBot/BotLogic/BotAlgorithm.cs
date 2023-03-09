using KlikaczBot.BotLogic.BotLogicHelpers;
using KlikaczBot.MouseButtonInteractionsClasses;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPointToClickGenerators;
using KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;
using KlikaczBot.SavingOptionsInFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.BotLogic;

public partial class BotAlgorithm : IBotLogic
{
    
    private readonly AppOptData _appOptData;
    private readonly IMoveToButtonPoint _moveToButtonPoint;
    private readonly IRandomValueProvider _randomValueProvider;
    public event EventHandler<BotRunTypeEnum> WaitTimeForRunStarted;
    public event EventHandler<DiffrentBotRoutesEnum> RouteTypeSelected;
    public event EventHandler<BotRunTypeEnum> RunTypeStarted;
    public event EventHandler<int> WaitTimeBetweenRunsStarted;

    public int NumberOf5minRuns { get; private set; }
    public int NumberOf15minRuns { get; private set; }
    public int NumberOf60minRuns { get; private set; }
    public int NumberOf5minRunsLeft { get; private set; }
    public int NumberOf15minRunsLeft { get; private set; }
    public int NumberOf60minRunsLeft { get; private set; }
    public CancellationTokenSource CancelOperation { get; private set; }



    public BotAlgorithm( AppOptData appOptData, IMoveToButtonPoint moveToButtonPoint, IRandomValueProvider randomValueProvider)
    {
        _appOptData = appOptData;           
        _moveToButtonPoint = moveToButtonPoint;
        _randomValueProvider = randomValueProvider;
    }


    protected virtual void OnWaitTimeForRunStarted(BotRunTypeEnum e)
    {
        WaitTimeForRunStarted?.Invoke(this, e);
    }

    protected virtual void OnRunTypeStarted(BotRunTypeEnum e)
    {
        RunTypeStarted?.Invoke(this, e);
    }

    protected virtual void OnRouteTypeSelected(DiffrentBotRoutesEnum e)
    {
        RouteTypeSelected?.Invoke(this, e);
    }

    protected virtual void OnWaitTimeForRunStarted(int e)
    {
        WaitTimeBetweenRunsStarted?.Invoke(this, e);
    }

    public async Task GoToAcceptEndOfRunAncClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.AcceptEndOfRun);
    }
           
    public async Task GoToFiveMinRunAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.FiveMinRun);
    }

    public async Task GoToBrowserInWindowsBarAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.BrowserInWindowsBar);
    }

    public async Task GoToBrowserMinimaliseAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.BrowserMinimalise);
    }

    public async Task GoToChangeRunTimeAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.ChangeRunTime);
    }

    public async Task GoToFivteenMinRunAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.FivteenMinRun);
    }

    public async Task GoToNextTabInBrowserAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.NextTabInBrowser);
    }

    public async Task GoToSendWombatAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.SendWombat);
    }

    public async Task GoToSixtyMinRunAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.SixtyMinRun);
    }

    public async Task GoToWombatTabInBrowserAndClickItAsync()
    {
         await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.WombatTabInBrowser);
    }
    public async Task GoToSendRunAfterTimeChangeAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.SendRunAfterTimeChange);
    }

    public async Task GoToNextWindowInBarAndClickItAsync()
    {
        await _moveToButtonPoint.GoAncClickButtonAsync(_appOptData.ButtonPositions.NextWindowInBar);
    }

    
    /*
    private async Task GoAncClickButton(ButtonPosSizeRecord button)
    {
        var startingPoint = _moveToButtonPoint.GetMousePos();
        var endPoint = _buttonRandomClickGenerator.GetButtonPointToClick(button);

        await _mouseMover.MoveMousePretendingHumanity((double)startingPoint.X,
            (double)startingPoint.Y, (double)endPoint.X, (double)endPoint.Y,
            RandomNumberGenerator.GetInt32((int)(100 * _appOptData.MinimalGravity), (int)(100 * _appOptData.MaximalGravity)) / 100,
            RandomNumberGenerator.GetInt32((int)(100 * _appOptData.MinimalWind), (int)(100 * _appOptData.MaximalWind)) / 100
            , 0);
        await _mouseKeybordWraper.ClickMouseLeftButton(endPoint,
            TimeSpan.FromMilliseconds(RandomNumberGenerator.GetInt32(_appOptData.MinimalDelayBeforeClick, _appOptData.MaximalDelayBeforeClick)),
            TimeSpan.FromMilliseconds(RandomNumberGenerator.GetInt32(_appOptData.MinimalClickTime, _appOptData.MaximalClickTime)),
            TimeSpan.FromMilliseconds(RandomNumberGenerator.GetInt32(_appOptData.MinimalDelayAfterClick, _appOptData.MaximalDelayAfterClick)));
    }
    */



    public async Task StartBotAsync(int percentageOf5MinRuns, int percentageOf15MinRuns, int percentageOf60MinRuns, int stamina)
    {
        int stamina5Min = stamina * percentageOf5MinRuns / 100;
        int stamina15Min = stamina * percentageOf15MinRuns / 100;
        int stamina60Min = stamina * percentageOf60MinRuns / 100;

        int numberOf5MinRuns = stamina5Min / _appOptData.StaminaCost5MinRun;
        int numberOf15MinRuns = stamina15Min / _appOptData.StaminaCost15MinRun;
        int numberOf60MinRuns = stamina60Min / _appOptData.StaminaCost60MinRun;


        int staminaLeft = stamina - numberOf5MinRuns * _appOptData.StaminaCost5MinRun - 
            numberOf15MinRuns * _appOptData.StaminaCost15MinRun - numberOf60MinRuns * _appOptData.StaminaCost60MinRun;
        
        int numberOf5FromStaminaLeft = staminaLeft/ _appOptData.StaminaCost5MinRun;
        int numberOf15FromStaminaLeft = staminaLeft / _appOptData.StaminaCost15MinRun;
        int numberOf60FromStaminaLeft = staminaLeft / _appOptData.StaminaCost60MinRun;

        BotRunTypeEnum mainRunOfBot = BotRunTypeEnum.FiveMin;
        if (percentageOf5MinRuns >= percentageOf60MinRuns  && percentageOf5MinRuns >= percentageOf15MinRuns)
        {
            if (numberOf5FromStaminaLeft >= 1)
            {
                numberOf5MinRuns += numberOf5FromStaminaLeft;
            }
            
            mainRunOfBot = BotRunTypeEnum.FiveMin;
        }

        if (percentageOf15MinRuns > percentageOf5MinRuns && percentageOf15MinRuns > percentageOf60MinRuns)
        {
            if (numberOf15FromStaminaLeft >= 1)
            {
                numberOf15MinRuns += numberOf15FromStaminaLeft;
            }
          
            mainRunOfBot = BotRunTypeEnum.FifteenMin;
        }

        if (percentageOf60MinRuns > percentageOf5MinRuns && percentageOf60MinRuns > percentageOf15MinRuns )
        {
            if (numberOf60FromStaminaLeft >= 1)
            {
                numberOf60MinRuns += numberOf60FromStaminaLeft;
            }
            mainRunOfBot = BotRunTypeEnum.SixtyMin;
        }

        if (percentageOf15MinRuns == percentageOf60MinRuns && 
            !(percentageOf5MinRuns >= percentageOf60MinRuns && percentageOf5MinRuns >= percentageOf15MinRuns))
        {
            if (numberOf5FromStaminaLeft >= 1)
            {
                numberOf5MinRuns += numberOf5FromStaminaLeft;
            }

            mainRunOfBot = BotRunTypeEnum.FiveMin;
        }


        NumberOf5minRuns = numberOf5MinRuns;
        NumberOf15minRuns = numberOf15MinRuns;
        NumberOf60minRuns = numberOf60MinRuns;

        int numberOfRuns = NumberOf5minRuns + NumberOf15minRuns + NumberOf60minRuns;
        List<BotRunTypeEnum> botRunsToSendList = new(numberOfRuns);
        for (int i = 0; i < numberOfRuns; i++)
        {
            if (numberOf5MinRuns > 0 && i < numberOf5MinRuns)
            {
                botRunsToSendList.Add(BotRunTypeEnum.FiveMin);
            }
            if (i < (numberOf15MinRuns + numberOf5MinRuns) && numberOf15MinRuns > 0 && numberOf5MinRuns <= i)
            {
                botRunsToSendList.Add(BotRunTypeEnum.FifteenMin);
            }
            if (i >= (numberOf15MinRuns + numberOf5MinRuns) && numberOf60MinRuns > 0)
            {
                botRunsToSendList.Add(BotRunTypeEnum.SixtyMin);
            }
        }

        CancelOperation = new();
        CancellationToken cancelationToken = CancelOperation.Token;
        
        BotRunTypeEnum currentRunType = mainRunOfBot;
        BotRunTypeEnum previousRunType = mainRunOfBot;
        
       await Task.Run(async () =>
       {

            DiffrentBotRoutesEnum previosBotRoute = DiffrentBotRoutesEnum.None;
            DiffrentBotRoutesEnum currentBotRoute = DiffrentBotRoutesEnum.None;

            for (int i = 0; i < numberOfRuns; i++)
            {
                if (cancelationToken.IsCancellationRequested)
                {
                    cancelationToken.ThrowIfCancellationRequested();
                }
                BotRunTypeEnum currentRunType;

                await  Task.Delay( _randomValueProvider.GetRandomIntValue( _appOptData.MinimalDelayBetweenRuns,
                        _appOptData.MaximalDelayBetweenRuns) *1000);

                if (botRunsToSendList.Count == 1)
                {
                    currentRunType = botRunsToSendList[0];
                    botRunsToSendList.Clear();
                }
                else
                {
                    int randomIndexRunToTake = _randomValueProvider.GetRandomIntValue(0, botRunsToSendList.Count-1);
                    currentRunType = botRunsToSendList[randomIndexRunToTake];
                    botRunsToSendList.RemoveAt(randomIndexRunToTake);
                }

                if (previosBotRoute != DiffrentBotRoutesEnum.None)
                {
                    switch (previosBotRoute)
                    {
                        case DiffrentBotRoutesEnum.ChangeTabToNext:
                            await GoToWombatTabInBrowserAndClickItAsync();
                            break;
                        case DiffrentBotRoutesEnum.MinimaliseBrowser:
                            await GoToBrowserInWindowsBarAndClickItAsync();
                            break;
                        case DiffrentBotRoutesEnum.GoToAnotherWindow:
                            await GoToBrowserInWindowsBarAndClickItAsync();
                            break;
                    }
                    await GoToAcceptEndOfRunAncClickItAsync();
                }


                if (currentRunType != previousRunType)
                {
                    switch (currentRunType)
                    {
                        case BotRunTypeEnum.FiveMin:
                            await GoToChangeRunTimeAndClickItAsync();
                            await GoToFiveMinRunAndClickItAsync();
                            await GoToSendRunAfterTimeChangeAndClickItAsync();

                            break;
                        case BotRunTypeEnum.FifteenMin:
                            await GoToChangeRunTimeAndClickItAsync();
                            await GoToFivteenMinRunAndClickItAsync();
                            await GoToSendRunAfterTimeChangeAndClickItAsync();
                            break;
                        case BotRunTypeEnum.SixtyMin:
                            await GoToChangeRunTimeAndClickItAsync();
                            await GoToSixtyMinRunAndClickItAsync();
                            await GoToSendRunAfterTimeChangeAndClickItAsync();
                            break;
                    }
                }
                else
                {
                    await GoToSendWombatAndClickItAsync();
                }

               if (botRunsToSendList.Count == 0)
               {
                   return;
               }

                currentBotRoute = Enum.GetValues<DiffrentBotRoutesEnum>()
                [_randomValueProvider.GetRandomIntValue(0, 3)];
                switch (currentBotRoute)
                {
                    case DiffrentBotRoutesEnum.MinimaliseBrowser:
                        await GoToBrowserMinimaliseAndClickItAsync();
                        break;
                    case DiffrentBotRoutesEnum.GoToAnotherWindow:
                        await GoToNextWindowInBarAndClickItAsync();
                        break;
                    case DiffrentBotRoutesEnum.ChangeTabToNext:
                        await GoToNextTabInBrowserAndClickItAsync();
                        break;
                    default:
                        throw new InvalidOperationException("Nie ma takiej operacji po runie");
                }
                await GoToRandomPointOnScreenAsync();

                switch (currentRunType)
                {
                    case BotRunTypeEnum.FiveMin:
                        await  Task.Delay( _appOptData.FiveMinRunDuration * 1000);
                        break;
                    case BotRunTypeEnum.FifteenMin:
                        await Task.Delay(_appOptData.FivteenMinRunDuration * 1000);
                        break;
                    case BotRunTypeEnum.SixtyMin:
                        await  Task.Delay(_appOptData.SixtyMinuteRunDuration * 1000);
                        break;
                }
                previosBotRoute = currentBotRoute;
                previousRunType = currentRunType;
            }
        }, cancelationToken);
    }
    /*
    public async Task GoToRandomPointOnScreenAsync()
    {           
        var startingPoint = _mouseKeybordWraper.GetMousePos();
        var screenResulution = Screen.PrimaryScreen.Bounds;
        var endPoint = new Point(
            RandomNumberGenerator.GetInt32(0, screenResulution.Right),
            RandomNumberGenerator.GetInt32(0, screenResulution.Bottom));

        await _mouseMover.MoveMousePretendingHumanity((double)startingPoint.X,
        (double)startingPoint.Y, (double)endPoint.X, (double)endPoint.Y,
            RandomNumberGenerator.GetInt32((int)(100 * _appOptData.MinimalGravity), (int)(100 * _appOptData.MaximalGravity)) / 100,
            RandomNumberGenerator.GetInt32((int)(100 * _appOptData.MinimalWind), (int)(100 * _appOptData.MaximalWind)) / 100
            , 0);
    }
    */
    public async Task GoToRandomPointOnScreenAsync()
    {
       await _moveToButtonPoint.GoToRandomPointOnScreenAsync();
    }


}





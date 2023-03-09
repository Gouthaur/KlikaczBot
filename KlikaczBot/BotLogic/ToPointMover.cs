using KlikaczBot.BotLogic.BotLogicHelpers;
using KlikaczBot.MouseButtonInteractionsClasses;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPointToClickGenerators;
using KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;
using KlikaczBot.SavingOptionsInFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.BotLogic;

public class ToPointMover : IMoveToButtonPoint
{
    private readonly IButtonPointToClickGenerator _toClickGenerator;
    private readonly IMouseKeybordWraper _mouseKeybordWraper;
    private readonly IMouseMover _mouseMover;
    private readonly AppOptData _appOptData;
    private readonly IRandomValueProvider _randomValueProvider;

    public ToPointMover(IButtonPointToClickGenerator toClickGenerator, IMouseKeybordWraper mouseKeybordWraper,IMouseMover mouseMover,
        AppOptData appOptData, IRandomValueProvider randomValueProvider)
    {
        _toClickGenerator = toClickGenerator;
        _mouseKeybordWraper = mouseKeybordWraper;
        _mouseMover = mouseMover;
        _appOptData = appOptData;
        _randomValueProvider = randomValueProvider;
    }
    public async Task GoAncClickButtonAsync(ButtonPosSizeRecord buttonPos)
    {

        var startingPoint = _mouseKeybordWraper.GetMousePos();
        var endPoint = _toClickGenerator.GetButtonPointToClick(buttonPos);

        await _mouseMover.MoveMousePretendingHumanityAsync((double)startingPoint.X,
            (double)startingPoint.Y, (double)endPoint.X, (double)endPoint.Y,
            _randomValueProvider.GetRandomDoubleValue( _appOptData.MinimalGravity,_appOptData.MaximalGravity),
            _randomValueProvider.GetRandomDoubleValue(_appOptData.MinimalWind, _appOptData.MaximalWind)
            , 30);
        await _mouseKeybordWraper.ClickMouseLeftButton(endPoint,
            TimeSpan.FromMilliseconds(_randomValueProvider.GetRandomIntValue(_appOptData.MinimalDelayBeforeClick, _appOptData.MaximalDelayBeforeClick)),
            TimeSpan.FromMilliseconds(_randomValueProvider.GetRandomIntValue(_appOptData.MinimalClickTime, _appOptData.MaximalClickTime)),
            TimeSpan.FromMilliseconds(_randomValueProvider.GetRandomIntValue(_appOptData.MinimalDelayAfterClick, _appOptData.MaximalDelayAfterClick)));
    }

    public async Task GoToRandomPointOnScreenAsync()
    {

        var startingPoint = _mouseKeybordWraper.GetMousePos();
        var screenResulution = Screen.PrimaryScreen.Bounds;
        var endPoint = new Point(
            _randomValueProvider.GetRandomIntValue(0, screenResulution.Right),
            _randomValueProvider.GetRandomIntValue(0, screenResulution.Bottom));
        
        await _mouseMover.MoveMousePretendingHumanityAsync((double)startingPoint.X,
                       (double)startingPoint.Y, (double)endPoint.X, (double)endPoint.Y,
                       _randomValueProvider.GetRandomDoubleValue(_appOptData.MinimalGravity, _appOptData.MaximalGravity),
                       _randomValueProvider.GetRandomDoubleValue(_appOptData.MinimalWind, _appOptData.MaximalWind)
                       , 30);
    }
}

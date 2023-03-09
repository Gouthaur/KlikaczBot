using KlikaczBot.BotLogic.BotLogicHelpers;
using KlikaczBot.SavingOptionsInFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;

public class WindMover2 : IMouseMover
{
    private readonly AppOptData _appOptData;
    private readonly IMouseKeybordWraper _mouseKeybordWraper;
    private readonly IRandomValueProvider _randomValueProvider;

    public WindMover2(AppOptData appOptData,IMouseKeybordWraper mouseKeybordWraper, IRandomValueProvider randomValueProvider)
    {
        _appOptData = appOptData;
        _mouseKeybordWraper = mouseKeybordWraper;
        _randomValueProvider = randomValueProvider;
    }


    //10.0 / randomSpeed, 15.0 / randomSpeed, 10.0 * randomSpeed, 10.0 * randomSpeed

    public async Task MoveMousePretendingHumanityAsync(double startPointX, double startPointY, double endPointX, double endPointY, double gravity, double wind, double targetArea)
    {
        double randomSpeed = _randomValueProvider.GetRandomDoubleValue(_appOptData.MinimalMouseSpeedValue, _appOptData.MaximalMouseSpeedValue);
        double maxWait = 10.0 / randomSpeed;
        double minWait = 15.0 / randomSpeed;
        double maxStep = 10.0 * randomSpeed;
        targetArea = 10.0 * randomSpeed;
        double dist, windX = 0, windY = 0, veloX = 0, veloY = 0, randomDist, veloMag, step;
        int oldX, oldY, newX = (int)Math.Round(startPointX), newY = (int)Math.Round(startPointY);

        double waitDiff = maxWait - minWait;
        double sqrt2 = Math.Sqrt(2.0);
        double sqrt3 = Math.Sqrt(3.0);
        double sqrt5 = Math.Sqrt(5.0);

        dist = Hypot(endPointX - startPointX, endPointY - startPointY);

        while (dist > 1.0)
        {

            wind = Math.Min(wind, dist);

            if (dist >= targetArea)
            {
                int w = _randomValueProvider.GetRandomIntValue(0,(int)Math.Round(wind) * 2 + 1);
                windX = windX / sqrt3 + (w - wind) / sqrt5;
                windY = windY / sqrt3 + (w - wind) / sqrt5;
            }
            else
            {
                windX = windX / sqrt2;
                windY = windY / sqrt2;
                if (maxStep < 3)
                    maxStep = _randomValueProvider.GetRandomIntValue(0, 3) + 3.0;
                else
                    maxStep = maxStep / sqrt5;
            }

            veloX += windX;
            veloY += windY;
            veloX = veloX + gravity * (endPointX - startPointX) / dist;
            veloY = veloY + gravity * (endPointY - startPointY) / dist;

            if (Hypot(veloX, veloY) > maxStep)
            {
                randomDist = maxStep / 2.0 + _randomValueProvider.GetRandomIntValue(0,(int)Math.Round(maxStep) / 2);
                veloMag = Hypot(veloX, veloY);
                veloX = (veloX / veloMag) * randomDist;
                veloY = (veloY / veloMag) * randomDist;
            }

            oldX = (int)Math.Round(startPointX);
            oldY = (int)Math.Round(startPointY);
            startPointX += veloX;
            startPointY += veloY;
            dist = Hypot(endPointX - startPointX, endPointY - startPointY);
            newX = (int)Math.Round(startPointX);
            newY = (int)Math.Round(startPointY);

            if (oldX != newX || oldY != newY)
                _mouseKeybordWraper.MoveMouseToPoint( new Point (newX, newY));

            step = Hypot(startPointX - oldX, startPointY - oldY);
            int wait = (int)Math.Round(waitDiff * (step / maxStep) + minWait);
            await Task.Delay(wait);
        }

        int endX = (int)Math.Round(endPointX);
        int endY = (int)Math.Round(endPointY);
        if (endX != newX || endY != newY)
            _mouseKeybordWraper.MoveMouseToPoint(new Point(endX, endY));

       
    }


    static double Hypot(double dx, double dy)
    {
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

using KlikaczBot.SavingOptionsInFile;
using PInvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;

public class WindMouseMover : IMouseMover
{
    public WindMouseMover(AppOptData appOptData)
    {
       _appOptData = appOptData;

    }

    private readonly AppOptData _appOptData;
    private double _mouseSpeed =45.5;
   

    private static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public static double Hypot(double x, double y)
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }

    public async Task MoveMousePretendingHumanityAsync(double startPointX, double startPointY, double endPointX, double endPointY, double gravity, double wind,
         double targetArea)
    {
        double veloX = 0,
            veloY = 0,
            windX = 0,
            windY = 0;

        var msp = _mouseSpeed; // (double)RandomNumberGenerator.GetInt32((int)(_appOptData.MinimalMouseSpeedValue * 100), (int)(_appOptData.MaximalMouseSpeedValue * 100)) / 100; 
        var sqrt2 = Math.Sqrt(2);
        var sqrt3 = Math.Sqrt(3);
        var sqrt5 = Math.Sqrt(5);

        var tDist = (int)Distance(Math.Round(startPointX), Math.Round(startPointY), Math.Round(endPointX), Math.Round(endPointY));
        var t = (uint)(Environment.TickCount + 10000);
        await Task.Run( async () =>
        {
            do
            {
                if (Environment.TickCount > t)
                    break;

                var dist = Hypot(startPointX - endPointX, startPointY - endPointY);
                wind = Math.Min(wind, dist);

                if (dist < 1)
                    dist = 1;

                var d = (Math.Round(Math.Round((double)tDist) * 0.3) / 7);

                if (d > 25)
                    d = 25;

                if (d < 5)
                    d = 5;

                double rCnc = RandomNumberGenerator.GetInt32(6);

                if (rCnc == 1)
                    d = 2;

                double maxStep;

                if (d <= Math.Round(dist))
                    maxStep = d;
                else
                    maxStep = Math.Round(dist);

                if (dist >= targetArea)
                {
                    windX = windX / sqrt3 + (RandomNumberGenerator.GetInt32((int)(Math.Round(wind) * 2 + 1)) - wind) / sqrt5;
                    windY = windY / sqrt3 + (RandomNumberGenerator.GetInt32((int)(Math.Round(wind) * 2 + 1)) - wind) / sqrt5;
                }
                else
                {
                    windX = windX / sqrt2;
                    windY = windY / sqrt2;
                }

                veloX = veloX + windX;
                veloY = veloY + windY;
                veloX = veloX + gravity * (endPointX - startPointX) / dist;
                veloY = veloY + gravity * (endPointY - startPointY) / dist;

                if (Hypot(veloX, veloY) > maxStep)
                {
                    var randomDist = maxStep / 2.0 + RandomNumberGenerator.GetInt32((int)(Math.Round(maxStep) / 2));
                    var veloMag = Math.Sqrt(veloX * veloX + veloY * veloY);
                    veloX = (veloX / veloMag) * randomDist;
                    veloY = (veloY / veloMag) * randomDist;
                }

                var lastX = (int)Math.Round(startPointX);
                var lastY = (int)Math.Round(startPointY);
                startPointX = startPointX + veloX;
                startPointY = startPointY + veloY;

                if (lastX != Math.Round(startPointX) || (lastY != Math.Round(startPointY)))
                    User32.SetCursorPos(Convert.ToInt32(startPointX), Convert.ToInt32(startPointY));

                var w = (RandomNumberGenerator.GetInt32((int)(Math.Round((double)(100 / msp)))) * 6);

                if (w < 5)
                    w = 5;

                w = (int)Math.Round(w * 0.9);
                await Task.Delay(w);
            } while (!(Hypot(startPointX - endPointX, startPointY - endPointY) < 1));
        });
        if (Math.Round(endPointX) != Math.Round(startPointX) || (Math.Round(endPointY) != Math.Round(startPointY)))
            User32.SetCursorPos(Convert.ToInt32(endPointX), Convert.ToInt32(endPointY));

        _mouseSpeed = msp;
      
    }
}

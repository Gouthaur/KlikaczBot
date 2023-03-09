using KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses.HumanMouseMoveSimulator;

public class WraperHWMM : IMouseMover
{
    public async Task MoveMousePretendingHumanityAsync(double startPointX, double startPointY, double endPointX, double endPointY, double gravity, double wind, double targetArea)
    {
        await Task.Run(() =>
        {
            HWMM.MoveMouse(endPointX, endPointY, () => { });
        });
    }
}

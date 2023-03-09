using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses.ButtonPosition.Unsused;

public class ButtonPositionFromMouse : IButtonPositionGette
{
    private IMouseKeybordWraper _MouseKeyboardWraper;

    public ButtonPositionFromMouse(IMouseKeybordWraper mouseWraper)
    {
        _MouseKeyboardWraper = mouseWraper;
    }

    public ButtonPosSizeRecord GetButtonPosFromMouse()
    {
        throw new NotImplementedException();
    }

    public async Task<ButtonPosSizeRecord> GetButtonPosFromMouseAsync(int timeoutMiniSec)
    {
        CancellationTokenSource cancelAfterTime = new();
        cancelAfterTime.CancelAfter(timeoutMiniSec);
        Point firstMousePosition = new();
        Point secondtMousePosition = new();

        try
        {
            await Task.Run(async () =>
            {
                while (!_MouseKeyboardWraper.CheckIfKeyIsPressed(113))
                {
                    await Task.Delay(50);
                }
                firstMousePosition = _MouseKeyboardWraper.GetMousePos();


            }, cancelAfterTime.Token);
            await Task.Delay(1000);
            await Task.Run(async () =>
            {
                while (!_MouseKeyboardWraper.CheckIfKeyIsPressed(113))
                {
                    await Task.Delay(50);
                }
                secondtMousePosition = _MouseKeyboardWraper.GetMousePos();
            }, cancelAfterTime.Token);
        }
        catch (TaskCanceledException ex)
        {
            throw new InvalidOperationException("Czas na klawisza enter minoł", ex);
        }

        return new ButtonPosSizeRecord(firstMousePosition.X, firstMousePosition.Y,
            Math.Abs(firstMousePosition.X - secondtMousePosition.X),
            Math.Abs(firstMousePosition.Y - secondtMousePosition.Y)
            );
    }


}

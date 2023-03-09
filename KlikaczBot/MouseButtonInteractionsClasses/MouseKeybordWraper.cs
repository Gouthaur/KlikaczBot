
using PInvoke;
using System.Security.Cryptography;

namespace KlikaczBot.MouseButtonInteractionsClasses;

public class MouseKeybordWraper : IMouseKeybordWraper
{
    public bool CheckIfLeftMouseButtonIsPressed()
    {
        if (User32.GetKeyState(0x01) == 0)
        {
            return false;
        }
        return true;
    }
    public bool CheckIfRightMouseButtonIsPressed()
    {

        if (User32.GetKeyState(0x02) == 0)
        {
            return false;
        }
        return true;
    }

    public void MoveMouseToPoint(Point point)
    {
        User32.mouse_event(User32.mouse_eventFlags.MOUSEEVENTF_MOVE, point.X, point.Y, 0, 0);                   
    }
    // 13 - ENTER 

    public bool CheckIfKeyIsPressed(int key)
    {

        short v = User32.GetKeyState(key);
        if (v == 1)
        {
            return true;
        }
        return false;
    }

    public Point GetMousePos()
    {          
        User32.GetCursorPos(out var pos);
        return new Point(pos.x,pos.y);            
    }

    public async Task ClickMouseLeftButton(Point point, TimeSpan delayBeforeClick, TimeSpan delayDuringClick, TimeSpan delayAfterClick)
    {
        await Task.Delay(delayBeforeClick);
        User32.mouse_event(User32.mouse_eventFlags.MOUSEEVENTF_LEFTDOWN,point.X,point.Y,0,0);
        await Task.Delay(delayDuringClick);
        User32.mouse_event(User32.mouse_eventFlags.MOUSEEVENTF_LEFTUP, point.X, point.Y, 0, 0);
        await Task.Delay(delayDuringClick);
    }
}
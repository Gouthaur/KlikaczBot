namespace KlikaczBot.MouseButtonInteractionsClasses;

public interface IMouseKeybordWraper
{
    bool CheckIfKeyIsPressed(int key);
    bool CheckIfLeftMouseButtonIsPressed();
    bool CheckIfRightMouseButtonIsPressed();
    Task ClickMouseLeftButton(Point point, TimeSpan delayBeforeClick, TimeSpan delayDuringClick, TimeSpan delayAfterClick);
    Point GetMousePos();
    void MoveMouseToPoint(Point point);
   
}
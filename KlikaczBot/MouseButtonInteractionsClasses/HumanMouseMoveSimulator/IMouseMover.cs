namespace KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;

public interface IMouseMover
{
    Task MoveMousePretendingHumanityAsync(double startPointX, double startPointY, double endPointX, double endPointY, double gravity, double wind, double targetArea);
}
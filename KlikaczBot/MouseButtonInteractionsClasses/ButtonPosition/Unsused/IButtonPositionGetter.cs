namespace KlikaczBot.MouseButtonInteractionsClasses.ButtonPosition.Unsused;

public interface IButtonPositionGette
{
    Task<ButtonPosSizeRecord> GetButtonPosFromMouseAsync(int timeoutMiniSec);
    ButtonPosSizeRecord GetButtonPosFromMouse();
}
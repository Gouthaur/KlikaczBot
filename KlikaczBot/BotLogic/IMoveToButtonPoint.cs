using KlikaczBot.MouseButtonInteractionsClasses;

namespace KlikaczBot.BotLogic;

public interface IMoveToButtonPoint
{
    Task GoAncClickButtonAsync(ButtonPosSizeRecord buttonPos);
    Task GoToRandomPointOnScreenAsync();
}
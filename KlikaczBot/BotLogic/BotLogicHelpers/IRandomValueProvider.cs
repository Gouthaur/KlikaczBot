namespace KlikaczBot.BotLogic.BotLogicHelpers;

public interface IRandomValueProvider
{
    int GetRandomIntValue(int minimalInclusive,int maximalExclusive);
    double GetRandomDoubleValue(double minimalInclusive, double maximalExclusive);

    int GetRandomMilisecondFromDateTime(DateTime minimalInclusive, DateTime maximalExclusive);

}
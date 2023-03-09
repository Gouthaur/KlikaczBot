using KlikaczBot.SavingOptionsInFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.BotLogic.BotLogicHelpers;

public class CryptoSafeRandomValueProvider : IRandomValueProvider
{
    public double GetRandomDoubleValue(double minimalInclusive, double maximalExclusive)
    {
        return Convert.ToDouble(RandomNumberGenerator.GetInt32((int)(minimalInclusive * 1000), (int)(maximalExclusive* 1000))/1000);
    }

    public int GetRandomIntValue(int minimalInclusive, int maximalExclusive)
    {
        return RandomNumberGenerator.GetInt32(minimalInclusive, maximalExclusive);
    }

    public int GetRandomMilisecondFromDateTime(DateTime minimalInclusive, DateTime maximalExclusive)
    {
        return RandomNumberGenerator.GetInt32(
            minimalInclusive.Hour * 360000 + minimalInclusive.Minute * 6000 + minimalInclusive.Second * 100 + minimalInclusive.Millisecond,
            maximalExclusive.Hour * 360000 + maximalExclusive.Minute * 6000 + maximalExclusive.Second * 100 + maximalExclusive.Millisecond );
    }
}

namespace KlikaczBot.SavingOptionsInFile.JsonSerialser;

public interface IJsonSerlizer
{
    public void SaveOptionsOnSystem(AppOptData options, string filePath);
    public AppOptData LoadOptionsOnSystem(string filePath);
}
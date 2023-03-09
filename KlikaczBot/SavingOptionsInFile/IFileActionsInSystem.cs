namespace KlikaczBot.SavingOptionsInFile;

public interface IFileActionsInSystem
{
    public void SaveFileInSystem(string file, string filePath);
    public string OpenFileFromSystem(string filePath);

    public bool CheckIfFileExsit(string filePath);
}
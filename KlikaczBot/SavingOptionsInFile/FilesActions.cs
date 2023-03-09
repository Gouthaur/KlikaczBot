using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KlikaczBot.SavingOptionsInFile;

public class FilesActions : IFileActionsInSystem
{
    public bool CheckIfFileExsit(string filePath)
    {
        if (File.Exists(filePath))
        {
            return true;
        }
        return false;                
    }

    public string OpenFileFromSystem(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public void SaveFileInSystem(string file, string filePath)
    {
        File.Delete(filePath);
        File.AppendAllText(filePath, file);
    }
}

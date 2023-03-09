using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using PuppeteerSharp;

namespace KlikaczBot.SavingOptionsInFile.JsonSerialser;

public class JsonSerialsierJsoNewsoft : IJsonSerlizer
{
    public JsonSerialsierJsoNewsoft(IFileActionsInSystem filesActions)
    {
        _filesActions = filesActions;
    }

    private IFileActionsInSystem _filesActions { get; }

    public AppOptData LoadOptionsOnSystem(string filePath)
    {
        if (!_filesActions.CheckIfFileExsit(filePath))
        {
           return new AppOptData();
        }
        var fileString= _filesActions.OpenFileFromSystem(filePath);
        var appOptData = JsonConvert.DeserializeObject<AppOptData>(fileString);
        if (appOptData == null)
        {
            throw new InvalidOperationException("Nie odczytano pliku z opcjami");  
        }
        return appOptData; 
    }
    public void SaveOptionsOnSystem(AppOptData options, string filePath)
    {
        _filesActions.SaveFileInSystem(JsonConvert.SerializeObject(options,Formatting.Indented),filePath);
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses;

[JsonObject(MemberSerialization.OptIn)]
public class BotButtons
{
    public BotButtons()
    {
        ButtonsList = new(12) { null,null,null,null, null, null, null, null, null, null, null, null };
    }
    
    private ButtonPosSizeRecord? _sendWombat;
    [JsonProperty("Przycisk wyslij wombata")]
    public ButtonPosSizeRecord? SendWombat
    {
        get
        {
            return _sendWombat;
        }
        set
        {
            _sendWombat = value;
            ButtonsList[0] = _sendWombat;               
        }
    }
    
    private ButtonPosSizeRecord? _acceptEndOfRun;
    [JsonProperty("Przycisk akceptuj koniec runa")]
    public ButtonPosSizeRecord? AcceptEndOfRun 
    {
        get
        {
            return _acceptEndOfRun;
        }
        set
        {               
            _acceptEndOfRun = value;
            ButtonsList[1] = _acceptEndOfRun;                
        }        
    }
    
    private ButtonPosSizeRecord? _changeRunTime;
    [JsonProperty("Przycisk zmiany czasu")]
    public ButtonPosSizeRecord? ChangeRunTime 
    {
        get
        {
            return _changeRunTime;
        }
        set
        {
            
            _changeRunTime = value;
            ButtonsList[2] = _changeRunTime;              
        }
    }
    private ButtonPosSizeRecord? _fiveMinRun;
    [JsonProperty("Przycisk 5 min")]
    public ButtonPosSizeRecord? FiveMinRun
    {
        get
        {
            return _fiveMinRun;
        }
        set
        {
           _fiveMinRun = value;
           ButtonsList[3] = _fiveMinRun;
        }
    }
    
    private ButtonPosSizeRecord? _fivteenMinRun;
    [JsonProperty("Przycisk 15 min")]
    public ButtonPosSizeRecord?  FivteenMinRun 
    {
        get
        {
            return _fivteenMinRun;
        }
        set
        {
            
           _fivteenMinRun = value;
           ButtonsList[4] = _fivteenMinRun;                
        }
    }

    private ButtonPosSizeRecord? _sixtyMinRun;
    [JsonProperty("Przycisk 60 min")]
    public ButtonPosSizeRecord? SixtyMinRun
    {
        get
        {
            return _sixtyMinRun;
        }
        set
        {
            
            _sixtyMinRun = value;
            ButtonsList[5] = _sixtyMinRun;
            
        }
    }
    
    private ButtonPosSizeRecord? _wombatTabInBrowser;
    [JsonProperty("Przycisk wombat taba w przegladarce")]
    public ButtonPosSizeRecord? WombatTabInBrowser 
    {
        get
        {
            return _wombatTabInBrowser;
        }
        set
        {
            _wombatTabInBrowser = value;
            ButtonsList[6] = _wombatTabInBrowser;
        }    
    }
    
    private ButtonPosSizeRecord? _nextTabInBrowser;
    [JsonProperty("Przycisk nastepny tab w przegladarce")]
    public ButtonPosSizeRecord? NextTabInBrowser
    {
        get
        {
            return _nextTabInBrowser;
        }
        set
        {
            _nextTabInBrowser = value;
            ButtonsList[7] = _nextTabInBrowser;
        }
    }
    
    private ButtonPosSizeRecord? _browserInWindowsBar;
    [JsonProperty("Przycisk przegladarki na pasku systemu")]
    public ButtonPosSizeRecord?  BrowserInWindowsBar
    {
        get
        {
            return _browserInWindowsBar;
        }
        set
        {
            _browserInWindowsBar = value;
            ButtonsList[8] = _browserInWindowsBar;                
        }
    }
    
    private ButtonPosSizeRecord? _browserMinimalise;
    [JsonProperty("Przycisk minimalalizacji przegladarki")]
    public ButtonPosSizeRecord? BrowserMinimalise
    {
        get
        {
            return _browserMinimalise;
        }
        set
        {
            _browserMinimalise = value;
            ButtonsList[9] = _browserMinimalise;                
        }
    }

    private ButtonPosSizeRecord? _sendRunAfterTimeChange;
    [JsonProperty("Przycisk wyslania womabata po zmianie czasu")]
    public ButtonPosSizeRecord? SendRunAfterTimeChange
    {
        get
        {
            return _sendRunAfterTimeChange;
        }
        set
        {
            _sendRunAfterTimeChange = value;
            ButtonsList[10] = _sendRunAfterTimeChange;
        }
    }

    private ButtonPosSizeRecord? _nextWindowInBar;
    [JsonProperty("Przycisk nastepny program w pasku stanu")]
    public ButtonPosSizeRecord? NextWindowInBar

    {
        get
        {
            return _nextWindowInBar;
        }
        set
        {
            _nextWindowInBar = value;
            ButtonsList[11] = _nextWindowInBar;
        }
    }

    public List<ButtonPosSizeRecord?> ButtonsList { get; private set; }
}

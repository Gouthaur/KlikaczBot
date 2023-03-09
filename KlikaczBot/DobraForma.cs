using KlikaczBot.MouseButtonInteractionsClasses;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPosition;
using KlikaczBot.SavingOptionsInFile;
using KlikaczBot.SavingOptionsInFile.JsonSerialser;
using static KlikaczBot.MouseButtonInteractionsClasses.ButtonPosition.ButtonSizeFromMouseAndKeybordFormEvents;
using  KlikaczBot.StaticHelpersMethods;
using System.Windows.Forms;
using System.Diagnostics;
using KlikaczBot.BotLogic;
using KlikaczBot.MouseButtonInteractionsClasses.MouseMoveSimulator;
using KlikaczBot.MouseButtonInteractionsClasses.ButtonPointToClickGenerators;
using KlikaczBot.BotLogic.BotLogicHelpers;
using KlikaczBot.MouseButtonInteractionsClasses.HumanMouseMoveSimulator;

namespace KlikaczBot;

public partial class DobraForma : Form
{     
    public DobraForma()
    {
        InitializeComponent();
        _appOptions = new();      
                   
        _fileActionsInSystem = new FilesActions();
        _jsonSerlizer = new JsonSerialsierJsoNewsoft(_fileActionsInSystem);
        
        _appOptions = _jsonSerlizer.LoadOptionsOnSystem(_appOptionsFilePath);
        if (_appOptions == null)
        {
            throw new InvalidOperationException("Nie został stworzony obiekt opcji (brak odczytu z pliku opcji)");
        }

        if (_appOptions.ButtonPositions == null)
        {
            _appOptions.ButtonPositions = new();
        }
        if (_appOptions.ButtonPositions.ButtonsList.Count == 20)
        {
            _appOptions.ButtonPositions.ButtonsList.RemoveRange(10, 10);
        }
               

        _nUpDownStamine.Value = 2000;
        _stamineLeft = 2000;
        MouseKeybordWraper mouseKeybordWraper = new();
        _buttonPosGetterFromFromEvents = new(mouseKeybordWraper);          
        this.KeyPreview = true;
        _calibrationButtonsList = new() {_btnCalibrateSendRun, _btnCalibrateAceptEnedRun, _btnCalibrateChangeTime,
            _btnCalibrateFiveMinuteRunBtn, _btnCalibrateFifteenMinuteRunBtn, _btnCalibrateSixtyMinuteRunBtn, _btnCalibrateTabWombatInBrowser, _btnCalibrateNextTabInBrowser,
        _btnCalibrateMaxBrowserWindow,_btnCalibrateBrowserMinimalisationButton,_btnCalibrateSendRunAfterTimeChange,_btnCalibrateNexWindowInBar};

        IButtonPointToClickGenerator buttonPointToClickGenerator = new RandomPointFormButtonPositionGenerator(); 
        IRandomValueProvider randomValueProvider = new CryptoSafeRandomValueProvider();
        //IMouseMover windMouseMover = new WindMover2(_appOptions,mouseKeybordWraper,randomValueProvider);
        IMouseMover windMouseMover = new WraperHWMM();

        IMoveToButtonPoint moveToButtonPoint = new ToPointMover(buttonPointToClickGenerator,mouseKeybordWraper,windMouseMover, _appOptions,randomValueProvider);
        _botLogic = new BotAlgorithm(_appOptions, moveToButtonPoint, randomValueProvider);
        ShowIfButtonsAreCalibrated();
        _btnCancel.Enabled= false;
    }
    
    private readonly string _appOptionsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"BotKlikaczData.json"); 
    private IFileActionsInSystem _fileActionsInSystem;
    private IJsonSerlizer _jsonSerlizer;
    private AppOptData _appOptions;

    private int _procentageOf5MinRun;
    private int _procentageOf15MinRun;
    private int _procentageOf60MinRun;
    private int _stamineLeft;
    private int _stamineCost5Min = 5;
    private int _stamineCost15Min = 12;
    private int _stamineCost60Min = 30;       
    
    private List<Button> _calibrationButtonsList;
    private ButtonsToCalibrate _buttonsToCalibrate = ButtonsToCalibrate.None;
    private ButtonSizeFromMouseAndKeybordFormEvents _buttonPosGetterFromFromEvents;
    private IBotLogic _botLogic;

                  
    private void ShowIfButtonsAreCalibrated()
    {
        for (int i = 0; i < _appOptions.ButtonPositions.ButtonsList.Count; i++)
        {
            if (_appOptions.ButtonPositions.ButtonsList[i] == null)
            {
                _calibrationButtonsList[i].BackColor = Color.Red;
            }
            else
            {
                _calibrationButtonsList[i].BackColor = Color.Green;
            }
        }
    }

    private bool CheckIfRunsProcentageIsBiggerThen100()
    {
        if (_nUpDown5MinRuns.Value + _nUpDown15MinRuns.Value + _nUpDown60MinRuns.Value > 100)
        {
            return true;
        }
        return false;
    }
    
    private void _nUpDown5MinRuns_ValueChanged(object sender, EventArgs e)
    {           
        if (CheckIfRunsProcentageIsBiggerThen100())
        {
            _nUpDown5MinRuns.Value = 100 - _nUpDown15MinRuns.Value - _nUpDown60MinRuns.Value;
        }
        _procentageOf5MinRun = Convert.ToInt32(_nUpDown5MinRuns.Value);
    }

    private void _nUpDown15MinRuns_ValueChanged(object sender, EventArgs e)
    {            
        if (CheckIfRunsProcentageIsBiggerThen100())
        {
            _nUpDown15MinRuns.Value = 100 - _nUpDown5MinRuns.Value - _nUpDown60MinRuns.Value;
        }
        _procentageOf15MinRun = Convert.ToInt32(_nUpDown15MinRuns.Value);
    }

    private void _nUpDown60MinRuns_ValueChanged(object sender, EventArgs e)
    {           
        if (CheckIfRunsProcentageIsBiggerThen100())
        {
            _nUpDown60MinRuns.Value = 100 - _nUpDown15MinRuns.Value - _nUpDown5MinRuns.Value;
        }
        _procentageOf60MinRun = Convert.ToInt32(_nUpDown60MinRuns.Value);
    }

    private bool CheckIfStaminaIsEnough()
    {
        if (_procentageOf5MinRun > 0 && _stamineLeft < _stamineCost5Min ||
            _procentageOf15MinRun > 0 && _stamineLeft < _stamineCost15Min ||
            _procentageOf60MinRun > 0 && _stamineLeft < _stamineCost60Min
            )
        {
            return false;
        }
        return true;
    }

    private void _btnStartClicker_Click(object sender, EventArgs e)
    {
        _labErrorsMainTab.Text = string.Empty;
        if (_procentageOf5MinRun + _procentageOf15MinRun + _procentageOf60MinRun != 100)
        {
            _labErrorsMainTab.Text = "Procenty wyprawek muszą wynosić łącznie 100%";
            return;
        }
        if (!CheckIfStaminaIsEnough())
        {
            _labErrorsMainTab.Text = "Za mało staminy do puszczenie wyprawek";
            return;
        }


        try
        {
            var result = _botLogic.StartBotAsync(_procentageOf5MinRun, _procentageOf15MinRun, _procentageOf60MinRun, _stamineLeft);
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
            {
                    throw ex;                   
            }
        }

    }
    private void _nUpDownStamine_ValueChanged(object sender, EventArgs e)
    {
        _stamineLeft = Convert.ToInt32(_nUpDownStamine.Value);
    }

    private void _btnStopClicker_Click(object sender, EventArgs e)
    {
        _botLogic.CancelOperation.Cancel();
    }


    System.Timers.Timer TimerForCalibrate = new(10000);
    
    private void ActionsAfterCalibrateButtonClick(ButtonsToCalibrate calibratedButton)
    {

        TimerForCalibrate.Elapsed += TimerForCalibrate_Elapsed;
        TimerForCalibrate.Start();
        _buttonsToCalibrate = calibratedButton;
        this.KeyDown += DobraForma_KeyDown;
        _calibrationButtonsList.ForEach(button => { button.Enabled= false; });
        _btnCancel.Enabled = true; 

    }
    
    private  void _btnCalibrateSendRun_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku wysłania wyprawki";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.SendWombat);
    }

    private void _btnCalibrateAceptEnedRun_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku konca wyprawki";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.AcceptEndOfRun);
    }
    private void _btnCalibrateChangeTime_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku zmiany czasu wyprawki";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.ChangeRunTime);
    }

    private void _btnCalibrateFiveMinuteRunBtn_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku zmiany czasu na 5 min";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.FiveMinRun);
    }

    private void _btnCalibrateFifteenMinuteRunBtn_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku zmiany czasu na 15 min";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.FivteenMinRun);
    }

    private void _btnCalibrateSixtyMinuteRunBtn_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku zmiany czasu na 60 min";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.SixtyMinRun);
    }

    private void _btnCalibrateTabWombatInBrowser_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku zmiany czasu na 5 min";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.WombatTabInBrowser);
    }

    private void _btnCalibrateNextTabInBrowser_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku zmiany na następny tab w przeglądarce";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.NextTabInBrowser);
    }

    private void _btnCalibrateMaxBrowserWindow_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku przegladarki na dolnym pasku windowsa";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.BrowserInWindowsBar);
    }

    private void _btnCalibrateBrowserMinimalisationButton_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku minimalizacji przeglądarki";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.BrowserMinimaliseButton);
    }



    private void TimerForCalibrate_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        _buttonPosGetterFromFromEvents.Reset();
        TimerForCalibrate.Stop();
        this.KeyDown -= DobraForma_KeyDown;
        this.BeginInvoke(new Action(() =>
        {
            _calibrationButtonsList.ForEach(button => { button.Enabled = true; });
            _labCalibrationButtons.Text = "";
            _btnCancel.Enabled = false;
        }));           
    }           
        
    private void CalibratingOperations(ButtonsToCalibrate calibratedButton,Action buttonValueAssigment)
    {
        if (_buttonPosGetterFromFromEvents.CalibrationStep == CalibrationSteps.FirstPoint)
        {
            _buttonPosGetterFromFromEvents.CalibratePosFromMouse();
        }
        else
        {
            _buttonPosGetterFromFromEvents.CalibratePosFromMouse();
            buttonValueAssigment.Invoke();
            TimerForCalibrate.Stop();
            _buttonPosGetterFromFromEvents.Reset();
            this.KeyDown -= DobraForma_KeyDown;
            _calibrationButtonsList.ForEach(button => { button.Enabled = true; });
            ShowIfButtonsAreCalibrated();
        }
    }
    private void DobraForma_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F2)
        {
            switch (_buttonsToCalibrate) 
            {
                case ButtonsToCalibrate.SendWombat:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.SendWombat = _buttonPosGetterFromFromEvents.CalibratedButton;
                    } );
                    break;
                
                case ButtonsToCalibrate.AcceptEndOfRun:
                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.AcceptEndOfRun = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.ChangeRunTime:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.ChangeRunTime = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.FiveMinRun:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.FiveMinRun = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.FivteenMinRun:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.FivteenMinRun = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.SixtyMinRun:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.SixtyMinRun = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.WombatTabInBrowser:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.WombatTabInBrowser = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.NextTabInBrowser:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.NextTabInBrowser = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.BrowserInWindowsBar:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.BrowserInWindowsBar = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.BrowserMinimaliseButton:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.BrowserMinimalise = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.SendRunAfterTimeChange:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.SendRunAfterTimeChange = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;
                case ButtonsToCalibrate.NextWindowInBar:

                    CalibratingOperations(_buttonsToCalibrate, () =>
                    {
                        _appOptions.ButtonPositions.NextWindowInBar = _buttonPosGetterFromFromEvents.CalibratedButton;
                    });
                    break;


                case ButtonsToCalibrate.None:
                    break;
                default:
                    throw new InvalidOperationException("Nie ma takeigo przycisku");
            }
        }
    }

    private void _btnCancel_Click(object sender, EventArgs e)
    {
        _buttonPosGetterFromFromEvents.Reset();
        TimerForCalibrate.Stop();
        this.KeyDown -= DobraForma_KeyDown;
        _calibrationButtonsList.ForEach(button => { button.Enabled = true; });
        _labCalibrationButtons.Text = "";
    }

    enum ButtonsToCalibrate
    {
        None,
        SendWombat,
        AcceptEndOfRun,
        ChangeRunTime,
        FiveMinRun,
        FivteenMinRun,
        SixtyMinRun,
        WombatTabInBrowser,
        NextTabInBrowser,
        BrowserInWindowsBar,
        BrowserMinimaliseButton,
        SendRunAfterTimeChange,
        NextWindowInBar
    }
   
    private void DobraForma_FormClosed(object sender, FormClosedEventArgs e)
    {
        _jsonSerlizer.SaveOptionsOnSystem(_appOptions, _appOptionsFilePath);
    }    

    private void _btnCalibrateSendRunAfterTimeChange_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja przycisku wysłąnie runa po zmianie czasu";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.SendRunAfterTimeChange);
    }

    private void _btnCalibrateNextWindowInBar_Click(object sender, EventArgs e)
    {
        _labCalibrationButtons.Text = "Kalibracja następnego okna po przegladarce na pasku stanu";
        ActionsAfterCalibrateButtonClick(ButtonsToCalibrate.NextWindowInBar);
    }
}

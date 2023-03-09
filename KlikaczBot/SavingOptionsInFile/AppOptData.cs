using KlikaczBot.MouseButtonInteractionsClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.SavingOptionsInFile;

[JsonObject(MemberSerialization.OptIn)]
public class AppOptData
{
    [JsonProperty("Pozycja przyciskow")]
    public BotButtons ButtonPositions { get; set; }
    
    [JsonProperty("Czas trwania 5 min -sec")]
    public int FiveMinRunDuration { get; set; }
    
    [JsonProperty("Czas trwania 15 -sec")]
    public int FivteenMinRunDuration { get; set; }
    
    [JsonProperty("Czas trwania 60 -sec ")] 
    public int SixtyMinuteRunDuration { get; set; }
    
    [JsonProperty("Minimalne opoznienie miedzy runami")]
    public int MinimalDelayBetweenRuns { get; set; }
    
    [JsonProperty("Maksymalne opuznienie miedzy runami")] 
    public int MaximalDelayBetweenRuns { get; set; }
    
    [JsonProperty("Maksymalna grawitacja")]
    public double MaximalGravity { get; set; }
    
    [JsonProperty("Minimalna grawitacja")]
    public double MinimalGravity { get; set; }
    
    [JsonProperty("Minimalny wiatr")]
    public double MinimalWind { get; set; }
    
    [JsonProperty("Maksymalny wiatr")]
    public double MaximalWind { get; set;}
    
    [JsonProperty("Minimalne opuznienie przed kilknieciem -ms ")]
    public int MinimalDelayBeforeClick { get; set; }
    [JsonProperty("Maksymalne opuznienie przed kilknieciem -ms ")]
    public int MaximalDelayBeforeClick { get; set; }
    [JsonProperty("Minimalny czas przytrzymania przycisku myszy podczas klikniecia -ms")]
    public int MinimalClickTime { get; set; }
    [JsonProperty("Maksmalny czas przytrzymania przycisku myszy podczas klikniecia -ms")]
    public int MaximalClickTime { get; set; }
    [JsonProperty("Minimalny czas opuznienia po kliknięciu -ms")]
    public int MinimalDelayAfterClick { get; set; }
    [JsonProperty("Maksymalny czas opuznienia po kliknięciu -ms")]
    public int MaximalDelayAfterClick { get; set; }
    [JsonProperty("Koszt staminy 5 min")]
    public int StaminaCost5MinRun { get; set; }
    [JsonProperty("Koszt staminy 15 min")]
    public int StaminaCost15MinRun { get; set; }
    [JsonProperty("Koszt staminy 60 min")]
    public int StaminaCost60MinRun { get; set; }
    
    [JsonProperty("Predkosc minimalna ruchu myszki")]
    public double MinimalMouseSpeedValue { get; set; }
    
    [JsonProperty("Predkosc maksymalna ruchu myszki")]
    public double MaximalMouseSpeedValue { get; set; }





}

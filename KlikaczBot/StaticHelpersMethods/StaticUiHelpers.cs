using KlikaczBot.SavingOptionsInFile;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.StaticHelpersMethods;

public static class StaticUiHelpers
{
    public static void PrepareDatePickerForShowingOnlyHourMinSecFormat(params DateTimePicker[] dateTimePickers)
    {
        for (int i = 0; i < dateTimePickers.Length; i++)
        {
            dateTimePickers[i].Format = DateTimePickerFormat.Custom;
            dateTimePickers[i].CustomFormat = "HH:mm:ss";
            dateTimePickers[i].ShowUpDown = true;
            dateTimePickers[i].Value = new DateTime().AddYears(2022);
        }
    }

    public static void PopulateDatePikersFromDataTime(DateTime dateTime, DateTimePicker timePicker)
    {
        if (dateTime == new DateTime())
        {
            timePicker.Value = dateTime.AddYears(2022);
        }
        else
        {
            timePicker.Value = dateTime;
        }
        
    }
}

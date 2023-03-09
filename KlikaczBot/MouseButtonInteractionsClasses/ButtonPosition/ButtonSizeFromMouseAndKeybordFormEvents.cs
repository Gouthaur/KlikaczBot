using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses.ButtonPosition;

public partial class ButtonSizeFromMouseAndKeybordFormEvents 
{
    public ButtonSizeFromMouseAndKeybordFormEvents(IMouseKeybordWraper mouseKeybordWraper)
    {
        _mouseKeybordWraper = mouseKeybordWraper;
    }
    public ButtonPosSizeRecord? CalibratedButton { get; private set;}
    private IMouseKeybordWraper _mouseKeybordWraper;

    private Point firstMousePosition;
    private Point secondtMousePosition;

    public CalibrationSteps CalibrationStep { get; private set; } = 0;
    public void CalibratePosFromMouse()
    {
        switch (CalibrationStep)
        {
            case CalibrationSteps.FirstPoint:
                firstMousePosition = _mouseKeybordWraper.GetMousePos();
                CalibrationStep = CalibrationSteps.SecondPoint;
                break;
            case CalibrationSteps.SecondPoint:
                secondtMousePosition = _mouseKeybordWraper.GetMousePos();
                CalibratedButton = new ButtonPosSizeRecord(firstMousePosition.X, firstMousePosition.Y,
                Math.Abs(firstMousePosition.X - secondtMousePosition.X),
                Math.Abs(firstMousePosition.Y - secondtMousePosition.Y));
                CalibrationStep = CalibrationSteps.FirstPoint;
                break;
            default:
                throw new InvalidOperationException("WTF");
        }            
    }
    public void Reset()
    {
        firstMousePosition = Point.Empty; secondtMousePosition = Point.Empty;
        CalibrationStep = CalibrationSteps.FirstPoint;           
    }
}

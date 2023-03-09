using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses.ButtonPointToClickGenerators;

public class RandomPointFormButtonPositionGenerator : IButtonPointToClickGenerator
{
         
    
    public Point GetButtonPointToClick(ButtonPosSizeRecord buttonPos)
    {
        int pointX, pointY;
        if (buttonPos.Width > 0)
        {
           pointX = RandomNumberGenerator.GetInt32(buttonPos.X, buttonPos.X + buttonPos.Width);
        }
        else
        {
            pointX = RandomNumberGenerator.GetInt32(buttonPos.X + buttonPos.Width, buttonPos.X);
        }
        if (buttonPos.Height > 0)
        {
            pointY = RandomNumberGenerator.GetInt32(buttonPos.Y, buttonPos.Y + buttonPos.Height);
        }
        else 
        {
            pointY = RandomNumberGenerator.GetInt32(buttonPos.Y + buttonPos.Height, buttonPos.Y);
        }  
        return new Point(pointX, pointY);
    }
}

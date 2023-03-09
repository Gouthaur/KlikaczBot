using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses;

public record ButtonPosSizeRecord 
{
    public ButtonPosSizeRecord(int x,int y,int width,int height)
    {
        X = x; Y = y; Width = width; Height = height;
    }
    public readonly int X;
    public readonly int Y;
    public readonly int Width;
    public readonly int Height;     
}

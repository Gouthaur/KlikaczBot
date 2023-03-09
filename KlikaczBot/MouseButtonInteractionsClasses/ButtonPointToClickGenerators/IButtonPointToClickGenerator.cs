using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlikaczBot.MouseButtonInteractionsClasses.ButtonPointToClickGenerators;

public interface IButtonPointToClickGenerator
{
    Point GetButtonPointToClick(ButtonPosSizeRecord buttonPos);
}

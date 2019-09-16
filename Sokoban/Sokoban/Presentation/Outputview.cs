using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Presentation
{
    class Outputview
    {


        public void Begin()
        {
            Console.WriteLine("|| Kies uit een van de volgende nummers:");
            Console.WriteLine("|| 1, 2, 3 of 4.");
        }

        public void ErrorMessageSelectingMap()
        {
            Console.WriteLine("|| Ik wist dat sommige mensen niks konden, maar jij bent echt een uitzondering.");
            Console.WriteLine("|| Probeer 1, 2, 3 of 4. Deze kun je vinden op de toetsen 1, 2, 3 of 4.");
        }

        public void printLine(string line)
        {
            Console.WriteLine(line);
        }

        public void StartOfGame()
        {
            System.Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("| Welcome at Sokoban                                           |");
            System.Console.WriteLine("|                                                              |");
            System.Console.WriteLine("| Meaning of the symbols in-game   |  Goal of the game         |");
            System.Console.WriteLine("|                                  |                           |");
            System.Console.WriteLine("| spacebar : outerspace            |  Push the crate(s)        |");
            System.Console.WriteLine("|        # : Wall                  |  to the destination place |");
            System.Console.WriteLine("|        · : Floor                 |  with the truck           |");
            System.Console.WriteLine("|        O : Crate                 |                           |");
            System.Console.WriteLine("|        0 : Crate on destination  |                           |");
            System.Console.WriteLine("|        x : Destination           |                           |");
            System.Console.WriteLine("|        @ : Truck                 |                           |");
            System.Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("> Choose a maze (1 - 6), s = stop");
        }

        public void printSymbol(char symbolToPrint)
        {
            Console.Write(symbolToPrint);
        }
        public void printNewLine()
        {
            Console.WriteLine("");
        }
    }
}

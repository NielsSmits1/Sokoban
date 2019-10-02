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
            Console.WriteLine("|| 1, 2, 3, 4, 5 of 6.");
        }

        public void ErrorMessageSelectingMap()
        {
            Console.WriteLine("|| Ik wist dat sommige mensen niks konden, maar jij bent echt een uitzondering.");
            Console.WriteLine("|| Probeer 1, 2, 3, 4, 5 of 6. Deze kun je vinden op de toetsen 1, 2, 3, 4, 5 of 6.");
        }

        public void printLine(string line)
        {
            Console.WriteLine(line);
        }

        public void StartOfGame()
        {
            System.Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("| Welkom bij Sokoban                                           |");
            System.Console.WriteLine("|                                                              |");
            System.Console.WriteLine("| De betekenis van de tekens       |  Het doel van het spel    |");
            System.Console.WriteLine("|                                  |                           |");
            System.Console.WriteLine("| spacebar : outerspace            |  Duw de kist(en)          |");
            System.Console.WriteLine("|        █ : Muur                  |  naar de bestemming       |");
            System.Console.WriteLine("|        · : Vloer                 |  met de truck.            |");
            System.Console.WriteLine("|        O : Kist                  |                           |");
            System.Console.WriteLine("|        0 : Kist op bestemming    |                           |");
            System.Console.WriteLine("|        x : Bestemming            |                           |");
            System.Console.WriteLine("|        ~ : Valkuil               |                           |");
            System.Console.WriteLine("|          : Gebroken valkuil      |                           |");
            System.Console.WriteLine("|        @ : Truck                 |                           |");
            System.Console.WriteLine("|        $ : Magazijn Medewerker   |                           |");
            System.Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("> Kies een doolhof (1 - 6), s = stop");
        }

        public void printSymbol(char symbolToPrint)
        {
            Console.Write(symbolToPrint);
        }
        public void printNewLine()
        {
            Console.WriteLine("");
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void WinMessage()
        {
            Console.WriteLine("Lekker man! Je hebt alle kisten op de goede plek weten te zetten!");
            Console.WriteLine("Zodra je op een toets drukt zal de applicatie afsluiten!");
        }

        public void ErrorMessageMoveIntoWall()
        {
            Console.WriteLine();
            Console.WriteLine("Je kunt niet in een muur lopen, probeer een andere richting.");
        }

        public void ErrorMessageMoveTwoCrates()
        {
            Console.WriteLine();
            Console.WriteLine("Je kunt geen twee kisten tegelijkertijd duwen.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Presentation;
using Sokoban.Domain;
using System.Windows.Forms;

namespace Sokoban.Process
{
    class Controller
    {

        private Game _game;
        private Inputview _inputview;
        private Outputview _outputview;


        public Controller()
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            string sFileName = openFile1.FileName;
            Parse.FileToCharArray(sFileName);
        }
    }
}

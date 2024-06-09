using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    [Serializable]
    public class GameState
    {
        public int GridSize { set; get; }
        public int NrOfPairsGuessed { set; get; }
        public int Level { get; set; }
        public ButtonContent[] Buttons { get; set; }
        public GameState() { }
        public GameState(int size,int nr, int level, ButtonContent[] buttons)//, MyButton[] but) 
        {
            GridSize = size;
            NrOfPairsGuessed = nr;
            Level = level;
            Buttons = buttons;
            //Buttons = but;
        }
    }
}

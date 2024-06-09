using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pairs
{
    public class MyButton: Button
    {
        private Image gameImage;
        private Image blankImage;
       

        public Image GameImage
        {
            get { return gameImage; }
            set
            {
                gameImage = value;
            }
        }
       
        public Image BlankImage
        {
            get { return blankImage; }
            set
            {
                blankImage = value;
            }
        }
    }
}

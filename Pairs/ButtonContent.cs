using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    public class ButtonContent
    {
        public string Name { set; get; }
        public string ImageSource { set; get; }
        public string Visibility { set; get; }
        public ButtonContent() { }
        public ButtonContent(string name, string imageSource, string visibility) 
        {
            Name = name; 
            ImageSource = imageSource;
            Visibility = visibility;
        }
    }
}

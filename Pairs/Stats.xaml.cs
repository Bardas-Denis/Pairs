using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        public string NrOfGamesWon { set; get; }
        public string NrOfGamesPlayed { set; get; } 
        public string CurrentUser { set; get; }
        public Stats(string User)
        {
            InitializeComponent();
            CurrentUser = User;
            string filePath = "../../Stats.txt";
            bool isNameFound = false;

            string[] lines = File.ReadAllLines(filePath);
            int index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    if (lines[i].Contains(CurrentUser))
                    {
                        isNameFound = true;
                        index = i;
                        break;
                    }
                }
            }
            if (isNameFound == false)
            {
                NrOfGamesPlayed = "0";
                NrOfGamesWon = "0";
            }
            else
            {
                string[] stat = lines[index].Split(' ');
                NrOfGamesPlayed = stat[1];
                NrOfGamesWon = stat[1];
            }
            DataContext = this;
        }

       
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GameChooser gC=new GameChooser();
            gC.CurrentUser = CurrentUser;
            gC.Show();
            this.Close();
        }
    }
}

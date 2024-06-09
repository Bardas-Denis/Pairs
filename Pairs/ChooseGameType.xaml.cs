using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for ChooseGameType.xaml
    /// </summary>
    public partial class ChooseGameType : Window
    {
        public string CurrentUser { set; get; }
        public ChooseGameType()
        {
            InitializeComponent();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            GameChooser gC=new GameChooser();
            gC.CurrentUser = CurrentUser;
            gC.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button clickedButton = sender as Button;
            String indexAsString = clickedButton.Tag.ToString();
            int index = int.Parse(indexAsString);
            Game g = new Game();
            g.CurrentUser = CurrentUser;
            g.setGridSize(index+1);
            g.Show();
            this.Close();
        }
    }
}

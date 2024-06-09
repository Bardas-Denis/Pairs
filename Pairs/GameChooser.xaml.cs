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
    /// Interaction logic for GameChooser.xaml
    /// </summary>
    public partial class GameChooser : Window
    {
        public String CurrentUser { set; get; }
        public GameChooser()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            ChooseGameType cGT= new ChooseGameType();
            cGT.CurrentUser=CurrentUser;
            cGT.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            Stats s = new Stats(CurrentUser);
            s.Show();
            this.Close();
        }

        private void OpenGame_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();
            g.CurrentUser = CurrentUser;
            g.OpenGameGrid();
            g.Show();
            this.Close();
        }
    }
}

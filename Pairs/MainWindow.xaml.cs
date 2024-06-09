using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
//using static Players.User;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> Users { get; set; } = new List<User>();
        public int Index { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
          
            string filePath = "../../Users.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line != "")
                    { 
                        string[] user = line.Split(' ');
                        string name = user[0];
                        string avatar = user[1];
                        Users.Add(new User(name, avatar));
                    }
                }
            }
            DataContext = Users;
        }

        private void newUser_Click(object sender, RoutedEventArgs e)
        {
            NewUser nU=new NewUser();
            nU.Show();
            this.Close();
        }
        

        private void NextUser_Click(object sender, RoutedEventArgs e)
        {
            Index++;
            if(PreviousUser.IsEnabled==false)
                PreviousUser.IsEnabled = true;
            if(Index<Users.Count)
            {
                DataContext = Users[Index];
            }
            if(Index+1>=Users.Count)
                NextUser.IsEnabled= false;
            
        }

        private void PreviousUser_Click(object sender, RoutedEventArgs e)
        {
            Index--;
            if (NextUser.IsEnabled == false)
                NextUser.IsEnabled = true;
            if(Index>=0)
            { 
                DataContext = Users[Index]; 
            }
            if (Index - 1 < 0)
                PreviousUser.IsEnabled = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            GameChooser gC = new GameChooser();
            gC.CurrentUser = Users[Index].Name;
            gC.Show();
            this.Close();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines("../../Users.txt");
            int index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    if (lines[i].Contains(Users[Index].Name))
                    {
                        index = i;
                        break;
                    }
                }
            }
            List<string> linesAsList=lines.ToList();
            linesAsList.RemoveAt(index);
            lines=linesAsList.ToArray();
            File.WriteAllLines("../../Users.txt", lines);

            lines = File.ReadAllLines("../../Stats.txt");
            index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    if (lines[i].Contains(Users[Index].Name))
                    {
                        index = i;
                        break;
                    }
                }
            }
            linesAsList = lines.ToList();
            linesAsList.RemoveAt(index);
            lines = linesAsList.ToArray();
            File.WriteAllLines("../../Stats.txt", lines);

            if (File.Exists(Users[Index].Name+".xml"))
            {
                File.Delete(Users[Index].Name + ".xml");
            }
            Users.RemoveAt(Index);
        }

    }
 
}

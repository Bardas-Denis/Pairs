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
using System.Xml.Serialization;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        { 
            InitializeComponent();

        }

        public String Username { get; set; } = "";
        public String Index { get; set; } = "";

        private void SetName_Click(object sender, RoutedEventArgs e)
        {
            bool isNameFound = false;
            string[] lines = File.ReadAllLines("../../Users.txt");
            foreach (string line in lines)
            {
                if (line.Contains(UsernameTextBox.Text))
                {
                    isNameFound = true;
                    break;
                }
            }
            if(isNameFound==false)
            {
                Username = UsernameTextBox.Text;
            }
            else
            {
                MessageBox.Show("Username already exists", "Invalid username", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ChooseImage_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Index= clickedButton.Tag.ToString();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            if(Index=="" && Username=="")
            {
                MessageBox.Show("Enter an username and choose an avatar", "Username and avatar not choosen", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            if (Index == "")
            {
                MessageBox.Show("Choose an avatar", "Avatar not choosen", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            if (Username=="")
            {
                MessageBox.Show("Enter an username", "Username not choosen", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (Index != "" && Username != "")
            {
                string filePath = "../../Users.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    string newPath = "./Images/Image" + Index + ".png";
                    writer.WriteLine(Username + " " + newPath);
                }
                MainWindow mW = new MainWindow();
                mW.Show();
                this.Close();
            }
        }

        private void BackToHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }
    }
}

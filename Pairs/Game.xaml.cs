using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
using System.Threading;
using System.Xml.Serialization;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public string CurrentUser { set; get; }
        private int gridSize = 4;
        private int nrOfImagesSelected = 0;
        private int nrOfpairsGuessed = 0;
        public int Level { get; set; } = 1;
        private MyButton previousButton = new MyButton();

        public Game()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public void setGridSize(int size)
        {
            gridSize = size;
            for (int i = 0; i < gridSize; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                game.RowDefinitions.Add(rowDefinition);

                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                game.ColumnDefinitions.Add(columnDefinition);
            }


            List<string> paths = new List<string>();
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < gridSize * gridSize / 2; i++)
            {
                int randomNumber = random.Next(1, 32);
                string path = "./GameImages/Image" + randomNumber + ".png";
                paths.Add(path);
                paths.Add(path);
            }
            string randomPath = "";


            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (i != gridSize / 2 || j != gridSize / 2 || gridSize % 2 == 0)
                    {
                        int index = random.Next(paths.Count);
                        if (paths.Count != 0)
                        {
                            randomPath = paths[index];
                            paths.RemoveAt(index);
                        }
                    }
                    Image img = new Image();
                    BitmapImage bimage = new BitmapImage();
                    bimage.BeginInit();
                    bimage.UriSource = new Uri(randomPath, UriKind.Relative);
                    bimage.EndInit();
                    img.Source = bimage;

                    Image blnkImg = new Image();
                    BitmapImage blnkimage = new BitmapImage();
                    blnkimage.BeginInit();
                    blnkimage.UriSource = new Uri("./GameImages/QuestionMarkImage.png", UriKind.Relative);
                    blnkimage.EndInit();
                    blnkImg.Source = blnkimage;

                    MyButton button = new MyButton();
                    button.Name = "button_" + i.ToString() + "_" + j.ToString();
                    if (i != gridSize / 2 || j != gridSize / 2 || gridSize % 2 == 0)
                    {
                        button.GameImage = img;
                        button.BlankImage = blnkImg;
                        button.Content = blnkImg;
                    }
                    else
                    {
                        button.IsEnabled = false;
                        button.Visibility = Visibility.Collapsed;
                    }

                    button.Margin = new Thickness(45 / gridSize);
                    button.Click += gameButton_Click;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    game.Children.Add(button);
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Make sure to save your progress before leaving!", "Save you game", MessageBoxButton.OK, MessageBoxImage.Warning);
            ChooseGameType cgT = new ChooseGameType();
            cgT.CurrentUser = CurrentUser;
            cgT.Show();
            this.Hide();
        }
        private async void gameButton_Click(object sender, RoutedEventArgs e)
        {
            if (nrOfImagesSelected == 0)
            {
                MyButton clickedButton = sender as MyButton;
                clickedButton.Content = clickedButton.GameImage;

                clickedButton.IsEnabled = false;
                nrOfImagesSelected++;
                previousButton = clickedButton;
                
            }
            else
            {
                if (nrOfImagesSelected == 1)
                {
                    MyButton clickedButton = sender as MyButton;
                    clickedButton.IsEnabled = false;

                    await Task.Run(() =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            clickedButton.Content = clickedButton.GameImage;
                        });
                    });
                    nrOfImagesSelected--;




                    BitmapImage bitmapCurrentImage = clickedButton.GameImage.Source as BitmapImage;
                    BitmapImage bitmapPreviousImage = previousButton.GameImage.Source as BitmapImage;
                    if (bitmapCurrentImage.UriSource == bitmapPreviousImage.UriSource)
                    {
                        nrOfpairsGuessed++;
                        await Task.Delay(500);
                        await Task.Run(() =>
                        {
                            Dispatcher.Invoke(() =>
                            {
                                previousButton.Visibility = Visibility.Hidden;
                                clickedButton.Visibility = Visibility.Hidden;
                            });
                        });
                        nrOfImagesSelected = 0;
                        if (nrOfpairsGuessed == gridSize * gridSize / 2)
                        {
                            //CurrentLevel.Visibility= Visibility.Hidden;
                            if (Level == 3)
                            {
                                bool isNameFound = false;
                                string filePath = "../../Stats.txt";
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
                                    using (StreamWriter writer = new StreamWriter(filePath, true))
                                    {
                                        writer.WriteLine(CurrentUser + " 1" + " 1");
                                    }
                                }
                                else
                                {
                                    string[] stat = lines[index].Split(' ');
                                    int nrOfGamesPlayed = Convert.ToInt32(stat[1]);
                                    int nrOfGamesWon = Convert.ToInt32(stat[2]);
                                    nrOfGamesPlayed++; nrOfGamesWon++;
                                    lines[index] = CurrentUser + " " + nrOfGamesPlayed.ToString() + " " + nrOfGamesWon.ToString();
                                    File.WriteAllLines(filePath, lines);
                                }
                                FinalMessage.Text = "Congratulations!! You have won the game";

                            }
                            FinalMessage.Visibility = Visibility.Visible;
                            if (Level < 3)
                            { nextLevelButton.Visibility = Visibility.Visible; }
                            nrOfpairsGuessed = 0;
                        }
                    }

                    else
                    {
                        await Task.Delay(500);
                        previousButton.IsEnabled = true;
                        clickedButton.IsEnabled = true;

                        await Task.Run(() =>
                        {
                            Dispatcher.Invoke(() =>
                            {
                                previousButton.Content = previousButton.BlankImage;
                                clickedButton.Content = clickedButton.BlankImage;
                            });
                        });

                    }


                }
            }

        }

        private void nextLevelButton_Click(object sender, RoutedEventArgs e)
        {
            Level++;
            //CurrentLevel.Visibility = Visibility.Visible;
            if (Level <= 3)
            {
                game.RowDefinitions.Clear();
                game.ColumnDefinitions.Clear();
                game.Children.Clear();
                FinalMessage.Visibility = Visibility.Hidden;
                nextLevelButton.Visibility = Visibility.Hidden;
                setGridSize(gridSize);
            }


        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = CurrentUser + ".xml";
            XmlSerializer xmlser = new XmlSerializer(typeof(GameState));
            FileStream fileStr = new FileStream(filePath, FileMode.Create);
            MyButton[] buttons = this.game.Children.OfType<MyButton>().ToArray();
            List<ButtonContent> buttons1 = new List<ButtonContent>();
            foreach (MyButton button in buttons)
            {
                string visibilty = "";
                string name = "";
                string content = "";
                if (button.Visibility != Visibility.Collapsed)
                {
                    if (button.Visibility == Visibility.Hidden) { visibilty = "Hidden"; }
                    if (button.Visibility == Visibility.Visible) { visibilty = "Visible"; }
                    BitmapImage Image = button.GameImage.Source as BitmapImage;
                    content = Image.UriSource.ToString();
                }
                else if (button.Visibility == Visibility.Collapsed) { visibilty = "Collapsed"; }

                name = button.Name;

                buttons1.Add(new ButtonContent(name, content, visibilty));
            }
            ButtonContent[] buttonContents = buttons1.ToArray();
            xmlser.Serialize(fileStr, new GameState(gridSize, nrOfpairsGuessed, Level, buttonContents));
            fileStr.Dispose();
        }
        public void OpenGameGrid()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(GameState));
            if(File.Exists(CurrentUser + ".xml"))
            {
                FileStream file = new FileStream(CurrentUser + ".xml", FileMode.Open);

                var c = (xmlser.Deserialize(file) as GameState);
                nrOfpairsGuessed = c.NrOfPairsGuessed;
                gridSize = c.GridSize;
                Level = c.Level;
                ButtonContent[] buttonContents = c.Buttons;
                for (int i = 0; i < gridSize; i++)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                    game.RowDefinitions.Add(rowDefinition);

                    ColumnDefinition columnDefinition = new ColumnDefinition();
                    columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                    game.ColumnDefinitions.Add(columnDefinition);
                }


                List<string> paths = new List<string>();
                Random random = new Random(DateTime.Now.Millisecond);

                for (int i = 0; i < gridSize * gridSize / 2; i++)
                {
                    int randomNumber = random.Next(1, 32);
                    string path = "./GameImages/Image" + randomNumber + ".png";
                    paths.Add(path);
                    paths.Add(path);
                }

                foreach (ButtonContent buttonContent in buttonContents)
                {
                    Image img = new Image();
                    BitmapImage bimage = new BitmapImage();
                    bimage.BeginInit();
                    bimage.UriSource = new Uri(buttonContent.ImageSource, UriKind.Relative);
                    bimage.EndInit();
                    img.Source = bimage;

                    Image blnkImg = new Image();
                    BitmapImage blnkimage = new BitmapImage();
                    blnkimage.BeginInit();
                    blnkimage.UriSource = new Uri("./GameImages/QuestionMarkImage.png", UriKind.Relative);
                    blnkimage.EndInit();
                    blnkImg.Source = blnkimage;

                    MyButton button = new MyButton();
                    button.Name = buttonContent.Name;

                    button.GameImage = img;
                    button.BlankImage = blnkImg;
                    button.Content = blnkImg;

                    if (buttonContent.Visibility == "Visible")
                    {
                        button.Visibility = Visibility.Visible;
                    }
                    else if (buttonContent.Visibility == "Collapsed")
                    {
                        button.Visibility = Visibility.Collapsed;
                    }
                    else if (buttonContent.Visibility == "Hidden")
                    {
                        button.Visibility = Visibility.Hidden;
                    }

                    button.Margin = new Thickness(45 / gridSize);
                    button.Click += gameButton_Click;
                    Grid.SetRow(button, buttonContent.Name[7] - '0');
                    Grid.SetColumn(button, buttonContent.Name[9] - '0');
                    game.Children.Add(button);

                }
                file.Dispose();
            }
            
        }

    }
}
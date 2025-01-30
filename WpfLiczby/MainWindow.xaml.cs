using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLiczby
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[] Liczby;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Wylosuj(object sender, RoutedEventArgs e)
        {
            wpisaneLiczbyTextbox.Text = "";
            WindowZakres windowZakres = new WindowZakres();
            windowZakres.ShowDialog();
            
                int ileLiczb = windowZakres.Ilosc;
                //MessageBox.Show(ileLiczb.ToString());
                Random random = new Random();
                for(int i = 0; i< ileLiczb; i++)
                {
                    int liczba = random.Next(1, 101);
                    wpisaneLiczbyTextbox.Text += liczba.ToString() + "\n";
                }
            

        }

        private void MenuItem_Click_Zapisz(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog()==true)
            {
                string[] tablicaLiczb = wpisaneLiczbyTextbox.Text.Split('\n'); ;
                File.WriteAllLines(saveFileDialog.FileName, tablicaLiczb);
            }
        }

        private void MenuItem_Click_Otworz(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog()==true)
            {
                string[] liczbyTekstowo = File.ReadAllLines(openFileDialog.FileName);
                wpisaneLiczbyTextbox.Text =String.Join("\n",liczbyTekstowo );
            }
        }
    }
}

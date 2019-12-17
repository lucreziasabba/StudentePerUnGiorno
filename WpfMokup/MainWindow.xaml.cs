using System;
using System.Collections.Generic;
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
using System.IO;

namespace WpfMokup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string file_name = "info.txt";
        string nome;
        string cognome;
        DateTime data;

        public MainWindow()
        {
            InitializeComponent();

        }


        private void Greet_Click(object sender, RoutedEventArgs e)
        {
            nome = txtNome.Text;
            cognome = txtCognome.Text;
            data = dtPicker.SelectedDate.Value;
            if (data>DateTime.Now)
                MessageBox.Show("Non puoi essere nato nel futuro!");
            if (nome == "" || cognome == "" || data == null)
                MessageBox.Show("Inserisci i valori!");
            else
                MessageBox.Show($"Welcome {nome} {cognome}, {data.ToShortDateString()}");
            
        }
        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            btnPrint.IsEnabled = true;
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            nome = txtNome.Text;
            cognome = txtCognome.Text;
            data = dtPicker.SelectedDate.Value;
            try
            {
                using (StreamWriter w = new StreamWriter(file_name, true))
                {
                    w.WriteLine($"{nome} {cognome} {data.ToShortDateString()}");
                }
            }
            catch
            {
                MessageBox.Show("Errore!");
            }

        }
    }
}

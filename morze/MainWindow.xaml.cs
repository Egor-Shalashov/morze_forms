using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using morze_lib;
using System.ComponentModel;

namespace morze
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        private Morze morze = new Morze();
        private string Lang;

        public MainWindow()
        {
            InitializeComponent();

            C_Box.Items.Add("Русский");
            C_Box.Items.Add("Английский");
            C_Box.Items.Add("Морзе");
            C_Box.SelectedItem = "Русский";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (C_Box.SelectedItem == "Русский")
            {
                ListBox.Items.Add(tr("ru"));
            }
            else if (C_Box.SelectedItem == "Английский")
            {
                ListBox.Items.Add(tr("en"));
            }
            else if (C_Box.SelectedItem == "Морзе")
            {
                if (char.ToUpper(t_box.Text[0]) >= 65 && char.ToUpper(t_box.Text[0]) <= 90)
                {
                    Lang = "en";
                }
                else if (char.ToUpper(t_box.Text[0]) >= 1040 && char.ToUpper(t_box.Text[0]) <= 1071)
                {
                    Lang = "ru";
                }
                string output = "";
                for (int i = 0; i < t_box.Text.Length; i++)
                {
                    output += morze.in_morze(t_box.Text[i], Lang);
                }
                ListBox.Items.Add(output);
            }
            else
            {
                ListBox.Items.Add("ERROR 1");
            }
        }
        private string tr(string lang)
        {
            string output = "";
            string temp = "";
            for (int i = 0; i < t_box.Text.Length; i++)
            {
                if (t_box.Text[i] != ' ' && t_box.Text[i] != '\n' && t_box.Text[i] != '\r')
                {
                    temp += t_box.Text[i];
                }
                else if (t_box.Text[i] == ' ' && t_box.Text[i-1] == ' ')
                {
                    output += ' ';
                }
                else if (t_box.Text[i] == '\n')
                {
                    output += morze.fr_morze(temp, lang);
                    output += '\n';
                }
                else
                {
                    output += morze.fr_morze(temp, lang);
                    temp = "";
                }
            }
            output += morze.fr_morze(temp, lang);
            return output;
        }
    }
}

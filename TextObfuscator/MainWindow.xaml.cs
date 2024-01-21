using Ookii.Dialogs.Wpf;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextObfuscator.Tools;

namespace TextObfuscator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            config = new Obfuscator.ObfuscationConfig(Array.Empty<string>(), true);
        }

        string SaveLocation = "";
        string Unobfuscated = "";
        string Obfuscated = "";

        public static Obfuscator.ObfuscationConfig config;

        private void SBSV_Checked(object sender, RoutedEventArgs e)
        {
            NViewTextBox.Visibility = Visibility.Collapsed;
            SideBySideView.Visibility = Visibility.Visible;
        }

        private void SBSV_Unchecked(object sender, RoutedEventArgs e)
        {
            NViewTextBox.Visibility = Visibility.Visible;
            SideBySideView.Visibility = Visibility.Collapsed;
        }

        private void FO_Click(object sender, RoutedEventArgs e)
        {
            VistaOpenFileDialog ofd = new VistaOpenFileDialog();
            ofd.Title = "Text Obfuscator/Redacter - Select file";

            if((bool)ofd.ShowDialog())
            {
                SaveLocation = ofd.FileName;
                Unobfuscated = File.ReadAllText(ofd.FileName);
                Update();
            }
        }

        private void Update()
        {
            SBSN.Text = Unobfuscated;
            Obfuscated = Obfuscator.Obfuscate(config, Unobfuscated);
            SBSE.Text = Obfuscated;
            NViewTextBox.Text = Obfuscated;
        }

        private void RO_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void OCF_Click(object sender, RoutedEventArgs e)
        {
            CustomWindow customWindow = new CustomWindow();
            customWindow.Show();
        }
    }
}
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
namespace Sim_Starter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {

            InitializeComponent();
            ListBoxPaths.ItemsSource = DataStorage.ProgramList;
            if (Initialize.StartProgramFileCheck() == true)
            {
                DataValid.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonAutostart.Visibility = Visibility.Hidden;
                ButtonManualstart.Visibility = Visibility.Hidden;
                DataValid.Visibility = Visibility.Hidden;
                DataError.Visibility = Visibility.Visible;
            }

        }

        private void CheckFiles()
        {
            if (Initialize.CheckProgramListForEntries() == true)
            {
                DataValid.Visibility = Visibility.Visible;
                DataError.Visibility = Visibility.Hidden;
                ButtonAutostart.Visibility = Visibility.Visible;
                ButtonManualstart.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonAutostart.Visibility = Visibility.Hidden;
                ButtonManualstart.Visibility = Visibility.Hidden;
                DataValid.Visibility = Visibility.Hidden;
                DataError.Visibility = Visibility.Visible;
            }
        }

        private void OnClickAutostart(object sender, RoutedEventArgs e)
        {
            AutoStart autoStart = new AutoStart();            
        }

        private void OnClickManualstart(object sender, RoutedEventArgs e)
        {
            ManualStart manualStart = new ManualStart();
            manualStart.Show();
        }

        private void LoadDataFile(object sender, RoutedEventArgs e)
        {
            StaticFileHandler.LoadDataSet();
        }

        private void AddProgram(object sender, RoutedEventArgs e)
        {
            StaticFileHandler.AddProgramToList();
            CheckFiles();
        }

        private void OnClickClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveConfigToMyDocuments(object sender, RoutedEventArgs e)
        {
            StaticFileHandler.SaveConfigToMyDocuments();
        }

        private void RemoveProgram(object sender, RoutedEventArgs e)
        {
            StaticFileHandler.RemoveProgramFromList(ListBoxPaths.SelectedItem.ToString());
        }
    }
}

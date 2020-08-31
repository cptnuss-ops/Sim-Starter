using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Sim_Starter
{
    /// <summary>
    /// Interaktionslogik für ManualStart.xaml
    /// </summary>
    public partial class ManualStart : Window
    {
        Process P = new Process();
        public ManualStart()
        {
            InitializeComponent();
            DisplayProgramListForManualstart.ItemsSource = DataStorage.ProgramList;
        }

        private void StartSelectedProgram(object sender, RoutedEventArgs e)
        {
            string SelectedItem = DisplayProgramListForManualstart.SelectedItem.ToString();
            int position = DisplayProgramListForManualstart.Items.IndexOf(SelectedItem);

            try
            {
                P.StartInfo.FileName = DataStorage.ProgramList[position];
                P.Start();
            }
            catch (Exception ex)
            {
                if (Application.Current.Windows.OfType<ExceptionWindow>().FirstOrDefault() == null)
                {
                    ExceptionWindow exceptionWindow = new ExceptionWindow();
                    exceptionWindow.ExceptionText.Text = ex.Message.ToString();
                    exceptionWindow.Show();
                }
            }
        }
    }
}

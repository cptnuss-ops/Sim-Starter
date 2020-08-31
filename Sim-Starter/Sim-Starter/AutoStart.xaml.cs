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
    /// Interaktionslogik für AutoStart.xaml
    /// </summary>
    public partial class AutoStart : Window
    {
        Process P = new Process();
        public AutoStart()
        {
            foreach (var item in DataStorage.ProgramList)
            {
                try
                {
                    P.StartInfo.FileName = item;
                    P.Start();
                }
                catch (Exception ex)
                {
                    ExceptionWindow exceptionWindow = new ExceptionWindow();
                    exceptionWindow.ExceptionText.Text = ex.Message.ToString();
                    exceptionWindow.Show();
                }
            }
        }
    }
}

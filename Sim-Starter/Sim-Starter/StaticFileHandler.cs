using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Starter
{
    public class StaticFileHandler
    {
        public static void AddProgramToList()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (DataStorage.ProgramList.Contains(openFileDialog.FileName))
                {
                    ExceptionWindow exceptionWindow = new ExceptionWindow();
                    exceptionWindow.ExceptionText.Text = "Dieses Programm ist bereits in der Liste !";
                    exceptionWindow.Show();
                }
                else
                {
                    DataStorage.ProgramList.Add(openFileDialog.FileName);
                }
               
                
            }
            else
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow();
                exceptionWindow.ExceptionText.Text = "No file selected!";
                exceptionWindow.Show();
            }
        }

        public static void SaveConfigToMyDocuments()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += @"\SimStarterInit.txt";

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("FILEVALID");

                foreach (string item in DataStorage.ProgramList)
                {
                    streamWriter.WriteLine(item);
                }
            };
        }

        internal static void LoadDataSet()
        {
            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;

            }
            else
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow();
                exceptionWindow.ExceptionText.Text = "No file selected!";
                exceptionWindow.Show();
            }

            DataStorage.ProgramList.Clear();

            using(StreamReader streamReader = new StreamReader(path))
            {
                do
                {
                    string line = "";
                    line = streamReader.ReadLine();

                    if (line != "FILEVALID")
                    {
                        DataStorage.ProgramList.Add(line);
                    }
                    

                } while (streamReader.Peek() != -1);
            };
        }

        internal static void RemoveProgramFromList(string StringToRemove)
        {
            DataStorage.ProgramList.Remove(StringToRemove);
        }
    }
}

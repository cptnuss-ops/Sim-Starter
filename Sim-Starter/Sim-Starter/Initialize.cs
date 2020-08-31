using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Starter
{
    public static class Initialize
    {
        public static bool StartProgramFileCheck()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += @"\SimStarterInit.txt";

            if (File.Exists(path))
            {                               
                using (StreamReader streamReader = new StreamReader(path))
                {
                    do
                    {
                        string line = streamReader.ReadLine();
                        if (line != "FILEVALID")
                        {
                            DataStorage.ProgramList.Add(line);
                        }
                        
                    } while (streamReader.Peek() != -1);
                };

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckProgramListForEntries()
        {
            if (DataStorage.ProgramList.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

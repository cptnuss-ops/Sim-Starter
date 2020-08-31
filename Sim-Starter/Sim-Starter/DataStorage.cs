using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Starter
{
    public static class DataStorage
    {
        public static ObservableCollection<string> ProgramList = new ObservableCollection<string>();
        public static ObservableCollection<string> ProgramNames = new ObservableCollection<string>();       
    }
}

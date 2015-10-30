using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHW
{
    class Program
    {
        static void Main(string[] args)
        {
            ISourceData data = new SqlReader();
            data.Open();
            data.Load();
            data.Parse();
            data.Close();
            data.GetData();
        }
    }
}

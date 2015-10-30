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
            ISourceData data = new TxtReader();
            data.Open();
            data.Load();
            data.Close();
            data.Parse();
            data.GetData();
        }
    }
}

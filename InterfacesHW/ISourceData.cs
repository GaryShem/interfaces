using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHW
{
    interface ISourceData
    {
        void Open();
        void Load();
       // void Save();
        void Close();
        void Parse();
        void GetData();
    }
}

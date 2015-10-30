using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHW
{
    class SqlReader : BaseClass, ISourceData
    {
        private string filename;
        public SqlReader()
        {
            this.filename = "text.accdb";
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
            throw new Exception("file is not opened for reading");
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Parse()
        {
            throw new NotImplementedException();
        }

        public void GetData()
        {
            Console.WriteLine("Groups[{0}]", _database.Groups.Count);
            foreach (Group @group in _database.Groups)
            {
                Console.WriteLine(@group);
            }
            Console.WriteLine("Students[{0}]", _database.Students.Count);
            foreach (Student student in _database.Students)
            {
                Console.WriteLine(student);
            }
        }
    }
}

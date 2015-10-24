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
            ISourceData data = new XmlReader();
            Student s = new Student
            {
                Id = 1,
                Name = "John Smith",
                GroupId = 1,
                EnrollYear = 2000
            };
            ((XmlReader)data)._database.Students.Add(s);
            s = new Student()
            {
                Id = 2,
                Name = "Not John Smith",
                GroupId = 2,
                EnrollYear = 2001
            };
            ((XmlReader)data)._database.Students.Add(s);
            data.Save();

        }
    }
}

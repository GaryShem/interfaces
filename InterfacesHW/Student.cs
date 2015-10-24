using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHW
{
    public class Student
    {
        private int _id;
        private string _name;
        private int _groupId;
        private int _enrollYear;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int EnrollYear
        {
            get { return _enrollYear; }
            set { _enrollYear = value; }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHW
{
    [Serializable]
    // ReSharper disable once InconsistentNaming
    public class db
    {
        private List<Student> _students = new List<Student>();
        private List<Group> _groups = new List<Group>();

        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public List<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

    }
}

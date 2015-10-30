using System;
using System.Linq;
using System.Text;

namespace InterfacesHW
{
    abstract class BaseClass
    {
        public db _database = new db();
        
        public void AddStudent(Student student)
        {
            _database.Students.Add(student);
        }

        public void AddGroup(Group group)
        {
            _database.Groups.Add(group);
        }

        protected Group FindGroup(int groupId)
        {
            foreach (var group in _database.Groups)
            {
                if (group.Id == groupId)
                    return group;
            }
            return null;
        }

        protected Student FindStudent(int studId)
        {
            foreach (Student student in _database.Students)
            {
                if (student.Id == studId)
                    return student;
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var student in _database.Students)
            {
                result.Append(String.Format("Id: {0}; Name: {1}; Group: {2}; Enrollment Year: {3};",
                    student.Id, student.Name, FindGroup(student.GroupId), student.EnrollYear));
            }
            return result.ToString();
        }
    }
}

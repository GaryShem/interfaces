using System;
using System.Linq;
using System.Text;

namespace InterfacesHW
{
    abstract class BaseClass : ISourceData
    {
        public db _database = new db();
        protected string filename;
        
        //public abstract void Open(); //свой для каждого источника //но не понимаю, зачем нужен
        //public abstract void Close(); //везде свой //такая же проблема
        public abstract void Load();
        public abstract void Save();
        public void AddStudent(Student student)
        {
            _database.Students.Add(student);
        }

        public void AddGroup(Group group)
        {
            _database.Groups.Add(group);
        }

        private Group FindGroup(int groupId)
        {
            return _database.Groups.FirstOrDefault(@group => @group.Id == groupId);
        }

        private Student FindStudent(int studId)
        {
            foreach (Student student in _database.Students)
            {
                if (student.Id == studId)
                    return student;
            }
            return null;
        }

        public Tuple<Student, Group> GetData(int studId)
        {
            Student student = FindStudent(studId);
            if (student == null)
                return null;
            return new Tuple<Student, Group>(student, FindGroup(student.GroupId));
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHW
{
    class TxtReader : BaseClass, ISourceData
    {
        private string filename;
        private TextReader _tempTextReader = null;
        private string _tempString = null;
        public TxtReader()
        {
            this.filename = "test.txt";
        }

        public void Open()
        {
            _tempTextReader = new StreamReader(filename);
        }

        public void Load()
        {
            if (_tempTextReader == null)
                throw new Exception("file is not opened for reading");
            _tempString = _tempTextReader.ReadToEnd();
        }

        public void Save()
        {
            StreamWriter sw = new StreamWriter(filename);

        }

        public void Close()
        {
            _tempTextReader.Close();
            _tempTextReader = null;
        }

        public void Parse()
        {
            if (String.IsNullOrEmpty(_tempString))
                throw new Exception("file has not been loaded");
            StringReader sr = new StringReader(_tempString);
            //groups
            //groups, get count //([A-Z])\w+
            string line = sr.ReadLine();
            Regex r = new Regex(@"\[(\d+)\]");
            Match m = r.Match(line);
            int count = int.Parse(m.Groups[1].ToString());
            for (int i = 0; i < count; i++)
            {
                line = sr.ReadLine();
                string[] fields = line.Split(';');
                int groupId = int.Parse(fields[0]);
                string groupDescr = fields[1];
                _database.Groups.Add(new Group(){Id = groupId, Description = groupDescr});
            }
            line = sr.ReadLine();
            m = r.Match(line);
            count = int.Parse(m.Groups[1].ToString());
            for (int i = 0; i < count; i++)
            {
                line = sr.ReadLine();
                string[] fields = line.Split(';');
                _database.Students.Add(new Student()
                {
                    Id = int.Parse(fields[0]),
                    GroupId = int.Parse(fields[1]),
                    Name = fields[2],
                    EnrollYear = int.Parse(fields[3])
                });
            }
            sr.Close();
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

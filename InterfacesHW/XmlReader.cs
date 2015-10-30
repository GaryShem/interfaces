using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace InterfacesHW
{
    class XmlReader : ISourceData
    {
        public db _database = new db();
        private string filename;
        private StreamReader _tempStreamReader = null;
        private string _tempXmlString = null;
        public XmlReader(string filename = "test.xml")
        {
            this.filename = filename;
        }

        public void Open()
        {
            _tempStreamReader = new StreamReader(filename);
        }

        public void Load()
        {
            if (_tempStreamReader == null)
                throw new Exception("file is not opened for reading");
            _tempXmlString = _tempStreamReader.ReadToEnd();
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(db));
            TextWriter recordString = new StreamWriter(filename);
            xmlSerializer.Serialize(recordString, _database);
            recordString.Close();
        }

        public void Close()
        {
            _tempStreamReader.Close();
            _tempStreamReader = null;
        }

        public void Parse()
        {
            if (String.IsNullOrEmpty(_tempXmlString))
                throw new Exception("file has not been loaded");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(db));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(_tempXmlString));
            _database = (db)xmlSerializer.Deserialize(ms);
            ms.Close();
        }

        /*public Tuple<Student, Group> GetData(int studId)
        {
            Student student = FindStudent(studId);
            if (student == null)
                return null;
            return new Tuple<Student, Group>(student, FindGroup(student.GroupId));
        }*/
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

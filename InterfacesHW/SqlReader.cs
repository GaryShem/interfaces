using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHW
{
    class SqlReader : ISourceData
    {
        private OleDbConnection _dbConnection;
        private OleDbDataReader _studentReader;
        private OleDbDataReader _groupReader;
        private string filename;
        public db _database = new db();
        public SqlReader()
        {
            this.filename = "test.accdb";
        }

        public void Open()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + String.Format("{0}\\{1};", Directory.GetCurrentDirectory(), filename);
            _dbConnection = new OleDbConnection(connectionString);
            _dbConnection.Open();
        }

        public void Load()
        {
            OleDbCommand readStudent = new OleDbCommand("SELECT * FROM Students", _dbConnection);
            OleDbCommand readGroup = new OleDbCommand("SELECT * FROM Groups", _dbConnection);

            _studentReader = readStudent.ExecuteReader();
            _groupReader = readGroup.ExecuteReader();
        }

        public void Close()
        {
            _dbConnection.Close();
        }

        public void Parse()
        {
            while (_studentReader.Read())
            {
                Student s = new Student()
                {
                    Id = _studentReader.GetInt32(0),
                    GroupId = _studentReader.GetInt32(1),
                    Name = _studentReader.GetString(2),
                    EnrollYear = _studentReader.GetInt32(3)
                };
                _database.Students.Add(s);
            }
            while (_groupReader.Read())
            {
                Group g = new Group()
                {
                    Id = _groupReader.GetInt32(0),
                    Description = _groupReader.GetString(1)
                };
                _database.Groups.Add(g);
            }
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

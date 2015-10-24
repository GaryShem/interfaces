using System;
using System.IO;
using System.Xml.Serialization;

namespace InterfacesHW
{
    class XmlReader : BaseClass
    {
        public XmlReader()
        {
            this.filename = "test.xml";
        }
        public override void Load()
        {
            FileStream dbfile = new FileStream(filename, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(db));
            _database = (db)xmlSerializer.Deserialize(dbfile);
            dbfile.Close();
        }

        public override void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(db));
            TextWriter recordString = new StreamWriter(filename);
            xmlSerializer.Serialize(recordString, _database);
            recordString.Close();
        }
    }
}

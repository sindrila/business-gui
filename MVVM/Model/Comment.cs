using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class Comment : IXmlSerializable
{
    private int _id;
    private string _username;
    private string _content;
    private DateTime _dateOfCreation;
    private DateTime _dateOfUpdate;

    public int Id { get => _id; set => _id = value; }
    public string Username { get => _username; set => _username = value;  }
    public string Content { get => _content; set => _content = value; }
    public DateTime DateOfCreation { get => _dateOfCreation; set => _dateOfCreation = value; }
    public DateTime DateOfUpdate { get => _dateOfUpdate; set => _dateOfUpdate = value; }

    public Comment()
    {

    }

    public Comment(int id, string username, string content, DateTime creation)
    {
        _id = id;
        _username = username;
        _content = content;
        _dateOfCreation = creation;
    }

    public XmlSchema? GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();

        // TODO: this if is experimental. It tries to bot read the comment if it is empty. Did not test it.
        if (reader.IsEmptyElement)
            return;

        reader.ReadStartElement("Comment");
        _id = int.Parse(reader.ReadElementString("Id"));
        _username = reader.ReadElementString("Username");
        _content = reader.ReadElementString("Content");
        _dateOfCreation = DateTime.Parse(reader.ReadElementString("DateOfCreation"));
        if (reader.IsStartElement("DateOfUpdate"))
        {
            _dateOfUpdate = DateTime.Parse(reader.ReadElementString("DateOfUpdate"));
        }
        reader.ReadEndElement();

    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("Id", Id.ToString());
        writer.WriteElementString("Username", Username);
        writer.WriteElementString("Content", Content);
        writer.WriteElementString("DateOfCreation", DateOfCreation.ToLongTimeString());
        writer.WriteElementString("DateOfUpdate", DateOfUpdate.ToLongTimeString());
    }
}

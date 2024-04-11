using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class FAQ : IXmlSerializable
{
    private int _id;
    private string _question;
    private string _answer;

    public FAQ() { }

    public FAQ(int id, string question, string answer)
    {
        _id = id;
        _question = question;
        _answer = answer;
    }

    public string GetQuestion() { return _question; }
    public string GetAnswer() { return _answer; }
    public int GetId() { return _id; }
    public void SetQuestion(string question) { _question = question; }
    public void SetAnswer(string answer) { _answer = answer; }

    // Implement IXmlSerializable interface

    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        bool isEmptyElement = reader.IsEmptyElement;
        reader.ReadStartElement();
        if (!isEmptyElement)
        {

            //_id = int.Parse(reader.ReadElementString("_id"));
            //_numberOfLikes = int.Parse(reader.ReadElementString("_numberOfLikes"));
            //_creationDate = DateTime.Parse(reader.ReadElementString("_creationDate"));
            //_imagePath = reader.ReadElementString("_imagePath");
            //_caption = reader.ReadElementString("_caption");

            _id = int.Parse(reader.ReadElementString("_id"));
            _question = reader.ReadElementString("_question");
            _answer = reader.ReadElementString("_answer");

            //_id = int.Parse(reader.ReadElementContentAsString("Id", ""));
            //_question = reader.ReadElementContentAsString("Question", "");
            //_answer = reader.ReadElementContentAsString("Answer", "");
            reader.ReadEndElement();
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("_id", _id.ToString());
        writer.WriteElementString("_question", _question);
        writer.WriteElementString("_answer", _answer);
    }
}

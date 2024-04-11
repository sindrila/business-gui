using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class FAQ : IXmlSerializable
{
    private int _id;
    private int _businessId;
    private string _question;
    private string _answer;

    public FAQ() { }

    public FAQ(int id, int businessId, string question, string answer)
    {
        _id = id;
        _businessId = businessId;
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
            _id = int.Parse(reader.ReadElementContentAsString("Id", ""));
            _businessId = int.Parse(reader.ReadElementContentAsString("BusinessId", ""));
            _question = reader.ReadElementContentAsString("Question", "");
            _answer = reader.ReadElementContentAsString("Answer", "");
            reader.ReadEndElement();
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("Id", _id.ToString());
        writer.WriteElementString("BusinessId", _businessId.ToString());
        writer.WriteElementString("Question", _question);
        writer.WriteElementString("Answer", _answer);
    }
}

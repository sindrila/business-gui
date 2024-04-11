using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[Serializable]
public class Account : IXmlSerializable
{
    private string _username;
    private string _password;

    public string Username => _username;
    public string Password => _password;

    public Account(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public Account()
    {
    }

    public override string ToString()
    {
        return $"Username: {_username}, Password: {_password}";
    }

    public XmlSchema? GetSchema()
    {
        return null; // Not needed
    }

    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement("Account"); // Move to the <Account> element

        _username = reader.ReadElementString("_username");
        _password = reader.ReadElementString("_password");

        reader.ReadEndElement(); // Close the <Account> element
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("_username", _username);
        writer.WriteElementString("_password", _password);

    }
}

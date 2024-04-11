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
    private string _firstname;
    private string _lastname;
    private string _email;
    private string _day;
    private string _month;
    private string _year;
    private string _gender;
    private DateTime _birthday;
    public string Username => _username;
    public string Password => _password;
    public string Firstname => _firstname;
    public string Lastname => _lastname;
    public string Email => _email;

    public DateTime Birhda => _birthday;
    public string Gender => _gender;
    public Account(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public Account(string username, string password,string firstname,string lastname,string email,string day,string month,string year,string gender)
    {
        _username = username;
        _password = password;
        _firstname = firstname;
        _lastname = lastname;
        _email = email;
        int dayy = int.Parse(_day);
        int monthh = int.Parse(_month);
        int yearr = int.Parse(_year);
        _birthday = new DateTime(yearr, monthh, dayy);
        _gender = gender;
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
        reader.ReadStartElement("User"); // Move to the <Account> element

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

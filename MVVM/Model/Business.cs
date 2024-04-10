using System;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;

[Serializable]
public class Business : IXmlSerializable
{
    [XmlElement ("_id")]
    private int _id;
    [XmlElement("_name")]
    private string _name;
    [XmlElement("_description")]
    private string _description;
    [XmlElement("_category")]
    private string _category;
    [XmlElement("_logo")]
    private string _logo;
    [XmlElement("_banner")]
    private string _banner;
    [XmlElement("_phoneNumber")]
    private string _phoneNumber;
    [XmlElement("_email")]
    private string _email;
    [XmlElement("_website")]
    private string _website;
    [XmlElement("_address")]
    private string _address;
    [XmlElement("_createdAt")]
    private DateTime _createdAt;

    public int Id => _id;
    public string Name => _name;
    public string Description => _description;
    public string Category => _category;
    public string Logo => _logo;
    public string Banner => _banner;
    public string PhoneNumber => _phoneNumber;
    public string Email => _email;
    public string Website => _website;
    public string Address => _address;
    public DateTime CreatedAt => _createdAt;

    public Business()
    {

    }
    public Business(int id, string name, string description, string category, string logo, string banner, string phoneNumber, string email, string website, string address, DateTime createdAt)
    {
        _id = id;
        _name = name;
        _description = description;
        _category = category;
        _logo = logo;
        _banner = banner;
        _phoneNumber = phoneNumber;
        _email = email;
        _website = website;
        _address = address;
        _createdAt = createdAt;
    }

    public void SetName(string name) => _name = name;
    public void SetDescription(string description) => _description = description;
    public void SetCategory(string category) => _category = category;
    public void SetLogo(string logo) => _logo = logo;
    public void SetBanner(string banner) => _banner = banner;
    public void SetPhoneNumber(string phoneNumber) => _phoneNumber = phoneNumber;
    public void SetEmail(string email) => _email = email;
    public void SetWebsite(string website) => _website = website;
    public void SetAddress(string address) => _address = address;
    public void SetCreatedAt(DateTime createdAt) => _createdAt = createdAt;

    public override string ToString()
    {
        return $"Business [ID: {_id}, Name: {_name}, Category: {_category}, Created: {_createdAt.ToShortDateString()}]";
    }

    public XmlSchema GetSchema()
    {
        return null; // Not needed
    }

    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement("Business"); // Move to the <Business> element

        // Read private fields from XML
        _id = int.Parse(reader.ReadElementString("_id"));
        _name = reader.ReadElementString("_name");
        _description = reader.ReadElementString("_description");
        _category = reader.ReadElementString("_category");
        _logo = reader.ReadElementString("_logo");
        _banner = reader.ReadElementString("_banner");
        _phoneNumber = reader.ReadElementString("_phoneNumber");
        _email = reader.ReadElementString("_email");
        _website = reader.ReadElementString("_website");
        _address = reader.ReadElementString("_address");
        _createdAt = DateTime.Parse(reader.ReadElementString("_createdAt"));

        reader.ReadEndElement(); // Move past the </Business> element
    }

    public void WriteXml(XmlWriter writer)
    {
        // Write the <Business> element
      

        // Write private fields to XML
        writer.WriteElementString("_id", _id.ToString());
        writer.WriteElementString("_name", _name);
        writer.WriteElementString("_description", _description);
        writer.WriteElementString("_category", _category);
        writer.WriteElementString("_logo", _logo);
        writer.WriteElementString("_banner", _banner);
        writer.WriteElementString("_phoneNumber", _phoneNumber);
        writer.WriteElementString("_email", _email);
        writer.WriteElementString("_website", _website);
        writer.WriteElementString("_address", _address);
        writer.WriteElementString("_createdAt", _createdAt.ToString());

      
    }

}

using System;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

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
    [XmlElement("_logoFullPath")]
    private string _logoShort;
    [XmlElement("_bannerFullPath")]
    private string _bannerShort;
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
    [XmlElement("_managerUsernames")]
    private List<string> _managerUsernames = new List<string>();

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

    public List<string> ManagerUsernames => _managerUsernames;

    public Business()
    {

    }
    public Business(int id, string name, string description, string category, string logo, string banner, string phoneNumber, string email, string website, string address, DateTime createdAt, List<string> managerUsernames)
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
        _managerUsernames = managerUsernames;
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

    public void SetManagerUsernames(List<string> managerUsernames) => _managerUsernames = managerUsernames;

    public void addManager(string managerUsername)
    {
        _managerUsernames.Add(managerUsername);
    }

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

        string binDirectory = "\\bin";
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string pathUntilBin;


        int index = basePath.IndexOf(binDirectory);
        pathUntilBin = basePath.Substring(0, index);

        // Placeholder values for logo, banner, etc.
        _logoShort = reader.ReadElementString("_logo");
        _bannerShort = reader.ReadElementString("_banner");

         _logo = Path.Combine(pathUntilBin, _logoShort);
        _banner = Path.Combine(pathUntilBin, _bannerShort);

        _phoneNumber = reader.ReadElementString("_phoneNumber");
        _email = reader.ReadElementString("_email");
        _website = reader.ReadElementString("_website");
        _address = reader.ReadElementString("_address");
        _createdAt = DateTime.Parse(reader.ReadElementString("_createdAt"));

        reader.ReadStartElement("_managerUsernames");
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "username")
            {
                _managerUsernames.Add(reader.ReadElementString("username"));
            }
            else
            {
                reader.Read();
            }
        }

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
        writer.WriteElementString("_logo", _logoShort);
        writer.WriteElementString("_banner", _bannerShort);
        writer.WriteElementString("_phoneNumber", _phoneNumber);
        writer.WriteElementString("_email", _email);
        writer.WriteElementString("_website", _website);
        writer.WriteElementString("_address", _address);
        writer.WriteElementString("_createdAt", _createdAt.ToString());
        writer.WriteStartElement("_managerUsernames");
        foreach (string username in _managerUsernames)
        {
            writer.WriteElementString("username", username);
        }
        writer.WriteEndElement(); // End the _managerUsernames element


    }

}

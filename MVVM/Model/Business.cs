using System;

public class Business
{
    private int _id;
    private string _name;
    private string _description;
    private string _category;
    private string _logo;
    private string _banner;
    private string _phoneNumber;
    private string _email;
    private string _website;
    private string _address;
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
}

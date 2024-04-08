using System;
using System.Collections.Generic;

public class Account
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Business> ManagedBusinesses { get; set; }

    public Account(string username, string password, List<Business> managedBusinesses)
    {
        Username = username;
        Password = password;
        ManagedBusinesses = managedBusinesses;
    }

    public Account()
    {
        ManagedBusinesses = new List<Business>();
    }

    public override string ToString()
    {
        return $"Username: {Username}, Password: {Password}, Managed Businesses: {ManagedBusinesses.Count}";
    }
}

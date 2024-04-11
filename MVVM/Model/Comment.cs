using System;

public class Comment
{
    private int _id;
    private string _username;
    private string _content;
    private DateTime _dateOfCreation;
    private DateTime _dateOfUpdate;

    public int Id => _id;
    public string Username => _username;
    public string Content => _content;
    public DateTime DateOfCreation => _dateOfCreation;
    public DateTime DateOfUpdate => _dateOfUpdate;


    public Comment(int id, string username, string content, DateTime creation, DateTime update)
    {
        _id = id;
        _username = username;
        _content = content;
        _dateOfCreation = creation;
        _dateOfUpdate = update;
    }

    public void SetContent(string content) => _content = content;
    public void SetDateOfCreation(string creation) => _dateOfCreation = DateOfCreation;
    public void SetDateOfUpdate(string update) => _dateOfUpdate = DateOfUpdate;

}

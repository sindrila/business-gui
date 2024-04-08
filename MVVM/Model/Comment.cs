using System;

public class Comment
{
    private int _id;
    private int _userId;
    private string _content;
    private DateTime _dateOfCreation;
    private DateTime _dateOfUpdate;

    public int Id => _id;
    public int UserId => _userId;
    public string Content => _content;
    public DateTime DateOfCreation => _dateOfCreation;
    public DateTime DateOfUpdate => _dateOfUpdate;


    public Comment(int id, int userId, string content, DateTime creation, DateTime update)
    {
        _id = id;
        _userId = userId;
        _content = content;
        _dateOfCreation = creation;
        _dateOfUpdate = update;
    }

    public void SetContent(string content) => _content = content;
    public void SetDateOfCreation(string creation) => _dateOfCreation = DateOfCreation;
    public void SetDateOfUpdate(string update) => _dateOfUpdate = DateOfUpdate;

}

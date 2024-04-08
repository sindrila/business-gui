using System;

public class FAQ
{
    private int _id;
    private int _businessId;
    private string _question;
    private string _answer;

    public FAQ(int id, int businessId, string question, string answer)
    {
        _id = id;
        _businessId = businessId;
        _question = question;
        _answer = answer;
    }
    public string GetQuestion(){ return _question; }
    public string GetAnswer() { return _answer; }
    public int GetId() { return _id; }
    public void SetQuestion(string question) { _question = question;}
    public void SetAnswear(string answer) { _answer = answer;}
}

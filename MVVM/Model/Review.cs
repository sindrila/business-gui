using System;

public class Review
{
	private int _id;
	private int _businessId;
	private int _userId;
	private int _rating;
	private string _comment;
	private string _title;
	private string _iamgePath;
	private DateTime _dateOfCreeation;
	private string _adminComment;


    public void SetAdminComment(string comment) { _adminComment = comment; }

    public Review(int id, int businessId, int userId, int rating, string comment, string title, string imagePath, DateTime dateOfCreation, string adminComment)
    {
        _id = id;
        _businessId = businessId;
        _userId = userId;
        _rating = rating;
        _comment = comment;
        _title = title;
        _iamgePath = imagePath;
        _dateOfCreeation = dateOfCreation;
        _adminComment = adminComment;
    }
    public Review() { this._id = this.GetReviewId() + 1; }
	public int GetRating() { return _rating; }
	public int GetReviewId() { return _id; }
	public string GetComment(){ return _comment; }
	public string GetTitle() { return _title; }
	public string GetImagePath() { return _iamgePath;}
	public string GetDateOfCreation() { return _dateOfCreeation.ToString();}
	public int GetBusinessId() { return _businessId; }
	public int GetUserId() { return _userId;}
	public string GetAdminComment() { return _adminComment; }
	public void SetUserId(int userId) { _userId = userId; }
	public  void SetTitle(string title) { _title = title;}
	public void SetImagePath(string imagePath) {  _iamgePath = imagePath;}
	 public void SetBusinessId(int businessId) { _businessId = businessId;}
	public void SetRating(int rating) {  _rating = rating; }
	public void SetComment(string comment) { _comment = comment;}
}

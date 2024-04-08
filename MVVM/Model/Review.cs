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
	private Comment _adminComment;

	public Review(int id, int businessId, int userId, int rating, string comment, string title, string imagePath, DateTime dateOfCreeation, Comment adminComment)
	{
		_id = id;
		_businessId = businessId;
		_userId = userId;
		_rating = rating;
		_comment = comment;
		_title = title;
		_iamgePath = imagePath;
		_dateOfCreeation = dateOfCreeation;
		_adminComment = adminComment;
	}
	public int GetRating() { return _rating; }
	public int GetReviewId() { return _id; }
	public string GetComment(){ return _comment; }
	public string GetTitle() { return _title; }
	public string GetImagePath() { return _iamgePath;}
	public string GetDateOfCreation() { return _dateOfCreeation.ToString();}
	public void SetAdminComment(Comment comment) { this._adminComment = comment; }

}

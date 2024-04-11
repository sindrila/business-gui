using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bussiness_social_media.MVVM.Model.Repository
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        Review GetReviewById(int id);
        void AddReview(string userName, int rating, string comment, string title, string imagePath, DateTime dateOfCreation, string adminComment);
        void UpdateReview(Review review);
        void DeleteReview(int id);
    }

    public class ReviewRepository : IReviewRepository
    {
        private List<Review> _reviews;
        private string _xmlFilePath;

        public ReviewRepository(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
            _reviews = new List<Review>();
            LoadReviewsFromXml();
        }

        ~ReviewRepository()
        {
            SaveReviewsToXml();
        }

        private void LoadReviewsFromXml()
        {
            try{
                if (File.Exists(_xmlFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Review), new XmlRootAttribute("Review"));

                    _reviews = new List<Review>();

                    using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Open))
                    {
                        using (XmlReader reader = XmlReader.Create(fileStream))
                        {
                            // Move to the first Business element
                            while (reader.ReadToFollowing("Review"))
                            {
                                // Deserialize each Business element and add it to the list
                                Review review = (Review)serializer.Deserialize(reader);
                                _reviews.Add(review);
                            }
                        }
                    }
                }
                else
                {
                    // Handle the case where the XML file doesn't exist
                    _reviews = new List<Review>();
                }
            }

            catch { }
            
        }

        private void SaveReviewsToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Review>), new XmlRootAttribute("ArrayOfReview"));

            using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, _reviews);
            }
        }

        public List<Review> GetAllReviews()
        {
            return _reviews;
        }

        public Review GetReviewById(int id)
        {
            return _reviews.FirstOrDefault(r => r.GetReviewId() == id);
        }

        public void AddReview(string userName, int rating, string comment, string title, string imagePath, DateTime dateOfCreation, string adminComment)
        {
            Review review = new Review(_getNextId(), userName, rating, comment, title, imagePath, dateOfCreation, adminComment);
            _reviews.Add(review);
            SaveReviewsToXml();
        }

        public void UpdateReview(Review review)
        {
            var existingReview = _reviews.FirstOrDefault(r => r.GetReviewId() == review.GetReviewId());
            if (existingReview != null)
            {
                existingReview.SetUserName(review.GetUserName());
                existingReview.SetRating(review.GetRating());
                existingReview.SetComment(review.GetComment());
                existingReview.SetTitle(review.GetTitle());
                existingReview.SetImagePath(review.GetImagePath());
                existingReview.SetAdminComment(review.GetAdminComment());
                SaveReviewsToXml();
            }
        }

        public void DeleteReview(int id)
        {
            var reviewToRemove = _reviews.FirstOrDefault(r => r.GetReviewId() == id);
            if (reviewToRemove != null)
            {
                _reviews.Remove(reviewToRemove);
                SaveReviewsToXml();
            }
        }

        private int _getNextId()
        {
            return _reviews.Count > 0 ? _reviews.Max(r => r.GetReviewId()) + 1 : 1;
        }
    }
}

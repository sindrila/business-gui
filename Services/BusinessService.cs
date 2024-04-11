
using business_social_media.Services;
using bussiness_social_media.MVVM.Model.Repository;
using System;
using System.IO;

namespace bussiness_social_media.Services
{
    public interface IBusinessService
    {
        List<Business> GetAllBusinesses();
        Business GetBusinessById(int id);
        void AddBusiness(string name, string description, string category, string logo, string banner, string phoneNumber, string email, string website, string address, DateTime createdAt, List<string> managerUsernames, List<int> postIds, List<int> reviewIds, List<int> faqIds);
        void UpdateBusiness(Business business);
        void DeleteBusiness(int id);
        List<Business> SearchBusinesses(string keyword);
        public List<Business> GetBusinessesManagedBy(string username);

        public bool IsUserManagerOfBusiness(int businessId, string username);
    }
    public class BusinessService : IBusinessService
    {
        private IBusinessRepository _businessRepository;
        private IFAQService _faqService;
        private IPostService _postService;
        private IReviewService _reviewService;

        public BusinessService(IBusinessRepository businessRepository, IFAQService FAQService, IPostService postService, IReviewService reviewService)
        {
            _businessRepository = businessRepository;
            _faqService = FAQService;
            _postService = postService;
            _reviewService = reviewService;
        }

        public List<Business> GetAllBusinesses()
        {
            return _businessRepository.GetAllBusinesses();
        }

        public Business GetBusinessById(int id)
        {
            return _businessRepository.GetBusinessById(id);
        }

        public void AddBusiness(string name, string description, string category, string logo, string banner, string phoneNumber, string email, string website, string address, DateTime createdAt, List<string> managerUsernames, List<int> postIds, List<int> reviewIds, List<int> faqIds)
        {
            _businessRepository.AddBusiness(name, description, category, logo, banner, phoneNumber, email, website, address, createdAt, managerUsernames, postIds, reviewIds, faqIds);
        }

        public void UpdateBusiness(Business business)
        {
            _businessRepository.UpdateBusiness(business);
        }

        public void DeleteBusiness(int id)
        {
            _businessRepository.DeleteBusiness(id);
        }

        public List<Business> SearchBusinesses(string keyword)
        {
           return _businessRepository.SearchBusinesses(keyword);
        }

        public List<Business> GetBusinessesManagedBy(string username)
        {
            List<Business> businessesManagedByUser = new List<Business>();

            foreach (Business business in _businessRepository.GetAllBusinesses())
            {
                if (business.ManagerUsernames.Contains(username))
                {
                    businessesManagedByUser.Add(business);
                }
            }

            return businessesManagedByUser;
        }

        public bool IsUserManagerOfBusiness(int businessId, string username)
        {
            Business business = _businessRepository.GetBusinessById(businessId);
            return business != null && business.ManagerUsernames.Contains(username);
        }
    }

}



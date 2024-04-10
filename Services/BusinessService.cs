
using bussiness_social_media.MVVM.Model.Repository;
using System;
using System.IO;

namespace bussiness_social_media.Services
{
    public interface IBusinessService
    {
        List<Business> GetAllBusinesses();
        Business GetBusinessById(int id);
        void AddBusiness(string name, string description, string category, string logo, string banner, string phoneNumber, string email, string website, string address, DateTime createdAt);
        void UpdateBusiness(Business business);
        void DeleteBusiness(int id);
        List<Business> SearchBusinesses(string keyword);
    }
    public class BusinessService : IBusinessService
    {
        private IBusinessRepository _businessRepository;

        public BusinessService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public List<Business> GetAllBusinesses()
        {
            return _businessRepository.GetAllBusinesses();
        }

        public Business GetBusinessById(int id)
        {
            return _businessRepository.GetBusinessById(id);
        }

        public void AddBusiness(string name, string description, string category, string logo, string banner, string phoneNumber, string email, string website, string address, DateTime createdAt)
        {
            _businessRepository.AddBusiness(name, description, category, logo, banner, phoneNumber, email, website, address, createdAt);
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
    }

}



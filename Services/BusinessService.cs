
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
        private List<Business> _businesses;

        private static Random _random = new Random();
        public BusinessService()
        {
            _businesses = new List<Business>();
            generate10RandomBusineses();
        }

        private void generate10RandomBusineses()
        {
            string[] categories = { "Food", "Tech", "Retail", "Finance", "Services" };
            string[] namePrefixes = { "The", "Super", "Awesome", "Modern", "Innovative" };
            string[] nameSuffixes = { "Co.", "Inc.", "Hub", "Solutions", "Place" };

            for (int i = 0; i < 10; i++)
            {
                string name = namePrefixes[_random.Next(namePrefixes.Length)] + " " + nameSuffixes[_random.Next(nameSuffixes.Length)];
                string description = "A cool business doing cool things!";
                string category = categories[_random.Next(categories.Length)];

                string binDirectory = "\\bin";
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string pathUntilBin;


                int index = basePath.IndexOf(binDirectory);
                pathUntilBin = basePath.Substring(0, index);

                // Placeholder values for logo, banner, etc.
                string logo = Path.Combine(pathUntilBin, $"Assets\\Images\\scat{i + 1}.jpg");
                string banner = Path.Combine(pathUntilBin, $"Assets\\Images\\banner{i + 1}.jpg");

                string phoneNumber = GenerateRandomPhoneNumber();
                string email = $"business{i}@example.com";
                string website = $"http://{name.Replace(' ', '-')}.com";
                string address = "123 Main St., Anytown, CA";

                AddBusiness(name, description, category, logo, banner, phoneNumber, email, website, address, DateTime.Now);
            }
        }
        private string GenerateRandomPhoneNumber()
        {
            return $"{_random.Next(100, 999)}-{_random.Next(100, 999)}-{_random.Next(1000, 9999)}";
        }
        public List<Business> GetAllBusinesses()
        {
            return _businesses;
        }

        public Business GetBusinessById(int id)
        {
            return _businesses.FirstOrDefault(b => b.Id == id);
        }

        public void AddBusiness(string name, string description, string category, string logo, string banner, string phoneNumber, string email, string website, string address, DateTime createdAt)
        {
            Business business = new Business(_getNextId(), name, description, category, logo, banner, phoneNumber, email, website, address, createdAt);
            _businesses.Add(business);
        }

        public void UpdateBusiness(Business business)
        {
            var existingBusiness = _businesses.FirstOrDefault(b => b.Id == business.Id);
            if (existingBusiness != null)
            {
                existingBusiness.SetName(business.Name);
                existingBusiness.SetDescription(business.Description);
                existingBusiness.SetCategory(business.Category);
                existingBusiness.SetLogo(business.Logo);
                existingBusiness.SetBanner(business.Banner);
                existingBusiness.SetPhoneNumber(business.PhoneNumber);
                existingBusiness.SetEmail(business.Email);
                existingBusiness.SetWebsite(business.Website);
                existingBusiness.SetAddress(business.Address);

            }
        }

        public void DeleteBusiness(int id)
        {
            var businessToRemove = _businesses.FirstOrDefault(b => b.Id == id);
            if (businessToRemove != null)
            {
                _businesses.Remove(businessToRemove);
            }
        }

        private int _getNextId()
        {
            return _businesses.Count > 0 ? _businesses.Max(b => b.Id) + 1 : 1;
        }


        public List<Business> SearchBusinesses(string keyword)
        {
            var filteredBusinesses = _businesses.Where(b =>
            (string.IsNullOrEmpty(keyword) ||
            b.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            b.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            b.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            ).ToList();
            return filteredBusinesses;

        }
    }

}



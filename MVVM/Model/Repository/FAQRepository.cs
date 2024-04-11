using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bussiness_social_media.MVVM.Model.Repository
{
    public interface IFAQRepository
    {
        List<FAQ> GetAllFAQs();
        FAQ GetFAQById(int id);
        void AddFAQ(int businessId, string question, string answer);
        void UpdateFAQ(FAQ faq);
        void DeleteFAQ(int id);
    }

    public class FAQRepository : IFAQRepository
    {
        private List<FAQ> _faqs;
        private string _xmlFilePath;

        public FAQRepository(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
            _faqs = new List<FAQ>();
            LoadFAQsFromXml();
        }

        ~FAQRepository()
        {
            SaveFAQsToXml();
        }

        private void LoadFAQsFromXml()
        {
            if (File.Exists(_xmlFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<FAQ>), new XmlRootAttribute("ArrayOfFAQ"));

                using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Open))
                {
                    _faqs = (List<FAQ>)serializer.Deserialize(fileStream);
                }
            }
            else
            {
                // Handle the case where the XML file doesn't exist
                _faqs = new List<FAQ>();
            }
        }

        private void SaveFAQsToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FAQ>), new XmlRootAttribute("ArrayOfFAQ"));

            using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, _faqs);
            }
        }

        public List<FAQ> GetAllFAQs()
        {
            return _faqs;
        }

        public FAQ GetFAQById(int id)
        {
            return _faqs.FirstOrDefault(f => f.GetId() == id);
        }

        public void AddFAQ(int businessId, string question, string answer)
        {
            FAQ faq = new FAQ(_getNextId(), businessId, question, answer);
            _faqs.Add(faq);
            SaveFAQsToXml();
        }

        public void UpdateFAQ(FAQ faq)
        {
            var existingFAQ = _faqs.FirstOrDefault(f => f.GetId() == faq.GetId());
            if (existingFAQ != null)
            {
                existingFAQ.SetQuestion(faq.GetQuestion());
                existingFAQ.SetAnswer(faq.GetAnswer());
                SaveFAQsToXml();
            }
        }

        public void DeleteFAQ(int id)
        {
            var faqToRemove = _faqs.FirstOrDefault(f => f.GetId() == id);
            if (faqToRemove != null)
            {
                _faqs.Remove(faqToRemove);
                SaveFAQsToXml();
            }
        }

        private int _getNextId()
        {
            return _faqs.Count > 0 ? _faqs.Max(f => f.GetId()) + 1 : 1;
        }
    }
}
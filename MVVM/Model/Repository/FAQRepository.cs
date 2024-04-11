using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bussiness_social_media.MVVM.Model.Repository
{
    public interface IFAQRepository
    {
        List<FAQ> GetAllFAQs();
        FAQ GetFAQById(int id);
        int AddFAQ(string faqQuestion, string faqAnswer);
        void UpdateFAQ(int faqID, string newFaqQuestion, string newFaqAnswer);
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
            SaveFAQsToXml();
        }

        ~FAQRepository()
        {
            SaveFAQsToXml();
        }

        private void LoadFAQsFromXml()
        {
            try {
                if (File.Exists(_xmlFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FAQ), new XmlRootAttribute("FAQ"));

                    _faqs = new List<FAQ>();

                    using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Open))
                    using (XmlReader reader = XmlReader.Create(fileStream))
                    {
                        // Move to the first FAQ element
                        while (reader.ReadToFollowing("FAQ"))
                        {
                            // Deserialize each FAQ element and add it to the list
                            FAQ faq = (FAQ)serializer.Deserialize(reader);
                            _faqs.Add(faq);
                        }
                    }
                }
                else
                {
                    // Handle the case where the XML file doesn't exist
                    _faqs = new List<FAQ>();
                }
            }
            catch { }
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

        public int AddFAQ(string faqQuestion, string faqAnswer)
        {
            int newID = _getNextId();
            FAQ faq = new FAQ(newID, faqQuestion, faqAnswer);
            _faqs.Add(faq);
            SaveFAQsToXml();
            return newID;
        }

        public void UpdateFAQ(int faqID, string newFaqQuestion, string newFaqAnswer)
        {
            var existingFAQ = _faqs.FirstOrDefault(f => f.GetId() ==faqID);
            if (existingFAQ != null)
            {
                existingFAQ.SetQuestion(newFaqQuestion);
                existingFAQ.SetAnswer(newFaqAnswer);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace bussiness_social_media.MVVM.Model.Repository
{
    public interface IFAQRepository
    {
        List<FAQ> GetAllFAQs();
        FAQ GetFAQById(int id);
        int AddFAQ(string faqQuestion, string faqAnswer);
        void UpdateFAQ(int id, string newFaqQuestion, string newFaqAnswer);
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
            // TODO: the destructor is not called?????? 
            // Probably all repositories are saved to file only after CRUD operations
            SaveFAQsToXml();
        }

        private void LoadFAQsFromXml()
        {
            try
            {
                _faqs = new List<FAQ>();
                if (File.Exists(_xmlFilePath))
                {
                    // I have no idea why only this line works
                    // It should have been (typeof(List<FAQ>), new XmlRootAttribute("ArrayOfFAQ")
                    // if you look in the xml file, the root attribute is a ArrayOfFaq
                    // but this line reads the first FAQ
                    // Tried to make it a List<FAQ>, got an exception
                    // Maybe it is a personal skill issue and this line is actually correct
                    // If shit goes south, look into this :* xoxo gossip girl
                    XmlSerializer serializer = new XmlSerializer(typeof(FAQ), new XmlRootAttribute("FAQ"));

                    using (FileStream fileStream = new FileStream(_xmlFilePath, FileMode.Open))
                    {
                        using (XmlReader reader = XmlReader.Create(fileStream))
                        {
                            while (reader.ReadToFollowing("FAQ"))
                            {
                                FAQ faq = (FAQ)serializer.Deserialize(reader);
                                _faqs.Add(faq);
                            }
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something terrible, terrible has happened during the execution of the program. Show this to your local IT guy: " + ex.Message);
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

        public int AddFAQ(string faqQuestion, string faqAnswer)
        {
            int newID = _getNextId();
            FAQ faq = new FAQ(newID, faqQuestion, faqAnswer);
            _faqs.Add(faq);
            SaveFAQsToXml();
            return newID;
        }

        public void UpdateFAQ(int id, string newFaqQuestion, string newFaqAnswer)
        {
            var existingFAQ = _faqs.FirstOrDefault(f => f.GetId() == id);
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

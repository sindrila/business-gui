using business_social_media.Services;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness_social_media.MVVM.ViewModel
{
    class UserManagedBusinessPagesViewModel : Core.ViewModel
    {
        private readonly IBusinessService _businessService;

        public UserManagedBusinessPagesViewModel(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        public void LoadBusinesses()
        {
            var businesses = _businessService.GetAllBusinesses();
        }
    }
}

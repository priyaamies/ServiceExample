using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WpfApplication.ServiceReference1;

namespace WpfApplication
{
    public class ViewModel
    {
        ServiceReference1.CountryServiceClient _serviceClient = new CountryServiceClient();

        public List<Country> Countries
        {
            get
            {
                return _serviceClient.GetCountries().ToList();
            }
        }

    }
}

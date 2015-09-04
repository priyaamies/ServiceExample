using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfService
{
    [ServiceContract]
    public interface ICountryService
    {

        [OperationContract]
        List<Country> GetCountries();

        [OperationContract]
        int CountOfCountries();
    }

    [DataContract]
    public class Country
    {
        int countryId;
        string countryName = string.Empty;
        string countryAbbr = string.Empty;

        [DataMember]
        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }
        [DataMember]
        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }
        [DataMember]
        public string CountryAbbr
        {
            get { return countryAbbr; }
            set { countryAbbr = value; }
        }
    }
}
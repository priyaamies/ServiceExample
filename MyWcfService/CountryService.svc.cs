using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace MyWcfService
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.
    public class CountryService : ICountryService
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\RaviPriya\Documents\Country.accdb;Persist Security Info=False");

        public int CountOfCountries()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select count(*) from Country", con);
            return Convert.ToInt32(cmd.ExecuteScalar());
            
        }
        public List<Country> GetCountries()
        {
            List<Country> CountryDetails = new List<Country>();
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from Country Order By CountryName", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Country countryInfo = new Country();
                        countryInfo.CountryId = Convert.ToInt32(dt.Rows[i]["CountryId"]);
                        countryInfo.CountryName = dt.Rows[i]["CountryName"].ToString();
                        countryInfo.CountryAbbr = dt.Rows[i]["CountryAbbr"].ToString();

                        CountryDetails.Add(countryInfo);
                    }
                }
                con.Close();
            }
            return CountryDetails;
        }
    }
    
}

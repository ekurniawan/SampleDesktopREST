using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using MyHospital.Billing.DataSosial.Bo;

namespace SampleDesktop.Services
{
    public class AgamaService
    {
        private RestClient _client;

        public AgamaService()
        {
            _client = new RestClient("http://localhost:53273/");
        }

        public IEnumerable<Agama> GetAll()
        {
            var request = new RestRequest("api/BillingDataSosial/Agama/ListAll", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            var response = _client.Execute<List<Agama>>(request);

            return response.Data;
        }
    }
}

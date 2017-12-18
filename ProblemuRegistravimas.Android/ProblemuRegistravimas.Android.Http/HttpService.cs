using ProblemuRegistravimas.AndroidProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ProblemuRegistravimas.AndroidProject.Http.Models;
using RestSharp;

namespace ProblemuRegistravimas.AndroidProject.Http
{
    public class HttpService : IHttpService
    {
        private static string _locationApiKey = "AIzaSyCscBsgen5gUdcVpe0bGoikdmPzC-I-Qr4";
        private static string _googlePlacesApi = "https://maps.googleapis.com/maps/api/place/autocomplete/json?location=54.9071472,23.955186400000002&radius=30000&strictbounds";

        public bool LoginUser(Login login)
        {
            //TODO Implement login logic
            return true;
        }

        public List<string> GetUsers()
        {
            //TODO Implement login logic
            return new List<string>
            {
                "Tomas Valiunas", "Random Dude", "Jonas Jonaitis", "Petras petraitis", "Tomas Tomaitis"
            };
        }

        public List<string> GetLocationAutocompleteList(string query)
        {
            var restClient = new RestClient(_googlePlacesApi);
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("key", _locationApiKey);
            request.AddQueryParameter("input", query);
            IRestResponse response = restClient.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var predictions = JsonConvert.DeserializeObject<Predictions>(response.Content);
                return predictions.predictions.Select(x => x.description).ToList();
            }
            return new List<string>();
        }
    }
}

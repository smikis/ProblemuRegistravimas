using ProblemuRegistravimas.AndroidProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ProblemuRegistravimas.AndroidProject.Http.Models;
using RestSharp;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ProblemuRegistravimas.AndroidProject.Http
{
    public class HttpService : IHttpService
    {
        private static string _locationApiKey = "AIzaSyCscBsgen5gUdcVpe0bGoikdmPzC-I-Qr4";
        private static string _googlePlacesApi = "https://maps.googleapis.com/maps/api/place/autocomplete/json?location=54.9071472,23.955186400000002&radius=30000&strictbounds";
        private static ISettings AppSettings => CrossSettings.Current;

        public bool LoginUser(Login login)
        {
            return Cache.Logins.Any(x => x.Username == login.Username && x.Password == login.Password);
        }

        public bool AssignProblem(int problemId)
        {
            var currentUser = AppSettings.GetValueOrDefault("username", string.Empty);
            var problem = Cache.Problems.FirstOrDefault(x => x.Id == problemId);
            if (problem != null)
                problem.AssignedUser = currentUser;
            return true;
        }

        public bool CloseProblem(int problemId)
        {
            var problem = Cache.Problems.FirstOrDefault(x => x.Id == problemId);
            if (problem != null)
                problem.Closed = true;
            return true;
        }

        public List<string> GetUsers()
        {
            //TODO Implement login logic
            return Cache.Clients.Select(x=> $"{x.Name} {x.LastName}").ToList();
        }

        public List<Problem> GetProblems(string status)
        {
            var currentUser = AppSettings.GetValueOrDefault("username", string.Empty);
            switch (status)
            {
                case "Assigned":
                    return Cache.Problems.Where(x => !x.Closed && x.AssignedUser == currentUser).ToList();
                case "Open":
                    return Cache.Problems.Where(x => x.AssignedUser == null && !x.Closed).ToList();
                case "Closed":
                    return Cache.Problems.Where(x => x.Closed && x.AssignedUser == currentUser).ToList();
            }
            return Cache.Problems;
        }

        public Problem GetProblem(int id)
        {
            return Cache.Problems.SingleOrDefault(x => x.Id == id);
        }

        public bool CreateProblem(string name, string description, string priority, string location, string client)
        {
            var problemId = Cache.Problems.Max(x => x.Id) + 1;
            var problem = new Problem
            {
                Id= problemId,
                Client = client,
                Name = name,
                Description = description,
                Priority = priority,
                Location = location,
                Closed = false
            };
            Cache.Problems.Add(problem);
            return true;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProblemuRegistravimas.AndroidProject.Models;

namespace ProblemuRegistravimas.AndroidProject.Http
{
    public static class Cache
    {
        
        public static List<Problem> Problems = new List<Problem>
        {
           new Problem
                {
                    Name = "Test problem",
                    Priority = "Normal",
                    Description = "Test problem description",
                    Location = "Studentų g. 67, Kaunas",
                    AssignedUser = "tomas",
                    Closed = false
                },

       new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Normal",
                    Description = "Test problem description 2",
                    Closed = false,
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem",
                    Priority = "Normal",
                    Description = "Test problem description",
                    Closed = false,
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Normal",
                    AssignedUser = "tomas",
                    Description = "Test problem description 2",
                    Closed = false,
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem",
                    Priority = "Normal",
                    Description = "Test problem description",
                    Closed = true,
                    AssignedUser = "tomas",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Critical",
                    Description = "Test problem description 2",
                    Closed = true,
                    AssignedUser = "tomas",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem",
                    Priority = "Critical",
                    Description = "Test problem description",
                    Closed = true,
                    AssignedUser = "tomas",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Critical",
                    Description = "Test problem description 2",
                    Closed = false,
                    AssignedUser = "tomas",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem",
                    Priority = "Critical",
                    Description = "Test problem description",
                    Closed = true,
                    AssignedUser = "tomas",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Critical",
                    Description = "Test problem description 2 Test problem description 2 Test problem description 2 Test problem description 2 Test problem description 2Test problem description 2Test problem description 2Test problem description 2Test problem description 2 Test problem description 2Test problem description 2",
                    Closed = false,
                    AssignedUser = "tomas",
                   Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem",
                    Priority = "Critical",
                    Description = "Test problem description",
                    Closed = true,
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Critical",
                    Description = "Test problem description 2",
                    Closed = false,
                    AssignedUser = "administrator",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem",
                    Priority = "Critical",
                    Description = "Test problem description Test problem description 2 Test problem description 2 Test problem description 2 Test problem description 2",
                    Closed = true,
                    AssignedUser = "tomas",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Major",
                    Description = "Test problem description 2",
                    Closed = true,
                    AssignedUser = "administrator",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem",
                    Priority = "Major",
                    Description = "Test problem description",
                    Closed = false,
                    AssignedUser = "tomas",
                    Location = "Studentų g. 67, Kaunas"
                },

               new Problem
                {
                    Name = "Test problem 2 ",
                    Priority = "Major",
                    Closed = true,
                    AssignedUser = "administrator",
                    Description = "Test problem description 2",
                    Location = "Studentų g. 67, Kaunas"
                },
        };

        //"Tomas Valiunas", "Random Dude", "Jonas Jonaitis", "Petras petraitis", "Tomas Tomaitis"
        public static List<Client> Clients = new List<Client>
        {
            new Client
            {
                Id =1,
                Name = "Tomas",
                LastName = "Valiunas",
                Address = "Studentų g. 67, Kaunas"
            },
            new Client
            {
                Id =2,
                Name = "Random",
                LastName = "Dude",
                Address = "Studentų g. 67, Kaunas"
            },
            new Client
            {
                Id =3,
                Name = "Jonas",
                LastName = "Jonaitis",
                Address = "Studentų g. 67, Kaunas"
            },
            new Client
            {
                Id =4,
                Name = "Petras",
                LastName = "petraitis",
                Address = "Studentų g. 67, Kaunas"
            },
            new Client
            {
                Id =5,
                Name = "Tomas",
                LastName = "Tomaitis",
                Address = "Studentų g. 67, Kaunas"
            }
        };


        public static List<Login> Logins = new List<Login>
        {
            new Login
            {
                Username = "tomas",
                Password = "tom"
            },
            new Login
            {
                Username = "administrator",
                Password = "tom"
            },
            new Login
            {
                Username = "new",
                Password = "new"
            }
        };


    }
}
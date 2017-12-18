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

namespace ProblemuRegistravimas.AndroidProject.Http.Models
{
    public class Prediction
    {
        public string description { get; set; }
        public string id { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
    }

    public class Predictions
    {
        public List<Prediction> predictions { get; set; }
        public string status { get; set; }
    }
}
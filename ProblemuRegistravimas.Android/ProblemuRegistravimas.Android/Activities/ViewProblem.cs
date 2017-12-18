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
using ProblemuRegistravimas.AndroidProject.Http;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "ViewProblem")]
    public class ViewProblem : Activity
    {
        private TextView _priorityField;
        private TextView _titleField;
        private TextView _locationField;
        private TextView _userField;
        private TextView _statusField;
        private TextView _descriptionField;
        private IHttpService _httpService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TODO Implement Dependency Injection
            _httpService = new HttpService();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewProblem);

            _priorityField = FindViewById<TextView>(Resource.Id.priorityField);
            _titleField = FindViewById<TextView>(Resource.Id.titleField);
            _locationField = FindViewById<TextView>(Resource.Id.locationField);
            _userField = FindViewById<TextView>(Resource.Id.userField);
            _statusField = FindViewById<TextView>(Resource.Id.statusField);
            _descriptionField = FindViewById<TextView>(Resource.Id.descriptionField);

            var id = Intent.GetIntExtra("PROBLEM_ID", 1);
            var problem = _httpService.GetProblem(id);
            _priorityField.Text = problem.Priority;
            _titleField.Text = problem.Name;
            _locationField.Text = problem.Location;
            _userField.Text = problem.Client;
            _statusField.Text = problem.Closed ? "Closed" : "Open";
            _descriptionField.Text = problem.Description;


        }
    }
}
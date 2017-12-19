using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ProblemuRegistravimas.AndroidProject.Http;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "ViewProblem")]
    public class ViewProblem : Activity, IOnMapReadyCallback

    {
        private int _id;
        private TextView _priorityField;
        private TextView _titleField;
        private TextView _locationField;
        private TextView _userField;
        private TextView _statusField;
        private TextView _descriptionField;
        private Button _closeButton;
        private Button _assignButton;
        private GoogleMap _map;
        private MapFragment _mapFragment;      
        private double _latitude;
        private double _longitude;

        private static ISettings AppSettings => CrossSettings.Current;
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
            _assignButton = FindViewById<Button>(Resource.Id.assignButton);
            _closeButton = FindViewById<Button>(Resource.Id.closeButton);

            _id = Intent.GetIntExtra("PROBLEM_ID", 1);
            var problem = _httpService.GetProblem(_id);
            _priorityField.Text = problem.Priority;
            _titleField.Text = problem.Name;
            _locationField.Text = problem.Location;
            _userField.Text = problem.Client;
            _statusField.Text = problem.Closed ? "Closed" : "Open";
            _descriptionField.Text = problem.Description;

            if (problem.Closed)
            {
                _closeButton.Visibility = ViewStates.Gone;
                _assignButton.Visibility = ViewStates.Gone;
            }
            else
            {
                var currentUser = AppSettings.GetValueOrDefault("username", string.Empty);
                if (currentUser == problem.AssignedUser)
                {
                    _closeButton.Visibility = ViewStates.Visible;
                    _assignButton.Visibility = ViewStates.Gone;
                }
                else
                {
                    _closeButton.Visibility = ViewStates.Gone;
                    _assignButton.Visibility = ViewStates.Visible;
                }
            }
           

            _closeButton.Click += _closeButton_Click;
            _assignButton.Click += _assignButton_Click;

            Geocoder coder = new Geocoder(this);
            IList<Address> addresses;
            addresses = coder.GetFromLocationName(problem.Location, 1);
            if (addresses.Count > 0)
            {
                _latitude = addresses[0].Latitude;
                _longitude = addresses[0].Longitude;
            }

            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);

        }

        private void _assignButton_Click(object sender, EventArgs e)
        {
            _httpService.AssignProblem(_id);
            StartActivity(typeof(HomeActivity));
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            _httpService.CloseProblem(_id);
            StartActivity(typeof(HomeActivity));
        }

        public void OnMapReady(GoogleMap map)
        {
            _map = map;
            MarkerOptions markerOpt1 = new MarkerOptions();
            LatLng kaunas = new LatLng(_latitude, _longitude);
            markerOpt1.SetPosition(kaunas);
            markerOpt1.SetTitle("Kaunas");
            markerOpt1.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
            _map.AddMarker(markerOpt1);

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(kaunas, 15);
            _map.MoveCamera(cameraUpdate);
        }
    }
}
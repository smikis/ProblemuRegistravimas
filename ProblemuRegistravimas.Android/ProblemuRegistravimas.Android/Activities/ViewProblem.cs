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
using ProblemuRegistravimas.AndroidProject.Http;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "ViewProblem")]
    public class ViewProblem : Activity, IOnMapReadyCallback

    {
        private TextView _priorityField;
        private TextView _titleField;
        private TextView _locationField;
        private TextView _userField;
        private TextView _statusField;
        private TextView _descriptionField;
        private GoogleMap _map;
        private MapFragment _mapFragment;
        private IHttpService _httpService;
        private double _latitude;
        private double _longitude;

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

            Geocoder coder = new Geocoder(this);
            IList<Address> addresses;
            addresses = coder.GetFromLocationName(problem.Location, 1);
            if (addresses.Count > 0)
            {
                double latitude = addresses[0].Latitude;
                double longitude = addresses[0].Longitude;
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

        public void OnMapReady(GoogleMap map)
        {
            _map = map;
            MarkerOptions markerOpt1 = new MarkerOptions();
            LatLng kaunas = new LatLng(54.9071472, 23.955186400000002);
            markerOpt1.SetPosition(kaunas);
            markerOpt1.SetTitle("Kaunas");
            markerOpt1.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
            _map.AddMarker(markerOpt1);

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(kaunas, 15);
            _map.MoveCamera(cameraUpdate);
        }
    }
}
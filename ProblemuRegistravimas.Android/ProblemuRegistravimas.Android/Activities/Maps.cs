using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;


namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "Maps")]
    public class Maps : Activity, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private MapFragment _mapFragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.map_fragment);
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
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using ProblemuRegistravimas.AndroidProject.Adapters;
using ProblemuRegistravimas.AndroidProject.Fragments;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            // Adding Toolbar to Main screen           
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Problemos";
            SetSupportActionBar(toolbar);
            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            SetViewAdapter(viewPager);

            tabs.SetupWithViewPager(viewPager);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += Fab_Click;

        }

        private void Fab_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(CreateProblemActivity));
        }

        private void SetViewAdapter(ViewPager viewPager)
        {
            ViewAdaper adapter = new ViewAdaper(SupportFragmentManager);
            adapter.AddFragment(new ListActiveProblemsFragment(), "Assigned");
            adapter.AddFragment(new ListOpenProblemsFragment(), "Open");
            adapter.AddFragment(new ListClosedProblemsFragment(), "Closed");
            viewPager.Adapter = adapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.problemMenu:
                    //do something
                    return true;
                case Resource.Id.usersMenu:
                    //do something
                    return true;
                case Resource.Id.settingsMenu:
                    //do something
                    return true;
                case Resource.Id.logoutMenu:
                    StartActivity(typeof(LoginActivity));
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        

    }
}
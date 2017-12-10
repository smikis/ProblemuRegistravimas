using Android.App;
using Android.OS;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "ProblemuRegistravimas.AndroidProject")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}


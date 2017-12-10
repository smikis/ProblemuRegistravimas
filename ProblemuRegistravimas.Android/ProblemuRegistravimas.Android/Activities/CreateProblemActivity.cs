using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "Register problem")]
    public class CreateProblemActivity : Activity
    {
        private Spinner _priorityField;
        private EditText _titleField;
        private EditText _locationField;
        private AutoCompleteTextView _userField;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.CreateProblem);
            _priorityField = FindViewById<Spinner>(Resource.Id.priorityField);
            _titleField = FindViewById<EditText>(Resource.Id.titleField);
            _locationField = FindViewById<EditText>(Resource.Id.locationField);
            _userField = FindViewById<AutoCompleteTextView>(Resource.Id.userField);

            _userField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, new List<string>{"Tomas Valiunas", "Random Dude", "Jonas Jonaitis", "Petras petraitis", "Tomas Tomaitis"});
            _priorityField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, new List<string> { "Normal", "Critical", "Major"});

        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Widget;
using ProblemuRegistravimas.AndroidProject.Http;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "Register problem")]
    public class CreateProblemActivity : Activity
    {
        private Spinner _priorityField;
        private EditText _titleField;
        private AutoCompleteTextView _locationField;
        private AutoCompleteTextView _userField;
        private EditText _description;
        private Button _createButton;

        private IHttpService _httpService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TODO Implement Dependency Injection
            _httpService = new HttpService();
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.CreateProblem);
            _priorityField = FindViewById<Spinner>(Resource.Id.priorityField);
            _titleField = FindViewById<EditText>(Resource.Id.titleField);
            _locationField = FindViewById<AutoCompleteTextView>(Resource.Id.locationField);
            _userField = FindViewById<AutoCompleteTextView>(Resource.Id.userField);
            _description = FindViewById<EditText>(Resource.Id.descriptionField);

            _locationField.TextChanged += _locationField_TextChanged;
            _createButton = FindViewById<Button>(Resource.Id.confirmButton);

            _createButton.Click += _createButton_Click;

            _userField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, _httpService.GetUsers());
            _locationField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, new List<string>());
            _priorityField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, new List<string> { "Normal", "Critical", "Major"});

        }

        private void _createButton_Click(object sender, System.EventArgs e)
        {
            _httpService.CreateProblem(_titleField.Text, _description.Text, _priorityField.SelectedItem.ToString(),
                _locationField.Text, _userField.Text);
            StartActivity(typeof(HomeActivity));
        }

        private void _locationField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.Text.Count()>= 5)
            {
                _locationField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, _httpService.GetLocationAutocompleteList(new string(e.Text.ToArray())));
            }
        }
    }

}
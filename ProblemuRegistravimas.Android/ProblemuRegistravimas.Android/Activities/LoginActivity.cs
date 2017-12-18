using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using ProblemuRegistravimas.AndroidProject.Http;
using ProblemuRegistravimas.AndroidProject.Models;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        private EditText _usernameField;
        private EditText _passwordField;
        private IHttpService _httpService;
        private static ISettings AppSettings => CrossSettings.Current;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TODO Implement Dependency Injection
            _httpService = new HttpService();
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            _usernameField = FindViewById<EditText>(Resource.Id.username);
            _usernameField.Text = AppSettings.GetValueOrDefault("username", string.Empty);
            _passwordField = FindViewById<EditText>(Resource.Id.password);

            var loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += LoginButton_Click;

            var forgotPasswordLink = FindViewById<TextView>(Resource.Id.forgotPasswordLink);
            forgotPasswordLink.Click += ForgotPasswordLink_Click; ;

        }

        private void ForgotPasswordLink_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CreateProblemActivity));
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_usernameField.Text) && !string.IsNullOrEmpty(_passwordField.Text))
            {
                AppSettings.AddOrUpdateValue("username", _usernameField.Text);
                //TODO Implement login logic here
                var loginModel = new Login
                {
                    Username = _usernameField.Text,
                    Password = _passwordField.Text
                };

                if (_httpService.LoginUser(loginModel))
                {

                }
                    //TODO Show error             
            } 
        }


    }
}
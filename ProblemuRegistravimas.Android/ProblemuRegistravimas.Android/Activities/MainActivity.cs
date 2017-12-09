﻿using Android.App;
using Android.OS;

namespace ProblemuRegistravimas.Android.Activities
{
    [Activity(Label = "ProblemuRegistravimas.Android")]
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


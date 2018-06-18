﻿using System;
using Android.App;
using Android.OS;
using Com.Liferay.Mobile.Android.Auth.Basic;
using Com.Liferay.Mobile.Android.Service;
using Com.Liferay.Mobile.Push;
using Org.Json;

namespace PushAndroid
{
    [Activity(Label = "PushAndroid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, Push.IOnSuccess, Push.IOnFailure
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var Session = new SessionImpl("http://10.0.2.2:8080", new BasicAuthentication("test@liferay.com", "test"));
            Push.With(Session)
                .WithPortalVersion(70)
                .OnSuccess(this)
                .OnFailure(this)
                .Register(this, "393909434085");
        }

        public void OnSuccess(JSONObject p0)
        {
            Console.WriteLine($"Device registered succesfully: {p0}");
        }

        public void OnFailure(Java.Lang.Exception p0)
        {
            Console.WriteLine($"Device register failed: {p0.Message}");
        }
    }
}
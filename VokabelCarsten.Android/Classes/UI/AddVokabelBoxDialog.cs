using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VokabelCarsten.Classes.UI
{
    class AddVokabelBoxDialog : Dialog
    {
        public AddVokabelBoxDialog(Activity activity) : base(activity)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AddVokabelBox);

            Button save = FindViewById<Button>(Resource.Id.save);
            save.Click += delegate
            {
                EditText title, colum1, colum2;
                title = FindViewById<EditText>(Resource.Id.title);
                colum1 = FindViewById<EditText>(Resource.Id.colum1);
                colum2 = FindViewById<EditText>(Resource.Id.colum2);
                
                Control.createVocabelKasten(title.Text, colum1.Text, colum2.Text);
                Dismiss();
            };

            Button cancel = FindViewById<Button>(Resource.Id.cancel);
            cancel.Click += delegate
            {
                Dismiss();
            };
        }
    }
}
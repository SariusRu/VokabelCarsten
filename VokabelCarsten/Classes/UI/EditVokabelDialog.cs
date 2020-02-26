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
    class EditVokabelDialog : Dialog
    {

        public EditVokabelDialog(Activity activity) : base(activity)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AddVokabel);

            Button save = FindViewById<Button>(Resource.Id.save);
            save.Click += delegate
            {
                EditText native, foreign;
                native = FindViewById<EditText>(Resource.Id.nativeVocab);
                foreign = FindViewById<EditText>(Resource.Id.foreignVocab);

                Control.createVocab(native.Text, foreign.Text);
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
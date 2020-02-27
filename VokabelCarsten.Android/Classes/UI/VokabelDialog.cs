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
    class VokabelDialog : Dialog
    {

        public VokabelDialog(Activity activity) : base(activity)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AddVokabel);

            Button save = FindViewById<Button>(Resource.Id.save);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);

            EditText native, foreign;
            native = FindViewById<EditText>(Resource.Id.nativeVocab);
            foreign = FindViewById<EditText>(Resource.Id.foreignVocab);

            //Load Clicked Item
            if (Control.getVocab() != null)
            {
                native.Text = Control.getVocab().side1;
                foreign.Text = Control.getVocab().side2;

                cancel.Text = base.Context.GetString(Resource.String.Delete);
            }

            save.Click += delegate
            {
                if (Control.getVocab() != null)
                {
                    Control.editVokab(native.Text, foreign.Text);
                }
                else
                {
                    Control.createVocab(native.Text, foreign.Text);
                }
                Dismiss();
            };

            cancel.Click += delegate
            {
                if(Control.getVocab() != null)
                {
                    Control.deleteVocab();
                }
                Dismiss();
            };
        }
    }
}
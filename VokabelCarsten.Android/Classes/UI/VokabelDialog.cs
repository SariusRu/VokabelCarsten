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

            //Find Elements
            Button save = FindViewById<Button>(Resource.Id.save);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);

            EditText native, foreign;
            native = FindViewById<EditText>(Resource.Id.nativeVocab);
            foreign = FindViewById<EditText>(Resource.Id.foreignVocab);

            //Load Clicked Item
            if (Control.GetVocab() != null)
            {
                native.Text = Control.GetVocab().Question;
                foreign.Text = Control.GetVocab().Answer;

                cancel.Text = base.Context.GetString(Resource.String.Delete);
            }

            //Handle Button Actions
            save.Click += delegate
            {
                if (Control.GetVocab() != null)
                {
                    //Item Exists => Edit
                    Control.EditVocab(native.Text, foreign.Text);
                }
                else
                {
                    //No Item Exists => Create
                    Control.CreateVocab(native.Text, foreign.Text);
                }
                Dismiss();
            };

            cancel.Click += delegate
            {
                if(Control.GetVocab() != null)
                {
                    //Delete Item if it Exists
                    Control.DeleteVocab();
                }
                Dismiss();
            };
        }
    }
}
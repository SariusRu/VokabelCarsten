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
    class VokabelBoxDialog : Dialog
    {
        public VokabelBoxDialog(Activity activity) : base(activity)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AddVokabelBox);

            Button save = FindViewById<Button>(Resource.Id.save);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);

            EditText title, colum1, colum2;
            title = FindViewById<EditText>(Resource.Id.title);
            colum1 = FindViewById<EditText>(Resource.Id.colum1);
            colum2 = FindViewById<EditText>(Resource.Id.colum2);

            //Load Existing Data
            if (Control.getCurrentVocabBox() != null) { 
                title.Text = Control.getCurrentVocabBox().name;
                colum1.Text = Control.getCurrentVocabBox().column1;
                colum2.Text = Control.getCurrentVocabBox().column2;
                
                cancel.Text = base.Context.GetString(Resource.String.Delete);
            }
            save.Click += delegate
            {
                if (Control.getCurrentVocabBox() != null)
                {
                    Control.editVocabBox(title.Text, colum1.Text, colum2.Text);
                }else
                {
                    Control.createVocabelKasten(title.Text, colum1.Text, colum2.Text);
                }
                Dismiss();
            };

            cancel.Click += delegate
            {
                if (Control.getCurrentVocabBox() != null)
                {
                    Control.deleteCurrentVocabBox();
                }
                Dismiss();
            };
        }
    }
}
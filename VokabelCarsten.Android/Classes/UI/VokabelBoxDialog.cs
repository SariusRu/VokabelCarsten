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

            //Find Elements
            Button save = FindViewById<Button>(Resource.Id.save);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);

            EditText title, colum1, colum2;
            title = FindViewById<EditText>(Resource.Id.title);
            colum1 = FindViewById<EditText>(Resource.Id.colum1);
            colum2 = FindViewById<EditText>(Resource.Id.colum2);

            //Load Existing Data
            if (Control.GetCurrentVocabBox() != null) { 
                title.Text = Control.GetCurrentVocabBox().name;
                colum1.Text = Control.GetCurrentVocabBox().spalte1;
                colum2.Text = Control.GetCurrentVocabBox().spalte2;
                
                cancel.Text = base.Context.GetString(Resource.String.Delete);
            }

            //Handle Button Actions
            save.Click += delegate
            {
                if (Control.GetCurrentVocabBox() != null)
                {
                    //Item Exists => Edit
                    Control.EditVocabBox(title.Text, colum1.Text, colum2.Text);
                }else
                {
                    //No Item Exists => Create
                    Control.CreateVocabBox(title.Text, colum1.Text, colum2.Text);
                }
                DataManager.staticDataManager.restoreLoadedBox();
                Dismiss();
            };

            cancel.Click += delegate
            {
                if (Control.GetCurrentVocabBox() != null)
                {
                    //Delete Item if it Exists
                    Control.DeleteCurrentVocabBox();
                }
                DataManager.staticDataManager.SaveVocabBoxesXML();
                Dismiss();
            };
        }
    }
}
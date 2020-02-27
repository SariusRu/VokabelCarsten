using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using VokabelCarsten.Classes.UI;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace VokabelCarsten
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textMessage;
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //Add For Debugging
            Control.createVocabelKasten("Vokabluar 1", "Englisch", "Deutsch");
            Control.createVocabelKasten("Vokabluar 2", "Englisch", "Deutsch");
            Control.createVocabelKasten("Vokabluar 3", "Englisch", "Deutsch");

            //Set Up Ui
            SetContentView(Resource.Layout.Main_Activity);
            //Set Up Recycler View
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.VokabelKastenRecycler);
            LinearLayoutManager mLayoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(mLayoutManager);
            VokabelKastenAdapter adapter = new VokabelKastenAdapter(this, Control.GetVocabBoxes());
            recyclerView.SetAdapter(adapter);

            Button addVokabelKastenButton = FindViewById<Button>(Resource.Id.AddVokabelKasten);
            addVokabelKastenButton.Click += delegate
            {
                //Notify New Creation
                Control.setSelectedVocabBox(-1);

                VokabelBoxDialog dialog = new VokabelBoxDialog(this);
                dialog.Show();

                adapter.NotifyDataSetChanged();
            };


            //Load Data
            textMessage = FindViewById<TextView>(Resource.Id.message);
            DataManager dataManager = DataManager.staticDataManager;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}



using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using VokabelCarsten.Classes.UI;

namespace VokabelCarsten
{
    [Activity(Label = "Vokabel Kasten")]
    public class VokabelActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Setup View
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditKasten);

            // Setup Recycle View
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.VokabelRecycler);
            LinearLayoutManager mLayoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(mLayoutManager);
            VokabelAdapter adapter = new VokabelAdapter(this, Control.GetCurrentVokabList());
            recyclerView.SetAdapter(adapter);

            TextView title = FindViewById<TextView>(Resource.Id.EditTitle);
            //Load in Name
            if (Control.GetCurrentVocabBox() != null)
            {
                title.Text = Control.GetCurrentVocabBox().name;
            }

            Button saveVocab = FindViewById<Button>(Resource.Id.SaveVokabel);
            saveVocab.Click += delegate
            {
                DataManager.staticDataManager.restoreLoadedBox();
            };

            Button addVocab = FindViewById<Button>(Resource.Id.AddVokabel);
            //Handle Add Button Actions
            addVocab.Click += delegate
            {
                //Notify New Creation
                Control.SetSelectedVocab(-1);

                VokabelDialog dialog = new VokabelDialog(this);
                dialog.Show();
                
                dialog.DismissEvent += delegate
                {
                    adapter.NotifyDataSetChanged();
                };
            };
            
            }
    }
}
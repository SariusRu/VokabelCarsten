
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using VokabelCarsten.Classes.UI;

namespace VokabelCarsten
{
    [Activity(Label = "EditVokabelKasten")]
    public class EditVokabelKasten : AppCompatActivity
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
            VokabelAdapter adapter = new VokabelAdapter(this, Control.getCurrentVokabelList());
            recyclerView.SetAdapter(adapter);

            EditText title = FindViewById<EditText>(Resource.Id.EditTitle);
            Button addVocab = FindViewById<Button>(Resource.Id.AddVokabel);
            addVocab.Click += delegate
            {
                EditVokabelDialog dialog = new EditVokabelDialog(this);
                dialog.Show();

                //ToDo:  Bad Practice?
                dialog.DismissEvent += delegate
                {
                    adapter.NotifyDataSetChanged();
                };
            };
            Button saveVocabBox = FindViewById<Button>(Resource.Id.SaveVocabBox);
            saveVocabBox.Click += delegate
            {
                DataManager.staticDataManager.SaveVocabBoxesXML();
            };
        }
    }
}
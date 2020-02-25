
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;

namespace VokabelCarsten
{
    [Activity(Label = "EditVokabelKasten")]
    public class EditVokabelKasten : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Setup View
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditKasten);

            EditText title = FindViewById<EditText>(Resource.Id.EditTitle);
            //ToDo: title.Text = Kasten Name Here

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.VokabelRecycler);
            recyclerView.SetAdapter(new VokabelAdapter(this, Control.getCurrentVokabelList()));
        }
    }
}
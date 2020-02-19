using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace VokabelCarsten
{
    public class VokabelViewHolder : RecyclerView.ViewHolder
    {
        //All Text Views
        public TextView native, foreign;

        //Find all Views
        public VokabelViewHolder(View itemview) : base(itemview)
        {
            native = itemview.FindViewById<TextView>(Resource.Id.VokabelNativLanguage);
            foreign = itemview.FindViewById<TextView>(Resource.Id.VokabelForeignLanguage);
        }
    }

    public class VokabelAdapter : RecyclerView.Adapter
    {
        Context context;

        public VokabelAdapter(Context Context)
        {
            context = Context;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the Elements:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.VokabelCard, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            VokabelViewHolder vh = new VokabelViewHolder(itemView);

            //Handle Creation of Cards
            vh.ItemView.Click += delegate
            {
                //Handle Editing
                //ToDo:
            };

            //Return View Holder
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            VokabelViewHolder vh = holder as VokabelViewHolder;

            //Load Text into Specific Cards
            //ToDo: vh.native.Text = Vokabel Array Here[position];  
            //ToDo: vh.foreign.Text = Vokabel Array Here[position]; 
        }

        public override int ItemCount
        {
            get
            {
                //ToDo: return Vokabel Array Here.Count (Without - 1 !!)
                throw new System.NotImplementedException();
            }
        }
    }
}
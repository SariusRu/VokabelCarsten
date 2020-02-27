using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using VokabelCarsten.Classes.UI;

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
        List<Vocab> vocabList;

        public VokabelAdapter(Context Context, List<Vocab> VocabelListe)
        {
            context = Context;
            vocabList = VocabelListe;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the Elements:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.VokabelCard, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            VokabelViewHolder vh = new VokabelViewHolder(itemView);

            //Handle Creation of Cards
            vh.ItemView.LongClick += delegate
            {
                //Handle Editing
                Control.setSelectedVocabel(vh.AdapterPosition);

                VokabelDialog dialog = new VokabelDialog((Activity)context);
                dialog.Show();

                dialog.DismissEvent += delegate
                {
                    NotifyDataSetChanged();
                };
            };

            //Return View Holder
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            VokabelViewHolder vh = holder as VokabelViewHolder;

            //Load Text into Specific Cards
            vh.native.Text = vocabList[position].side1;
            vh.foreign.Text = vocabList[position].side2;
        }

        public override int ItemCount
        {
            get
            {
                return vocabList.Count;
            }
        }
    }
}
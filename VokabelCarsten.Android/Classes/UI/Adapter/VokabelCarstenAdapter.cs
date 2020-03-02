using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using VokabelCarsten.Classes.UI;

namespace VokabelCarsten
{
    public class VokabelKastenViewHolder : RecyclerView.ViewHolder
    {
        //All Text Views
        public TextView title;
        public Button add, learn;

        //Find all Views
        public VokabelKastenViewHolder(View itemview) : base(itemview)
        {
            title = itemview.FindViewById<TextView>(Resource.Id.VokabelCarstenName);
            add = itemview.FindViewById<Button>(Resource.Id.Add);
            learn = itemview.FindViewById<Button>(Resource.Id.Learn);
        }
    }

    public class VokabelKastenAdapter : RecyclerView.Adapter
    {
        Context context;
        public List<VocabBox> list;

        public VokabelKastenAdapter(Context Context, List<VocabBox> List)
        {
            context = Context;
            list = List;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the Elements:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.VokabelKastenCard, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            VokabelKastenViewHolder vh = new VokabelKastenViewHolder(itemView);

            //Handle Creation of Cards
            vh.add.Click += delegate
            {
                Control.SetSelectedVocabBox(vh.AdapterPosition);

                //Show Vocabeln
                context.StartActivity(typeof(VokabelActivity));
            };

            vh.learn.Click += delegate
            {
                Control.SetSelectedVocabBox(vh.AdapterPosition);

                //Show Learn Activity
                context.StartActivity(typeof(LearnActivity));
            };

            vh.ItemView.LongClick += delegate
            {
                Control.SetSelectedVocabBox(vh.AdapterPosition);
                

                VokabelBoxDialog dialog = new VokabelBoxDialog((Activity)context);
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
            VokabelKastenViewHolder vh = holder as VokabelKastenViewHolder;

            //Load Text into Specific Cards
            vh.title.Text = list[position].name;
        }

        public override int ItemCount{
            get
            {
                return list.Count;
            }
        }
    }
}
 
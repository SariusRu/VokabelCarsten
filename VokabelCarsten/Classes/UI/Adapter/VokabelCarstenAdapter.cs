using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace VokabelCarsten
{
    public class VokabelKastenViewHolder : RecyclerView.ViewHolder
    {
        //All Text Views
        public TextView title;
        public Button edit, learn;

        //Find all Views
        public VokabelKastenViewHolder(View itemview) : base(itemview)
        {
            title = itemview.FindViewById<TextView>(Resource.Id.VokabelCarstenName);
            edit = itemview.FindViewById<Button>(Resource.Id.Edit);
            learn = itemview.FindViewById<Button>(Resource.Id.Learn);
        }
    }

    public class VokabelKastenAdapter : RecyclerView.Adapter
    {
        Context context;

        public VokabelKastenAdapter(Context Context)
        {
            context = Context;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the Elements:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.VokabelKastenCard, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            VokabelKastenViewHolder vh = new VokabelKastenViewHolder(itemView);

            //Handle Creation of Cards
            vh.edit.Click += delegate
            {
                //ToDo: Do Stuff Here
                Toast.MakeText(context, "Edit was Clicked", ToastLength.Short);
                context.StartActivity(typeof(EditVokabelKasten));
            };

            vh.learn.Click += delegate
            {
                //ToDo: Do Stuff Here
                Toast.MakeText(context, "Learn was Clicked", ToastLength.Short);

                /*if(selectedMode == Mode1){
                    context.StartActivity(typeof(Learn1));
                }
                */
            };

            //Return View Holder
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            VokabelKastenViewHolder vh = holder as VokabelKastenViewHolder;

            //Load Text into Specific Cards
            //ToDo: vh.title.Text = Kasten Array Here[position]  
        }

        public override int ItemCount{
            get
            {
                //ToDo: return Kasten Array Here.Count (Without - 1 !!)
                throw new System.NotImplementedException();
            }
        }
    }
}
 
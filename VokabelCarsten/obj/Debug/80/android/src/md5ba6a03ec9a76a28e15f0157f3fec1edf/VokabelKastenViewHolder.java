package md5ba6a03ec9a76a28e15f0157f3fec1edf;


public class VokabelKastenViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("VokabelCarsten.VokabelKastenViewHolder, VokabelCarsten", VokabelKastenViewHolder.class, __md_methods);
	}


	public VokabelKastenViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == VokabelKastenViewHolder.class)
			mono.android.TypeManager.Activate ("VokabelCarsten.VokabelKastenViewHolder, VokabelCarsten", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

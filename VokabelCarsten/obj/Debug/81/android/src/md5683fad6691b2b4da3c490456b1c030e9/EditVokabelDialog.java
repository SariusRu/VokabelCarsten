package md5683fad6691b2b4da3c490456b1c030e9;


public class EditVokabelDialog
	extends android.app.Dialog
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("VokabelCarsten.Classes.UI.EditVokabelDialog, VokabelCarsten", EditVokabelDialog.class, __md_methods);
	}


	public EditVokabelDialog (android.content.Context p0)
	{
		super (p0);
		if (getClass () == EditVokabelDialog.class)
			mono.android.TypeManager.Activate ("VokabelCarsten.Classes.UI.EditVokabelDialog, VokabelCarsten", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public EditVokabelDialog (android.content.Context p0, boolean p1, android.content.DialogInterface.OnCancelListener p2)
	{
		super (p0, p1, p2);
		if (getClass () == EditVokabelDialog.class)
			mono.android.TypeManager.Activate ("VokabelCarsten.Classes.UI.EditVokabelDialog, VokabelCarsten", "Android.Content.Context, Mono.Android:System.Boolean, mscorlib:Android.Content.IDialogInterfaceOnCancelListener, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public EditVokabelDialog (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == EditVokabelDialog.class)
			mono.android.TypeManager.Activate ("VokabelCarsten.Classes.UI.EditVokabelDialog, VokabelCarsten", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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

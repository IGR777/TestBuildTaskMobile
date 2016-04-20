using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace TestBuildTaskMobile.Droid
{
	[Activity (Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MyTheme")]
	public class MainActivity : Activity
	{
		int count = 1;
		bool showImage;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			var imageView = FindViewById<ImageView> (Resource.Id.myImageView);

			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				if(!showImage)
					imageView.Visibility = ViewStates.Visible;
			};
		}
	}
}



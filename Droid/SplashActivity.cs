
using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;

namespace TestBuildTaskMobile.Droid
{
	[Activity (Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]			
	public class SplashActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Create your application here
		}

		protected async override void OnResume()
		{
			base.OnResume();

			await Task.Delay(2000); 
			StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}
	}
}


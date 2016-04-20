using System;
using System.IO;

namespace BuildTasks
{
	public class ChangeSplashScreenAndroidTask:AndroidFileTask
	{
		protected const string splashImage = "splash.png";

		public override bool Execute ()
		{
			Log.LogMessage (Configuration);
			Log.LogMessage (Path.GetDirectoryName(ProjectPath));
			Log.LogMessage (IntermediateOutputPath);

			ChangeFile (splashImage);
			return true;
		}
	}
}


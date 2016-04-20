using System;
using System.IO;

namespace BuildTasks
{
	public class ChangeAppIconAndroidTask:AndroidFileTask
	{
		protected const string icon = "Icon.png";

		public override bool Execute ()
		{
			Log.LogMessage (Configuration);
			Log.LogMessage (Path.GetDirectoryName(ProjectPath));
			Log.LogMessage (IntermediateOutputPath);

			ChangeFile (icon);
			return true;
		}
	}
}


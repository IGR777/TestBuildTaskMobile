using System;
using System.IO;

namespace BuildTasks
{
	public class ChangeLogoAndroidTask:AndroidFileTask
	{
		protected const string targetFile = "image.png";

		public override bool Execute ()
		{
			Log.LogMessage (Configuration);
			Log.LogMessage (Path.GetDirectoryName(ProjectPath));
			Log.LogMessage (IntermediateOutputPath);

			ChangeFile (targetFile);
			return true;
		}
	}
}


using System;
using System.IO;

namespace BuildTasks
{
	public class ChangeColorsAndroidTask:AndroidFileTask
	{
		protected const string targetFile = "colors.xml";

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


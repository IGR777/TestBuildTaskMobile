using System;
using System.IO;

namespace BuildTasks
{
	public class ChangeStringsAndroidTask:AndroidFileTask
	{
		protected const string targetFile = "Strings.xml";

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


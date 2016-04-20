using System;
using System.IO;
//using Microsoft.Build.Utilities;
using System.Threading.Tasks;

namespace BuildTasks
{
	public class ChangeLayoutAndroidTask:AndroidFileTask
	{
		protected const string targetFile = "Main.xml";

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


using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.IO;

namespace BuildTasks
{

	public class BaseAndroidTask:Task{

		protected string buildItemsDir = "BuildItems";

		[Required]
		public virtual string ProjectPath 	{ get; set; }

		public string Configuration{ get; set; }

		public string IntermediateOutputPath { get; set; }

		public string AssemblyName{ get; set; }

		public override bool Execute ()
		{
			return true;
		}
	}

	public class AndroidFileTask:BaseAndroidTask
	{
		protected const string resDir = "res";

		protected void ChangeFile (string icon)
		{
			Log.LogMessage ("buildItemsDir - "+ buildItemsDir);
			Log.LogMessage ("Getting directories");
			var configDirectory = Path.Combine (Path.GetDirectoryName (ProjectPath), buildItemsDir, Configuration);
			if (!Directory.Exists (configDirectory)) {
				Log.LogMessage (String.Format("Directory not found - {0}", configDirectory));
				return;
			}
			var directories = 
				Directory.GetDirectories(configDirectory);
			Log.LogMessage ("Directories found");
			foreach (var dir in directories) {
				Log.LogMessage (dir);
			}

			foreach (var dir in directories) {
				var iconFile = Path.Combine (dir, icon);
				var localDirName = Path.GetFileName (dir);
				Log.LogMessage (String.Format("{0} - {1}", nameof(localDirName),localDirName));
				if (File.Exists (iconFile)) {	
					var outIcon = Path.Combine (Path.GetDirectoryName (ProjectPath), IntermediateOutputPath,resDir,localDirName,icon);
					Log.LogMessage (String.Format("{0} - {1}", nameof(outIcon),outIcon));
					if (File.Exists (outIcon)) {
						File.Copy (iconFile, outIcon, true);
						Log.LogMessage ("File copied");
					} else {
						Log.LogMessage ("Out icon found");
					}
				} else {
					Log.LogMessage (String.Format("{0} not exist", iconFile));
				}
			}
		}
	}
}


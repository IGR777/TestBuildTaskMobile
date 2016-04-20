using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace BuildTasks
{
	public class ChangeAppNameAndroidTask:BaseAndroidTask
	{
		const string propertiesDir = "Properties";
		const string androidManifest = "AndroidManifest.xml";
		const string configFile = "PackageName.txt";

		public override bool Execute ()
		{
			ChangePackageName ();
			return true;
		}

		protected void ChangePackageName ()
		{
			Log.LogMessage ("Getting config file");
			var configPath = Path.Combine (Path.GetDirectoryName (ProjectPath), buildItemsDir, Configuration, configFile);

//			if (!File.Exists (configPath)) {
//				Log.LogMessage ("File {0} not exist",configPath);
//				return;
//			}
//
//			var packageName = File.ReadAllText (configPath).Trim ();
//
			var packageName = "123";
			Log.LogMessage ("Package name - {0}",packageName);

			var manifestFile = Path.Combine (Path.GetDirectoryName (ProjectPath), propertiesDir, androidManifest);
			if (File.Exists (manifestFile)) {
				var xml = XDocument.Load (manifestFile);
				var element = xml.Root.Elements().Where(el=>el.Name.LocalName.Equals("application"));
				var attr = element.Attributes ().FirstOrDefault (item => item.Name.LocalName.Equals ("label"));
				if (attr != null) {
					attr.Value = packageName;
				} else {
					Log.LogMessage ("Attribute not found");
					return;
				}
				xml.Save (manifestFile);
				Log.LogMessage ("Manifest saved");
//				var attr = xml.Root.Attributes ().FirstOrDefault (item => item.Name.LocalName.Equals ("package"));
//				if (attr != null) {
//					attr.Value = packageName;
//				} else {
//					Log.LogMessage ("Attribute not found");
//					return;
//				}
//				xml.Save (manifestFile);
//				Log.LogMessage ("Manifest saved");
			} else {
				Log.LogMessage (String.Format ("Manifest file - {0} not found", manifestFile));
			}
		}
	}
}


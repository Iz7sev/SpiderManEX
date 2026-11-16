using System;
using System.IO;
using System.Xml;
using UnityEditor.Android;

namespace WebSwing.Editor
{
    // Public app identifier issued to Web Swing Lab in the iz7 Meta developer team.
    // This is an app ID, never an app secret or access token.
    public sealed class MetaAppIdentity : IPostGenerateGradleAndroidProject
    {
        const string Android = "http://schemas.android.com/apk/res/android";
        public const string AppId = "1426470817218114";
        public int callbackOrder => 10000;

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            var file = Path.Combine(path, "src/main/AndroidManifest.xml");
            var document = new XmlDocument();
            document.Load(file);
            var application = document.SelectSingleNode("/manifest/application") as XmlElement;
            if (application == null) throw new InvalidOperationException("Android application element missing.");
            XmlElement identity = null;
            foreach (XmlNode node in application.ChildNodes)
                if (node is XmlElement element && element.Name == "meta-data" &&
                    element.GetAttribute("name", Android) == "com.oculus.app_id") identity = element;
            if (identity == null)
            {
                identity = document.CreateElement("meta-data");
                identity.SetAttribute("name", Android, "com.oculus.app_id");
                application.AppendChild(identity);
            }
            identity.SetAttribute("value", Android, AppId);
            foreach (XmlNode node in application.ChildNodes)
                if (node is XmlElement activity && activity.Name == "activity" &&
                    activity.GetAttribute("name", Android) == "com.unity3d.player.UnityPlayerActivity")
                    activity.SetAttribute("label", Android, "ウェブシューターアプリ");
            document.Save(file);
            // OpenXR generates this library separately. Use the public device names;
            // its default list includes the retired Quest 1 and internal code names.
            var xrFile = Path.Combine(path, "xrmanifest.androidlib/AndroidManifest.xml");
            if (!File.Exists(xrFile)) throw new FileNotFoundException("Generated XR manifest missing.", xrFile);
            var xrDocument = new XmlDocument();
            xrDocument.Load(xrFile);
            var xrApplication = xrDocument.SelectSingleNode("/manifest/application") as XmlElement;
            if (xrApplication == null) throw new InvalidOperationException("XR application element missing.");
            bool devicesFound = false;
            foreach (XmlNode node in xrApplication.ChildNodes)
                if (node is XmlElement element && element.Name == "meta-data" &&
                    element.GetAttribute("name", Android) == "com.oculus.supportedDevices")
                {
                    element.SetAttribute("value", Android, "quest3|quest3s");
                    devicesFound = true;
                }
            if (!devicesFound) throw new InvalidOperationException("XR supportedDevices entry missing.");
            xrDocument.Save(xrFile);
            UnityEngine.Debug.Log("WEB_META_APP_ID_OK: " + AppId);
        }
    }
}


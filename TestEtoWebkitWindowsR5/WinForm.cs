using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace TestEtoWebkit
{
    public partial class WinForm : Form
    {
        public WebBrowser Wv { get; private set; }
        public bool IndexLoaded = false;
        string index;
        public WinForm()
        {
            InitializeComponent();
            Wv = webBrowser;
            Wv.DocumentCompleted += E_DocumentLoaded;
            Wv.Navigating += E_DocumentLoading;
        }

        public void SetWVUrl(string url)
        {
            index = url.Replace("\\", "/");
            Wv.Url = new Uri(index);
        }

        private void E_DocumentLoading(object sender, WebBrowserNavigatingEventArgs e)
        {
            Rhino.RhinoApp.WriteLine(e.Url.ToString());
            Rhino.RhinoApp.WriteLine(index);

            if (e.Url.AbsolutePath != index && IndexLoaded)
            {
                e.Cancel = true;

                var result = "";
                var deserializedObject = new TestObject();

                if (e.Url.ToString().Contains("sayhi"))
                {
                    result = Wv.Document.InvokeScript("SayHi(\"Luis\"); return payload;").ToString();
                    //result = Wv.ExecuteScript("SayHi(\"Luis\"); return payload;");
                    deserializedObject = JsonConvert.DeserializeObject<TestObject>(result);
                }

                if (e.Url.ToString().Contains("returndata"))
                {
                    result = Wv.Document.InvokeScript("ReturnData(1000); return payload;").ToString();
                    //result = Wv.ExecuteScript("ReturnData(1000); return payload;");
                    deserializedObject = JsonConvert.DeserializeObject<TestObject>(result);
                }

                Rhino.RhinoApp.WriteLine(deserializedObject.ReturnValue);

                foreach (var num in deserializedObject.Numbers)
                    Rhino.RhinoApp.Write("{0}{1}", num, ",");

                Rhino.RhinoApp.WriteLine();

            }
        }

        private void E_DocumentLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath == index) IndexLoaded = true;
        }
    }
}

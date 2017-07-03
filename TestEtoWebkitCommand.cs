using Rhino;
using Rhino.Commands;
using System.IO;
using System.Reflection;

namespace TestEtoWebkit
{
    public class TestEtoWebkitCommand : Command
    {

        public string PathResources { get; set; }
        public string IndexPath { get; set; }

        public TestEtoWebkitCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static TestEtoWebkitCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "TestEtoWebkitCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoApp.WriteLine("The {0} command is under construction.", EnglishName);

            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyPath = Path.GetDirectoryName(assemblyLocation);
            PathResources = Path.Combine(assemblyPath, "app");
            IndexPath = Path.Combine(PathResources, "index.html");

            dynamic form;

#if ETO

            form = new EtoForm();

#elif WINR5
            form = new WinForm();
#endif
            form.ShowInTaskbar = true;
            form.TopMost = true;
            form.BringToFront();

            form.SetWVUrl(IndexPath);
            form.Show();

            return Result.Success;
        }
    }
}

using System.Diagnostics;

namespace TestWebUI
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class Pipeline
    {
        #region Properties

        public int Counter { get; set; }

        #endregion

        #region Ctor

        public Pipeline()
        {
            Counter = 0;
        }

        #endregion

        #region Methods

        public void Count(bool direction)
        {
            if (direction)
                Counter++;
            else
                Counter--;

            Debug.WriteLine(Counter, "Pipeline");
            Rhino.RhinoApp.WriteLine("Counting "+ Counter.ToString());
        }

        #endregion
    }
}
using System;
using System.Diagnostics;

namespace ICEWebSiteTestAutomationBase.Utils
{
    internal class EnvironmentPropertyReader
    {
        public static string GetPropertyOrEnv(string name, string theDefault)
        {
            var theValue = Environment.GetEnvironmentVariable(name);

            if (theValue == null)
            {
                Debug.WriteLine("No Environment Variable or Property named [" + name + "] using default value [" +
                                theDefault + "]");
                theValue = theDefault;
            }
            else
            {
                Debug.WriteLine("Using Environment Variable " + name + " with value " + theValue);
            }

            return theValue;
        }
    }
}
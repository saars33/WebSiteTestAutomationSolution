using System;

namespace ICEWebSiteTestAutomationBase.Exceptions
{
    [Serializable]
    internal class UnknownBrowserException : Exception
    {
        public UnknownBrowserException(string message) : base(message)
        {
        }

        public UnknownBrowserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
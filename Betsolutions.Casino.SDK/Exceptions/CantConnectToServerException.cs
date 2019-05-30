using System;
using System.Net;

namespace Betsolutions.Casino.SDK.Exceptions
{
    public class CantConnectToServerException : Exception
    {
        public CantConnectToServerException(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        public CantConnectToServerException(HttpStatusCode httpStatusCode, string content)
        {
            HttpStatusCode = httpStatusCode;
            Content = content;
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public string Content { get; set; }
    }
}

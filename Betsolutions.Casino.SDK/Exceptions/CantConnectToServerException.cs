using System;
using System.Net;
using RestSharp;

namespace Betsolutions.Casino.SDK.Exceptions
{
    public sealed class CantConnectToServerException : Exception
    {
        internal CantConnectToServerException(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        internal CantConnectToServerException(IRestResponse response)
        {
            HttpStatusCode = response.StatusCode;
            Content = response.Content;
            ResponseUri = response.ResponseUri.ToString();
            StatusDescription = response.StatusDescription;
        }

        public HttpStatusCode HttpStatusCode { get; }
        public string Content { get; }
        public string ResponseUri { get; }
        public string StatusDescription { get; }

        public override string ToString()
        {
            return $"{nameof(HttpStatusCode)}: {HttpStatusCode}, {nameof(ResponseUri)}: {ResponseUri}, {nameof(StatusDescription)}: {StatusDescription}, {nameof(Content)}: {Content}";
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebRequestor
{
    /// <summary>
    /// Simple class for sending GET and POST HTTP requests and reading the returned response stream
    /// </summary>
    public class WebRequestor
    {
        private readonly WebRequest _request;
        private Stream _dataStream;

        public string Status { get; set; }

        public WebRequestor(string url)
        {
            // Create a request using a URL that can receive a post.

            _request = WebRequest.Create(url);
        }

        public WebRequestor(string url, string method) : this(url)
        {
            if (String.Compare(method, "POST", StringComparison.OrdinalIgnoreCase) == 0 || String.Compare(method, "GET", StringComparison.OrdinalIgnoreCase) == 0)
            {
                //set the request method type
                _request.Method = method;
            }
            else
            {
                throw new Exception("Unsupported web request method type");
            }
        }

        public WebRequestor(string url, string method, string data) : this(url, method)
        {
            try
            {
                // Create POST data and convert it to a byte array.
                string postData = data;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType property of the WebRequest.
                _request.ContentType = "application/x-www-form-urlencoded";

                // Set the ContentLength property of the WebRequest.
                _request.ContentLength = byteArray.Length;

                // Get the request stream.
                _dataStream = _request.GetRequestStream();

                // Write the data to the request stream.
                _dataStream.Write(byteArray, 0, byteArray.Length);

                // Close the Stream object.
                _dataStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create WebRequestor", ex);
            }
        }

        public string GetResponse()
        {
            try
            {
                string result = string.Empty;

                // Get the original response.
                WebResponse response = _request.GetResponse();

                Status = ((HttpWebResponse)response).StatusDescription;

                // Get the stream containing all content returned by the requested server.
                _dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                if (_dataStream != null)
                {
                    StreamReader reader = new StreamReader(_dataStream);

                    // Read the content fully up to the end.
                    string responseFromServer = reader.ReadToEnd();

                    // Clean up the streams.
                    reader.Close();
                    _dataStream.Close();
                    response.Close();

                    result = responseFromServer;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create WebRequestor", ex);
            }
        }
    }
}

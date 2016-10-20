using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Exchange.WebServices.Data.Core
{
    public class EwsHttpResponse : IEwsHttpWebResponse
    {
        /// <summary>
        /// Underlying HttpResponseMessage.
        /// </summary>
        readonly HttpResponseMessage response;

        /// <summary>
        /// Converter response headers
        /// </summary>
        readonly WebHeaderCollection headers;

        /// <summary>
        /// Initializes a new instance of the <see cref="EwsHttpWebResponse"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        internal EwsHttpResponse(HttpResponseMessage response)
        {
            this.response = response;
            headers = new WebHeaderCollection();
            foreach( var header in response.Headers)
                headers[header.Key] = header.Value.FirstOrDefault();
        }

        #region IEwsHttpWebResponse Members

        /// <summary>
        /// Closes the response stream.
        /// </summary>
        void IEwsHttpWebResponse.Close()
        {
            this.response.Dispose();
        }

        /// <summary>
        /// Gets the stream that is used to read the body of the response from the server.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> containing the body of the response.
        /// </returns>
        Stream IEwsHttpWebResponse.GetResponseStream()
        {
            return response.Content.ReadAsStreamAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the method that is used to encode the body of the response.
        /// </summary>
        /// <returns>A string that describes the method that is used to encode the body of the response.</returns>
        string IEwsHttpWebResponse.ContentEncoding
        {
            get { return this.response.Content.Headers.ContentEncoding.FirstOrDefault(); }
        }

        /// <summary>
        /// Gets the content type of the response.
        /// </summary>
        /// <returns>A string that contains the content type of the response.</returns>
        string IEwsHttpWebResponse.ContentType
        {
            get { return this.response.Content.Headers.ContentType?.ToString(); }
        }  

        /// <summary>
        /// Gets the headers that are associated with this response from the server.
        /// </summary>
        /// <returns>A <see cref="T:System.Net.WebHeaderCollection"/> that contains the header information returned with the response.</returns>
        WebHeaderCollection IEwsHttpWebResponse.Headers
        {
            get { return headers; }
        }

        /// <summary>
        /// Gets the URI of the Internet resource that responded to the request.
        /// </summary>
        /// <returns>A <see cref="T:System.Uri"/> that contains the URI of the Internet resource that responded to the request.</returns>
        Uri IEwsHttpWebResponse.ResponseUri
        {
            get { return this.response.RequestMessage.RequestUri; }
        }

        /// <summary>
        /// Gets the status of the response.
        /// </summary>
        /// <returns>One of the System.Net.HttpStatusCode values.</returns>
        HttpStatusCode IEwsHttpWebResponse.StatusCode
        {
            get { return this.response.StatusCode; }
        }

        /// <summary>
        /// Gets the status description returned with the response.
        /// </summary>
        /// <returns>A string that describes the status of the response.</returns>
        string IEwsHttpWebResponse.StatusDescription
        {
            get { return this.response.ReasonPhrase; }
        }

        /// <summary>
        /// Gets the version of the HTTP protocol that is used in the response.
        /// </summary>
        /// <value></value>
        /// <returns>System.Version that contains the HTTP protocol version of the response.</returns>
        Version IEwsHttpWebResponse.ProtocolVersion
        {
            get { return this.response.Version; }
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            this.response.Dispose();
        }

        #endregion
    }
}

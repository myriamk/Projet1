using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Hermes.MyProfile.Web.Shared.Http
{
    public class ImageContentActionResult : IHttpActionResult
    {
        private readonly byte[] imageContent;
        private readonly string contentType;

        public ImageContentActionResult(byte[] imageContent, string contentType )
        {
            this.imageContent = imageContent;
            this.contentType = contentType;
        }
        
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                HttpResponseMessage response;

            response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(imageContent)
            };
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                

           
                return response;
            }, cancellationToken);
        }
    }
}
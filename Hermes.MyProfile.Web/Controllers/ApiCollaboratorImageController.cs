using Hermes.MyProfile.Web.Shared.Enum;
using Hermes.MyProfile.Web.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Web.Hosting;
using System.Web.Http;
using Hermes.MyProfile.Web.Shared.Http;
using Hermes.MyProfile.Web.Models;
using Hermes.MyProfile.Domain.Entities;
using Hermes.MyProfile.Helpers;

namespace Hermes.MyProfile.Web.Controllers
{
    [Authorize]
    public class ApiCollaboratorImageController : ApiController
    {
        private ICollaboratorProfileService _CollaboratorProfileService;

      
        public ApiCollaboratorImageController(ICollaboratorProfileService collaboratorProfileService)
        {
            this._CollaboratorProfileService = collaboratorProfileService;

        }
      
        [Route("api/CollaboratorImage/{userName}/{size?}/{format?}")]
        public IHttpActionResult Get(string userName,string size=null, string format=null)
        {


            IHttpActionResult result;

            FormatRetourImage selectedFormat;
            //  CollaboratorImageSize selectedSize;
            CollaboratorImageSize selectedSize = String.IsNullOrEmpty(size) || !Enum.TryParse<CollaboratorImageSize>(size,out  selectedSize) ? CollaboratorImageSize.large : selectedSize;
            selectedFormat = String.IsNullOrEmpty(format) || !Enum.TryParse<FormatRetourImage>(format, out  selectedFormat) ? FormatRetourImage.IMG: selectedFormat;
            

            if (selectedFormat == FormatRetourImage.IMG)
            {


                #region format IMG
                var imagePhoto = _CollaboratorProfileService.GetCollaboratorPhoto(userName, selectedSize);
                if (imagePhoto != null && imagePhoto.Content != null)
                {
                    result = new ImageContentActionResult(imagePhoto.Content, imagePhoto.ImageFormat.GetMimeType());
                }
                else
                    result = NotFound();

                #endregion
            }
            else
            {

                #region Format URL
                result = Ok(new CollaboratorImageReference {
                    //TODO contenu URL A revoir - tester si User Exists ?  
                    ImageURL = $"{Request.RequestUri.GetLeftPart(UriPartial.Authority)}/api/CollaboratorImage/{userName}/{selectedSize.ToString()}/{FormatRetourImage.IMG.ToString()}/"
                    ,
                    ImageBackOfficeURL = $"{Request.RequestUri.GetLeftPart(UriPartial.Authority)}/CollaboratorProfile/edit/{userName}"

                });
                #endregion

            }
            return result;


        }


      

      
    }
}

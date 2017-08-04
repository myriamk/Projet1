using Hermes.MyProfile.Domain.Entities;
using Hermes.MyProfile.Helpers.ActiveDirectory;
using Hermes.MyProfile.Web.Models;
using Hermes.MyProfile.Web.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hermes.MyProfile.Web.Controllers
{
    public class ApiCollaboratorProfileController : ApiController
    {

        
        private ICollaboratorProfileService _CollaboratorProfileService;
      
        
        public ApiCollaboratorProfileController(ICollaboratorProfileService collaboratorProfileService)
        {
          
            this._CollaboratorProfileService  = collaboratorProfileService; 
        }


       

        [Route("api/CollaboratorProfile/{userName}/{withPhotos?}")]
        public CollaboratorProfile Get(string userName,bool withPhotos=true)
        {

           
            var ret= _CollaboratorProfileService.GetCollaboratorProfile(userName, withPhotos);
           
            return ret;
        }


        



        [HttpPut]
        public IHttpActionResult SaveProfile(CollaboratorProfile collaborator)
        {
            return Ok();
           
        }
    }
}

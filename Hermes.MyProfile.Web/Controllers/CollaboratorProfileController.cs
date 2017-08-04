using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hermes.MyProfile.Web.Controllers
{
    public class CollaboratorProfileController : Controller
    {
        // GET: CollaboratorProfile/userName
        [Authorize]
        public ActionResult Edit(string userName)
        {
            return View("Edit",(object)userName);
        }

   
    }
}
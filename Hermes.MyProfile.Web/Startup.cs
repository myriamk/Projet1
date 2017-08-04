using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Unity.WebApi;

namespace Hermes.MyProfile.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         

            ConfigureAuth(app);



        }
    }
}

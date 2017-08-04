using Hermes.MyProfile.Domain.Entities;
using Hermes.MyProfile.Web.Models;

namespace Hermes.MyProfile.Web.Services
{
    public interface ICollaboratorProfileService
    {

      
        CollaboratorProfile GetCollaboratorProfile(string userName,bool loadPhotos) ;

        ImagePhoto GetCollaboratorPhoto(string userName, CollaboratorImageSize size);

        void UpdateCollaboratorProfile(CollaboratorProfile cp);
    }
}
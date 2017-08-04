using Hermes.MyProfile.Domain.Entities;
namespace Hermes.MyProfile.Web.Services
{
    public interface ICachedImageLoader
    {


        void LoadImagePhotoFromCache(ImagePhoto imagePhoto);
        
    }
}
using System.Drawing.Imaging;

namespace Hermes.MyProfile.Domain.Entities
{
   

    public interface IImagePhoto
    {
        byte[] Content { get; set; }
        ImageFormat ImageFormat { get; set; }
        string ImageName { get; set; }
        CollaboratorImageSize Size { get; set; }
    }
}
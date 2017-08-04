using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.MyProfile.Domain.Entities
{
    [DataContract]
    public class SmallImagePhoto : ImagePhoto
    {
        public SmallImagePhoto(string imageName, ImageFormat imageFormat) : base(imageName, CollaboratorImageSize.small, imageFormat)
        {
             this._imageName = $"{_imageName}_{CollaboratorImageSize.small.ToString()}";
        }
        
    }
}

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
    public class ImagePhoto : IImagePhoto
    {


        protected CollaboratorImageSize _size;
        protected System.Drawing.Imaging.ImageFormat _imageFormat;
        protected string _imageName;

        protected Byte[]  _content;

        [DataMember]
        public Byte[] Content { get => _content; set => _content = value; }


        [DataMember]
        public CollaboratorImageSize Size { get => _size; set => _size = value; }

    
        public string ImageName { get => _imageName; set => _imageName = value; }
       
        public ImageFormat ImageFormat { get => _imageFormat; set => _imageFormat = value; }


        public string ImageFormatStr { get => ImageFormat.ToString(); }


        public ImagePhoto(string imageName, CollaboratorImageSize size, ImageFormat imageFormat)
        {
            _size = size;

            _imageName = imageName;
            _imageFormat = imageFormat;
        }
    }
}

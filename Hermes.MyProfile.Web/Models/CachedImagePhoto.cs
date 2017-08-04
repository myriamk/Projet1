using Hermes.MyProfile.Domain.Entities;
using Hermes.MyProfile.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.Text;

namespace Hermes.MyProfile.Web.Models
{
    [DataContract]
    public abstract class CachedImagePhoto: ImagePhoto
    {
     
        int _expirationMinutesOffset;
        
        public CachedImagePhoto(string imageName, CollaboratorImageSize size, ImageFormat imageFormat, int expirationMinutesOffset) : base(imageName, size, imageFormat)
        {
            _expirationMinutesOffset = expirationMinutesOffset;
           
        }

        protected abstract byte[] LoadImagePhoto(string image);
        
       

        public void LoadImagePhotoFromCache()
        {

           _content= Caching.GetObjectFromCache<byte[]>(_imageName, _expirationMinutesOffset, _imageName => LoadImagePhoto(_imageName));

            
            

        }

    }
}

using Hermes.MyProfile.Domain.Entities;
using Hermes.MyProfile.Helpers;
using Hermes.MyProfile.Web.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace Hermes.MyProfile.Web.Services
{
    public abstract class CachedImageLoader:ICachedImageLoader
    {
        private readonly int _CacheExpirationMinutesOffset = Int32.Parse(ConfigurationManager.AppSettings["cacheItemPolicy:expirationMinutesOffset"]);


     
      

        protected abstract byte[] LoadImagePhoto(ImagePhoto imagePhoto);
      

        /// <summary>
        /// Initialise imagePhoto Content
        /// </summary>
        /// <param name="imagePhoto"></param>
        public void LoadImagePhotoFromCache(ImagePhoto imagePhoto)
        {
            imagePhoto.Content = Caching.GetObjectFromCache<byte[],ImagePhoto>(imagePhoto
                ,imagePhoto.ImageName
                , _CacheExpirationMinutesOffset
                , i => LoadImagePhoto(i)
                );
        }
    }

}
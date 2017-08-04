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
    public class FileSystemCachedImagePhoto : CachedImagePhoto,IImagePhoto
    {
        private string _path;

        public FileSystemCachedImagePhoto(string imageName, CollaboratorImageSize size, ImageFormat imageFormat, int expirationMinutesOffset,string path) : base(imageName, size, imageFormat, expirationMinutesOffset)
        {
            _path = path;
        }

        protected override byte[] LoadImagePhoto()
        {
            byte[] ret = null;
            var pathImage = $"{_path}{_imageName}{_imageFormat.FileExtensionFromEncoder()}"; 
            if (File.Exists(pathImage))
            {
                using (FileStream fileStream = new FileStream(pathImage, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    Image image = Image.FromStream(fileStream);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, ImageFormat.Jpeg);
                        ret = memoryStream.ToArray();

                    }

                }

            }
            return ret;
        }
    }
}

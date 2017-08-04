using Hermes.MyProfile.Domain.Entities;
using Hermes.MyProfile.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Hermes.MyProfile.Web.Services
{
    public class FileSystemCachedImageLoader : CachedImageLoader
    {

        private readonly string _CollaboratorImageStoragePath = ConfigurationManager.AppSettings["image:CollaboratorImageStoragePath"];





        protected override byte[] LoadImagePhoto(ImagePhoto imagePhoto)
        {
            byte[] ret = null;
            var pathImage = $"{_CollaboratorImageStoragePath}{imagePhoto.ImageName}{imagePhoto.ImageFormat.FileExtensionFromEncoder()}";
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
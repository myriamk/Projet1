using Hermes.MyProfile.Domain.Entities;
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
    public class CollaboratorImageService : ICollaboratorImageService
    {
        private static object ThisLock = new object();

        /// <summary>
        /// Retourne l'image avec le nom spécifié à partir du cache 
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public  Byte[] GetImage(string userName, CollaboratorImageSize size)
        {

            byte[] collaboratorImgBytes;

            var imageDefaultExtension = ConfigurationManager.AppSettings["image:DefaultExtension"];
            var imagePrefixeName = ConfigurationManager.AppSettings["image:PrefixeName"];

            
            string imageName = $"{imagePrefixeName}{userName}_{size.ToString()}.{imageDefaultExtension}";




            //Get image from cache
            collaboratorImgBytes = MemoryCache.Default.Get(imageName) as byte[];
            if (collaboratorImgBytes == null)
            {
                lock (ThisLock)
                {
                    //Check to see if anyone wrote to the cache while we where waiting our turn to write the new value.
                    collaboratorImgBytes = MemoryCache.Default.Get(imageName) as byte[];
                    if (collaboratorImgBytes == null)
                    {
                        #region Load image from file
                        String filePath = String.Format("{0}{1}"
                            , ConfigurationManager.AppSettings["image:CollaboratorImageStoragePath"]
                            , imageName
                            );
                        if (File.Exists(filePath))
                        {
                            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                Image image = Image.FromStream(fileStream);
                                using (MemoryStream memoryStream = new MemoryStream())
                                {
                                    image.Save(memoryStream, ImageFormat.Jpeg);
                                    collaboratorImgBytes = memoryStream.ToArray();
                                    int minutesOffset;
                                    var policy = new CacheItemPolicy()
                                    {

                                        AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(Int32.TryParse(ConfigurationManager.AppSettings["cacheItemPolicy:expirationMinutesOffset"], out minutesOffset) ? minutesOffset : 2)
                                    };
                                    MemoryCache.Default.Add(imageName, collaboratorImgBytes, policy);
                                }

                            }

                        }
                        #endregion
                    }

                }

            }
            return collaboratorImgBytes;
        }


    }
}
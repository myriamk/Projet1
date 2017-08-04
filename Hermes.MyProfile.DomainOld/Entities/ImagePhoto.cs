using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hermes.MyProfile.Domain.Entities
{
    public class ImagePhoto
    {
        int _size;
        public ImagePhoto(int size)
        {
            _size = size;
        }


        Byte[] Content { get; set; }


        public bool LoadFromFile(string filePath)
        {

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

    }
}

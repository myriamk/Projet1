using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;

namespace Hermes.MyProfile.Domain.Entities
{
    public class CollaboratorPhotos : ICollaboratorPhotos
    {

        public CollaboratorPhotos(string basePhotoName) => _basePhotoName = basePhotoName;
        
        string _basePhotoName ;
        public string BasePhotoName { get => _basePhotoName; set => _basePhotoName = value; }
        public IImagePhoto SmallImage { get; set; }

        public IImagePhoto MediumImage { get; set; }
  
        public IImagePhoto LargeImage { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.MyProfile.Domain.Entities
{
    public class CollaboratorPhotos
    {
        public ImagePhoto SmallImage { get; set; }

        public ImagePhoto MediumImage { get; set; }
  
        public ImagePhoto LargeImage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.MyProfile.Domain.Entities
{
    public class ImageLarge : ImagePhoto
    {
        public ImageLarge(int size) : base(200)
        {
        }
    }
}

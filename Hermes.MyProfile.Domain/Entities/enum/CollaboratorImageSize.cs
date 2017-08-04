using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Hermes.MyProfile.Domain.Entities
{
    public enum CollaboratorImageSize
    {
       [Description("Small")]
        small,
       [Description("Medium")]
        medium,
       [Description("Large")]
        large
    }
}
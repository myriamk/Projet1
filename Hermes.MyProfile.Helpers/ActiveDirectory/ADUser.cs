using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hermes.MyProfile.Helpers.ActiveDirectory
{
   [DirectoryObjectClass("User")]
    //[DirectoryObjectClass("person")]
    public class ADUser : UserPrincipal
    {

        public ADUser(PrincipalContext context) : base(context)
        {

        }

        // Implement the overloaded search method FindByIdentity.
        public static new ADUser FindByIdentity(PrincipalContext context,
                                                       string identityValue)
        {
            return (ADUser)FindByIdentityWithType(context,
                                                         typeof(ADUser),
                                                         identityValue);
        }


        #region General attributes

        [DirectoryProperty("manager")]
        public string Manager
        {
            get { return this.ExtensionGetSingleString("manager"); }
           // set { ExtensionSet("manager", value); }
        }



        [DirectoryProperty("mobile")]
        public string MobilePhone
        {
            get { return this.ExtensionGetSingleString("mobile");   }
            set { this.ExtensionSet("mobile", value); }
        }
        
        [DirectoryProperty("mail")]
        public string MailAddress
        {
            get { return this.ExtensionGetSingleString("mail"); }
            set { ExtensionSet("mail", value); }
        }
      
        [DirectoryProperty("title")]
        public string Title
        {
            get { return this.ExtensionGetSingleString("title"); }
          
            set { ExtensionSet("title", value); }
        }

     

        [DirectoryProperty("telephoneNumber")]
        public string OfficePhone
        {
            get { return this.ExtensionGetSingleString("telephoneNumber"); }
            set { ExtensionSet("telephoneNumber", value); }
        }

      
        [DirectoryProperty("physicalDeliveryOfficeName")]
        public string Office
        {
            get { return this.ExtensionGetSingleString("physicalDeliveryOfficeName"); }
            set { ExtensionSet("physicalDeliveryOfficeName", value); }

        }

        [DirectoryProperty("preferredLanguage")]
        public string PreferredLanguage
        {
            get { return this.ExtensionGetSingleString("preferredLanguage"); }
            set { ExtensionSet("preferredLanguage", value); }

        }
        #endregion
        #region Orgaznisation attributes
        [DirectoryProperty("company")]
        public string Company
        {
            get { return this.ExtensionGetSingleString("company"); }
            set { ExtensionSet("company", value); }
            
        }
        [DirectoryProperty("department")]
        public string Service
        {
            get { return this.ExtensionGetSingleString("department"); }
            set { ExtensionSet("department", value); }

        }

        [DirectoryProperty("division")]
        public string Division
        {
            get { return this.ExtensionGetSingleString("division"); }
            set { ExtensionSet("division", value); }

        }
        #endregion
        #region Address attributes
        [DirectoryProperty("streetAddress")]
        public string StreetAddress
        {
            get { return this.ExtensionGetSingleString("streetAddress"); }
            set { ExtensionSet("streetAddress", value); }

        }

        [DirectoryProperty("postOfficeBox")]
        public string PostOfficeBox
        {
            get { return this.ExtensionGetSingleString("postOfficeBox"); }
            set { ExtensionSet("postOfficeBox", value); }

        }
        [DirectoryProperty("L")]
        public string City
        {
            get { return this.ExtensionGetSingleString("L"); }
            set { ExtensionSet("L", value); }

        }

        [DirectoryProperty("st")]
        public string State
        {
            get { return this.ExtensionGetSingleString("st"); }
            set { ExtensionSet("st", value); }

        }

        [DirectoryProperty("postalCode")]
        public string PostalCode
        {
            get { return this.ExtensionGetSingleString("postalCode"); }
            set { ExtensionSet("postalCode", value); }

        }

        [DirectoryProperty("co")]
        public string Country
        {
            get { return this.ExtensionGetSingleString("co"); }
            set { ExtensionSet("co", value); }

        }


        #endregion
        #region Photos attributes
        [DirectoryProperty("thumbnailPhoto")]
        public Byte[] ThumbnailPhoto
        {
            get
            {
                return this.ExtensionGetBytes("thumbnailPhoto");
            }
            set
            {
                this.ExtensionSetValue("thumbnailPhoto", value);
            }
        }

        [DirectoryProperty("thumbnailLogo")]
        public Byte[] ThumbnailLogo
        {
            get
            {
                return this.ExtensionGetBytes("thumbnailLogo");
            }
            set
            {
                this.ExtensionSetValue("thumbnailLogo", value);
            }
        }





        [DirectoryProperty("jpegPhoto")]
        public Byte[] JpegPhoto
        {
            get
            {
                return this.ExtensionGetBytes("jpegPhoto");
            }
            set
            {
                this.ExtensionSetValue("jpegPhoto", value);
            }
        }
        [DirectoryProperty("thumbnailPhoto")]
        public Image ThumbnailPhotoImage
        {
            get
            {
                return this.ExtensionGetImage("thumbnailPhoto");
            }
            set
            {
                this.ExtensionSetImage("thumbnailPhoto", value);
            }
        }

        [DirectoryProperty("thumbnailLogo")]
        public Image ThumbnailLogoImage
        {
            get
            {
                return this.ExtensionGetImage("thumbnailLogo");
            }
            set
            {
                this.ExtensionSetImage("thumbnailLogo", value);
            }
        }





        [DirectoryProperty("jpegPhoto")]
        public Image[] JpegPhotoImage
        {
            get
            {
                return this.ExtensionGetImages("jpegPhoto");
            }
            set
            {
                this.ExtensionSetImages("jpegPhoto", value);
            }
        }
        #endregion



        //    [DirectoryProperty("preferredLanguage")]
        //    public CultureInfo PreferredLanguage
        //    {
        //        get {


        //            return (ExtensionGet("preferredLanguage").Length >0) ? new CultureInfo((string)ExtensionGet("preferredLanguage")[0] ): null; }
        //        set { ExtensionSet("preferredLanguage", value.Name); }


        //}






    }
}

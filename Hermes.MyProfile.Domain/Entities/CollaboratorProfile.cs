using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Serialization;

namespace Hermes.MyProfile.Domain.Entities
{
    [DataContract]
    public class CollaboratorProfile
    {
        readonly string prefixePhoto = "photo_";
        readonly ImageFormat photoFormat = ImageFormat.Jpeg;
        private SmallImagePhoto _smallImage;
        private MediumImagePhoto _mediumImage;
        private LargeImagePhoto _largeImage;

        public CollaboratorProfile(string userName)
        {
            _userName = userName;
            _smallImage = new SmallImagePhoto($"{prefixePhoto}{userName}", photoFormat);
            _mediumImage = new MediumImagePhoto($"{prefixePhoto}{userName}", photoFormat);
            _largeImage = new LargeImagePhoto($"{prefixePhoto}{userName}", photoFormat);

        }
        [DataMember]
        public SmallImagePhoto SmallImage { get => _smallImage; set => _smallImage = value; }
    

        [DataMember]
        public MediumImagePhoto MediumImage { get => _mediumImage; set => _mediumImage = value; }
        [DataMember]
        public LargeImagePhoto LargeImage { get=>_largeImage; set=>_largeImage=value; }


        string _userName;
        [DataMember]
        public string UserName { get => _userName; set=>_userName=value; }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }
        public string MobilePhone { get; set; }
       
        public string MailAddress { get; set; }
       
        public string OfficePhone { get; set; }
       
        public string PreferredLanguage { get; set; }
      
        public string Company { get; set; }
        

        public string Service { get; set; }
       

        public string Division { get; set; }


        public string Office { get; set; }
        public string StreetAddress { get; set; }
       

        public string PostOfficeBox { get; set; }
      

        public string City { get; set; }
       


        public string State { get; set; }
       


        public string PostalCode { get; set; }


        public string Country { get; set; }
     
    }
}
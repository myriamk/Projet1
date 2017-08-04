using System;
using System.Collections.Generic;
using System.Linq;


namespace Hermes.MyProfile.Domain.Entities
{
    public class CollaboratorProfile
    {

        public readonly string UserNameTest;

        public string UserName { get; set; }
        public string FirstName { get; set; }
      
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
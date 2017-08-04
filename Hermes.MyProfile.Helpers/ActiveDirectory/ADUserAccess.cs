using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Drawing;

namespace Hermes.MyProfile.Helpers.ActiveDirectory
{
    public class ADUserAccess:IDisposable
    {

        public ADUserAccess(string userCN, string adDomainName, string adContainer, string adServerLogin, string adServerMdp)
        {
            _userCN = userCN;
            //        principalContext thisPrincipalContext =
            //new PrincipalContext(ContextType.Domain, null, "CN=Users,DC=estagioit,DC=local",login,pwd);
              this._principalContext = new PrincipalContext(ContextType.Domain, adDomainName, adContainer, adServerLogin, adServerMdp);

      
         
        }


        #region Fields
        private string _userCN;
        private PrincipalContext _principalContext;
       
        private ADUser _userProfilePrincipal;
        protected ADUser UserPrincipal {
            get {

                if (_userProfilePrincipal != null)
                {
                    return _userProfilePrincipal;
                }
                else
                {

                    _userProfilePrincipal= ADUser.FindByIdentity(_principalContext, _userCN);
                    if (_userProfilePrincipal == null)
                    {
                        _principalContext.Dispose();
                        throw new Exception("Can't find user " + _userCN);
                    }
                    return _userProfilePrincipal;

                }
               
                
            } }
        #endregion

        #region User Method's
        public bool UserExists {get { return UserPrincipal != null; } }

        /// <summary>
        /// Save Profile in AD
        /// </summary>
        public void SaveUserProfile()
        {
            if (_userProfilePrincipal != null)
                _userProfilePrincipal.Save();


        }

        public void Dispose()
        {

            _userProfilePrincipal.Dispose();

            _principalContext.Dispose();

        }
        #endregion
        #region Accessor's

        public Byte[] JpegPhoto
        {
            get { return _userProfilePrincipal.JpegPhoto; }
            set { _userProfilePrincipal.JpegPhoto = value; }
        }

        public Byte[] ThumbnailPhoto
        {
            get { return _userProfilePrincipal.ThumbnailPhoto; }
            set { _userProfilePrincipal.ThumbnailPhoto = value; }
        }


        public string FirstName
        {
            get { return _userProfilePrincipal.GivenName; }
            set { _userProfilePrincipal.GivenName = value; }
        }
        public string LastName
        {
            get { return _userProfilePrincipal.Surname; }
            set { _userProfilePrincipal.Surname = value; }
        }

        public string Office
        {
            get { return _userProfilePrincipal.Office; }
            set { _userProfilePrincipal.Office = value; }
        }




        public string MobilePhone
        {
            get { return _userProfilePrincipal.MobilePhone; }
            set { _userProfilePrincipal.MobilePhone = value; }
        }

      
        public string MailAddress
        {
            get { return _userProfilePrincipal.MailAddress; }
            set { _userProfilePrincipal.MailAddress = value; }

        }

        public string Title
        {
            get { return _userProfilePrincipal.Title; }
            set { _userProfilePrincipal.Title = value; }
         
        }

      
        public string Manager
        {
            get { return _userProfilePrincipal.Manager; }
            
        }

      
        public string OfficePhone
        {
            get { return _userProfilePrincipal.OfficePhone; }
            set { _userProfilePrincipal.OfficePhone = value; }
        }

        
        public string PreferredLanguage
        {
            get { return _userProfilePrincipal.PreferredLanguage; }
            set { _userProfilePrincipal.PreferredLanguage = value; }

        }

       
        public string Company
        {
            get { return _userProfilePrincipal.Company; }
            set { _userProfilePrincipal.Company = value; }

        }
       
        public string Service
        {
            get { return _userProfilePrincipal.Service; }
            set { _userProfilePrincipal.Service = value; }

        }

      
        public string Division
        {
            get { return _userProfilePrincipal.Division; }
            set { _userProfilePrincipal.Division = value; }

        }

        
        public string StreetAddress
        {
            get { return _userProfilePrincipal.StreetAddress; }
            set { _userProfilePrincipal.StreetAddress = value; }

        }

        
        public string PostOfficeBox
        {
            get { return _userProfilePrincipal.PostOfficeBox; }
            set { _userProfilePrincipal.PostOfficeBox = value; }

        }
       
        public string City
        {
            get { return _userProfilePrincipal.City; }
            set { _userProfilePrincipal.City = value; }
        }

       
        public string State
        {
            get { return _userProfilePrincipal.State; }
            set { _userProfilePrincipal.State = value; }

        }

 
        public string PostalCode
        {
            get { return _userProfilePrincipal.PostalCode; }
            set { _userProfilePrincipal.PostalCode = value; }

        }

    
        public string Country
        {
            get { return _userProfilePrincipal.Country; }
            set { _userProfilePrincipal.Country = value; }

        }
        #endregion

    }
}

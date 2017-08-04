using Hermes.MyProfile.Domain.Entities;
using Hermes.MyProfile.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hermes.MyProfile.Web.Services
{
    public class CollaboratorProfileService: ICollaboratorProfileService
    {

        ICachedImageLoader _CachedImageLoader;
        public CollaboratorProfileService(ICachedImageLoader cachedImageLoader)
        {

            _CachedImageLoader = cachedImageLoader;
        }

        private List<CollaboratorProfile> _CollaboratorProfiles = new List<CollaboratorProfile>()
        {
            new CollaboratorProfile("cejeanneret"){ LastName="Jeanneret-Gris",FirstName="Charles-Edouard" , MailAddress="cejeanneret@hermes.fr", Title="Chef de projet",MobilePhone="+33667054415"}
            ,new CollaboratorProfile("pdurand"){ LastName="Durand",FirstName="Pascal" , MailAddress="pdurand@hermes.fr", Title="Artisan",MobilePhone="+33667054414"}

        };
        /// <summary>
        /// Get collaborator photos
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="loadPhotos"></param>
        /// <returns></returns>
        public CollaboratorProfile   GetCollaboratorProfile(string userName,bool loadPhotos)
        {
            //var ret = new CollaboratorProfile();
            //using (var adUserAccess = new ADUserAccess(userName
            //      , ConfigurationManager.AppSettings["ldap:domain"]
            //     , ConfigurationManager.AppSettings["ldap:container"]
            //        , ConfigurationManager.AppSettings["ldap:login"],
            //        ConfigurationManager.AppSettings["ldap:password"]))
            //{
            //    ret.MailAddress = adUserAccess.MailAddress;
            //    ret.OfficePhone = adUserAccess.OfficePhone;
            //    ret.LastName= adUserAccess.LastName;


            //}

            var ret = _CollaboratorProfiles.FirstOrDefault(cp => cp.UserName == userName);
            if (loadPhotos && ret != null)
            {
                _CachedImageLoader.LoadImagePhotoFromCache(ret.SmallImage);
                _CachedImageLoader.LoadImagePhotoFromCache(ret.MediumImage);
                _CachedImageLoader.LoadImagePhotoFromCache(ret.LargeImage);

            }


            return ret;

        }
       
        /// <summary>
        /// Get Collaborator photo
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="size">image size</param>
        /// <returns></returns>
        public ImagePhoto GetCollaboratorPhoto(string userName, CollaboratorImageSize size)
        {
            ImagePhoto ret = null;
            var p = _CollaboratorProfiles.FirstOrDefault(cp => cp.UserName == userName);
            if (p != null)
            {
                switch (size)
                {
                    case CollaboratorImageSize.small: ret = p.SmallImage; break;
                    case CollaboratorImageSize.medium: ret = p.MediumImage; break;
                    case CollaboratorImageSize.large: ret = p.LargeImage; break;
                    default: ret = p.MediumImage;break;
                }
                if (p != null)
                    _CachedImageLoader.LoadImagePhotoFromCache(ret);
            }

            return ret;

        }

        public void UpdateCollaboratorProfile(CollaboratorProfile cp)
        {
           var cpToUpdate= _CollaboratorProfiles.FirstOrDefault(c => c.UserName == cp.UserName);


        }

    }
}
namespace Hermes.MyProfile.Domain.Entities
{
    public interface ICollaboratorPhotos
    {
        string BasePhotoName { get; set; }
        IImagePhoto LargeImage { get; set; }
        IImagePhoto MediumImage { get; set; }
        IImagePhoto SmallImage { get; set; }
    }
}
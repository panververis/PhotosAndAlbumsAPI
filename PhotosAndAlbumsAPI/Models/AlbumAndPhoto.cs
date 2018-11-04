namespace PhotosAndAlbumsAPI.Models
{
    /// <summary>
    /// "AlbumAndPhoto", used to hold the aggregated data of Albums and Photos (joined on their AlbumID).
    /// </summary>
    /// <remarks>
    /// Mind to review the "IsPropertyWiseEqual" property in case Properties are added!
    /// </remarks>
    public class AlbumAndPhoto
    {
        #region Properties

        public int      UserID              { get; private set; }
        public int      AlbumID             { get; private set; }
        public string   AlbumTitle          { get; private set; }
        public int      PhotoID             { get; private set; }
        public string   PhotoTitle          { get; private set; }
        public string   PhotoUrl            { get; private set; }
        public string   PhotoThumbnailUrl   { get; private set; }

        #endregion

        #region Ctor

        public AlbumAndPhoto(int userID, int albumID, string albumTitle, int photoID, string photoTitle, string photoUrl, string photoTumbnailUrl)
        {
            UserID              = userID;
            AlbumID             = albumID;
            AlbumTitle          = albumTitle;
            PhotoID             = photoID;
            PhotoTitle          = photoTitle;
            PhotoUrl            = photoUrl;
            PhotoThumbnailUrl   = photoTumbnailUrl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Comparer function used to facilitate the check of whether two AlbumAndPhoto objects are Equal with regards to their Properties
        /// </summary>
        public bool IsPropertyWiseEqual(AlbumAndPhoto otherAlbumAndPhoto)
        {
            return (    UserID              == otherAlbumAndPhoto.UserID
                    &&  AlbumID             == otherAlbumAndPhoto.AlbumID
                    &&  AlbumTitle          == otherAlbumAndPhoto.AlbumTitle
                    &&  PhotoID             == otherAlbumAndPhoto.PhotoID
                    &&  PhotoTitle          == otherAlbumAndPhoto.PhotoTitle
                    &&  PhotoUrl            == otherAlbumAndPhoto.PhotoUrl
                    &&  PhotoThumbnailUrl   == otherAlbumAndPhoto.PhotoThumbnailUrl);
        }

        #endregion
    }
}

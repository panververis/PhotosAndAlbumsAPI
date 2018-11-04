namespace PhotosAndAlbumsAPI.Models
{
    public class Photo
    {
        #region Properties

        public int      AlbumID         { get; private set; }
        public int      ID              { get; private set; }
        public string   Title           { get; private set; }
        public string   Url             { get; private set; }
        public string   ThumbnailUrl    { get; private set; }

        #endregion

        #region Ctor

        public Photo(int albumID, int id, string title, string url, string thumbnailUrl) {
            AlbumID             = albumID;
            ID                  = id;
            Title               = title;
            Url                 = url;
            ThumbnailUrl        = thumbnailUrl;
        }

        #endregion
    }
}

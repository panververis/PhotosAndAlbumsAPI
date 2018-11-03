using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Models
{
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
    }

}

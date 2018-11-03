using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Models
{
    public class Album
    {
        #region Properties

        public int      UserID          { get; private set; }
        public int      ID              { get; private set; }
        public string   Title           { get; private set; }

        #endregion

        #region Ctor

        public Album(int userID, int id, string title) {
            UserID  = userID;
            ID      = id;
            Title   = title;
        }

        #endregion
    }
}

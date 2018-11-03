using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Models
{
    public class Photo
    {
        public int      AlbumID         { get; private set; }
        public int      ID              { get; private set; }
        public string   Title           { get; private set; }
        public string   Url             { get; private set; }
        public string   ThumbnailUrl    { get; private set; }
    }
}

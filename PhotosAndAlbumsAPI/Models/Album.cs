using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Models
{
    public class Album
    {
        public int      UserID          { get; private set; }
        public int      ID              { get; private set; }
        public string   Title           { get; private set; }
    }
}

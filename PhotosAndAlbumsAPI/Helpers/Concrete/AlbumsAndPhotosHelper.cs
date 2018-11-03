using PhotosAndAlbumsAPI.Helpers.Interface;
using PhotosAndAlbumsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Helpers.Concrete
{
    public class AlbumsAndPhotosHelper : IAlbumsAndPhotosHelper
    {
        public IEnumerable<AlbumAndPhoto> GetAggregatedAlbumAndPhotoResult(IEnumerable<Album> albums, IEnumerable<Photo> photos)
        {
            throw new NotImplementedException();
        }
    }
}

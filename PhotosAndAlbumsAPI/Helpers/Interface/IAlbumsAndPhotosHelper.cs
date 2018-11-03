using PhotosAndAlbumsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Helpers.Interface
{
    public interface IAlbumsAndPhotosHelper
    {
        IEnumerable<AlbumAndPhoto> GetAggregatedAlbumAndPhotoResult(IEnumerable<Album> albums, IEnumerable<Photo> photos);
    }
}

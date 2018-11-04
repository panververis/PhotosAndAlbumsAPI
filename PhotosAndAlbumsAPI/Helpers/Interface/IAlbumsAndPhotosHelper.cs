using PhotosAndAlbumsAPI.Models;
using System.Collections.Generic;

namespace PhotosAndAlbumsAPI.Helpers.Interface
{
    /// <summary>
    /// This is the interface for a helper class that helps aggregate the matching by album Id Albums with their matching Photos, 
    /// and produce an IEnumerable of AlbumAndPhoto objects
    /// </summary>
    public interface IAlbumsAndPhotosHelper
    {
        IEnumerable<AlbumAndPhoto> GetAggregatedAlbumsAndPhotosResult(IEnumerable<Album> albums, IEnumerable<Photo> photos);
    }
}

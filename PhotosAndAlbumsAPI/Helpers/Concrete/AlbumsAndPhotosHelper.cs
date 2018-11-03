using PhotosAndAlbumsAPI.Helpers.Interface;
using PhotosAndAlbumsAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhotosAndAlbumsAPI.Helpers.Concrete
{
    public class AlbumsAndPhotosHelper : IAlbumsAndPhotosHelper
    {
        public IEnumerable<AlbumAndPhoto> GetAggregatedAlbumsAndPhotosResult(IEnumerable<Album> albumsEnumerable, IEnumerable<Photo> photosEnumerable) {
            //  Guard clause - checking for null or empty
            if (albumsEnumerable == null || !albumsEnumerable.Any() || photosEnumerable == null || !photosEnumerable.Any()) {
                return new List<AlbumAndPhoto>();
            }

            //  Initializing the to-be-returned List
            List<AlbumAndPhoto> aggregatedAlbumAndPhotoList = new List<AlbumAndPhoto>();

            //  "Aggregating" the matching albums with their matching Photos, and return the compiled List
            foreach (Album album in albumsEnumerable) {
                foreach (Photo photo in photosEnumerable.Where(photo => photo.AlbumID == album.ID)) {
                    aggregatedAlbumAndPhotoList.Add(new AlbumAndPhoto(album.UserID, album.ID, album.Title, photo.ID, photo.Title, photo.Url, photo.ThumbnailUrl));
                }
            }
            return aggregatedAlbumAndPhotoList;
        }
    }
}

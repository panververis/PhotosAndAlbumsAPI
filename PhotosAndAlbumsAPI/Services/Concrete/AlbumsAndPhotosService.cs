using PhotosAndAlbumsAPI.Helpers.Interface;
using PhotosAndAlbumsAPI.Models;
using PhotosAndAlbumsAPI.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Concrete
{
    public class AlbumsAndPhotosService : IAlbumsAndPhotosService
    {
        #region Fields

        private readonly IAlbumsService         _albumsService;
        private readonly IPhotosService         _photosService;
        private readonly IAlbumsAndPhotosHelper _albumsAndPhotosHelper;

        #endregion

        #region Ctor

        public AlbumsAndPhotosService(
            IAlbumsService          albumsService, 
            IPhotosService          photosService,
            IAlbumsAndPhotosHelper  albumsAndPhotosHelper) {
            _albumsService          = albumsService;
            _photosService          = photosService;
            _albumsAndPhotosHelper  = albumsAndPhotosHelper;
        }

        #endregion

        #region Public methods

        public async Task<IEnumerable<AlbumAndPhoto>> GetAlbumsAndPhotosAsync() {
            IEnumerable<AlbumAndPhoto> albumsAndPhotosAggregated = new List<AlbumAndPhoto>();
            IEnumerable<Album> albums = await _albumsService.GetAlbumsAsync();
            if (albums == null || !albums.Any()) {
                return albumsAndPhotosAggregated;
            }
            IEnumerable<Photo> photos = await _photosService.GetPhotosAsync();
            if (photos == null || !photos.Any()) {
                return albumsAndPhotosAggregated;
            }
            albumsAndPhotosAggregated = _albumsAndPhotosHelper.GetAggregatedAlbumsAndPhotosResult(albums, photos);
            return albumsAndPhotosAggregated;
        }

        public async Task<IEnumerable<AlbumAndPhoto>> GetAlbumsAndPhotosForUserAsync(int userId) {
            IEnumerable<AlbumAndPhoto> albumsAndPhotosAggregated = new List<AlbumAndPhoto>();
            IEnumerable<Album> albums = await _albumsService.GetAlbumsForUserAsync(userId);
            if (albums == null || !albums.Any()) {
                return albumsAndPhotosAggregated;
            }
            IEnumerable<Photo> photos = await _photosService.GetPhotosAsync();
            if (photos == null || !photos.Any()) {
                return albumsAndPhotosAggregated;
            }
            albumsAndPhotosAggregated = _albumsAndPhotosHelper.GetAggregatedAlbumsAndPhotosResult(albums, photos);
            return albumsAndPhotosAggregated;
        }

        #endregion
    }
}

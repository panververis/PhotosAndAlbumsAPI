using PhotosAndAlbumsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Interface
{
    public interface IAlbumsAndPhotosService {
        Task<IEnumerable<AlbumAndPhoto>> GetAlbumsAndPhotosAsync();
        Task<IEnumerable<AlbumAndPhoto>> GetAlbumsAndPhotosForUserAsync(int userId);
    }
}

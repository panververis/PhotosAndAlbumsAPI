using PhotosAndAlbumsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Interface
{
    public interface IPhotosService {
        Task<IEnumerable<Photo>> GetPhotosAsync();
    }
}

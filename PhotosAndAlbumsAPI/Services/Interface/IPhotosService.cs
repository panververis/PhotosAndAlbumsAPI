using PhotosAndAlbumsAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Interface
{
    public interface IPhotosService {

        Task<IEnumerable<Photo>> GetPhotosAsync();
    }
}

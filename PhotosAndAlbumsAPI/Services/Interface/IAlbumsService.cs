using PhotosAndAlbumsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Interface
{
    public interface IAlbumsService {

        Task<IEnumerable<Album>> GetAlbumsAsync();
    }
}

﻿using PhotosAndAlbumsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Interface
{
    public interface IAlbumsService {
        Task<IEnumerable<Album>> GetAlbumsAsync();
        Task<IEnumerable<Album>> GetAlbumsForUserAsync(int userId);
    }
}

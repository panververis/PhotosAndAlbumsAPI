using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotosAndAlbumsAPI.Models;
using PhotosAndAlbumsAPI.Services.Interface;

namespace PhotosAndAlbumsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsAndPhotosController : ControllerBase
    {
        #region Fields

        private readonly IAlbumsAndPhotosService _albumsAndPhotosService;

        #endregion

        #region Ctor

        public AlbumsAndPhotosController(IAlbumsAndPhotosService albumsAndPhotosService) {
            _albumsAndPhotosService = albumsAndPhotosService;
        }

        #endregion

        #region Public  / exposed methods

        // GET: api/AlbumsAndPhotos
        [HttpGet]
        public async Task<IActionResult> GetAlbumsAndPhotos()
        {
            IEnumerable<AlbumAndPhoto> albumsAndPhotosEnumerable = new List<AlbumAndPhoto>();
            try {
                albumsAndPhotosEnumerable = await _albumsAndPhotosService.GetAlbumsAndPhotosAsync();
                return Ok(albumsAndPhotosEnumerable);
            }
            catch(Exception exception) {
                return StatusCode(500, $"Server error - {exception.Message}. {exception.InnerException}");
            }
        }

        #endregion

        // GET: api/AlbumsAndPhotos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumsAndPhotosForUser(int id)
        {
            try {
                IEnumerable<AlbumAndPhoto>  albumsAndPhotosEnumerable = await _albumsAndPhotosService.GetAlbumsAndPhotosForUserAsync(id);
                return Ok(albumsAndPhotosEnumerable);
            }
            catch (Exception exception) {
                return StatusCode(500, $"Server error - {exception.Message}. {exception.InnerException}");
            }
        }
    }
}

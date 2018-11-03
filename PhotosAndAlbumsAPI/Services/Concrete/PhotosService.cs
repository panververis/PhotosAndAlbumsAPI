using Microsoft.Extensions.Configuration;
using PhotosAndAlbumsAPI.Models;
using PhotosAndAlbumsAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Concrete
{
    public class PhotosService : IPhotosService
    {
        #region Fields

        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration     _configuration;

        #endregion

        #region Ctor

        public PhotosService(IHttpClientFactory clientFactory, IConfiguration configuration) {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        #endregion

        #region Public methods

        public async Task<IEnumerable<Photo>> GetPhotosAsync() {
            //  Guard Clause - checking for null or empty "Photos" URL configuration
            string photosUrl = _configuration["PhotosUrl"];
            if (String.IsNullOrEmpty(photosUrl)) {
                throw new Exception($"Configuration {photosUrl} is not defined");
            }
            HttpClient httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(photosUrl);
            //httpClient.DefaultRequestHeaders.Accept.Add();
            HttpResponseMessage reponse = await httpClient.GetAsync("/");
            if (reponse.IsSuccessStatusCode) {
                return await reponse.Content.ReadAsAsync<IEnumerable<Photo>>();
            }
            else {
                return new List<Photo>();
            }
        }

        #endregion

    }
}

using Microsoft.Extensions.Configuration;
using PhotosAndAlbumsAPI.Models;
using PhotosAndAlbumsAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPI.Services.Concrete
{
    public class AlbumsService : IAlbumsService
    {
        #region Fields

        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration     _configuration;

        #endregion

        #region Ctor

        public AlbumsService(IHttpClientFactory clientFactory, IConfiguration configuration) {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        #endregion

        #region Public methods

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            //  Guard Clause - checking for null or empty "Albums" URL configuration missing
            string albumsUrl = _configuration["AlbumsUrl"];
            if (String.IsNullOrEmpty(albumsUrl)) {
                throw new Exception($"Configuration {albumsUrl} is not defined");
            }
            HttpClient httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(albumsUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage reponse = await httpClient.GetAsync("");
            if (reponse.IsSuccessStatusCode) {
                return await reponse.Content.ReadAsAsync<IEnumerable<Album>>();
            }
            else {
                return new List<Album>();
            }
        }

        public async Task<IEnumerable<Album>> GetAlbumsForUserAsync(int userId)
        {
            //  Guard Clause - checking for null or empty "Albums" URL configuration missing
            string albumsUrl = _configuration["AlbumsUrl"];
            if (String.IsNullOrEmpty(albumsUrl))
            {
                throw new Exception($"Configuration {albumsUrl} is not defined");
            }
            HttpClient httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(albumsUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string parameter = $"/albums/?userId={ userId.ToString()}";
            HttpResponseMessage reponse = await httpClient.GetAsync(parameter);
            if (reponse.IsSuccessStatusCode) {
                return await reponse.Content.ReadAsAsync<IEnumerable<Album>>();
            }
            else {
                return new List<Album>();
            }
        }

        #endregion
    }
}

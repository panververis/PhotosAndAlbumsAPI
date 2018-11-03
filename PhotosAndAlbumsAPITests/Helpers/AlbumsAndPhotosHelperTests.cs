using NUnit.Framework;
using PhotosAndAlbumsAPI.Helpers.Concrete;
using PhotosAndAlbumsAPI.Helpers.Interface;
using PhotosAndAlbumsAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotosAndAlbumsAPITests.Helpers
{
    [TestFixture]
    public class AlbumsAndPhotosHelperTests
    {
        private IAlbumsAndPhotosHelper _albumsAndPhotosHelper;

        [SetUp]
        public void SetUp() {
            _albumsAndPhotosHelper = new AlbumsAndPhotosHelper();
        }

        [Test]
        public void CheckHelperClassReturnsValidResult() {
            Assert.IsInstanceOf<IEnumerable<AlbumAndPhoto>>(_albumsAndPhotosHelper);
        }

        private List<Album> GetTestAlbumsList() {
            return new List<Album>() {
                new Album(1, 1, "test_album_1"),
                new Album(2, 2, "test_album_2")
            };
        }

        private List<Photo> GetTestPhotoList() {
            return new List<Photo>() {
                new Photo(1, 1, "test_photo_1", "photo_url_1", "thumbnail_url_1"),
                new Photo(1, 2, "test_photo_2", "photo_url_2", "thumbnail_url_2"),
                new Photo(2, 3, "test_photo_3", "photo_url_3", "thumbnail_url_3"),
                new Photo(2, 4, "test_photo_4", "photo_url_4", "thumbnail_url_4")
            };
        }
    }
}

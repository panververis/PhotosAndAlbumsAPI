using Moq;
using NUnit.Framework;
using PhotosAndAlbumsAPI.Helpers.Concrete;
using PhotosAndAlbumsAPI.Helpers.Interface;
using PhotosAndAlbumsAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhotosAndAlbumsAPITests.Helpers
{
    [TestFixture]
    public class AlbumsAndPhotosHelperTests
    {
        #region Fields

        private IAlbumsAndPhotosHelper _albumsAndPhotosHelper;

        #endregion

        #region Set Up

        [SetUp]
        public void SetUp() {
            _albumsAndPhotosHelper = new AlbumsAndPhotosHelper();
        }

        #endregion

        #region Tests

        [Test]
        public void CheckHelperClassReturnsExpectedType() {
            Assert.IsInstanceOf<IEnumerable<AlbumAndPhoto>>(_albumsAndPhotosHelper.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()));
        }

        [Test]
        public void CheckHelperClassReturnsEmptyEnumerableIfNoAlbumsExistAsInput() {
            var albumsAndPhotosEnumerable = _albumsAndPhotosHelper.GetAggregatedAlbumsAndPhotosResult(null, GetTestPhotoList());
            Assert.AreEqual(0, albumsAndPhotosEnumerable.Count());
        }

        [Test]
        public void CheckHelperClassReturnsEmptyEnumerableIfNoPhotosExistAsInput() {
            var albumsAndPhotosEnumerable = _albumsAndPhotosHelper.GetAggregatedAlbumsAndPhotosResult(GetTestAlbumsList(), null);
            Assert.AreEqual(0, albumsAndPhotosEnumerable.Count());
        }

        [Test]
        public void CheckHelperClassReturnsCorrectResultIfInputIsCorrect() {
            List<AlbumAndPhoto> albumsAndPhotosEnumerable = _albumsAndPhotosHelper.GetAggregatedAlbumsAndPhotosResult(GetTestAlbumsList(), GetTestPhotoList()).ToList();
            List<AlbumAndPhoto> albumsAndPhotosEnumerableExpected = GetTestAlbumAndPhotoList();
            for (int i = 0; i < albumsAndPhotosEnumerable.Count(); i++ ) {
                Assert.IsTrue(albumsAndPhotosEnumerable[i].IsPropertyWiseEqual(albumsAndPhotosEnumerableExpected[i]));
            }
        }

        #endregion

        #region Helper Methods

        private List<Album> GetTestAlbumsList()
        {
            return new List<Album>() {
                new Album(1, 1, "test_album_1"),
                new Album(2, 2, "test_album_2")
            };
        }

        private List<Photo> GetTestPhotoList()
        {
            return new List<Photo>() {
                new Photo(1, 1, "test_photo_1", "photo_url_1", "thumbnail_url_1"),
                new Photo(1, 2, "test_photo_2", "photo_url_2", "thumbnail_url_2"),
                new Photo(2, 3, "test_photo_3", "photo_url_3", "thumbnail_url_3"),
                new Photo(2, 4, "test_photo_4", "photo_url_4", "thumbnail_url_4")
            };
        }

        private List<AlbumAndPhoto> GetTestAlbumAndPhotoList() {
            return new List<AlbumAndPhoto>() {
                new AlbumAndPhoto(1, 1, "test_album_1", 1, "test_photo_1", "photo_url_1", "thumbnail_url_1"),
                new AlbumAndPhoto(1, 1, "test_album_1", 2, "test_photo_2", "photo_url_2", "thumbnail_url_2"),
                new AlbumAndPhoto(2, 2, "test_album_2", 3, "test_photo_3", "photo_url_3", "thumbnail_url_3"),
                new AlbumAndPhoto(2, 2, "test_album_2", 4, "test_photo_4", "photo_url_4", "thumbnail_url_4")
            };
        }

        #endregion
    }  
}

using Moq;
using NUnit.Framework;
using PhotosAndAlbumsAPI.Helpers.Interface;
using PhotosAndAlbumsAPI.Models;
using PhotosAndAlbumsAPI.Services.Concrete;
using PhotosAndAlbumsAPI.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPITests.Services
{
    [TestFixture]
    public class AlbumsAndPhotosServiceTests
    {
        [Test]
        public void CheckAlbumsAndPhotosServiceReturnsCorrectType()
        {
            //  Arrange (mocking all necessary services / and helpers)
            var _albumsServiceMock = new Mock<IAlbumsService>();
            _albumsServiceMock.Setup(x => x.GetAlbumsAsync()).Returns(Task.FromResult(result: It.IsAny<IEnumerable<Album>>()));
            var _photosServiceMock = new Mock<IPhotosService>();
            _photosServiceMock.Setup(x => x.GetPhotosAsync()).Returns(Task.FromResult(result: It.IsAny<IEnumerable<Photo>>()));
            var _albumsAndPhotosHelperMock = new Mock<IAlbumsAndPhotosHelper>();
            _albumsAndPhotosHelperMock.Setup(x => x.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()))
                                .Returns(It.IsAny<IEnumerable<AlbumAndPhoto>>);
            IAlbumsAndPhotosService albumsAndPhotosService = new AlbumsAndPhotosService(_albumsServiceMock.Object, _photosServiceMock.Object, _albumsAndPhotosHelperMock.Object);

            //  Act
            var albumAndPhotos = albumsAndPhotosService.GetAlbumsAndPhotosAsync().Result;

            //  Assert
            Assert.IsInstanceOf(typeof(IEnumerable<AlbumAndPhoto>), albumAndPhotos);
        }

        [Test]
        public void CheckAlbumsAndPhotosServiceReturnsEmptyListIfNoAlbumsArePresent()
        {
            //  Arrange (mocking all necessary services / and helpers)
            var _albumsServiceMock = new Mock<IAlbumsService>();
            _albumsServiceMock.Setup(x => x.GetAlbumsAsync()).Returns(Task.FromResult(result: new List<Album>() {} as IEnumerable<Album>));
            var _photosServiceMock = new Mock<IPhotosService>();
            _photosServiceMock.Setup(x => x.GetPhotosAsync()).Returns(Task.FromResult(result: It.IsAny<IEnumerable<Photo>>()));
            var _albumsAndPhotosHelperMock = new Mock<IAlbumsAndPhotosHelper>();
            _albumsAndPhotosHelperMock.Setup(x => x.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()))
                                .Returns(It.IsAny<IEnumerable<AlbumAndPhoto>>);
            IAlbumsAndPhotosService albumsAndPhotosService = new AlbumsAndPhotosService(_albumsServiceMock.Object, _photosServiceMock.Object, _albumsAndPhotosHelperMock.Object);

            //  Act
            IEnumerable<AlbumAndPhoto> albumAndPhotos = albumsAndPhotosService.GetAlbumsAndPhotosAsync().Result;

            //  Assert
            Assert.AreEqual(albumAndPhotos.Count(), 0);
        }

        [Test]
        public void CheckAlbumsAndPhotosServiceReturnsEmptyListIfNoPhotosArePresent()
        {
            //  Arrange (mocking all necessary services / and helpers)
            var _albumsServiceMock = new Mock<IAlbumsService>();
            _albumsServiceMock.Setup(x => x.GetAlbumsAsync()).Returns(Task.FromResult(result: It.IsAny<IEnumerable<Album>>()));
            var _photosServiceMock = new Mock<IPhotosService>();
            _photosServiceMock.Setup(x => x.GetPhotosAsync()).Returns(Task.FromResult(result: new List<Photo>() { } as IEnumerable<Photo>));
            var _albumsAndPhotosHelperMock = new Mock<IAlbumsAndPhotosHelper>();
            _albumsAndPhotosHelperMock.Setup(x => x.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()))
                                .Returns(It.IsAny<IEnumerable<AlbumAndPhoto>>);
            IAlbumsAndPhotosService albumsAndPhotosService = new AlbumsAndPhotosService(_albumsServiceMock.Object, _photosServiceMock.Object, _albumsAndPhotosHelperMock.Object);

            //  Act
            IEnumerable<AlbumAndPhoto> albumAndPhotos = albumsAndPhotosService.GetAlbumsAndPhotosAsync().Result;

            //  Assert
            Assert.AreEqual(albumAndPhotos.Count(), 0);
        }

        [Test]
        public void CheckAlbumsAndPhotosForUserServiceReturnsCorrectType()
        {
            //  Arrange (mocking all necessary services / and helpers)
            var _albumsServiceMock = new Mock<IAlbumsService>();
            _albumsServiceMock.Setup(x => x.GetAlbumsForUserAsync(It.IsAny<int>())).Returns(Task.FromResult(result: It.IsAny<IEnumerable<Album>>()));
            var _photosServiceMock = new Mock<IPhotosService>();
            _photosServiceMock.Setup(x => x.GetPhotosAsync()).Returns(Task.FromResult(result: It.IsAny<IEnumerable<Photo>>()));
            var _albumsAndPhotosHelperMock = new Mock<IAlbumsAndPhotosHelper>();
            _albumsAndPhotosHelperMock.Setup(x => x.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()))
                                .Returns(It.IsAny<IEnumerable<AlbumAndPhoto>>);
            IAlbumsAndPhotosService albumsAndPhotosService = new AlbumsAndPhotosService(_albumsServiceMock.Object, _photosServiceMock.Object, _albumsAndPhotosHelperMock.Object);

            //  Act
            var albumAndPhotos = albumsAndPhotosService.GetAlbumsAndPhotosForUserAsync(It.IsAny<int>()).Result;

            //  Assert
            Assert.IsInstanceOf(typeof(IEnumerable<AlbumAndPhoto>), albumAndPhotos);
        }

        [Test]
        public void CheckAlbumsAndPhotosForUserServiceReturnsEmptyListIfNoAlbumsArePresent()
        {
            //  Arrange (mocking all necessary services / and helpers)
            var _albumsServiceMock = new Mock<IAlbumsService>();
            _albumsServiceMock.Setup(x => x.GetAlbumsForUserAsync(It.IsAny<int>()))
                                .Returns(Task.FromResult(result: new List<Album>() { } as IEnumerable<Album>));
            var _photosServiceMock = new Mock<IPhotosService>();
            _photosServiceMock.Setup(x => x.GetPhotosAsync())
                                .Returns(Task.FromResult(result: It.IsAny<IEnumerable<Photo>>()));
            var _albumsAndPhotosHelperMock = new Mock<IAlbumsAndPhotosHelper>();
            _albumsAndPhotosHelperMock.Setup(x => x.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()))
                                .Returns(It.IsAny<IEnumerable<AlbumAndPhoto>>);
            IAlbumsAndPhotosService albumsAndPhotosService = new AlbumsAndPhotosService(_albumsServiceMock.Object, _photosServiceMock.Object, _albumsAndPhotosHelperMock.Object);

            //  Act
            IEnumerable<AlbumAndPhoto> albumAndPhotos = albumsAndPhotosService.GetAlbumsAndPhotosForUserAsync(It.IsAny<int>()).Result;

            //  Assert
            Assert.AreEqual(albumAndPhotos.Count(), 0);
        }

        [Test]
        public void CheckAlbumsAndPhotosForUserServiceReturnsEmptyListIfNoPhotosArePresent()
        {
            //  Arrange (mocking all necessary services / and helpers)
            var _albumsServiceMock = new Mock<IAlbumsService>();
            _albumsServiceMock.Setup(x => x.GetAlbumsForUserAsync(It.IsAny<int>()))
                                .Returns(Task.FromResult(result: It.IsAny<IEnumerable<Album>>()));
            var _photosServiceMock = new Mock<IPhotosService>();
            _photosServiceMock.Setup(x => x.GetPhotosAsync())
                                .Returns(Task.FromResult(result: new List<Photo>() { } as IEnumerable<Photo>));
            var _albumsAndPhotosHelperMock = new Mock<IAlbumsAndPhotosHelper>();
            _albumsAndPhotosHelperMock.Setup(x => x.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()))
                                .Returns(It.IsAny<IEnumerable<AlbumAndPhoto>>);
            IAlbumsAndPhotosService albumsAndPhotosService = new AlbumsAndPhotosService(_albumsServiceMock.Object, _photosServiceMock.Object, _albumsAndPhotosHelperMock.Object);

            //  Act
            IEnumerable<AlbumAndPhoto> albumAndPhotos = albumsAndPhotosService.GetAlbumsAndPhotosForUserAsync(It.IsAny<int>()).Result;

            //  Assert
            Assert.AreEqual(albumAndPhotos.Count(), 0);
        }

        [Test]
        public void CheckAlbumsAndPhotosForUserServiceReturnsOnlyForTheUser([Random(1, 100, 50)] int randomUserID)
        {
            //  Arrange (mocking all necessary services / and helpers)
            var _albumsServiceMock = new Mock<IAlbumsService>();
            _albumsServiceMock.Setup(x => x.GetAlbumsForUserAsync(randomUserID))
                                .Returns(Task.FromResult(result: It.IsAny<IEnumerable<Album>>()));
            var _photosServiceMock = new Mock<IPhotosService>();
            _photosServiceMock.Setup(x => x.GetPhotosAsync())
                                .Returns(Task.FromResult(result: It.IsAny<IEnumerable<Photo>>()));
            var _albumsAndPhotosHelperMock = new Mock<IAlbumsAndPhotosHelper>();
            _albumsAndPhotosHelperMock.Setup(x => x.GetAggregatedAlbumsAndPhotosResult(It.IsAny<IEnumerable<Album>>(), It.IsAny<IEnumerable<Photo>>()))
                                .Returns(It.IsAny<IEnumerable<AlbumAndPhoto>>);
            IAlbumsAndPhotosService albumsAndPhotosService = new AlbumsAndPhotosService(_albumsServiceMock.Object, _photosServiceMock.Object, _albumsAndPhotosHelperMock.Object);

            //  Act
            var albumAndPhotos = albumsAndPhotosService.GetAlbumsAndPhotosForUserAsync(randomUserID).Result;

            //  Assert
            Assert.AreEqual(albumAndPhotos.All(x => x.UserID == randomUserID), true);
        }
    }
}

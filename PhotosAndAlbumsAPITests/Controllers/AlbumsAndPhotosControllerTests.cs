using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PhotosAndAlbumsAPI.Controllers;
using PhotosAndAlbumsAPI.Models;
using PhotosAndAlbumsAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotosAndAlbumsAPITests.Controllers
{
    [TestFixture]
    public class AlbumsAndPhotosControllerTests
    {
        [Test]
        public async Task AlbumsAndPhotosControllerDoesNotReturnOkIfExceptionIsRaised() {

            //  Arrange
            var albumsAndPhotosServiceMock = new Mock<IAlbumsAndPhotosService>();
            albumsAndPhotosServiceMock.Setup(x => x.GetAlbumsAndPhotosAsync())
                                .Throws<Exception>();
            var albumsAndPhotosController = new AlbumsAndPhotosController(albumsAndPhotosServiceMock.Object);

            //  Act
            var result = await albumsAndPhotosController.GetAlbumsAndPhotos();

            //  Assert
            Assert.IsInstanceOf(typeof(ObjectResult), result);
            Assert.IsNotInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task AlbumsAndPhotosControllerReturnsOkResultWithWhatTheAlbumsAndPhotosServiceReturns()
        {

            //  Arrange
            var albumAndPhotoForTest = new AlbumAndPhoto(1, 1, "", 1, "", "", "");
            var albumsAndPhotosServiceMock = new Mock<IAlbumsAndPhotosService>();
            albumsAndPhotosServiceMock.Setup(x => x.GetAlbumsAndPhotosAsync())
                                .Returns(Task.FromResult(result: new List<AlbumAndPhoto>() { albumAndPhotoForTest } as IEnumerable<AlbumAndPhoto>));
            var albumsAndPhotosController = new AlbumsAndPhotosController(albumsAndPhotosServiceMock.Object);

            //  Act
            var result = await albumsAndPhotosController.GetAlbumsAndPhotos();

            //  Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.IsInstanceOf(typeof(IEnumerable<AlbumAndPhoto>), (result as OkObjectResult).Value);
            Assert.AreEqual(((result as OkObjectResult).Value as IEnumerable<AlbumAndPhoto>).FirstOrDefault(), albumAndPhotoForTest);
        }
    }
}

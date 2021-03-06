﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task AlbumsAndPhotosControllerActionDoesNotReturnOkIfExceptionIsRaised() {

            //  Arrange
            var albumsAndPhotosServiceMock = new Mock<IAlbumsAndPhotosService>();
            albumsAndPhotosServiceMock.Setup(x => x.GetAlbumsAndPhotosAsync()).Throws<Exception>();
            var albumsAndPhotosController = new AlbumsAndPhotosController(albumsAndPhotosServiceMock.Object);

            //  Act
            var result = await albumsAndPhotosController.GetAlbumsAndPhotos();

            //  Assert
            Assert.IsInstanceOf(typeof(ObjectResult), result);
            Assert.IsNotInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task AlbumsAndPhotosControllerActionReturnsOkResultWithWhatTheAlbumsAndPhotosServiceReturns(
            [Random(1, 100, 5)] int randomUserID, 
            [Random(1, 100, 5)] int albumID,
            [Random(1, 100, 5)] int photoID)
        {
            //  Arrange
            var albumAndPhotoForTest = new AlbumAndPhoto(randomUserID, albumID, "", photoID, "", "", "");
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

        [Test]
        public async Task AlbumsAndPhotosForUserControllerActionDoesNotReturnOkIfExceptionIsRaised()
        {

            //  Arrange
            var albumsAndPhotosServiceMock = new Mock<IAlbumsAndPhotosService>();
            albumsAndPhotosServiceMock.Setup(x => x.GetAlbumsAndPhotosForUserAsync(It.IsAny<int>())).Throws<Exception>();
            var albumsAndPhotosController = new AlbumsAndPhotosController(albumsAndPhotosServiceMock.Object);

            //  Act
            var result = await albumsAndPhotosController.GetAlbumsAndPhotosForUser(It.IsAny<int>());

            //  Assert
            Assert.IsInstanceOf(typeof(ObjectResult), result);
            Assert.IsNotInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task AlbumsAndPhotosForUserControllerActionReturnsOkResultWithWhatTheAlbumsAndPhotosServiceReturns(
            [Random(1, 100, 5)] int randomUserID,
            [Random(1, 100, 5)] int albumID,
            [Random(1, 100, 5)] int photoID)
        {
            //  Arrange
            var albumAndPhotoForTest = new AlbumAndPhoto(randomUserID, albumID, "", photoID, "", "", "");
            var albumsAndPhotosServiceMock = new Mock<IAlbumsAndPhotosService>();
            albumsAndPhotosServiceMock.Setup(x => x.GetAlbumsAndPhotosForUserAsync(1))
                                .Returns(Task.FromResult(result: new List<AlbumAndPhoto>() { albumAndPhotoForTest } as IEnumerable<AlbumAndPhoto>));
            var albumsAndPhotosController = new AlbumsAndPhotosController(albumsAndPhotosServiceMock.Object);

            //  Act
            var result = await albumsAndPhotosController.GetAlbumsAndPhotosForUser(1);

            //  Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.IsInstanceOf(typeof(IEnumerable<AlbumAndPhoto>), (result as OkObjectResult).Value);
            Assert.AreEqual(((result as OkObjectResult).Value as IEnumerable<AlbumAndPhoto>).FirstOrDefault(), albumAndPhotoForTest);
        }

        [Test]
        public async Task AlbumsAndPhotosForUserControllerActionReturnsOkResultWithWhatTheAlbumsAndPhotosServiceReturnsOnlyForTheUser([Random(1, 100, 50)] int randomUserID)
        {

            //  Arrange
            var albumAndPhotoForTest = new AlbumAndPhoto(randomUserID, 1, "", 1, "", "", "");
            var albumsAndPhotosServiceMock = new Mock<IAlbumsAndPhotosService>();
            albumsAndPhotosServiceMock.Setup(x => x.GetAlbumsAndPhotosForUserAsync(2))
                                .Returns(Task.FromResult(result: new List<AlbumAndPhoto>() { albumAndPhotoForTest } as IEnumerable<AlbumAndPhoto>));
            var albumsAndPhotosController = new AlbumsAndPhotosController(albumsAndPhotosServiceMock.Object);

            //  Act
            var result = await albumsAndPhotosController.GetAlbumsAndPhotosForUser(2);

            //  Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.IsInstanceOf(typeof(IEnumerable<AlbumAndPhoto>), (result as OkObjectResult).Value);
            Assert.AreEqual(((result as OkObjectResult).Value as IEnumerable<AlbumAndPhoto>).FirstOrDefault(), albumAndPhotoForTest);
            Assert.AreEqual(((result as OkObjectResult).Value as IEnumerable<AlbumAndPhoto>).All(x => x.UserID == randomUserID), true);
        }
    }
}

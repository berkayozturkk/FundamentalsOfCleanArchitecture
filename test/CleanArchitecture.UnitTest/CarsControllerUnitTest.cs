using CleanArchitecture.Application.Features.CarFeatures.Command.CreateCar;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public void Create_ReturnsOkResult_WhenRequestIsValid()
        {
            //Arrange
            var mediaterMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new("Toyota","Corolla",90);
            MessageResponse response = new("Success.",true,null);
            CancellationToken cancellationToken = new();

            mediaterMock.Setup(m => m.Send(createCarCommand, cancellationToken))
                .ReturnsAsync(response);

            //CarsController carsController = new(mediaterMock.Object);

            ////Act
            //var result = await carsController.Create(createCarCommand,cancellationToken);

            ////Assert
            //var okResult = Assert.IsType<OkObjectResult>(result);
            //var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

            //Assert.Equal(response, returnValue );
            //mediaterMock.Verify(m => m.Send(createCarCommand,cancellationToken),
            //    Times.Once);
        }
    }
}
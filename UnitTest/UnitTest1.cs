using MediatR;
using Models;
using Moq;
using Repository;
using UseCases.Dto;
using UseCases.interfaces;

namespace UnitTest;

public class Test
{
    private Mock<IBaseLogic> _mockBaseLogic;
    private Mock<IMediator> _mockMediator;
    private Mock<IOrders> _mockOrder;

    [SetUp]
    public void Setup()
    {
        _mockBaseLogic = new Mock<IBaseLogic>();
        _mockMediator = new Mock<IMediator>();
        _mockOrder = new Mock<IOrders>();
    }

    [Test]
    public async Task TestCreateOrder()
    {
        // Arrange
        var command = new CreateOrderDto()
        {
            ProductInfoId = Guid.Parse("04c33d50-0bd7-4f91-84fb-1bbb6b602b61"),
            SelectedQuantity = 1
        };
        var expectedGuid = Guid.NewGuid();
        _mockOrder.Setup(o => o.CreateOrder(It.IsAny<CreateOrderDto>()))
            .ReturnsAsync(expectedGuid);
        
        // Act
        var result = await _mockOrder.Object.CreateOrder(command);
        // Assert
        Assert.That(result, Is.EqualTo(expectedGuid));
    }
    
    [Test]
    public async Task TestRemoveOrder()
    {
        // Arrange
        var orderId = Guid.Parse("04c33d50-0bd7-4f91-84fb-1bbb6b602b61");

        _mockOrder.Setup(o => o.RemoveOrder(It.IsAny<Guid>())).Verifiable();

        // Act
        await _mockOrder.Object.RemoveOrder(orderId);

        // Assert
        _mockOrder.Verify(o => o.RemoveOrder(It.Is<Guid>(id => id == orderId)), Times.Once);
    }
    
    [Test]
    public async Task TestRecoveryOrder()
    {
        // Arrange
        var orderId = Guid.Parse("04c33d50-0bd7-4f91-84fb-1bbb6b602b61");

        _mockOrder.Setup(o => o.RecoveryOrder(It.IsAny<Guid>())).Verifiable();

        // Act
        await _mockOrder.Object.RecoveryOrder(orderId);

        // Assert
        _mockOrder.Verify(o => o.RecoveryOrder(It.Is<Guid>(id => id == orderId)), Times.Once);
    }
}
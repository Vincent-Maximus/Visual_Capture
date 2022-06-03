using Moq;
using Visual_Capture.BLL.Entities;

namespace Visual_Capture.Unit_Test;

[TestClass]
public class Reservations
{
    private readonly Reservation _reservation;
    private readonly Mock<Reservation> _reservationMock = new Mock<Reservation>();
    // private readonly Mock<Photographer> _photographer = new Mock<Photographer>();
    // private readonly Mock<Customer> _customer = new Mock<Customer>();

    
    public Reservations()
    {
        _reservation = new Reservation();
    }
    
    
    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsTrue(true);
    }
}
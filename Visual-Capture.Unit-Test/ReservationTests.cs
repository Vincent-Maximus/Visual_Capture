using Moq;
using Visual_Capture.BLL.Manager;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;


namespace Visual_Capture.Unit_Test;

[TestClass]
public class ReservationTests
{
    private readonly ReservationManager _sut;
    private readonly Mock<IManagerDal<ReservationDTO>> _reservationMock = new Mock<IManagerDal<ReservationDTO>>();

    public ReservationTests()
    {
        _sut = new ReservationManager(_reservationMock.Object);
    }

    //The tests xD
    [TestMethod]
    public void GetOne_ShouldReturnReservation_IfReservationExists()
    {
        // Dummy Data
        var reservationId = Guid.NewGuid();
        var reservationCustomerId = Guid.NewGuid();
        var reservationDateTime = DateTime.Now;
        var reservationAmountPeople = 5;

        var ReservationDTO = new ReservationDTO()
        {
            Id = reservationId,
            CustomerId = reservationCustomerId,
            DateTime = reservationDateTime,
            AmountPeople = reservationAmountPeople,
        };

        _reservationMock.Setup(x => x.Get(reservationId)).Returns(ReservationDTO);

        //Run
        var reservation = _sut.GetOne(reservationId);

        //Test
        Assert.AreEqual(reservationId, reservation.Id);
    }

    //The tests xD
    [TestMethod]
    public void GetOne_ShouldReturnNull_IfReservationDoesntExists()
    {
        _reservationMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(()=> null);

        //Run
        var reservation = _sut.GetOne(Guid.NewGuid());

        //Test
        Assert.IsNull(reservation);
    }
}
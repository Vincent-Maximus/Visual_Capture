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
    
    // ________________________________
    [TestMethod]
    public void GetAll_ShouldReturnNull_IfThereAreNoReservations()
    {
        // Dummy Data
        List<ReservationDTO> _reservationDTO = new List<ReservationDTO>();
        _reservationMock.Setup(x => x.GetAll()).Returns(() => null);

        //Run
        var reservation = _sut.GetAll();

        //Test
        Assert.IsNull(reservation);
    }


    [TestMethod]
    public void Create_ShouldNotReturnGivenListOfReservations()
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
        
        _reservationMock.Setup(x => x.Create(ReservationDTO))
            .Returns(null);

        //Run
        var reservation = _sut.Create(ReservationDTO);

        //Test
        Assert.AreNotEqual(reservation, ReservationDTO);
    }

    [TestMethod]
    public void Create_ShouldReturnFalse_IfQueryUnsuccessful()
    {
        //this is hard to test the otherwise around, because it requires the Dal to be connected. (witch is not what we want)
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

        _reservationMock.Setup(x => x.Create(ReservationDTO))
            .Returns(null);

        //Run
        var reservation = _sut.Create(ReservationDTO);

        //Test
        Assert.IsFalse(reservation);
    }
    
}
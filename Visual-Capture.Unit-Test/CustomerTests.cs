using Moq;
using Visual_Capture.BLL.Manager;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.Unit_Test;

[TestClass]
public class CustomerTests
{
    // private readonly IManagerDal<CustomerDTO> _customersManagerDal;
    private readonly CustomerManager _sut;
    private readonly Mock<IManagerDal<CustomerDTO>> _customerMock = new Mock<IManagerDal<CustomerDTO>>();

    public CustomerTests()
    {
        _sut = new CustomerManager(_customerMock.Object);
    }

    //The tests xD
    [TestMethod]
    public void GetOne_ShouldReturnCustomer_IfCustomerExists()
    {
        // Dummy Data
        var customerId = Guid.NewGuid();
        var customerName = "Vincent Maximus";
        var customerEmail = "vjp.maximus@gmail.com";
        var customerPhone = "0631521355";

        var CustomerDTO = new CustomerDTO
        {
            Id = customerId,
            Name = customerName,
            Email = customerEmail,
            PhoneNumber = customerPhone,
        };

        _customerMock.Setup(x => x.Get(customerId)).Returns(CustomerDTO);

        //Run
        var customer = _sut.GetOne(customerId);

        //Test
        Assert.AreEqual(customerId, customer.Id);
        Assert.AreEqual(customerName, customer.Name);
    }


    [TestMethod]
    public void GetOne_ShouldReturnNull_IfCustomerDoesntExists()
    {
        //Arrange
        _customerMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(() => null);

        //Run
        var customer = _sut.GetOne(Guid.NewGuid());

        //Test
        Assert.IsNull(customer);
    }

    [TestMethod]
    public void GetAll_ShouldReturnListCustomers()
    {
        // Dummy Data
        List<CustomerDTO> _customerDTO = new List<CustomerDTO>();

        var customerId = Guid.NewGuid();
        var customerName = "Vincent Maximus";
        var customerEmail = "vjp.maximus@gmail.com";
        var customerPhone = "0631521355";

        _customerDTO.Add(new CustomerDTO()
        {
            Id = customerId,
            Name = customerName,
            Email = customerEmail,
            PhoneNumber = customerPhone,
        });

        _customerMock.Setup(x => x.GetAll()).Returns(_customerDTO);

        //Run
        var customer = _sut.GetAll();

        //Test
        Assert.AreEqual(customer, _customerDTO);
    }

    [TestMethod]
    public void GetAll_ShouldReturnNull_IfThereAreNoCustomers()
    {
        // Dummy Data
        List<CustomerDTO> _customerDTO = new List<CustomerDTO>();
        _customerMock.Setup(x => x.GetAll()).Returns(() => null);

        //Run
        var customer = _sut.GetAll();

        //Test

        Assert.IsNull(customer);
    }


    [TestMethod]
    public void Create_ShouldNotReturnGivenListOfCustomers()
    {
        // Dummy Data
        var customerId = Guid.NewGuid();
        var customerName = "Vincent Maximus";
        var customerEmail = "vjp.maximus@gmail.com";
        var customerPhone = "0631521355";

        var _customerDTO = new CustomerDTO
        {
            Id = customerId,
            Name = customerName,
            Email = customerEmail,
            PhoneNumber = customerPhone,
        };

        _customerMock.Setup(x => x.Create(_customerDTO))
            .Returns(null);

        //Run
        var customer = _sut.Create(_customerDTO);

        //Test
        Assert.AreNotEqual(customer, _customerDTO);
    }

    [TestMethod]
    public void Create_ShouldReturnFalse_IfQueryUnsuccessful()
    {
        //this is hard to test the otherwise around, because it requires the Dal to be connected. (witch is not what we want)
        // Dummy Data
        var customerId = Guid.NewGuid();
        var customerName = "Vincent Maximus";
        var customerEmail = "vjp.maximus@gmail.com";
        var customerPhone = "0631521355";

        var _customerDTO = new CustomerDTO
        {
            Id = customerId,
            Name = customerName,
            Email = customerEmail,
            PhoneNumber = customerPhone,
        };

        _customerMock.Setup(x => x.Create(_customerDTO))
            .Returns(null);

        //Run
        var customer = _sut.Create(_customerDTO);

        //Test
        Assert.IsFalse(customer);
    }
}
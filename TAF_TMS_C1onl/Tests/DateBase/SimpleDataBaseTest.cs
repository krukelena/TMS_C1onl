using NLog;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;

using TAF_TMS_C1onl.Services.DateBases;

namespace TAF_TMS_C1onl.Tests.DataBase;

public class SimpleDataBaseTest
{

    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private SimpleDBConnector _simpleDbConnector;
    private CustomerService _customersService;
    
    [OneTimeSetUp]
    public void SetUp()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _customersService = new CustomerService(_simpleDbConnector.Connection);
    }
    [OneTimeTearDown]
    public void TearDown()
    {
        _simpleDbConnector.CloseConnection();
    }

    [Test]
    public void GetAllCustomerTest()
    {
        var customersList = _customersService.GetAllCustomers();

        Assert.That(customersList, Has.Count.GreaterThanOrEqualTo(2));

    }

  
    [Test]

    public void AddCustomersTest()
    {
        _logger.Info("Addcustomer Test started...");
        int affectedRows = _customersService.AddCustomer(new Customer
            {
            Firstname = "Tat",
            Lastname = "Kruk",
            Email = "Qwe@mail.ru",
            Age = 30

        });
        Assert.That(1, Is.EqualTo(affectedRows));

        _logger.Info("AddCustomer Test ended...");
    }

}


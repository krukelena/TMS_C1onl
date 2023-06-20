using TAF_TMS_C1onl.Core;

using TAF_TMS_C1onl.Services.DateBases;

namespace TAF_TMS_C1onl.Tests.DataBase;

public class SimpleDataBaseTest
{
    private SimpleDBConnector _simpleDbConnector;
    private CustomerService _customersService;

    [Test]
    public void tmp()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _customersService = new CustomerService(_simpleDbConnector.Connection);

        _customersService.DropTable();
        _customersService.CreateTable();

        _simpleDbConnector.CloseConnection();
    }
}


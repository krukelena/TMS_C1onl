using TAF_TMS_C1onl.Clients;

namespace TAF_TMS_C1onl.Services.Api;

public class BaseService
{
    protected ApiClient _apiClient;

    public BaseService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}
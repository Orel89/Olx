

namespace OlxCore.Interfaces.Services
{
    public interface IRestService
    {
        Task<T> RequestAsync<T>(HttpMethod method, string resource, Dictionary<string, string>? additioalHeaders = null);

        Task<T> RequestAsync<T>(HttpMethod method, string resource, object requestBody, Dictionary<string, string>? additioalHeaders = null);
    }
}

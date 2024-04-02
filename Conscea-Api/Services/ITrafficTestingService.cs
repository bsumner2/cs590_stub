namespace Conscea_Api.Services;

public interface ITrafficTestingService {
    public Task<IEnumerable<int>> SieveOfEratosthenese(int upper_lim);

}
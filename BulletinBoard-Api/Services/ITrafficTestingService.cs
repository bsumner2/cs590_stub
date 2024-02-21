namespace BulletinBoard_Api.Services;

public interface ITrafficTestingService {
    public Task<IEnumerable<int>> SeiveOfEratosthenese(int upper_lim);


}
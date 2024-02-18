using BulletinBoard_Api.Data;
using BulletinBoard_Api.Models;

namespace BulletinBoard_Api.Services;

public interface IAccountService {


    public Task<string?> GetUsername(Guid accId);
    public Task<AccountActionResult> Create(string username, string digestHexString);
    public Task<Tuple<AccountActionResult, Guid>> Login(string username, string digestHexString);

    public Task<bool> Logout(Guid accId);




}

public enum AccountActionResult {
    INVALID_USERNAME_LEN=-6,
    INVALID_USERNAME,
    INVALID_DIGEST,
    USERNAME_DNE,
    USERNAME_ALREADY_EXISTS,
    WRONG_PASSWORD,
    OKAY

    

}
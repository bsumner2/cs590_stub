using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using BulletinBoard_Api.Data;
using BulletinBoard_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard_Api.Services;

public class AccountService : IAccountService
{

    private readonly BulletinBoardContext _ctx;

    public AccountService(BulletinBoardContext ctx) { _ctx = ctx; }
    public async Task<AccountActionResult> Create(string username, string digestHexString)
    {

        if (username.Length==0 || username.Length > 32)
            return AccountActionResult.INVALID_USERNAME_LEN;
        
        char[] unameChars = username.ToCharArray();

        for (int i = 0; i < username.Length; ++i) {
            if ('_'!=unameChars[i] && !Char.IsLetterOrDigit(unameChars[i]))
                return AccountActionResult.INVALID_USERNAME;
        }

        if (await _ctx.Account.Where(s=>s.Username==username).Select(s=>s).AnyAsync())
            return AccountActionResult.USERNAME_ALREADY_EXISTS;
            
        byte[]? messageDigest = SHA256DigestBytesFromHex(digestHexString);

        if (messageDigest is null)
            return AccountActionResult.INVALID_DIGEST;

        

        Account acc = new Account {
            Username = username,
            ShaDigest = messageDigest,
            IsOnline = false,
        };

        await _ctx.Account.AddAsync(acc);

        await _ctx.SaveChangesAsync();
        
        return AccountActionResult.OKAY;
    }

    public async Task<string?> GetUsername(Guid accId)
    {
        Account? acc = await _ctx.Account.FindAsync(accId);
        if (acc is null)
            return null;
        return acc.Username;
        
    }
    private static bool PassMatch(byte[] a, byte[] b) {
        if ((b.Length != 32) || (a.Length != b.Length))
            return false;
        for (int i = 0; i < 4; ++i)
        {
            // BitConverter.ToUInt<bitlength> (allegedly according to Bing) allows for raw reinterpretation of bits
            // that comprise a memory block as a different-sized int type, like how you can do in C/C++
            // (ex:
            // uint8_t foo[256];
            // uint64_t bar = *(&foo[16]);
            // -------- equivalent in C#:
            // byte foo[256];
            // UInt64 bar = BitConverter.ToUint64(foo, 16));
            // )
            // This sort of raw reinterpretation of a block of memory turns this 32-member byte array equality check
            // into a 4-member ulong array (4 ulongs = 32 bytes / 8 bytes per ulong) equality check without any
            // of the significant overhead we'd otherwise risk incurring if we were to use more-abstracted/higher-level
            // methods of conversion/typecasting.
            if (BitConverter.ToUInt64(a, i << 3) == BitConverter.ToUInt64(b, i << 3))
                continue;
            return false;
        }
        return true;
    }


    private static sbyte ParseCapitalHexDigit(char x) {
        if (x > '9' ) {
            if (x < 'A' || x > 'F')
                return -1;
            x += (char)10;
            x -= 'A';
        } else if (x < '0') {
            return -1;
        } else {
            x -= '0';
        }

        return (sbyte)x;

    }

    private static byte[]? SHA256DigestBytesFromHex(string passWdMsgDigest) {
        if (passWdMsgDigest.Length != 64)
            return null;
        sbyte tmp1, tmp2;  // Declared outside of loop body to save from overhead
                            // of having vars constantly being realloc'd each loop.
        byte[] ret = new byte[32];
        for (int i=0; i < 32; ++i)
        {
            // Hoping that using all of these bitwise operations in lieu of
            // regular arithmetic operators will offer at least some level
            // of noticeable improvement.

            // Using i << 1 and i << 1 | 1 in order to get every char in the array as paiif (!ParseCapitalHexDigit(tmp1) || !ParseCapitalHexDigit(tmp2))rs of chars.
            tmp1 = ParseCapitalHexDigit(char.ToUpper(passWdMsgDigest[i << 1]));  // Index: i << 1 = 2*i
            tmp2 = ParseCapitalHexDigit(char.ToUpper(passWdMsgDigest[(i << 1) | 1]));  // (i << 1) | 1 = 2*i + 1


            if ((0x0F&tmp1)!=tmp1 || (0x0F&tmp2)!=tmp2)
                return null;
            
            ret[i] = (byte)((tmp1<<4)&0xF0);
            ret[i] |= (byte)(tmp2&0x0F);

        }
        return ret;
    }

    public async Task<Tuple<AccountActionResult, Guid>> Login(string username, string digestHexString)
    {
        Account? acc = await _ctx.Account.Where(s=>s.Username==username).Select(s=>s).FirstAsync();
        if (acc is null)
            return new Tuple<AccountActionResult, Guid>(AccountActionResult.USERNAME_DNE, Guid.Empty);

        byte[]? digestBytes = SHA256DigestBytesFromHex(digestHexString);
        if (digestBytes is null)
            return new Tuple<AccountActionResult, Guid>(AccountActionResult.INVALID_DIGEST, Guid.Empty);

        if (!PassMatch(acc.ShaDigest, digestBytes))
            return new Tuple<AccountActionResult, Guid>(AccountActionResult.WRONG_PASSWORD, Guid.Empty);


        
        acc.IsOnline = true;
        await _ctx.SaveChangesAsync();
        return new Tuple<AccountActionResult, Guid>(AccountActionResult.OKAY, acc.Id);
    }

    public async Task<bool> Logout(Guid accId)
    {
        Account? acc = await _ctx.Account.FindAsync(accId);
        if (acc is null)
            return false;

        if (!acc.IsOnline)
            return false;

        acc.IsOnline = false;
        await _ctx.SaveChangesAsync();

        return true;
    }
}

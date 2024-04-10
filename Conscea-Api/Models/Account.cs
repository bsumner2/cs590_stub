using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conscea_Api.Models;

public class Account
{
    [Required, Key]
    public int Id { get; set; }

    [Required, StringLength(32)]
    public string Username { get; set; }

    /* Password stored as SHA-256 hash code. */
    /* Password. 32 chars long seems like a prudent limit. */
    [Required, Column(TypeName = "varbinary(32)")]
    public byte[] ShaDigest { get; set; }

    [Required]
    public bool IsOnline { get; set; }

    // ----------------------------------------
    // todo: add data annotations

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [Required]
    public string Email { get; set; }

    public string? Phone { get; set; }
    public string? Grade { get; set; }
    public string? Role { get; set; }
}

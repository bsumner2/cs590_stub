using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conscea_Api.Models;

public class Account {

    [Required, Key]
    /* GUID-based user key for sake of speed when looking for users. */
    public Guid Id { get; set; }
    /* Password. 32 chars long seems like a prudent limit. */
    [Required, StringLength(32)]
    public string Username { get; set; }

    /* Password stored as SHA-256 hash code. */
    [Required, Column(TypeName = "varbinary(32)")]
    public byte[] ShaDigest { get; set; }
    [Required]
    public bool IsOnline { get; set; }
}
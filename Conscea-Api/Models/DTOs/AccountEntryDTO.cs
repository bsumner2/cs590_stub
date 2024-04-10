namespace Conscea_Api.Models.DTOs;


public class AccountEntryDTO
{
    public string username { get; set; }
    public Guid Id { get; set; }

    // ----------------------------------------
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? email { get; set; }

}
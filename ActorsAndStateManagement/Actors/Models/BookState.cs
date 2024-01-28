namespace BookControlService.Models;

public record struct BookState
{
    public string LicenseNumber { get; init; }
    public DateTime EntryTimestamp { get; init; }
    public DateTime? ExitTimestamp { get; init; }

    public BookState(string licenseNumber, DateTime entryTimestamp, DateTime? exitTimestamp = null)
    {
        this.LicenseNumber = licenseNumber;
        this.EntryTimestamp = entryTimestamp;
        this.ExitTimestamp = exitTimestamp;
    }
}

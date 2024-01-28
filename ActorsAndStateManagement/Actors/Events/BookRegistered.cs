namespace BookControlService.Events;

public record struct BookRegistered(int Library, string LicenseNumber, DateTime Timestamp);
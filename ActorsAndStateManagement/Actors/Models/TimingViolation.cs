namespace BookControlService.Models;

public record struct TimingViolation(string BookId, string LibraryId, int ViolationInMinutes, DateTime Timestamp);
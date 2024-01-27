namespace BookControlService.DomainServices;

public interface ITimingViolationCalculator
{
    int DetermineTimingViolationInMinutes(DateTime entryTimestamp, DateTime exitTimestamp);
    string GetLibraryId();
}

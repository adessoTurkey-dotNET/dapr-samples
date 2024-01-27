namespace BookControlService.DomainServices;

public class DefaultTimingViolationCalculator : ITimingViolationCalculator
{
    private readonly string _libraryId;
    private readonly int _maxAllowedTimeInMinutes;
    private readonly int _legalCorrectionInMinutes;

    public DefaultTimingViolationCalculator(string libraryId, int sectionLengthInMinutes, int maxAllowedTimeInMinutes, int legalCorrectionInMinutes)
    {
        _libraryId = libraryId;
        _maxAllowedTimeInMinutes = maxAllowedTimeInMinutes;
        _legalCorrectionInMinutes = legalCorrectionInMinutes;
    }

    public int DetermineTimingViolationInMinutes(DateTime entryTimestamp, DateTime exitTimestamp)
    {
        double elapsedMinutes = exitTimestamp.Subtract(entryTimestamp).TotalMinutes;
        int violation = Convert.ToInt32(elapsedMinutes - _maxAllowedTimeInMinutes - _legalCorrectionInMinutes);
        return violation;
    }

    public string GetLibraryId()
    {
        return _libraryId;
    }
}

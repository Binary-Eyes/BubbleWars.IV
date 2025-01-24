namespace BinaryEyes.Common.Enums
{
    /// <summary>
    /// The TrackingConfidence enumeration provides values describing a simplified
    /// scheme of denoting the confidence we have in a tracked value.
    /// </summary>
    public enum TrackingConfidence
    {
        NoSupported = -1,
        Invalid = 0,
        LowConfidence = 1,
        HighConfidence = 2,
        Accurate = 3,
    }
}
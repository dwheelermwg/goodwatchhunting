using System;

namespace HealthKitData.Collections
{
  /// <summary>
  /// User HealthRecords
  /// </summary>
  public class HealthRecords
  {
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the health date time.
    /// </summary>
    public DateTime HealthDateTime { get; set; }

    /// <summary>
    /// Gets or sets the heart rate.
    /// </summary>
    public int HeartRate { get; set; }

    /// <summary>
    /// Gets or sets the body temperature.
    /// </summary>
    public decimal BodyTemperature { get; set; }

    /// <summary>
    /// Gets or sets the blood pressure.
    /// </summary>
    public int BloodPressure { get; set; }

    /// <summary>
    /// Gets or sets the respiratory rate.
    /// </summary>
    public int RespiratoryRate { get; set; }

    /// <summary>
    /// Gets or sets the step count.
    /// </summary>
    public int StepCount { get; set; }
  }
}
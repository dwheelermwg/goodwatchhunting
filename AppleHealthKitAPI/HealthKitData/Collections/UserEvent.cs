using System;

namespace HealthKitData.Collections
{
  /// <summary>
  /// User Events
  /// </summary>
  public class UserEvent
  {
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the health record.
    /// </summary>
    public HealthRecords HealthRecord { get; set; }

    /// <summary>
    /// Gets or sets the event identifier.
    /// </summary>
    public string EventId { get; set; }

    /// <summary>
    /// Gets or sets the start time.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time.
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Gets or sets the user unique identifier.
    /// </summary>
    public string UserGuid { get; set; }
  }
}

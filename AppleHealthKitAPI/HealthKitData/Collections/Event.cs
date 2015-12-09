namespace HealthKitData.Collections
{
  public class Event
  {
    /// <summary>
    /// Gets or sets the event identifier.
    /// </summary>
    public int EventId { get; set; }

    /// <summary>
    /// Gets or sets the name of the event.
    /// </summary>
    public string EventName { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the type of the event.
    /// </summary>
    public EventType EventType { get; set; }

    /// <summary>
    /// Gets or sets the goal.
    /// </summary>
    public string Goal { get; set; }
  }
}
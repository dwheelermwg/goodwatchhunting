using System;

namespace HealthKitData.Collections
{

  /// <summary>
  /// User
  /// </summary>
  public class User
  {
    /// <summary>
    /// The application unique identifier
    /// </summary>
    public string ApplicationGuid { get; set; }

    /// <summary>
    /// Gets or sets the user unique identifier.
    /// </summary>
    public string UserGuid { get; set; }

    /// <summary>
    /// The first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The last login
    /// </summary>
    public DateTime LastLogin { get; set; }

    /// <summary>
    /// The experience
    /// </summary>
    public int Experience { get; set; }

    /// <summary>
    /// The level
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets the inches.
    /// </summary>
    public int Inches { get; set; }

    /// <summary>
    /// Gets or sets the feet.
    /// </summary>
    public int Feet { get; set; }

    /// <summary>
    /// Gets or sets the step count.
    /// </summary>
    public int StepCount { get; set; }

    /// <summary>
    /// Gets the height.
    /// </summary>
    public string Height
    {
      get
      {
        return string.Format("{0}' {1}''", Feet, Inches); 
      }
    }
  }
}
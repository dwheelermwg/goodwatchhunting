﻿namespace HealthKitAPI.Infrastructure
{
  public static class RoutesTemplates
  {
    public static readonly string AllEvents = "events/collection";

    public static readonly string GetEventById = "events/{id}";

    public static readonly string GetEventByUserId = "users/{id}/events/{id}";
  }
}
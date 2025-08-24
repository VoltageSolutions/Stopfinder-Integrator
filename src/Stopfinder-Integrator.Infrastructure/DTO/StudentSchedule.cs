using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Infrastructure.DTO;

public record StudentSchedule(
    [property: JsonPropertyName("subscriptionOwner")] bool? SubscriptionOwner,
    [property: JsonPropertyName("riderId")] int? RiderId,
    [property: JsonPropertyName("externalId")] int? ExternalId,
    [property: JsonPropertyName("localId")] string? LocalId,
    [property: JsonPropertyName("firstName")] string? FirstName,
    [property: JsonPropertyName("lastName")] string? LastName,
    [property: JsonPropertyName("grade")] string? Grade,
    [property: JsonPropertyName("school")] string? School,
    [property: JsonPropertyName("xCoord")] double? XCoord,
    [property: JsonPropertyName("yCoord")] double? YCoord,
    [property: JsonPropertyName("schoolX")] double? SchoolX,
    [property: JsonPropertyName("schoolY")] double? SchoolY,
    [property: JsonPropertyName("transferSchoolX")] double? TransferSchoolX,
    [property: JsonPropertyName("transferSchoolY")] double? TransferSchoolY,
    [property: JsonPropertyName("clientId")] int? ClientId,
    [property: JsonPropertyName("feedbackEnabled")] bool? FeedbackEnabled,
    [property: JsonPropertyName("trips")] List<Trip>? Trips,
    [property: JsonPropertyName("displayTripAlias")] bool? DisplayTripAlias,
    [property: JsonPropertyName("displayVehicle")] bool? DisplayVehicle,
    [property: JsonPropertyName("enableGeoAlerts")] bool? EnableGeoAlerts,
    [property: JsonPropertyName("enableEtaAlerts")] bool? EnableEtaAlerts,
    [property: JsonPropertyName("displayTripPath")] bool? DisplayTripPath,
    [property: JsonPropertyName("displayOtherStop")] bool? DisplayOtherStop,
    [property: JsonPropertyName("displayVehicleOnMap")] bool? DisplayVehicleOnMap,
    [property: JsonPropertyName("beforeTrip")] int? BeforeTrip,
    [property: JsonPropertyName("afterTrip")] int? AfterTrip,
    [property: JsonPropertyName("dataSourceId")] int? DataSourceId,
    [property: JsonPropertyName("sequence")] int? Sequence,
    [property: JsonPropertyName("timeZoneMinutes")] double? TimeZoneMinutes,
    [property: JsonPropertyName("scannedHistoryEnabled")] bool? ScannedHistoryEnabled,
    [property: JsonPropertyName("attendanceEnabled")] bool? AttendanceEnabled,
    [property: JsonPropertyName("subscriptionId")] int? SubscriptionId,
    [property: JsonPropertyName("attendanceValue")] bool? AttendanceValue,
    [property: JsonPropertyName("vehicleSubstitutionValue")] bool? VehicleSubstitutionValue,
    [property: JsonPropertyName("vehicleSubstitutionEnabled")] bool? VehicleSubstitutionEnabled,
    [property: JsonPropertyName("mapSettings")] StopfinderIntegrator.Infrastructure.DTO.MapSettings? MapSettings
);

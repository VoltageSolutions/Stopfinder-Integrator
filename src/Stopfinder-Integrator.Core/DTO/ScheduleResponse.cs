using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Stopfinder_Integrator.Core.DTO
{

    public record ScheduleResponse(
        [property: JsonPropertyName("date")] DateTime Date,
        [property: JsonPropertyName("studentSchedules")] List<StudentSchedule> StudentSchedules
    );

    public record StudentSchedule(
        [property: JsonPropertyName("subscriptionOwner")] bool SubscriptionOwner,
        [property: JsonPropertyName("riderId")] int RiderId,
        [property: JsonPropertyName("externalId")] int ExternalId,
        [property: JsonPropertyName("localId")] string LocalId,
        [property: JsonPropertyName("firstName")] string FirstName,
        [property: JsonPropertyName("lastName")] string LastName,
        [property: JsonPropertyName("grade")] string Grade,
        [property: JsonPropertyName("school")] string School,
        [property: JsonPropertyName("xCoord")] double XCoord,
        [property: JsonPropertyName("yCoord")] double YCoord,
        [property: JsonPropertyName("schoolX")] double SchoolX,
        [property: JsonPropertyName("schoolY")] double SchoolY,
        [property: JsonPropertyName("transferSchoolX")] double? TransferSchoolX,
        [property: JsonPropertyName("transferSchoolY")] double? TransferSchoolY,
        [property: JsonPropertyName("clientId")] int ClientId,
        [property: JsonPropertyName("feedbackEnabled")] bool FeedbackEnabled,
        [property: JsonPropertyName("trips")] List<Trip> Trips,
        [property: JsonPropertyName("displayTripAlias")] bool DisplayTripAlias,
        [property: JsonPropertyName("displayVehicle")] bool DisplayVehicle,
        [property: JsonPropertyName("enableGeoAlerts")] bool EnableGeoAlerts,
        [property: JsonPropertyName("enableEtaAlerts")] bool EnableEtaAlerts,
        [property: JsonPropertyName("displayTripPath")] bool DisplayTripPath,
        [property: JsonPropertyName("displayOtherStop")] bool DisplayOtherStop,
        [property: JsonPropertyName("displayVehicleOnMap")] bool DisplayVehicleOnMap,
        [property: JsonPropertyName("beforeTrip")] int BeforeTrip,
        [property: JsonPropertyName("afterTrip")] int AfterTrip,
        [property: JsonPropertyName("dataSourceId")] int DataSourceId,
        [property: JsonPropertyName("sequence")] int Sequence,
        [property: JsonPropertyName("timeZoneMinutes")] double TimeZoneMinutes,
        [property: JsonPropertyName("scannedHistoryEnabled")] bool ScannedHistoryEnabled,
        [property: JsonPropertyName("attendanceEnabled")] bool AttendanceEnabled,
        [property: JsonPropertyName("subscriptionId")] int SubscriptionId,
        [property: JsonPropertyName("attendanceValue")] bool AttendanceValue,
        [property: JsonPropertyName("vehicleSubstitutionValue")] bool VehicleSubstitutionValue,
        [property: JsonPropertyName("vehicleSubstitutionEnabled")] bool VehicleSubstitutionEnabled,
        [property: JsonPropertyName("mapSettings")] MapSettings MapSettings
    );

    public record Trip(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("vehicleId")] int VehicleId,
        [property: JsonPropertyName("busNumber")] string BusNumber,
        [property: JsonPropertyName("pickUpStopName")] string PickUpStopName,
        [property: JsonPropertyName("pickUpStopXCoord")] double PickUpStopXCoord,
        [property: JsonPropertyName("pickUpStopId")] int PickUpStopId,
        [property: JsonPropertyName("pickUpStopYCoord")] double PickUpStopYCoord,
        [property: JsonPropertyName("pickUpTime")] DateTime PickUpTime,
        [property: JsonPropertyName("dropOffStopName")] string DropOffStopName,
        [property: JsonPropertyName("dropOffStopXCoord")] double DropOffStopXCoord,
        [property: JsonPropertyName("dropOffStopYCoord")] double DropOffStopYCoord,
        [property: JsonPropertyName("dropOffStopId")] int DropOffStopId,
        [property: JsonPropertyName("dropOffTime")] DateTime DropOffTime,
        [property: JsonPropertyName("toSchool")] bool ToSchool,
        [property: JsonPropertyName("isTransfer")] bool IsTransfer,
        [property: JsonPropertyName("isException")] bool IsException,
        [property: JsonPropertyName("tripAlias")] string TripAlias,
        [property: JsonPropertyName("adjustMinutes")] int AdjustMinutes,
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("startTime")] DateTime StartTime,
        [property: JsonPropertyName("finishTime")] DateTime FinishTime,
        [property: JsonPropertyName("sequence")] int? Sequence
    );

    public record MapSettings(
        [property: JsonPropertyName("extent")] Extent Extent,
        [property: JsonPropertyName("longitude")] double Longitude,
        [property: JsonPropertyName("latitude")] double Latitude
    );

    public record Extent(
        [property: JsonPropertyName("xmin")] double Xmin,
        [property: JsonPropertyName("ymin")] double Ymin,
        [property: JsonPropertyName("xmax")] double Xmax,
        [property: JsonPropertyName("ymax")] double Ymax,
        [property: JsonPropertyName("spatialReference")] SpatialReference SpatialReference
    );

    public record SpatialReference(
        [property: JsonPropertyName("wkid")] int Wkid
    );
}

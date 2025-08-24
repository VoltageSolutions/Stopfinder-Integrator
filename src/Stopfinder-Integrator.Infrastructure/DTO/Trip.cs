using System;
using System.Text.Json.Serialization;

namespace StopfinderIntegrator.Infrastructure.DTO;

public record Trip(
    [property: JsonPropertyName("name")] string? Name,
    [property: JsonPropertyName("vehicleId")] int? VehicleId,
    [property: JsonPropertyName("busNumber")] string? BusNumber,
    [property: JsonPropertyName("pickUpStopName")] string? PickUpStopName,
    [property: JsonPropertyName("pickUpStopXCoord")] double? PickUpStopXCoord,
    [property: JsonPropertyName("pickUpStopId")] int? PickUpStopId,
    [property: JsonPropertyName("pickUpStopYCoord")] double? PickUpStopYCoord,
    [property: JsonPropertyName("pickUpTime")] DateTime? PickUpTime,
    [property: JsonPropertyName("dropOffStopName")] string? DropOffStopName,
    [property: JsonPropertyName("dropOffStopXCoord")] double? DropOffStopXCoord,
    [property: JsonPropertyName("dropOffStopYCoord")] double? DropOffStopYCoord,
    [property: JsonPropertyName("dropOffStopId")] int? DropOffStopId,
    [property: JsonPropertyName("dropOffTime")] DateTime? DropOffTime,
    [property: JsonPropertyName("toSchool")] bool? ToSchool,
    [property: JsonPropertyName("isTransfer")] bool? IsTransfer,
    [property: JsonPropertyName("isException")] bool? IsException,
    [property: JsonPropertyName("tripAlias")] string? TripAlias,
    [property: JsonPropertyName("adjustMinutes")] int? AdjustMinutes,
    [property: JsonPropertyName("id")] int? Id,
    [property: JsonPropertyName("startTime")] DateTime? StartTime,
    [property: JsonPropertyName("finishTime")] DateTime? FinishTime,
    [property: JsonPropertyName("sequence")] int? Sequence
);

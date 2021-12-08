// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Rooms.Models
{
    /// <summary>
    /// The standard result from sendAsync request.
    /// </summary>
    public class RoomResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomResult"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdDateTime"></param>
        /// <param name="validFrom"></param>
        /// <param name="validUntil"></param>
        /// <param name="participants"></param>
        /// <param name="invalidParticipants"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="successful"></param>
        /// <param name="errorMessage"></param>
        public RoomResult(string id, DateTimeOffset createdDateTime, DateTimeOffset validFrom, DateTimeOffset validUntil,
             IReadOnlyDictionary<string, object> participants, IReadOnlyDictionary<string, object> invalidParticipants,
             int httpStatusCode, bool successful, string errorMessage)
        {
            Id = id;
            CreatedDateTime = createdDateTime;
            ValidFrom = validFrom;
            ValidUntil = validUntil;
            Participants = participants;
            InvalidParticipants = invalidParticipants;
            HttpStatusCode = httpStatusCode;
            Successful = successful;
            ErrorMessage = errorMessage;
        }

        internal RoomResult(CreateRoomResponse createRoomResponse, int httpStatusCode, bool successful, string errorMessage)
        {
            Id = createRoomResponse.Room.Id;
            CreatedDateTime = createRoomResponse.Room.CreatedDateTime;
            ValidFrom = createRoomResponse.Room.ValidFrom;
            ValidUntil = createRoomResponse.Room.ValidUntil;
            Participants = createRoomResponse.Room.Participants;
            InvalidParticipants = createRoomResponse.InvalidParticipants;
            HttpStatusCode = httpStatusCode;
            Successful = successful;
            ErrorMessage = errorMessage;
        }

        internal RoomResult(UpdateRoomResponse updateRoomResponse, int httpStatusCode, bool successful, string errorMessage)
        {
            Id = updateRoomResponse.Room.Id;
            CreatedDateTime = updateRoomResponse.Room.CreatedDateTime;
            ValidFrom = updateRoomResponse.Room.ValidFrom;
            ValidUntil = updateRoomResponse.Room.ValidUntil;
            Participants = updateRoomResponse.Room.Participants;
            InvalidParticipants = updateRoomResponse.InvalidParticipants;
            HttpStatusCode = httpStatusCode;
            Successful = successful;
            ErrorMessage = errorMessage;
        }

        internal RoomResult(RoomModel roomModel, int httpStatusCode, bool successful, string errorMessage)
        {
            Id = roomModel.Id;
            CreatedDateTime = roomModel.CreatedDateTime;
            ValidFrom = roomModel.ValidFrom;
            ValidUntil = roomModel.ValidUntil;
            Participants = roomModel.Participants;
            InvalidParticipants = null;
            HttpStatusCode = httpStatusCode;
            Successful = successful;
            ErrorMessage = errorMessage;
        }

        /// <summary> Unique identifier of a room. This id is server generated. </summary>
        public string Id { get; }
        /// <summary> The timestamp when the room was created at the server. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? CreatedDateTime { get; }
        /// <summary> The timestamp from when the room is open for joining. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ValidFrom { get; }
        /// <summary> The timestamp from when the room can no longer be joined. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ValidUntil { get; }
        /// <summary> Collection of identities invited to the room. </summary>
        public IReadOnlyDictionary<string, object> Participants { get; }
        /// <summary> Collection of invalid identities invited to the room. </summary>
        public IReadOnlyDictionary<string, object> InvalidParticipants { get; }
        /// <summary> HTTP Status code. </summary>
        public int HttpStatusCode { get; }
        /// <summary> Indicates if the message is processed successfully or not. </summary>
        public bool Successful { get; }
        /// <summary> Optional error message in case of 4xx/5xx/repeatable errors. </summary>
         public string ErrorMessage { get; }
    }
}

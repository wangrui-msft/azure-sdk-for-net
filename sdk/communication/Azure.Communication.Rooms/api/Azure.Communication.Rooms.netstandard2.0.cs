namespace Azure.Communication.Rooms
{
    public partial class RoomsClient
    {
        protected RoomsClient() { }
        public RoomsClient(string connectionString) { }
        public RoomsClient(string connectionString, Azure.Communication.Rooms.RoomsClientOptions options) { }
        public RoomsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public RoomsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Rooms.RoomsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.RoomResult> CreateRoom(Azure.Communication.Rooms.Models.CreateRoomRequest createRoomRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.RoomResult>> CreateRoomAsync(Azure.Communication.Rooms.Models.CreateRoomRequest createRoomRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.RoomResult> GetRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.RoomResult>> GetRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Rooms.Models.RoomResult> UpdateRoom(string roomId, Azure.Communication.Rooms.Models.UpdateRoomRequest updateRoomRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Rooms.Models.RoomResult>> UpdateRoomAsync(string roomId, Azure.Communication.Rooms.Models.UpdateRoomRequest updateRoomRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoomsClientOptions : Azure.Core.ClientOptions
    {
        public RoomsClientOptions(Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion version = Azure.Communication.Rooms.RoomsClientOptions.ServiceVersion.V2021_04_07) { }
        public enum ServiceVersion
        {
            V2021_04_07 = 1,
        }
    }
}
namespace Azure.Communication.Rooms.Models
{
    public static partial class AzureCommunicationRoomServiceModelFactory
    {
        public static Azure.Communication.Rooms.Models.CreateRoomResponse CreateRoomResponse(Azure.Communication.Rooms.Models.RoomModel room = null, System.Collections.Generic.IReadOnlyDictionary<string, object> invalidParticipants = null) { throw null; }
        public static Azure.Communication.Rooms.Models.RoomModel RoomModel(string id = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, object> participants = null) { throw null; }
        public static Azure.Communication.Rooms.Models.UpdateRoomResponse UpdateRoomResponse(Azure.Communication.Rooms.Models.RoomModel room = null, System.Collections.Generic.IReadOnlyDictionary<string, object> invalidParticipants = null) { throw null; }
    }
    public partial class CreateRoomRequest
    {
        public CreateRoomRequest() { }
        public System.Collections.Generic.IDictionary<string, object> Participants { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } set { } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } set { } }
    }
    public partial class CreateRoomResponse
    {
        internal CreateRoomResponse() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> InvalidParticipants { get { throw null; } }
        public Azure.Communication.Rooms.Models.RoomModel Room { get { throw null; } }
    }
    public partial class RoomModel
    {
        internal RoomModel() { }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Participants { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } }
    }
    public partial class RoomResult
    {
        public RoomResult(string id, System.DateTimeOffset createdDateTime, System.DateTimeOffset validFrom, System.DateTimeOffset validUntil, System.Collections.Generic.IReadOnlyDictionary<string, object> participants, System.Collections.Generic.IReadOnlyDictionary<string, object> invalidParticipants, int httpStatusCode, bool successful, string errorMessage) { }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int HttpStatusCode { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> InvalidParticipants { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Participants { get { throw null; } }
        public bool Successful { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } }
    }
    public partial class UpdateRoomRequest
    {
        public UpdateRoomRequest() { }
        public System.Collections.Generic.IDictionary<string, object> Participants { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } set { } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } set { } }
    }
    public partial class UpdateRoomResponse
    {
        internal UpdateRoomResponse() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> InvalidParticipants { get { throw null; } }
        public Azure.Communication.Rooms.Models.RoomModel Room { get { throw null; } }
    }
}

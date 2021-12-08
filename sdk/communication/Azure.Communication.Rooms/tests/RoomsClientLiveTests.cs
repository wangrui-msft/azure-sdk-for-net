// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using System;
//@@ using Azure.Communication.Rooms
#endregion Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using System.Threading.Tasks;
using Azure.Communication.Rooms.Models;
using NUnit.Framework;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientLiveTests : RoomsClientLiveTestBase
    {
        public RoomsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AcsRoomRequestLiveTest()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();
            try
            {
                CreateRoomRequest createRoomRequest = new CreateRoomRequest();
                Response<RoomResult> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomRequest);
                RoomResult createRoomResult = createRoomResponse.Value;
                Assert.True(createRoomResult.Successful);
                Assert.AreEqual(201, createRoomResult.HttpStatusCode);
                Assert.IsFalse(string.IsNullOrWhiteSpace(createRoomResult.Id));

                var createdRoomId = createRoomResult.Id;

                UpdateRoomRequest updateRoomRequest = new UpdateRoomRequest()
                {
                    ValidFrom = new DateTimeOffset(2021, 8, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)),
                    ValidUntil = new DateTimeOffset(2021, 8, 2, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)),
                };

                Response<RoomResult> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, updateRoomRequest);
                RoomResult updateRoomResult = updateRoomResponse.Value;
                Assert.True(updateRoomResult.Successful);
                Assert.AreEqual(200, updateRoomResult.HttpStatusCode);
                Assert.IsFalse(string.IsNullOrWhiteSpace(updateRoomResult.Id));

                Response<RoomResult> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
                RoomResult getRoomResult = getRoomResponse.Value;
                Assert.True(getRoomResult.Successful);
                Assert.AreEqual(200, getRoomResult.HttpStatusCode);
                Assert.IsFalse(string.IsNullOrWhiteSpace(getRoomResult.Id));

                Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
                Assert.AreEqual(204, deleteRoomResponse.Status);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}

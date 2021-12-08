// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Rooms.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Rooms.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    ///
    public partial class Sample1_RoomsClient : RoomsClientLiveTestBase
    {
        public Sample1_RoomsClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AcsRoomRequestSample()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
            CreateRoomRequest createRoomRequest = new CreateRoomRequest();
            Response<RoomResult> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomRequest);
            RoomResult createRoomResult = createRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync

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

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
            Response<RoomResult> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, updateRoomRequest);
            RoomResult updateRoomResult = updateRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync

            Assert.True(updateRoomResult.Successful);
            Assert.AreEqual(200, updateRoomResult.HttpStatusCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(updateRoomResult.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
            Response<RoomResult> getRoomResponse = await roomsClient.GetRoomAsync(
                //@@ createdRoomId: "existing room Id which is created already
                /*@@*/ createdRoomId);
            RoomResult getRoomResult = getRoomResponse.Value;
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync

            Assert.True(getRoomResult.Successful);
            Assert.AreEqual(200, getRoomResult.HttpStatusCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(getRoomResult.Id));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
            Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(
                //@@ createdRoomId: "existing room Id which is created already
                /*@@*/ createdRoomId);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync

            Assert.AreEqual(204, deleteRoomResponse.Status);
        }

        [Test]
        public async Task RoomRequestsTroubleShooting()
        {
            RoomsClient roomsClient = CreateInstrumentedRoomsClient();
            #region Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
            try
            {
                CreateRoomRequest createRoomRequest = new CreateRoomRequest();
                Response<RoomResult> createRoomResponse = await roomsClient.CreateRoomAsync(createRoomRequest);
                RoomResult createRoomResult = createRoomResponse.Value;

                if (createRoomResult.Successful)
                {
                    Console.WriteLine($"Successfully create this room: {createRoomResult.Id}.");
                }
                else
                {
                    Console.WriteLine($"Status code {createRoomResult.HttpStatusCode} and error message {createRoomResult.ErrorMessage}.");
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
        }
    }
}

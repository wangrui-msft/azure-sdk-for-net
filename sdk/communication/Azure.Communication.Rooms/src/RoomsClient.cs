﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Communication.Rooms.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Rooms
{
    /// <summary>
    /// The Azure Communication Services Rooms client.
    /// </summary>
    public class RoomsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        internal RoomsRestClient RoomsServiceClient { get; }

        #region public constructors - all arguments need null check

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="connectionString"></param>
        public RoomsClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new RoomsClientOptions())
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="options"></param>
        public RoomsClient(string connectionString, RoomsClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new RoomsClientOptions())
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="keyCredential"></param>
        /// <param name="options"></param>
        public RoomsClient(Uri endpoint, AzureKeyCredential keyCredential, RoomsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new RoomsClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="tokenCredential"></param>
        /// <param name="options"></param>
        public RoomsClient(Uri endpoint, TokenCredential tokenCredential, RoomsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new RoomsClientOptions())
        { }

        #endregion

        #region private constructors

        private RoomsClient(ConnectionString connectionString, RoomsClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private RoomsClient(string endpoint, TokenCredential tokenCredential, RoomsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private RoomsClient(string endpoint, AzureKeyCredential keyCredential, RoomsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private RoomsClient(string endpoint, HttpPipeline httpPipeline, RoomsClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RoomsServiceClient = new RoomsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsClient"/> class.
        /// </summary>
        protected RoomsClient()
        {
            _clientDiagnostics = null!;
            RoomsServiceClient = null!;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="createRoomRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<RoomResult>> CreateRoomAsync(CreateRoomRequest createRoomRequest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Response<CreateRoomResponse> createRoomResponse =
                    await RoomsServiceClient.CreateRoomAsync(createRoomRequest, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new RoomResult(createRoomResponse, 201, true, null), createRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="createRoomRequest"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<RoomResult> CreateRoom(CreateRoomRequest createRoomRequest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(CreateRoom)}");
            scope.Start();
            try
            {
                Response<CreateRoomResponse> createRoomResponse =
                     RoomsServiceClient.CreateRoom(createRoomRequest, cancellationToken);
                return Response.FromValue(new RoomResult(createRoomResponse, 201, true, null), createRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="updateRoomRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<RoomResult>> UpdateRoomAsync(string roomId, UpdateRoomRequest updateRoomRequest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                Response<UpdateRoomResponse> updateRoomResponse =
                    await RoomsServiceClient.UpdateRoomAsync(roomId, updateRoomRequest, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new RoomResult(updateRoomResponse, 200, true, null), updateRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="updateRoomRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response<RoomResult> UpdateRoom(string roomId, UpdateRoomRequest updateRoomRequest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(UpdateRoom)}");
            scope.Start();
            try
            {
                Response<UpdateRoomResponse> updateRoomResponse =
                    RoomsServiceClient.UpdateRoom(roomId, updateRoomRequest, cancellationToken);
                return Response.FromValue(new RoomResult(updateRoomResponse, 200, true, null), updateRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response<RoomResult>> GetRoomAsync(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRoom)}");
            scope.Start();
            try
            {
                Response<RoomModel> getRoomResponse =
                    await RoomsServiceClient.GetRoomAsync(roomId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new RoomResult(getRoomResponse, 200, true, null), getRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response<RoomResult> GetRoom(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(GetRoom)}");
            scope.Start();
            try
            {
                Response<RoomModel> getRoomResponse =
                    RoomsServiceClient.GetRoom(roomId, cancellationToken);
                return Response.FromValue(new RoomResult(getRoomResponse, 200, true, null), getRoomResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{Response}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<Response> DeleteRoomAsync(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(DeleteRoom)}");
            scope.Start();
            try
            {
                return await RoomsServiceClient.DeleteRoomAsync(roomId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roomId"/> is null. </exception>
        public virtual Response DeleteRoom(string roomId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RoomsClient)}.{nameof(DeleteRoom)}");
            scope.Start();
            try
            {
                return RoomsServiceClient.DeleteRoom(roomId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}

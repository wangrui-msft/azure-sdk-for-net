# Azure Communication Rooms client library for .NET

This package contains a C# SDK for the Rooms Service of Azure Communication Services.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication Rooms client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.Rooms --version 1.0.0-beta.1
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`RoomsClient` provides the functionality to create, update, get, delete rooms.

### Using statements
```C# Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using System;
using Azure.Communication.Rooms
```

### Authenticate the client
Rooms clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
RoomsClient client = new RoomsClient(connectionString);
```

Alternatively, Rooms clients can also be authenticated using a valid token credential. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication. 

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
RoomsClient client = new RoomsClient(new Uri(endpoint), tokenCredential);
```

## Examples

The following sections provide several code snippets covering some of the most common tasks, which is available at Sample1_RoomsRequesets.md

## Troubleshooting
### Service Responses
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.
```C# Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
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
```

## Next steps
- [Read more about Rooms in Azure Communication Services][nextsteps]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/

<!-- TODO -->
Update the sample code links once the sdk is published

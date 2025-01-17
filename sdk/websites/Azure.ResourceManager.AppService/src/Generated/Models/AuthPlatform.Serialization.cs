// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class AuthPlatform : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IsEnabled))
            {
                writer.WritePropertyName("enabled");
                writer.WriteBooleanValue(IsEnabled.Value);
            }
            if (Optional.IsDefined(RuntimeVersion))
            {
                writer.WritePropertyName("runtimeVersion");
                writer.WriteStringValue(RuntimeVersion);
            }
            if (Optional.IsDefined(ConfigFilePath))
            {
                writer.WritePropertyName("configFilePath");
                writer.WriteStringValue(ConfigFilePath);
            }
            writer.WriteEndObject();
        }

        internal static AuthPlatform DeserializeAuthPlatform(JsonElement element)
        {
            Optional<bool> enabled = default;
            Optional<string> runtimeVersion = default;
            Optional<string> configFilePath = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("runtimeVersion"))
                {
                    runtimeVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("configFilePath"))
                {
                    configFilePath = property.Value.GetString();
                    continue;
                }
            }
            return new AuthPlatform(Optional.ToNullable(enabled), runtimeVersion.Value, configFilePath.Value);
        }
    }
}

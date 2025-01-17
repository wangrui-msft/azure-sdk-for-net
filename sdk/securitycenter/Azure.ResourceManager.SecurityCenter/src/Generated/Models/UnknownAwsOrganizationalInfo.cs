// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> The UnknownAwsOrganizationalInfo. </summary>
    internal partial class UnknownAwsOrganizationalInfo : AwsOrganizationalInfo
    {
        /// <summary> Initializes a new instance of UnknownAwsOrganizationalInfo. </summary>
        /// <param name="organizationMembershipType"> The multi cloud account&apos;s membership type in the organization. </param>
        internal UnknownAwsOrganizationalInfo(OrganizationMembershipType organizationMembershipType) : base(organizationMembershipType)
        {
            OrganizationMembershipType = organizationMembershipType;
        }
    }
}

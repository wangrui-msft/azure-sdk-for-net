// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> This activity executes inner activities until the specified boolean expression results to true or timeout is reached, whichever is earlier. </summary>
    public partial class UntilActivity : ControlActivity
    {
        /// <summary> Initializes a new instance of UntilActivity. </summary>
        /// <param name="name"> Activity name. </param>
        /// <param name="expression"> An expression that would evaluate to Boolean. The loop will continue until this expression evaluates to true. </param>
        /// <param name="activities"> List of activities to execute. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="expression"/> or <paramref name="activities"/> is null. </exception>
        public UntilActivity(string name, Expression expression, IEnumerable<Activity> activities) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(expression, nameof(expression));
            Argument.AssertNotNull(activities, nameof(activities));

            Expression = expression;
            Activities = activities.ToList();
            Type = "Until";
        }

        /// <summary> Initializes a new instance of UntilActivity. </summary>
        /// <param name="name"> Activity name. </param>
        /// <param name="type"> Type of activity. </param>
        /// <param name="description"> Activity description. </param>
        /// <param name="dependsOn"> Activity depends on condition. </param>
        /// <param name="userProperties"> Activity user properties. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="expression"> An expression that would evaluate to Boolean. The loop will continue until this expression evaluates to true. </param>
        /// <param name="timeout"> Specifies the timeout for the activity to run. If there is no value specified, it takes the value of TimeSpan.FromDays(7) which is 1 week as default. Type: string (or Expression with resultType string), pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])). Type: string (or Expression with resultType string), pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])). </param>
        /// <param name="activities"> List of activities to execute. </param>
        internal UntilActivity(string name, string type, string description, IList<ActivityDependency> dependsOn, IList<UserProperty> userProperties, IDictionary<string, object> additionalProperties, Expression expression, object timeout, IList<Activity> activities) : base(name, type, description, dependsOn, userProperties, additionalProperties)
        {
            Expression = expression;
            Timeout = timeout;
            Activities = activities;
            Type = type ?? "Until";
        }

        /// <summary> An expression that would evaluate to Boolean. The loop will continue until this expression evaluates to true. </summary>
        public Expression Expression { get; set; }
        /// <summary> Specifies the timeout for the activity to run. If there is no value specified, it takes the value of TimeSpan.FromDays(7) which is 1 week as default. Type: string (or Expression with resultType string), pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])). Type: string (or Expression with resultType string), pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])). </summary>
        public object Timeout { get; set; }
        /// <summary> List of activities to execute. </summary>
        public IList<Activity> Activities { get; }
    }
}

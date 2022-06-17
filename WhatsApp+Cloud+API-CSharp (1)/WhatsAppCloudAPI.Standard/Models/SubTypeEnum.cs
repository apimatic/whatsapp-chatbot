// <copyright file="SubTypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace WhatsAppCloudAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using WhatsAppCloudAPI.Standard;
    using WhatsAppCloudAPI.Standard.Utilities;

    /// <summary>
    /// SubTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubTypeEnum
    {
        /// <summary>
        ///Refers to a previously created quick reply button that allows for the customer to return a predefined message.
        /// QuickReply.
        /// </summary>
        [EnumMember(Value = "quick_reply")]
        QuickReply,

        /// <summary>
        ///Refers to a previously created button that allows the customer to visit the URL generated by appending the text parameter to the predefined prefix URL in the template.
        /// Url.
        /// </summary>
        [EnumMember(Value = "url")]
        Url
    }
}
// <copyright file="OpenAIFile.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace OpenAIAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using OpenAIAPI.Standard;
    using OpenAIAPI.Standard.Utilities;

    /// <summary>
    /// OpenAIFile.
    /// </summary>
    public class OpenAIFile
    {
        private object statusDetails;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "status_details", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIFile"/> class.
        /// </summary>
        public OpenAIFile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIFile"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="mObject">object.</param>
        /// <param name="bytes">bytes.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="filename">filename.</param>
        /// <param name="purpose">purpose.</param>
        /// <param name="status">status.</param>
        /// <param name="statusDetails">status_details.</param>
        public OpenAIFile(
            string id = null,
            string mObject = null,
            int? bytes = null,
            int? createdAt = null,
            string filename = null,
            string purpose = null,
            string status = null,
            object statusDetails = null)
        {
            this.Id = id;
            this.MObject = mObject;
            this.Bytes = bytes;
            this.CreatedAt = createdAt;
            this.Filename = filename;
            this.Purpose = purpose;
            this.Status = status;
            if (statusDetails != null)
            {
                this.StatusDetails = statusDetails;
            }

        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets MObject.
        /// </summary>
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public string MObject { get; set; }

        /// <summary>
        /// Gets or sets Bytes.
        /// </summary>
        [JsonProperty("bytes", NullValueHandling = NullValueHandling.Ignore)]
        public int? Bytes { get; set; }

        /// <summary>
        /// Gets or sets CreatedAt.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets Filename.
        /// </summary>
        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets Purpose.
        /// </summary>
        [JsonProperty("purpose", NullValueHandling = NullValueHandling.Ignore)]
        public string Purpose { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets StatusDetails.
        /// </summary>
        [JsonProperty("status_details")]
        public object StatusDetails
        {
            get
            {
                return this.statusDetails;
            }

            set
            {
                this.shouldSerialize["status_details"] = true;
                this.statusDetails = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OpenAIFile : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStatusDetails()
        {
            this.shouldSerialize["status_details"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatusDetails()
        {
            return this.shouldSerialize["status_details"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is OpenAIFile other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Bytes == null && other.Bytes == null) || (this.Bytes?.Equals(other.Bytes) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Filename == null && other.Filename == null) || (this.Filename?.Equals(other.Filename) == true)) &&
                ((this.Purpose == null && other.Purpose == null) || (this.Purpose?.Equals(other.Purpose) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.StatusDetails == null && other.StatusDetails == null) || (this.StatusDetails?.Equals(other.StatusDetails) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.Bytes = {(this.Bytes == null ? "null" : this.Bytes.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}");
            toStringOutput.Add($"this.Filename = {(this.Filename == null ? "null" : this.Filename == string.Empty ? "" : this.Filename)}");
            toStringOutput.Add($"this.Purpose = {(this.Purpose == null ? "null" : this.Purpose == string.Empty ? "" : this.Purpose)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"StatusDetails = {(this.StatusDetails == null ? "null" : this.StatusDetails.ToString())}");
        }
    }
}
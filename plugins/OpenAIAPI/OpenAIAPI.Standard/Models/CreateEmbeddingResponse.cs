// <copyright file="CreateEmbeddingResponse.cs" company="APIMatic">
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
    /// CreateEmbeddingResponse.
    /// </summary>
    public class CreateEmbeddingResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmbeddingResponse"/> class.
        /// </summary>
        public CreateEmbeddingResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmbeddingResponse"/> class.
        /// </summary>
        /// <param name="mObject">object.</param>
        /// <param name="model">model.</param>
        /// <param name="data">data.</param>
        public CreateEmbeddingResponse(
            string mObject = null,
            string model = null,
            List<Models.Datum1> data = null)
        {
            this.MObject = mObject;
            this.Model = model;
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets MObject.
        /// </summary>
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public string MObject { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Datum1> Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateEmbeddingResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateEmbeddingResponse other &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");
        }
    }
}
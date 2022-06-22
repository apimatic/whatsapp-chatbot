// <copyright file="CreateCompletionResponse.cs" company="APIMatic">
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
    /// CreateCompletionResponse.
    /// </summary>
    public class CreateCompletionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompletionResponse"/> class.
        /// </summary>
        public CreateCompletionResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompletionResponse"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="mObject">object.</param>
        /// <param name="created">created.</param>
        /// <param name="model">model.</param>
        /// <param name="choices">choices.</param>
        public CreateCompletionResponse(
            string id = null,
            string mObject = null,
            int? created = null,
            string model = null,
            List<Models.Choice> choices = null)
        {
            this.Id = id;
            this.MObject = mObject;
            this.Created = created;
            this.Model = model;
            this.Choices = choices;
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
        /// Gets or sets Created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public int? Created { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets Choices.
        /// </summary>
        [JsonProperty("choices", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Choice> Choices { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCompletionResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateCompletionResponse other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Created == null && other.Created == null) || (this.Created?.Equals(other.Created) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Choices == null && other.Choices == null) || (this.Choices?.Equals(other.Choices) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.Created = {(this.Created == null ? "null" : this.Created.ToString())}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.Choices = {(this.Choices == null ? "null" : $"[{string.Join(", ", this.Choices)} ]")}");
        }
    }
}
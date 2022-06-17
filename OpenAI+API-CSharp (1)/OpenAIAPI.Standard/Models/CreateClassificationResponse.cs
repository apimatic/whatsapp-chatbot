// <copyright file="CreateClassificationResponse.cs" company="APIMatic">
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
    /// CreateClassificationResponse.
    /// </summary>
    public class CreateClassificationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClassificationResponse"/> class.
        /// </summary>
        public CreateClassificationResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClassificationResponse"/> class.
        /// </summary>
        /// <param name="mObject">object.</param>
        /// <param name="model">model.</param>
        /// <param name="searchModel">search_model.</param>
        /// <param name="completion">completion.</param>
        /// <param name="label">label.</param>
        /// <param name="selectedExamples">selected_examples.</param>
        public CreateClassificationResponse(
            string mObject = null,
            string model = null,
            string searchModel = null,
            string completion = null,
            string label = null,
            List<Models.SelectedExample> selectedExamples = null)
        {
            this.MObject = mObject;
            this.Model = model;
            this.SearchModel = searchModel;
            this.Completion = completion;
            this.Label = label;
            this.SelectedExamples = selectedExamples;
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
        /// Gets or sets SearchModel.
        /// </summary>
        [JsonProperty("search_model", NullValueHandling = NullValueHandling.Ignore)]
        public string SearchModel { get; set; }

        /// <summary>
        /// Gets or sets Completion.
        /// </summary>
        [JsonProperty("completion", NullValueHandling = NullValueHandling.Ignore)]
        public string Completion { get; set; }

        /// <summary>
        /// Gets or sets Label.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets SelectedExamples.
        /// </summary>
        [JsonProperty("selected_examples", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.SelectedExample> SelectedExamples { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateClassificationResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateClassificationResponse other &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.SearchModel == null && other.SearchModel == null) || (this.SearchModel?.Equals(other.SearchModel) == true)) &&
                ((this.Completion == null && other.Completion == null) || (this.Completion?.Equals(other.Completion) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true)) &&
                ((this.SelectedExamples == null && other.SelectedExamples == null) || (this.SelectedExamples?.Equals(other.SelectedExamples) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.SearchModel = {(this.SearchModel == null ? "null" : this.SearchModel == string.Empty ? "" : this.SearchModel)}");
            toStringOutput.Add($"this.Completion = {(this.Completion == null ? "null" : this.Completion == string.Empty ? "" : this.Completion)}");
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label == string.Empty ? "" : this.Label)}");
            toStringOutput.Add($"this.SelectedExamples = {(this.SelectedExamples == null ? "null" : $"[{string.Join(", ", this.SelectedExamples)} ]")}");
        }
    }
}
// <copyright file="CreateAnswerResponse.cs" company="APIMatic">
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
    /// CreateAnswerResponse.
    /// </summary>
    public class CreateAnswerResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAnswerResponse"/> class.
        /// </summary>
        public CreateAnswerResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAnswerResponse"/> class.
        /// </summary>
        /// <param name="mObject">object.</param>
        /// <param name="model">model.</param>
        /// <param name="searchModel">search_model.</param>
        /// <param name="completion">completion.</param>
        /// <param name="answers">answers.</param>
        /// <param name="selectedDocuments">selected_documents.</param>
        public CreateAnswerResponse(
            string mObject = null,
            string model = null,
            string searchModel = null,
            string completion = null,
            List<string> answers = null,
            List<Models.SelectedDocument> selectedDocuments = null)
        {
            this.MObject = mObject;
            this.Model = model;
            this.SearchModel = searchModel;
            this.Completion = completion;
            this.Answers = answers;
            this.SelectedDocuments = selectedDocuments;
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
        /// Gets or sets Answers.
        /// </summary>
        [JsonProperty("answers", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Answers { get; set; }

        /// <summary>
        /// Gets or sets SelectedDocuments.
        /// </summary>
        [JsonProperty("selected_documents", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.SelectedDocument> SelectedDocuments { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateAnswerResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateAnswerResponse other &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.SearchModel == null && other.SearchModel == null) || (this.SearchModel?.Equals(other.SearchModel) == true)) &&
                ((this.Completion == null && other.Completion == null) || (this.Completion?.Equals(other.Completion) == true)) &&
                ((this.Answers == null && other.Answers == null) || (this.Answers?.Equals(other.Answers) == true)) &&
                ((this.SelectedDocuments == null && other.SelectedDocuments == null) || (this.SelectedDocuments?.Equals(other.SelectedDocuments) == true));
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
            toStringOutput.Add($"this.Answers = {(this.Answers == null ? "null" : $"[{string.Join(", ", this.Answers)} ]")}");
            toStringOutput.Add($"this.SelectedDocuments = {(this.SelectedDocuments == null ? "null" : $"[{string.Join(", ", this.SelectedDocuments)} ]")}");
        }
    }
}
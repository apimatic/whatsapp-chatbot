// <copyright file="FineTune.cs" company="APIMatic">
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
    /// FineTune.
    /// </summary>
    public class FineTune
    {
        private string fineTunedModel;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "fine_tuned_model", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="FineTune"/> class.
        /// </summary>
        public FineTune()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FineTune"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="mObject">object.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="model">model.</param>
        /// <param name="fineTunedModel">fine_tuned_model.</param>
        /// <param name="organizationId">organization_id.</param>
        /// <param name="status">status.</param>
        /// <param name="hyperparams">hyperparams.</param>
        /// <param name="trainingFiles">training_files.</param>
        /// <param name="validationFiles">validation_files.</param>
        /// <param name="resultFiles">result_files.</param>
        /// <param name="events">events.</param>
        public FineTune(
            string id = null,
            string mObject = null,
            int? createdAt = null,
            int? updatedAt = null,
            string model = null,
            string fineTunedModel = null,
            string organizationId = null,
            string status = null,
            object hyperparams = null,
            List<Models.OpenAIFile> trainingFiles = null,
            List<Models.OpenAIFile> validationFiles = null,
            List<Models.OpenAIFile> resultFiles = null,
            List<Models.FineTuneEvent> events = null)
        {
            this.Id = id;
            this.MObject = mObject;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Model = model;
            if (fineTunedModel != null)
            {
                this.FineTunedModel = fineTunedModel;
            }

            this.OrganizationId = organizationId;
            this.Status = status;
            this.Hyperparams = hyperparams;
            this.TrainingFiles = trainingFiles;
            this.ValidationFiles = validationFiles;
            this.ResultFiles = resultFiles;
            this.Events = events;
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
        /// Gets or sets CreatedAt.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets UpdatedAt.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets FineTunedModel.
        /// </summary>
        [JsonProperty("fine_tuned_model")]
        public string FineTunedModel
        {
            get
            {
                return this.fineTunedModel;
            }

            set
            {
                this.shouldSerialize["fine_tuned_model"] = true;
                this.fineTunedModel = value;
            }
        }

        /// <summary>
        /// Gets or sets OrganizationId.
        /// </summary>
        [JsonProperty("organization_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Hyperparams.
        /// </summary>
        [JsonProperty("hyperparams", NullValueHandling = NullValueHandling.Ignore)]
        public object Hyperparams { get; set; }

        /// <summary>
        /// Gets or sets TrainingFiles.
        /// </summary>
        [JsonProperty("training_files", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.OpenAIFile> TrainingFiles { get; set; }

        /// <summary>
        /// Gets or sets ValidationFiles.
        /// </summary>
        [JsonProperty("validation_files", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.OpenAIFile> ValidationFiles { get; set; }

        /// <summary>
        /// Gets or sets ResultFiles.
        /// </summary>
        [JsonProperty("result_files", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.OpenAIFile> ResultFiles { get; set; }

        /// <summary>
        /// Gets or sets Events.
        /// </summary>
        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.FineTuneEvent> Events { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FineTune : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFineTunedModel()
        {
            this.shouldSerialize["fine_tuned_model"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFineTunedModel()
        {
            return this.shouldSerialize["fine_tuned_model"];
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

            return obj is FineTune other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.FineTunedModel == null && other.FineTunedModel == null) || (this.FineTunedModel?.Equals(other.FineTunedModel) == true)) &&
                ((this.OrganizationId == null && other.OrganizationId == null) || (this.OrganizationId?.Equals(other.OrganizationId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Hyperparams == null && other.Hyperparams == null) || (this.Hyperparams?.Equals(other.Hyperparams) == true)) &&
                ((this.TrainingFiles == null && other.TrainingFiles == null) || (this.TrainingFiles?.Equals(other.TrainingFiles) == true)) &&
                ((this.ValidationFiles == null && other.ValidationFiles == null) || (this.ValidationFiles?.Equals(other.ValidationFiles) == true)) &&
                ((this.ResultFiles == null && other.ResultFiles == null) || (this.ResultFiles?.Equals(other.ResultFiles) == true)) &&
                ((this.Events == null && other.Events == null) || (this.Events?.Equals(other.Events) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt.ToString())}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.FineTunedModel = {(this.FineTunedModel == null ? "null" : this.FineTunedModel == string.Empty ? "" : this.FineTunedModel)}");
            toStringOutput.Add($"this.OrganizationId = {(this.OrganizationId == null ? "null" : this.OrganizationId == string.Empty ? "" : this.OrganizationId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"Hyperparams = {(this.Hyperparams == null ? "null" : this.Hyperparams.ToString())}");
            toStringOutput.Add($"this.TrainingFiles = {(this.TrainingFiles == null ? "null" : $"[{string.Join(", ", this.TrainingFiles)} ]")}");
            toStringOutput.Add($"this.ValidationFiles = {(this.ValidationFiles == null ? "null" : $"[{string.Join(", ", this.ValidationFiles)} ]")}");
            toStringOutput.Add($"this.ResultFiles = {(this.ResultFiles == null ? "null" : $"[{string.Join(", ", this.ResultFiles)} ]")}");
            toStringOutput.Add($"this.Events = {(this.Events == null ? "null" : $"[{string.Join(", ", this.Events)} ]")}");
        }
    }
}
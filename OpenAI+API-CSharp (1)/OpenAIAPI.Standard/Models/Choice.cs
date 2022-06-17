// <copyright file="Choice.cs" company="APIMatic">
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
    /// Choice.
    /// </summary>
    public class Choice
    {
        private Models.Logprobs logprobs;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "logprobs", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Choice"/> class.
        /// </summary>
        public Choice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Choice"/> class.
        /// </summary>
        /// <param name="text">text.</param>
        /// <param name="index">index.</param>
        /// <param name="logprobs">logprobs.</param>
        /// <param name="finishReason">finish_reason.</param>
        public Choice(
            string text = null,
            int? index = null,
            Models.Logprobs logprobs = null,
            string finishReason = null)
        {
            this.Text = text;
            this.Index = index;
            if (logprobs != null)
            {
                this.Logprobs = logprobs;
            }

            this.FinishReason = finishReason;
        }

        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets Index.
        /// </summary>
        [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or sets Logprobs.
        /// </summary>
        [JsonProperty("logprobs")]
        public Models.Logprobs Logprobs
        {
            get
            {
                return this.logprobs;
            }

            set
            {
                this.shouldSerialize["logprobs"] = true;
                this.logprobs = value;
            }
        }

        /// <summary>
        /// Gets or sets FinishReason.
        /// </summary>
        [JsonProperty("finish_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string FinishReason { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Choice : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLogprobs()
        {
            this.shouldSerialize["logprobs"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLogprobs()
        {
            return this.shouldSerialize["logprobs"];
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

            return obj is Choice other &&
                ((this.Text == null && other.Text == null) || (this.Text?.Equals(other.Text) == true)) &&
                ((this.Index == null && other.Index == null) || (this.Index?.Equals(other.Index) == true)) &&
                ((this.Logprobs == null && other.Logprobs == null) || (this.Logprobs?.Equals(other.Logprobs) == true)) &&
                ((this.FinishReason == null && other.FinishReason == null) || (this.FinishReason?.Equals(other.FinishReason) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Text = {(this.Text == null ? "null" : this.Text == string.Empty ? "" : this.Text)}");
            toStringOutput.Add($"this.Index = {(this.Index == null ? "null" : this.Index.ToString())}");
            toStringOutput.Add($"this.Logprobs = {(this.Logprobs == null ? "null" : this.Logprobs.ToString())}");
            toStringOutput.Add($"this.FinishReason = {(this.FinishReason == null ? "null" : this.FinishReason == string.Empty ? "" : this.FinishReason)}");
        }
    }
}
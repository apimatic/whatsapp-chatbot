// <copyright file="SelectedExample.cs" company="APIMatic">
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
    /// SelectedExample.
    /// </summary>
    public class SelectedExample
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedExample"/> class.
        /// </summary>
        public SelectedExample()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedExample"/> class.
        /// </summary>
        /// <param name="document">document.</param>
        /// <param name="text">text.</param>
        /// <param name="label">label.</param>
        public SelectedExample(
            int? document = null,
            string text = null,
            string label = null)
        {
            this.Document = document;
            this.Text = text;
            this.Label = label;
        }

        /// <summary>
        /// Gets or sets Document.
        /// </summary>
        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public int? Document { get; set; }

        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets Label.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SelectedExample : ({string.Join(", ", toStringOutput)})";
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

            return obj is SelectedExample other &&
                ((this.Document == null && other.Document == null) || (this.Document?.Equals(other.Document) == true)) &&
                ((this.Text == null && other.Text == null) || (this.Text?.Equals(other.Text) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Document = {(this.Document == null ? "null" : this.Document.ToString())}");
            toStringOutput.Add($"this.Text = {(this.Text == null ? "null" : this.Text == string.Empty ? "" : this.Text)}");
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label == string.Empty ? "" : this.Label)}");
        }
    }
}
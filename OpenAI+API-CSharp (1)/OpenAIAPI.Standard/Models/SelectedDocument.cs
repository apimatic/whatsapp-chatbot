// <copyright file="SelectedDocument.cs" company="APIMatic">
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
    /// SelectedDocument.
    /// </summary>
    public class SelectedDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedDocument"/> class.
        /// </summary>
        public SelectedDocument()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedDocument"/> class.
        /// </summary>
        /// <param name="document">document.</param>
        /// <param name="text">text.</param>
        public SelectedDocument(
            int? document = null,
            string text = null)
        {
            this.Document = document;
            this.Text = text;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SelectedDocument : ({string.Join(", ", toStringOutput)})";
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

            return obj is SelectedDocument other &&
                ((this.Document == null && other.Document == null) || (this.Document?.Equals(other.Document) == true)) &&
                ((this.Text == null && other.Text == null) || (this.Text?.Equals(other.Text) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Document = {(this.Document == null ? "null" : this.Document.ToString())}");
            toStringOutput.Add($"this.Text = {(this.Text == null ? "null" : this.Text == string.Empty ? "" : this.Text)}");
        }
    }
}
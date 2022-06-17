// <copyright file="Datum.cs" company="APIMatic">
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
    /// Datum.
    /// </summary>
    public class Datum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Datum"/> class.
        /// </summary>
        public Datum()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Datum"/> class.
        /// </summary>
        /// <param name="mObject">object.</param>
        /// <param name="document">document.</param>
        /// <param name="score">score.</param>
        public Datum(
            string mObject = null,
            int? document = null,
            double? score = null)
        {
            this.MObject = mObject;
            this.Document = document;
            this.Score = score;
        }

        /// <summary>
        /// Gets or sets MObject.
        /// </summary>
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public string MObject { get; set; }

        /// <summary>
        /// Gets or sets Document.
        /// </summary>
        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public int? Document { get; set; }

        /// <summary>
        /// Gets or sets Score.
        /// </summary>
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public double? Score { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Datum : ({string.Join(", ", toStringOutput)})";
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

            return obj is Datum other &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Document == null && other.Document == null) || (this.Document?.Equals(other.Document) == true)) &&
                ((this.Score == null && other.Score == null) || (this.Score?.Equals(other.Score) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.Document = {(this.Document == null ? "null" : this.Document.ToString())}");
            toStringOutput.Add($"this.Score = {(this.Score == null ? "null" : this.Score.ToString())}");
        }
    }
}
// <copyright file="Datum1.cs" company="APIMatic">
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
    /// Datum1.
    /// </summary>
    public class Datum1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Datum1"/> class.
        /// </summary>
        public Datum1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Datum1"/> class.
        /// </summary>
        /// <param name="index">index.</param>
        /// <param name="mObject">object.</param>
        /// <param name="embedding">embedding.</param>
        public Datum1(
            int? index = null,
            string mObject = null,
            List<double> embedding = null)
        {
            this.Index = index;
            this.MObject = mObject;
            this.Embedding = embedding;
        }

        /// <summary>
        /// Gets or sets Index.
        /// </summary>
        [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or sets MObject.
        /// </summary>
        [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
        public string MObject { get; set; }

        /// <summary>
        /// Gets or sets Embedding.
        /// </summary>
        [JsonProperty("embedding", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Embedding { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Datum1 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Datum1 other &&
                ((this.Index == null && other.Index == null) || (this.Index?.Equals(other.Index) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Embedding == null && other.Embedding == null) || (this.Embedding?.Equals(other.Embedding) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Index = {(this.Index == null ? "null" : this.Index.ToString())}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.Embedding = {(this.Embedding == null ? "null" : $"[{string.Join(", ", this.Embedding)} ]")}");
        }
    }
}
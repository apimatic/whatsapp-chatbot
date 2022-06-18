// <copyright file="Logprobs.cs" company="APIMatic">
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
    /// Logprobs.
    /// </summary>
    public class Logprobs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Logprobs"/> class.
        /// </summary>
        public Logprobs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logprobs"/> class.
        /// </summary>
        /// <param name="tokens">tokens.</param>
        /// <param name="tokenLogprobs">token_logprobs.</param>
        /// <param name="topLogprobs">top_logprobs.</param>
        /// <param name="textOffset">text_offset.</param>
        public Logprobs(
            List<string> tokens = null,
            List<double> tokenLogprobs = null,
            object topLogprobs = null,
            List<int> textOffset = null)
        {
            this.Tokens = tokens;
            this.TokenLogprobs = tokenLogprobs;
            this.TopLogprobs = topLogprobs;
            this.TextOffset = textOffset;
        }

        /// <summary>
        /// Gets or sets Tokens.
        /// </summary>
        [JsonProperty("tokens", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tokens { get; set; }

        /// <summary>
        /// Gets or sets TokenLogprobs.
        /// </summary>
        [JsonProperty("token_logprobs", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> TokenLogprobs { get; set; }

        /// <summary>
        /// Gets or sets TopLogprobs.
        /// </summary>
        [JsonProperty("top_logprobs", NullValueHandling = NullValueHandling.Ignore)]
        public object TopLogprobs { get; set; }

        /// <summary>
        /// Gets or sets TextOffset.
        /// </summary>
        [JsonProperty("text_offset", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> TextOffset { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Logprobs : ({string.Join(", ", toStringOutput)})";
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

            return obj is Logprobs other &&
                ((this.Tokens == null && other.Tokens == null) || (this.Tokens?.Equals(other.Tokens) == true)) &&
                ((this.TokenLogprobs == null && other.TokenLogprobs == null) || (this.TokenLogprobs?.Equals(other.TokenLogprobs) == true)) &&
                ((this.TopLogprobs == null && other.TopLogprobs == null) || (this.TopLogprobs?.Equals(other.TopLogprobs) == true)) &&
                ((this.TextOffset == null && other.TextOffset == null) || (this.TextOffset?.Equals(other.TextOffset) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Tokens = {(this.Tokens == null ? "null" : $"[{string.Join(", ", this.Tokens)} ]")}");
            toStringOutput.Add($"this.TokenLogprobs = {(this.TokenLogprobs == null ? "null" : $"[{string.Join(", ", this.TokenLogprobs)} ]")}");
            toStringOutput.Add($"TopLogprobs = {(this.TopLogprobs == null ? "null" : this.TopLogprobs.ToString())}");
            toStringOutput.Add($"this.TextOffset = {(this.TextOffset == null ? "null" : $"[{string.Join(", ", this.TextOffset)} ]")}");
        }
    }
}
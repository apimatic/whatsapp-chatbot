// <copyright file="CreateEmbeddingRequest.cs" company="APIMatic">
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
    /// CreateEmbeddingRequest.
    /// </summary>
    public class CreateEmbeddingRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmbeddingRequest"/> class.
        /// </summary>
        public CreateEmbeddingRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmbeddingRequest"/> class.
        /// </summary>
        /// <param name="model">model.</param>
        /// <param name="input">input.</param>
        /// <param name="user">user.</param>
        public CreateEmbeddingRequest(
            string model,
            string input,
            string user = null)
        {
            this.Model = model;
            this.Input = input;
            this.User = user;
        }

        /// <summary>
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Input text to get embeddings for, encoded as a string or array of tokens. To get embeddings for multiple inputs in a single request, pass an array of strings or array of token arrays. Each input must not exceed 2048 tokens in length.
        /// Unless your are embedding code, we suggest replacing newlines (`\n`) in your input with a single space, as we have observed inferior results when newlines are present.
        /// </summary>
        [JsonProperty("input")]
        public string Input { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which will help OpenAI to monitor and detect abuse.
        /// </summary>
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateEmbeddingRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateEmbeddingRequest other &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Input == null && other.Input == null) || (this.Input?.Equals(other.Input) == true)) &&
                ((this.User == null && other.User == null) || (this.User?.Equals(other.User) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.Input = {(this.Input == null ? "null" : this.Input == string.Empty ? "" : this.Input)}");
            toStringOutput.Add($"this.User = {(this.User == null ? "null" : this.User == string.Empty ? "" : this.User)}");
        }
    }
}
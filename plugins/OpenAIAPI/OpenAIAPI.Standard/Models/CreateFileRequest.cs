// <copyright file="CreateFileRequest.cs" company="APIMatic">
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
    /// CreateFileRequest.
    /// </summary>
    public class CreateFileRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFileRequest"/> class.
        /// </summary>
        public CreateFileRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFileRequest"/> class.
        /// </summary>
        /// <param name="file">file.</param>
        /// <param name="purpose">purpose.</param>
        public CreateFileRequest(
            Stream file,
            string purpose)
        {
            this.File = file;
            this.Purpose = purpose;
        }

        /// <summary>
        /// Name of the [JSON Lines](https://jsonlines.readthedocs.io/en/latest/) file to be uploaded.
        /// If the `purpose` is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your [training examples](/docs/guides/fine-tuning/prepare-training-data).
        /// </summary>
        [JsonProperty("file")]
        public Stream File { get; set; }

        /// <summary>
        /// The intended purpose of the uploaded documents.
        /// Use "fine-tune" for [Fine-tuning](/docs/api-reference/fine-tunes). This allows us to validate the format of the uploaded file.
        /// </summary>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateFileRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateFileRequest other &&
                ((this.File == null && other.File == null) || (this.File?.Equals(other.File) == true)) &&
                ((this.Purpose == null && other.Purpose == null) || (this.Purpose?.Equals(other.Purpose) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.File = {(this.File == null ? "null" : this.File.ToString())}");
            toStringOutput.Add($"this.Purpose = {(this.Purpose == null ? "null" : this.Purpose == string.Empty ? "" : this.Purpose)}");
        }
    }
}
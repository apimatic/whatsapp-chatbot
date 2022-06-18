// <copyright file="CreateSearchRequest.cs" company="APIMatic">
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
    /// CreateSearchRequest.
    /// </summary>
    public class CreateSearchRequest
    {
        private List<string> documents;
        private string file;
        private int? maxRerank;
        private bool? returnMetadata;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "documents", false },
            { "file", false },
            { "max_rerank", true },
            { "return_metadata", true },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSearchRequest"/> class.
        /// </summary>
        public CreateSearchRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSearchRequest"/> class.
        /// </summary>
        /// <param name="query">query.</param>
        /// <param name="documents">documents.</param>
        /// <param name="file">file.</param>
        /// <param name="maxRerank">max_rerank.</param>
        /// <param name="returnMetadata">return_metadata.</param>
        /// <param name="user">user.</param>
        public CreateSearchRequest(
            string query,
            List<string> documents = null,
            string file = null,
            int? maxRerank = 200,
            bool? returnMetadata = false,
            string user = null)
        {
            this.Query = query;
            if (documents != null)
            {
                this.Documents = documents;
            }

            if (file != null)
            {
                this.File = file;
            }

            this.MaxRerank = maxRerank;
            this.ReturnMetadata = returnMetadata;
            this.User = user;
        }

        /// <summary>
        /// Query to search against the documents.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// Up to 200 documents to search over, provided as a list of strings.
        /// The maximum document length (in tokens) is 2034 minus the number of tokens in the query.
        /// You should specify either `documents` or a `file`, but not both.
        /// </summary>
        [JsonProperty("documents")]
        public List<string> Documents
        {
            get
            {
                return this.documents;
            }

            set
            {
                this.shouldSerialize["documents"] = true;
                this.documents = value;
            }
        }

        /// <summary>
        /// The ID of an uploaded file that contains documents to search over.
        /// You should specify either `documents` or a `file`, but not both.
        /// </summary>
        [JsonProperty("file")]
        public string File
        {
            get
            {
                return this.file;
            }

            set
            {
                this.shouldSerialize["file"] = true;
                this.file = value;
            }
        }

        /// <summary>
        /// The maximum number of documents to be re-ranked and returned by search.
        /// This flag only takes effect when `file` is set.
        /// </summary>
        [JsonProperty("max_rerank")]
        public int? MaxRerank
        {
            get
            {
                return this.maxRerank;
            }

            set
            {
                this.shouldSerialize["max_rerank"] = true;
                this.maxRerank = value;
            }
        }

        /// <summary>
        /// A special boolean flag for showing metadata. If set to `true`, each document entry in the returned JSON will contain a "metadata" field.
        /// This flag only takes effect when `file` is set.
        /// </summary>
        [JsonProperty("return_metadata")]
        public bool? ReturnMetadata
        {
            get
            {
                return this.returnMetadata;
            }

            set
            {
                this.shouldSerialize["return_metadata"] = true;
                this.returnMetadata = value;
            }
        }

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

            return $"CreateSearchRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetDocuments()
        {
            this.shouldSerialize["documents"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFile()
        {
            this.shouldSerialize["file"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMaxRerank()
        {
            this.shouldSerialize["max_rerank"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReturnMetadata()
        {
            this.shouldSerialize["return_metadata"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDocuments()
        {
            return this.shouldSerialize["documents"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFile()
        {
            return this.shouldSerialize["file"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxRerank()
        {
            return this.shouldSerialize["max_rerank"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnMetadata()
        {
            return this.shouldSerialize["return_metadata"];
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

            return obj is CreateSearchRequest other &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Documents == null && other.Documents == null) || (this.Documents?.Equals(other.Documents) == true)) &&
                ((this.File == null && other.File == null) || (this.File?.Equals(other.File) == true)) &&
                ((this.MaxRerank == null && other.MaxRerank == null) || (this.MaxRerank?.Equals(other.MaxRerank) == true)) &&
                ((this.ReturnMetadata == null && other.ReturnMetadata == null) || (this.ReturnMetadata?.Equals(other.ReturnMetadata) == true)) &&
                ((this.User == null && other.User == null) || (this.User?.Equals(other.User) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query == string.Empty ? "" : this.Query)}");
            toStringOutput.Add($"this.Documents = {(this.Documents == null ? "null" : $"[{string.Join(", ", this.Documents)} ]")}");
            toStringOutput.Add($"this.File = {(this.File == null ? "null" : this.File == string.Empty ? "" : this.File)}");
            toStringOutput.Add($"this.MaxRerank = {(this.MaxRerank == null ? "null" : this.MaxRerank.ToString())}");
            toStringOutput.Add($"this.ReturnMetadata = {(this.ReturnMetadata == null ? "null" : this.ReturnMetadata.ToString())}");
            toStringOutput.Add($"this.User = {(this.User == null ? "null" : this.User == string.Empty ? "" : this.User)}");
        }
    }
}
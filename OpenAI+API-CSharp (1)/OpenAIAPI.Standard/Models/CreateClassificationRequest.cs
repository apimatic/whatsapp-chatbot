// <copyright file="CreateClassificationRequest.cs" company="APIMatic">
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
    /// CreateClassificationRequest.
    /// </summary>
    public class CreateClassificationRequest
    {
        private List<List<string>> examples;
        private string file;
        private List<string> labels;
        private string searchModel;
        private double? temperature;
        private int? logprobs;
        private int? maxExamples;
        private object logitBias;
        private bool? returnPrompt;
        private bool? returnMetadata;
        private object expand;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "examples", false },
            { "file", false },
            { "labels", false },
            { "search_model", true },
            { "temperature", true },
            { "logprobs", false },
            { "max_examples", true },
            { "logit_bias", false },
            { "return_prompt", true },
            { "return_metadata", true },
            { "expand", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClassificationRequest"/> class.
        /// </summary>
        public CreateClassificationRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClassificationRequest"/> class.
        /// </summary>
        /// <param name="model">model.</param>
        /// <param name="query">query.</param>
        /// <param name="examples">examples.</param>
        /// <param name="file">file.</param>
        /// <param name="labels">labels.</param>
        /// <param name="searchModel">search_model.</param>
        /// <param name="temperature">temperature.</param>
        /// <param name="logprobs">logprobs.</param>
        /// <param name="maxExamples">max_examples.</param>
        /// <param name="logitBias">logit_bias.</param>
        /// <param name="returnPrompt">return_prompt.</param>
        /// <param name="returnMetadata">return_metadata.</param>
        /// <param name="expand">expand.</param>
        /// <param name="user">user.</param>
        public CreateClassificationRequest(
            string model,
            string query,
            List<List<string>> examples = null,
            string file = null,
            List<string> labels = null,
            string searchModel = "ada",
            double? temperature = 0,
            int? logprobs = null,
            int? maxExamples = 200,
            object logitBias = null,
            bool? returnPrompt = false,
            bool? returnMetadata = false,
            object expand = null,
            string user = null)
        {
            this.Model = model;
            this.Query = query;
            if (examples != null)
            {
                this.Examples = examples;
            }

            if (file != null)
            {
                this.File = file;
            }

            if (labels != null)
            {
                this.Labels = labels;
            }

            this.SearchModel = searchModel;
            this.Temperature = temperature;
            if (logprobs != null)
            {
                this.Logprobs = logprobs;
            }

            this.MaxExamples = maxExamples;
            if (logitBias != null)
            {
                this.LogitBias = logitBias;
            }

            this.ReturnPrompt = returnPrompt;
            this.ReturnMetadata = returnMetadata;
            if (expand != null)
            {
                this.Expand = expand;
            }

            this.User = user;
        }

        /// <summary>
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Query to be classified.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// A list of examples with labels, in the following format:
        /// `[["The movie is so interesting.", "Positive"], ["It is quite boring.", "Negative"], ...]`
        /// All the label strings will be normalized to be capitalized.
        /// You should specify either `examples` or `file`, but not both.
        /// </summary>
        [JsonProperty("examples")]
        public List<List<string>> Examples
        {
            get
            {
                return this.examples;
            }

            set
            {
                this.shouldSerialize["examples"] = true;
                this.examples = value;
            }
        }

        /// <summary>
        /// The ID of the uploaded file that contains training examples. See [upload file](/docs/api-reference/files/upload) for how to upload a file of the desired format and purpose.
        /// You should specify either `examples` or `file`, but not both.
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
        /// The set of categories being classified. If not specified, candidate labels will be automatically collected from the examples you provide. All the label strings will be normalized to be capitalized.
        /// </summary>
        [JsonProperty("labels")]
        public List<string> Labels
        {
            get
            {
                return this.labels;
            }

            set
            {
                this.shouldSerialize["labels"] = true;
                this.labels = value;
            }
        }

        /// <summary>
        /// ID of the model to use for [Search](/docs/api-reference/searches/create). You can select one of `ada`, `babbage`, `curie`, or `davinci`.
        /// </summary>
        [JsonProperty("search_model")]
        public string SearchModel
        {
            get
            {
                return this.searchModel;
            }

            set
            {
                this.shouldSerialize["search_model"] = true;
                this.searchModel = value;
            }
        }

        /// <summary>
        /// What sampling `temperature` to use. Higher values mean the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        /// </summary>
        [JsonProperty("temperature")]
        public double? Temperature
        {
            get
            {
                return this.temperature;
            }

            set
            {
                this.shouldSerialize["temperature"] = true;
                this.temperature = value;
            }
        }

        /// <summary>
        /// Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. For example, if `logprobs` is 5, the API will return a list of the 5 most likely tokens. The API will always return the `logprob` of the sampled token, so there may be up to `logprobs+1` elements in the response.
        /// The maximum value for `logprobs` is 5. If you need more than this, please contact support@openai.com and describe your use case.
        /// When `logprobs` is set, `completion` will be automatically added into `expand` to get the logprobs.
        /// </summary>
        [JsonProperty("logprobs")]
        public int? Logprobs
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
        /// The maximum number of examples to be ranked by [Search](/docs/api-reference/searches/create) when using `file`. Setting it to a higher value leads to improved accuracy but with increased latency and cost.
        /// </summary>
        [JsonProperty("max_examples")]
        public int? MaxExamples
        {
            get
            {
                return this.maxExamples;
            }

            set
            {
                this.shouldSerialize["max_examples"] = true;
                this.maxExamples = value;
            }
        }

        /// <summary>
        /// Modify the likelihood of specified tokens appearing in the completion.
        /// Accepts a json object that maps tokens (specified by their token ID in the GPT tokenizer) to an associated bias value from -100 to 100. You can use this [tokenizer tool](/tokenizer?view=bpe) (which works for both GPT-2 and GPT-3) to convert text to token IDs. Mathematically, the bias is added to the logits generated by the model prior to sampling. The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100 should result in a ban or exclusive selection of the relevant token.
        /// As an example, you can pass `{"50256": -100}` to prevent the <|endoftext|> token from being generated.
        /// </summary>
        [JsonProperty("logit_bias")]
        public object LogitBias
        {
            get
            {
                return this.logitBias;
            }

            set
            {
                this.shouldSerialize["logit_bias"] = true;
                this.logitBias = value;
            }
        }

        /// <summary>
        /// If set to `true`, the returned JSON will include a "prompt" field containing the final prompt that was used to request a completion. This is mainly useful for debugging purposes.
        /// </summary>
        [JsonProperty("return_prompt")]
        public bool? ReturnPrompt
        {
            get
            {
                return this.returnPrompt;
            }

            set
            {
                this.shouldSerialize["return_prompt"] = true;
                this.returnPrompt = value;
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
        /// If an object name is in the list, we provide the full information of the object; otherwise, we only provide the object ID. Currently we support `completion` and `file` objects for expansion.
        /// </summary>
        [JsonProperty("expand")]
        public object Expand
        {
            get
            {
                return this.expand;
            }

            set
            {
                this.shouldSerialize["expand"] = true;
                this.expand = value;
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

            return $"CreateClassificationRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetExamples()
        {
            this.shouldSerialize["examples"] = false;
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
        public void UnsetLabels()
        {
            this.shouldSerialize["labels"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSearchModel()
        {
            this.shouldSerialize["search_model"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTemperature()
        {
            this.shouldSerialize["temperature"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLogprobs()
        {
            this.shouldSerialize["logprobs"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMaxExamples()
        {
            this.shouldSerialize["max_examples"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLogitBias()
        {
            this.shouldSerialize["logit_bias"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReturnPrompt()
        {
            this.shouldSerialize["return_prompt"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetReturnMetadata()
        {
            this.shouldSerialize["return_metadata"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetExpand()
        {
            this.shouldSerialize["expand"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExamples()
        {
            return this.shouldSerialize["examples"];
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
        public bool ShouldSerializeLabels()
        {
            return this.shouldSerialize["labels"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSearchModel()
        {
            return this.shouldSerialize["search_model"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTemperature()
        {
            return this.shouldSerialize["temperature"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLogprobs()
        {
            return this.shouldSerialize["logprobs"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxExamples()
        {
            return this.shouldSerialize["max_examples"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLogitBias()
        {
            return this.shouldSerialize["logit_bias"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnPrompt()
        {
            return this.shouldSerialize["return_prompt"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnMetadata()
        {
            return this.shouldSerialize["return_metadata"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpand()
        {
            return this.shouldSerialize["expand"];
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

            return obj is CreateClassificationRequest other &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Examples == null && other.Examples == null) || (this.Examples?.Equals(other.Examples) == true)) &&
                ((this.File == null && other.File == null) || (this.File?.Equals(other.File) == true)) &&
                ((this.Labels == null && other.Labels == null) || (this.Labels?.Equals(other.Labels) == true)) &&
                ((this.SearchModel == null && other.SearchModel == null) || (this.SearchModel?.Equals(other.SearchModel) == true)) &&
                ((this.Temperature == null && other.Temperature == null) || (this.Temperature?.Equals(other.Temperature) == true)) &&
                ((this.Logprobs == null && other.Logprobs == null) || (this.Logprobs?.Equals(other.Logprobs) == true)) &&
                ((this.MaxExamples == null && other.MaxExamples == null) || (this.MaxExamples?.Equals(other.MaxExamples) == true)) &&
                ((this.LogitBias == null && other.LogitBias == null) || (this.LogitBias?.Equals(other.LogitBias) == true)) &&
                ((this.ReturnPrompt == null && other.ReturnPrompt == null) || (this.ReturnPrompt?.Equals(other.ReturnPrompt) == true)) &&
                ((this.ReturnMetadata == null && other.ReturnMetadata == null) || (this.ReturnMetadata?.Equals(other.ReturnMetadata) == true)) &&
                ((this.Expand == null && other.Expand == null) || (this.Expand?.Equals(other.Expand) == true)) &&
                ((this.User == null && other.User == null) || (this.User?.Equals(other.User) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query == string.Empty ? "" : this.Query)}");
            toStringOutput.Add($"this.Examples = {(this.Examples == null ? "null" : $"[{string.Join(", ", this.Examples)} ]")}");
            toStringOutput.Add($"this.File = {(this.File == null ? "null" : this.File == string.Empty ? "" : this.File)}");
            toStringOutput.Add($"this.Labels = {(this.Labels == null ? "null" : $"[{string.Join(", ", this.Labels)} ]")}");
            toStringOutput.Add($"this.SearchModel = {(this.SearchModel == null ? "null" : this.SearchModel == string.Empty ? "" : this.SearchModel)}");
            toStringOutput.Add($"this.Temperature = {(this.Temperature == null ? "null" : this.Temperature.ToString())}");
            toStringOutput.Add($"this.Logprobs = {(this.Logprobs == null ? "null" : this.Logprobs.ToString())}");
            toStringOutput.Add($"this.MaxExamples = {(this.MaxExamples == null ? "null" : this.MaxExamples.ToString())}");
            toStringOutput.Add($"LogitBias = {(this.LogitBias == null ? "null" : this.LogitBias.ToString())}");
            toStringOutput.Add($"this.ReturnPrompt = {(this.ReturnPrompt == null ? "null" : this.ReturnPrompt.ToString())}");
            toStringOutput.Add($"this.ReturnMetadata = {(this.ReturnMetadata == null ? "null" : this.ReturnMetadata.ToString())}");
            toStringOutput.Add($"Expand = {(this.Expand == null ? "null" : this.Expand.ToString())}");
            toStringOutput.Add($"this.User = {(this.User == null ? "null" : this.User == string.Empty ? "" : this.User)}");
        }
    }
}
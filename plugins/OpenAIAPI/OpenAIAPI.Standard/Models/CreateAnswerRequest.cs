// <copyright file="CreateAnswerRequest.cs" company="APIMatic">
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
    /// CreateAnswerRequest.
    /// </summary>
    public class CreateAnswerRequest
    {
        private List<string> documents;
        private string file;
        private string searchModel;
        private int? maxRerank;
        private double? temperature;
        private int? logprobs;
        private int? maxTokens;
        private string stop;
        private int? n;
        private object logitBias;
        private bool? returnMetadata;
        private bool? returnPrompt;
        private object expand;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "documents", false },
            { "file", false },
            { "search_model", true },
            { "max_rerank", true },
            { "temperature", true },
            { "logprobs", false },
            { "max_tokens", true },
            { "stop", false },
            { "n", true },
            { "logit_bias", false },
            { "return_metadata", true },
            { "return_prompt", true },
            { "expand", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAnswerRequest"/> class.
        /// </summary>
        public CreateAnswerRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAnswerRequest"/> class.
        /// </summary>
        /// <param name="model">model.</param>
        /// <param name="question">question.</param>
        /// <param name="examples">examples.</param>
        /// <param name="examplesContext">examples_context.</param>
        /// <param name="documents">documents.</param>
        /// <param name="file">file.</param>
        /// <param name="searchModel">search_model.</param>
        /// <param name="maxRerank">max_rerank.</param>
        /// <param name="temperature">temperature.</param>
        /// <param name="logprobs">logprobs.</param>
        /// <param name="maxTokens">max_tokens.</param>
        /// <param name="stop">stop.</param>
        /// <param name="n">n.</param>
        /// <param name="logitBias">logit_bias.</param>
        /// <param name="returnMetadata">return_metadata.</param>
        /// <param name="returnPrompt">return_prompt.</param>
        /// <param name="expand">expand.</param>
        /// <param name="user">user.</param>
        public CreateAnswerRequest(
            string model,
            string question,
            List<List<string>> examples,
            string examplesContext,
            List<string> documents = null,
            string file = null,
            string searchModel = "ada",
            int? maxRerank = 200,
            double? temperature = 0,
            int? logprobs = null,
            int? maxTokens = 16,
            string stop = null,
            int? n = 1,
            object logitBias = null,
            bool? returnMetadata = false,
            bool? returnPrompt = false,
            object expand = null,
            string user = null)
        {
            this.Model = model;
            this.Question = question;
            this.Examples = examples;
            this.ExamplesContext = examplesContext;
            if (documents != null)
            {
                this.Documents = documents;
            }

            if (file != null)
            {
                this.File = file;
            }

            this.SearchModel = searchModel;
            this.MaxRerank = maxRerank;
            this.Temperature = temperature;
            if (logprobs != null)
            {
                this.Logprobs = logprobs;
            }

            this.MaxTokens = maxTokens;
            if (stop != null)
            {
                this.Stop = stop;
            }

            this.N = n;
            if (logitBias != null)
            {
                this.LogitBias = logitBias;
            }

            this.ReturnMetadata = returnMetadata;
            this.ReturnPrompt = returnPrompt;
            if (expand != null)
            {
                this.Expand = expand;
            }

            this.User = user;
        }

        /// <summary>
        /// ID of the model to use for completion. You can select one of `ada`, `babbage`, `curie`, or `davinci`.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Question to get answered.
        /// </summary>
        [JsonProperty("question")]
        public string Question { get; set; }

        /// <summary>
        /// List of (question, answer) pairs that will help steer the model towards the tone and answer format you'd like. We recommend adding 2 to 3 examples.
        /// </summary>
        [JsonProperty("examples")]
        public List<List<string>> Examples { get; set; }

        /// <summary>
        /// A text snippet containing the contextual information used to generate the answers for the `examples` you provide.
        /// </summary>
        [JsonProperty("examples_context")]
        public string ExamplesContext { get; set; }

        /// <summary>
        /// List of documents from which the answer for the input `question` should be derived. If this is an empty list, the question will be answered based on the question-answer examples.
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
        /// The ID of an uploaded file that contains documents to search over. See [upload file](/docs/api-reference/files/upload) for how to upload a file of the desired format and purpose.
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
        /// The maximum number of documents to be ranked by [Search](/docs/api-reference/searches/create) when using `file`. Setting it to a higher value leads to improved accuracy but with increased latency and cost.
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
        /// What [sampling temperature](https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277) to use. Higher values mean the model will take more risks and value 0 (argmax sampling) works better for scenarios with a well-defined answer.
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
        /// The maximum number of tokens allowed for the generated answer
        /// </summary>
        [JsonProperty("max_tokens")]
        public int? MaxTokens
        {
            get
            {
                return this.maxTokens;
            }

            set
            {
                this.shouldSerialize["max_tokens"] = true;
                this.maxTokens = value;
            }
        }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        [JsonProperty("stop")]
        public string Stop
        {
            get
            {
                return this.stop;
            }

            set
            {
                this.shouldSerialize["stop"] = true;
                this.stop = value;
            }
        }

        /// <summary>
        /// How many answers to generate for each question.
        /// </summary>
        [JsonProperty("n")]
        public int? N
        {
            get
            {
                return this.n;
            }

            set
            {
                this.shouldSerialize["n"] = true;
                this.n = value;
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

            return $"CreateAnswerRequest : ({string.Join(", ", toStringOutput)})";
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
        public void UnsetSearchModel()
        {
            this.shouldSerialize["search_model"] = false;
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
        public void UnsetMaxTokens()
        {
            this.shouldSerialize["max_tokens"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetStop()
        {
            this.shouldSerialize["stop"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetN()
        {
            this.shouldSerialize["n"] = false;
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
        public void UnsetReturnMetadata()
        {
            this.shouldSerialize["return_metadata"] = false;
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
        public void UnsetExpand()
        {
            this.shouldSerialize["expand"] = false;
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
        public bool ShouldSerializeSearchModel()
        {
            return this.shouldSerialize["search_model"];
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
        public bool ShouldSerializeMaxTokens()
        {
            return this.shouldSerialize["max_tokens"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStop()
        {
            return this.shouldSerialize["stop"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeN()
        {
            return this.shouldSerialize["n"];
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
        public bool ShouldSerializeReturnMetadata()
        {
            return this.shouldSerialize["return_metadata"];
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

            return obj is CreateAnswerRequest other &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Question == null && other.Question == null) || (this.Question?.Equals(other.Question) == true)) &&
                ((this.Examples == null && other.Examples == null) || (this.Examples?.Equals(other.Examples) == true)) &&
                ((this.ExamplesContext == null && other.ExamplesContext == null) || (this.ExamplesContext?.Equals(other.ExamplesContext) == true)) &&
                ((this.Documents == null && other.Documents == null) || (this.Documents?.Equals(other.Documents) == true)) &&
                ((this.File == null && other.File == null) || (this.File?.Equals(other.File) == true)) &&
                ((this.SearchModel == null && other.SearchModel == null) || (this.SearchModel?.Equals(other.SearchModel) == true)) &&
                ((this.MaxRerank == null && other.MaxRerank == null) || (this.MaxRerank?.Equals(other.MaxRerank) == true)) &&
                ((this.Temperature == null && other.Temperature == null) || (this.Temperature?.Equals(other.Temperature) == true)) &&
                ((this.Logprobs == null && other.Logprobs == null) || (this.Logprobs?.Equals(other.Logprobs) == true)) &&
                ((this.MaxTokens == null && other.MaxTokens == null) || (this.MaxTokens?.Equals(other.MaxTokens) == true)) &&
                ((this.Stop == null && other.Stop == null) || (this.Stop?.Equals(other.Stop) == true)) &&
                ((this.N == null && other.N == null) || (this.N?.Equals(other.N) == true)) &&
                ((this.LogitBias == null && other.LogitBias == null) || (this.LogitBias?.Equals(other.LogitBias) == true)) &&
                ((this.ReturnMetadata == null && other.ReturnMetadata == null) || (this.ReturnMetadata?.Equals(other.ReturnMetadata) == true)) &&
                ((this.ReturnPrompt == null && other.ReturnPrompt == null) || (this.ReturnPrompt?.Equals(other.ReturnPrompt) == true)) &&
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
            toStringOutput.Add($"this.Question = {(this.Question == null ? "null" : this.Question == string.Empty ? "" : this.Question)}");
            toStringOutput.Add($"this.Examples = {(this.Examples == null ? "null" : $"[{string.Join(", ", this.Examples)} ]")}");
            toStringOutput.Add($"this.ExamplesContext = {(this.ExamplesContext == null ? "null" : this.ExamplesContext == string.Empty ? "" : this.ExamplesContext)}");
            toStringOutput.Add($"this.Documents = {(this.Documents == null ? "null" : $"[{string.Join(", ", this.Documents)} ]")}");
            toStringOutput.Add($"this.File = {(this.File == null ? "null" : this.File == string.Empty ? "" : this.File)}");
            toStringOutput.Add($"this.SearchModel = {(this.SearchModel == null ? "null" : this.SearchModel == string.Empty ? "" : this.SearchModel)}");
            toStringOutput.Add($"this.MaxRerank = {(this.MaxRerank == null ? "null" : this.MaxRerank.ToString())}");
            toStringOutput.Add($"this.Temperature = {(this.Temperature == null ? "null" : this.Temperature.ToString())}");
            toStringOutput.Add($"this.Logprobs = {(this.Logprobs == null ? "null" : this.Logprobs.ToString())}");
            toStringOutput.Add($"this.MaxTokens = {(this.MaxTokens == null ? "null" : this.MaxTokens.ToString())}");
            toStringOutput.Add($"this.Stop = {(this.Stop == null ? "null" : this.Stop == string.Empty ? "" : this.Stop)}");
            toStringOutput.Add($"this.N = {(this.N == null ? "null" : this.N.ToString())}");
            toStringOutput.Add($"LogitBias = {(this.LogitBias == null ? "null" : this.LogitBias.ToString())}");
            toStringOutput.Add($"this.ReturnMetadata = {(this.ReturnMetadata == null ? "null" : this.ReturnMetadata.ToString())}");
            toStringOutput.Add($"this.ReturnPrompt = {(this.ReturnPrompt == null ? "null" : this.ReturnPrompt.ToString())}");
            toStringOutput.Add($"Expand = {(this.Expand == null ? "null" : this.Expand.ToString())}");
            toStringOutput.Add($"this.User = {(this.User == null ? "null" : this.User == string.Empty ? "" : this.User)}");
        }
    }
}
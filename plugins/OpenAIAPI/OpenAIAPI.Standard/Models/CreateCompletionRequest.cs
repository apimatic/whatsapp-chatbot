// <copyright file="CreateCompletionRequest.cs" company="APIMatic">
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
    /// CreateCompletionRequest.
    /// </summary>
    public class CreateCompletionRequest
    {
        private string suffix;
        private int? maxTokens;
        private double? temperature;
        private double? topP;
        private int? n;
        private bool? stream;
        private int? logprobs;
        private bool? echo;
        private string stop;
        private double? presencePenalty;
        private double? frequencyPenalty;
        private int? bestOf;
        private object logitBias;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "suffix", false },
            { "max_tokens", true },
            { "temperature", true },
            { "top_p", true },
            { "n", true },
            { "stream", true },
            { "logprobs", false },
            { "echo", true },
            { "stop", false },
            { "presence_penalty", true },
            { "frequency_penalty", true },
            { "best_of", true },
            { "logit_bias", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompletionRequest"/> class.
        /// </summary>
        public CreateCompletionRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompletionRequest"/> class.
        /// </summary>
        /// <param name="model">model.</param>
        /// <param name="prompt">prompt.</param>
        /// <param name="suffix">suffix.</param>
        /// <param name="maxTokens">max_tokens.</param>
        /// <param name="temperature">temperature.</param>
        /// <param name="topP">top_p.</param>
        /// <param name="n">n.</param>
        /// <param name="stream">stream.</param>
        /// <param name="logprobs">logprobs.</param>
        /// <param name="echo">echo.</param>
        /// <param name="stop">stop.</param>
        /// <param name="presencePenalty">presence_penalty.</param>
        /// <param name="frequencyPenalty">frequency_penalty.</param>
        /// <param name="bestOf">best_of.</param>
        /// <param name="logitBias">logit_bias.</param>
        /// <param name="user">user.</param>
        public CreateCompletionRequest(
            string model,
            string prompt = "<|endoftext|>",
            string suffix = null,
            int? maxTokens = 16,
            double? temperature = 1,
            double? topP = 1,
            int? n = 1,
            bool? stream = false,
            int? logprobs = null,
            bool? echo = false,
            string stop = null,
            double? presencePenalty = 0,
            double? frequencyPenalty = 0,
            int? bestOf = 1,
            object logitBias = null,
            string user = null)
        {
            this.Model = model;
            this.Prompt = prompt;
            if (suffix != null)
            {
                this.Suffix = suffix;
            }

            this.MaxTokens = maxTokens;
            this.Temperature = temperature;
            this.TopP = topP;
            this.N = n;
            this.Stream = stream;
            if (logprobs != null)
            {
                this.Logprobs = logprobs;
            }

            this.Echo = echo;
            if (stop != null)
            {
                this.Stop = stop;
            }

            this.PresencePenalty = presencePenalty;
            this.FrequencyPenalty = frequencyPenalty;
            this.BestOf = bestOf;
            if (logitBias != null)
            {
                this.LogitBias = logitBias;
            }

            this.User = user;
        }

        /// <summary>
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of token arrays.
        /// Note that <|endoftext|> is the document separator that the model sees during training, so if a prompt is not specified the model will generate as if from the beginning of a new document.
        /// </summary>
        [JsonProperty("prompt", NullValueHandling = NullValueHandling.Ignore)]
        public string Prompt { get; set; }

        /// <summary>
        /// The suffix that comes after a completion of inserted text.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        {
            get
            {
                return this.suffix;
            }

            set
            {
                this.shouldSerialize["suffix"] = true;
                this.suffix = value;
            }
        }

        /// <summary>
        /// The maximum number of [tokens](/tokenizer) to generate in the completion.
        /// The token count of your prompt plus `max_tokens` cannot exceed the model's context length. Most models have a context length of 2048 tokens (except for the newest models, which support 4096).
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
        /// What [sampling temperature](https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277) to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        /// We generally recommend altering this or `top_p` but not both.
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
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// We generally recommend altering this or `temperature` but not both.
        /// </summary>
        [JsonProperty("top_p")]
        public double? TopP
        {
            get
            {
                return this.topP;
            }

            set
            {
                this.shouldSerialize["top_p"] = true;
                this.topP = value;
            }
        }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// **Note:** Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.
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
        /// Whether to stream back partial progress. If set, tokens will be sent as data-only [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format) as they become available, with the stream terminated by a `data: [DONE]` message.
        /// </summary>
        [JsonProperty("stream")]
        public bool? Stream
        {
            get
            {
                return this.stream;
            }

            set
            {
                this.shouldSerialize["stream"] = true;
                this.stream = value;
            }
        }

        /// <summary>
        /// Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. For example, if `logprobs` is 5, the API will return a list of the 5 most likely tokens. The API will always return the `logprob` of the sampled token, so there may be up to `logprobs+1` elements in the response.
        /// The maximum value for `logprobs` is 5. If you need more than this, please contact support@openai.com and describe your use case.
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
        /// Echo back the prompt in addition to the completion
        /// </summary>
        [JsonProperty("echo")]
        public bool? Echo
        {
            get
            {
                return this.echo;
            }

            set
            {
                this.shouldSerialize["echo"] = true;
                this.echo = value;
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
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.
        /// [See more information about frequency and presence penalties.](/docs/api-reference/parameter-details)
        /// </summary>
        [JsonProperty("presence_penalty")]
        public double? PresencePenalty
        {
            get
            {
                return this.presencePenalty;
            }

            set
            {
                this.shouldSerialize["presence_penalty"] = true;
                this.presencePenalty = value;
            }
        }

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
        /// [See more information about frequency and presence penalties.](/docs/api-reference/parameter-details)
        /// </summary>
        [JsonProperty("frequency_penalty")]
        public double? FrequencyPenalty
        {
            get
            {
                return this.frequencyPenalty;
            }

            set
            {
                this.shouldSerialize["frequency_penalty"] = true;
                this.frequencyPenalty = value;
            }
        }

        /// <summary>
        /// Generates `best_of` completions server-side and returns the "best" (the one with the highest log probability per token). Results cannot be streamed.
        /// When used with `n`, `best_of` controls the number of candidate completions and `n` specifies how many to return – `best_of` must be greater than `n`.
        /// **Note:** Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.
        /// </summary>
        [JsonProperty("best_of")]
        public int? BestOf
        {
            get
            {
                return this.bestOf;
            }

            set
            {
                this.shouldSerialize["best_of"] = true;
                this.bestOf = value;
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
        /// A unique identifier representing your end-user, which will help OpenAI to monitor and detect abuse.
        /// </summary>
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCompletionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSuffix()
        {
            this.shouldSerialize["suffix"] = false;
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
        public void UnsetTemperature()
        {
            this.shouldSerialize["temperature"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTopP()
        {
            this.shouldSerialize["top_p"] = false;
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
        public void UnsetStream()
        {
            this.shouldSerialize["stream"] = false;
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
        public void UnsetEcho()
        {
            this.shouldSerialize["echo"] = false;
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
        public void UnsetPresencePenalty()
        {
            this.shouldSerialize["presence_penalty"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFrequencyPenalty()
        {
            this.shouldSerialize["frequency_penalty"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBestOf()
        {
            this.shouldSerialize["best_of"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLogitBias()
        {
            this.shouldSerialize["logit_bias"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSuffix()
        {
            return this.shouldSerialize["suffix"];
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
        public bool ShouldSerializeTemperature()
        {
            return this.shouldSerialize["temperature"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTopP()
        {
            return this.shouldSerialize["top_p"];
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
        public bool ShouldSerializeStream()
        {
            return this.shouldSerialize["stream"];
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
        public bool ShouldSerializeEcho()
        {
            return this.shouldSerialize["echo"];
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
        public bool ShouldSerializePresencePenalty()
        {
            return this.shouldSerialize["presence_penalty"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFrequencyPenalty()
        {
            return this.shouldSerialize["frequency_penalty"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBestOf()
        {
            return this.shouldSerialize["best_of"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLogitBias()
        {
            return this.shouldSerialize["logit_bias"];
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

            return obj is CreateCompletionRequest other &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Prompt == null && other.Prompt == null) || (this.Prompt?.Equals(other.Prompt) == true)) &&
                ((this.Suffix == null && other.Suffix == null) || (this.Suffix?.Equals(other.Suffix) == true)) &&
                ((this.MaxTokens == null && other.MaxTokens == null) || (this.MaxTokens?.Equals(other.MaxTokens) == true)) &&
                ((this.Temperature == null && other.Temperature == null) || (this.Temperature?.Equals(other.Temperature) == true)) &&
                ((this.TopP == null && other.TopP == null) || (this.TopP?.Equals(other.TopP) == true)) &&
                ((this.N == null && other.N == null) || (this.N?.Equals(other.N) == true)) &&
                ((this.Stream == null && other.Stream == null) || (this.Stream?.Equals(other.Stream) == true)) &&
                ((this.Logprobs == null && other.Logprobs == null) || (this.Logprobs?.Equals(other.Logprobs) == true)) &&
                ((this.Echo == null && other.Echo == null) || (this.Echo?.Equals(other.Echo) == true)) &&
                ((this.Stop == null && other.Stop == null) || (this.Stop?.Equals(other.Stop) == true)) &&
                ((this.PresencePenalty == null && other.PresencePenalty == null) || (this.PresencePenalty?.Equals(other.PresencePenalty) == true)) &&
                ((this.FrequencyPenalty == null && other.FrequencyPenalty == null) || (this.FrequencyPenalty?.Equals(other.FrequencyPenalty) == true)) &&
                ((this.BestOf == null && other.BestOf == null) || (this.BestOf?.Equals(other.BestOf) == true)) &&
                ((this.LogitBias == null && other.LogitBias == null) || (this.LogitBias?.Equals(other.LogitBias) == true)) &&
                ((this.User == null && other.User == null) || (this.User?.Equals(other.User) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.Prompt = {(this.Prompt == null ? "null" : this.Prompt == string.Empty ? "" : this.Prompt)}");
            toStringOutput.Add($"this.Suffix = {(this.Suffix == null ? "null" : this.Suffix == string.Empty ? "" : this.Suffix)}");
            toStringOutput.Add($"this.MaxTokens = {(this.MaxTokens == null ? "null" : this.MaxTokens.ToString())}");
            toStringOutput.Add($"this.Temperature = {(this.Temperature == null ? "null" : this.Temperature.ToString())}");
            toStringOutput.Add($"this.TopP = {(this.TopP == null ? "null" : this.TopP.ToString())}");
            toStringOutput.Add($"this.N = {(this.N == null ? "null" : this.N.ToString())}");
            toStringOutput.Add($"this.Stream = {(this.Stream == null ? "null" : this.Stream.ToString())}");
            toStringOutput.Add($"this.Logprobs = {(this.Logprobs == null ? "null" : this.Logprobs.ToString())}");
            toStringOutput.Add($"this.Echo = {(this.Echo == null ? "null" : this.Echo.ToString())}");
            toStringOutput.Add($"this.Stop = {(this.Stop == null ? "null" : this.Stop == string.Empty ? "" : this.Stop)}");
            toStringOutput.Add($"this.PresencePenalty = {(this.PresencePenalty == null ? "null" : this.PresencePenalty.ToString())}");
            toStringOutput.Add($"this.FrequencyPenalty = {(this.FrequencyPenalty == null ? "null" : this.FrequencyPenalty.ToString())}");
            toStringOutput.Add($"this.BestOf = {(this.BestOf == null ? "null" : this.BestOf.ToString())}");
            toStringOutput.Add($"LogitBias = {(this.LogitBias == null ? "null" : this.LogitBias.ToString())}");
            toStringOutput.Add($"this.User = {(this.User == null ? "null" : this.User == string.Empty ? "" : this.User)}");
        }
    }
}
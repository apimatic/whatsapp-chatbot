// <copyright file="CreateEditRequest.cs" company="APIMatic">
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
    /// CreateEditRequest.
    /// </summary>
    public class CreateEditRequest
    {
        private string input;
        private int? n;
        private double? temperature;
        private double? topP;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "input", false },
            { "n", true },
            { "temperature", true },
            { "top_p", true },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEditRequest"/> class.
        /// </summary>
        public CreateEditRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEditRequest"/> class.
        /// </summary>
        /// <param name="model">model.</param>
        /// <param name="instruction">instruction.</param>
        /// <param name="input">input.</param>
        /// <param name="n">n.</param>
        /// <param name="temperature">temperature.</param>
        /// <param name="topP">top_p.</param>
        public CreateEditRequest(
            string model,
            string instruction,
            string input = null,
            int? n = 1,
            double? temperature = 1,
            double? topP = 1)
        {
            this.Model = model;
            if (input != null)
            {
                this.Input = input;
            }

            this.Instruction = instruction;
            this.N = n;
            this.Temperature = temperature;
            this.TopP = topP;
        }

        /// <summary>
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The input text to use as a starting point for the edit.
        /// </summary>
        [JsonProperty("input")]
        public string Input
        {
            get
            {
                return this.input;
            }

            set
            {
                this.shouldSerialize["input"] = true;
                this.input = value;
            }
        }

        /// <summary>
        /// The instruction that tells the model how to edit the prompt.
        /// </summary>
        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        /// <summary>
        /// How many edits to generate for the input and instruction.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateEditRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetInput()
        {
            this.shouldSerialize["input"] = false;
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
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInput()
        {
            return this.shouldSerialize["input"];
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

            return obj is CreateEditRequest other &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Input == null && other.Input == null) || (this.Input?.Equals(other.Input) == true)) &&
                ((this.Instruction == null && other.Instruction == null) || (this.Instruction?.Equals(other.Instruction) == true)) &&
                ((this.N == null && other.N == null) || (this.N?.Equals(other.N) == true)) &&
                ((this.Temperature == null && other.Temperature == null) || (this.Temperature?.Equals(other.Temperature) == true)) &&
                ((this.TopP == null && other.TopP == null) || (this.TopP?.Equals(other.TopP) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.Input = {(this.Input == null ? "null" : this.Input == string.Empty ? "" : this.Input)}");
            toStringOutput.Add($"this.Instruction = {(this.Instruction == null ? "null" : this.Instruction == string.Empty ? "" : this.Instruction)}");
            toStringOutput.Add($"this.N = {(this.N == null ? "null" : this.N.ToString())}");
            toStringOutput.Add($"this.Temperature = {(this.Temperature == null ? "null" : this.Temperature.ToString())}");
            toStringOutput.Add($"this.TopP = {(this.TopP == null ? "null" : this.TopP.ToString())}");
        }
    }
}